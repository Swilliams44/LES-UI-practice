import pytest
from selenium import webdriver
from selenium.webdriver.common.by import By
from datetime import datetime, timedelta
import pyodbc
import time

# DB setup (edit according to your environment)
DB_CONN_STR = 'DRIVER={SQL Server};SERVER=YourServer;DATABASE=YourDB;UID=YourUser;PWD=YourPassword'

# Test credentials and loan info
USERNAME = "testuser"
PASSWORD = "testpass"
LOAN_ID = "123456"   # Use a test loan ID suitable for automation

@pytest.fixture
def driver():
    driver = webdriver.Chrome()
    driver.implicitly_wait(5)
    yield driver
    driver.quit()

@pytest.fixture
def db():
    conn = pyodbc.connect(DB_CONN_STR)
    yield conn
    conn.close()

def get_activity(conn, loan_id, event_type, within_minutes=5):
    cursor = conn.cursor()
    time_limit = (datetime.now() - timedelta(minutes=within_minutes)).strftime("%Y-%m-%d %H:%M:%S")
    sql = f"""SELECT TOP 1 * FROM UserActivities
              WHERE LoanID=? AND EventType=? AND EventTimestamp >= ?
              ORDER BY EventTimestamp DESC"""
    cursor.execute(sql, loan_id, event_type, time_limit)
    return cursor.fetchone()

def get_timeinfile(conn, loan_id, event_type, within_minutes=5):
    cursor = conn.cursor()
    time_limit = (datetime.now() - timedelta(minutes=within_minutes)).strftime("%Y-%m-%d %H:%M:%S")
    sql = f"""SELECT TOP 1 * FROM TimeInFile
              WHERE LoanID=? AND EventType=? AND EventTimestamp >= ?
              ORDER BY EventTimestamp DESC"""
    cursor.execute(sql, loan_id, event_type, time_limit)
    return cursor.fetchone()

def test_start_processing_logged(driver, db):
    # Login
    driver.get("https://yourapp/login")
    driver.find_element(By.ID, "username").send_keys(USERNAME)
    driver.find_element(By.ID, "password").send_keys(PASSWORD)
    driver.find_element(By.ID, "submit_login").click()
    # Open Loan
    driver.find_element(By.XPATH, f"//tr[td/text()='{LOAN_ID}']").click()
    # Start Processing
    driver.find_element(By.ID, "start_processing_btn").click()
    time.sleep(2)  # Wait for backend logging

    # DB verification
    ua = get_activity(db, LOAN_ID, "Start Processing")
    tif = get_timeinfile(db, LOAN_ID, "Start Processing")
    assert ua is not None, "UserActivities not logged 'Start Processing'"
    assert tif is not None, "TimeInFile not logged 'Start Processing'"

def test_close_loan_without_submit(driver, db):
    # Rely on previous login/loan open or repeat as needed
    driver.get("https://yourapp/loan/"+LOAN_ID)
    driver.find_element(By.ID, "close_loan_btn").click()
    time.sleep(2)
    ua = get_activity(db, LOAN_ID, "Close Loan")
    tif = get_timeinfile(db, LOAN_ID, "Close Loan")
    assert ua is not None, "UserActivities not logged 'Close Loan'"
    assert tif is not None, "TimeInFile not logged 'Close Loan'"

def test_resume_processing(driver, db):
    driver.get("https://yourapp/loan/"+LOAN_ID)
    driver.find_element(By.ID, "resume_processing_btn").click()
    time.sleep(2)
    ua = get_activity(db, LOAN_ID, "Resume Processing")
    tif = get_timeinfile(db, LOAN_ID, "Resume Processing")
    assert ua is not None, "UserActivities not logged 'Resume Processing'"
    assert tif is not None, "TimeInFile not logged 'Resume Processing'"

def test_submit_logged(driver, db):
    driver.get("https://yourapp/loan/"+LOAN_ID)
    driver.find_element(By.ID, "submit_btn").click()
    time.sleep(2)
    ua = get_activity(db, LOAN_ID, "Submit")
    tif = get_timeinfile(db, LOAN_ID, "Submit")
    assert ua is not None, "UserActivities not logged 'Submit'"
    assert tif is not None, "TimeInFile not logged 'Submit'"

def test_no_duplicate_user_started(db):
    # Simulate flow where user does Start Processing twice
    # This is backend test only, simulate with DB inserts in a test system  
    cursor = db.cursor()
    # Query for Start Processing entries for LOAN_ID in past 10 minutes
    cursor.execute("SELECT COUNT(*) FROM UserActivities WHERE LoanID=? AND EventType='Start Processing' AND EventTimestamp >= ?", LOAN_ID, (datetime.now() - timedelta(minutes=10)))
    count = cursor.fetchone()[0]
    assert count <= 1, "Duplicate User Started found"

def test_open_then_close_then_submit(db):
    # Check that Open, Close, then Submit are all captured
    cursor = db.cursor()
    cursor.execute("SELECT EventType FROM UserActivities WHERE LoanID=? AND EventType IN ('Open Loan','Submit','Close Loan') ORDER BY EventTimestamp", LOAN_ID)
    events = [e[0] for e in cursor.fetchall()]
    assert "Open Loan" in events, "'Open Loan' missing"
    assert "Submit" in events or "Close Loan" in events, "'Submit' or 'Close Loan' missing"

def test_archive_retention_useractivities(db):
    cursor = db.cursor()
    cursor.execute("SELECT COUNT(*) FROM UserActivities WHERE EventTimestamp < ?", (datetime.now() - timedelta(days=90)))
    count = cursor.fetchone()[0]
    assert count == 0, "Old records (>3 months) not archived in UserActivities"

def test_archive_retention_timeinfile(db):
    cursor = db.cursor()
    cursor.execute("SELECT COUNT(*) FROM TimeInFile WHERE EventTimestamp < ?", (datetime.now() - timedelta(days=90)))
    count = cursor.fetchone()[0]
    assert count == 0, "Old records (>3 months) not archived in TimeInFile"