import os
import time
import pytest
from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.common.keys import Keys

# Constants (set to your environment)
BASE_URL = "https://LES-SPW-Git-Practice.com"
USERNAME = "clientuser"
PASSWORD = "password"
DOWNLOAD_DIR = "/tmp/downloads"

@pytest.fixture(scope="session")
def browser():
    options = webdriver.ChromeOptions()
    prefs = {"download.default_directory": DOWNLOAD_DIR}
    options.add_experimental_option("prefs", prefs)
    driver = webdriver.Chrome(options=options)
    yield driver
    driver.quit()

def login(driver, username, password):
    driver.get(BASE_URL + "/login")
    driver.find_element(By.ID, "username").send_keys(username)
    driver.find_element(By.ID, "password").send_keys(password)
    driver.find_element(By.ID, "loginButton").click()

def test_document_library_tab_visible(browser):
    login(browser, USERNAME, PASSWORD)
    # Replace with exact selector/text for "Document Library"
    assert browser.find_element(By.LINK_TEXT, "Document Library").is_displayed()

def test_document_library_accessible_for_clients(browser):
    login(browser, USERNAME, PASSWORD)
    browser.find_element(By.LINK_TEXT, "Document Library").click()
    assert "Document Library" in browser.title

def test_document_categories_displayed(browser):
    login(browser, USERNAME, PASSWORD)
    browser.find_element(By.LINK_TEXT, "Document Library").click()
    for category in ["Vendor Management", "User Guides", "Communications"]:
        assert browser.find_element(By.XPATH, f"//div[contains(text(),'{category}')]").is_displayed()

def test_category_expand_shows_documents(browser):
    login(browser, USERNAME, PASSWORD)
    browser.find_element(By.LINK_TEXT, "Document Library").click()
    categories = ["Vendor Management", "User Guides", "Communications"]
    for category in categories:
        category_elem = browser.find_element(By.XPATH, f"//div[contains(text(),'{category}')]")
        category_elem.click()
        # Example: assumes documents are listed under ul/li when expanded
        assert browser.find_elements(By.XPATH, f"//div[contains(text(),'{category}')]/following-sibling::ul/li")

def test_download_pdf_document(browser):
    login(browser, USERNAME, PASSWORD)
    browser.find_element(By.LINK_TEXT, "Document Library").click()
    browser.find_element(By.XPATH, "//div[contains(text(),'Vendor Management')]").click()
    # Find and click the first PDF link
    pdf_link = browser.find_element(By.XPATH, "//a[contains(@href, '.pdf')]")
    pdf_link.click()
    time.sleep(2)  # Allow download to complete; adjust as necessary
    files = os.listdir(DOWNLOAD_DIR)
    assert any(f.endswith('.pdf') for f in files)

def test_upload_and_download_excel_document(browser):
    login(browser, USERNAME, PASSWORD)
    browser.find_element(By.LINK_TEXT, "Document Library").click()
    browser.find_element(By.XPATH, "//div[contains(text(),'Vendor Management')]").click()
    # Upload file (adjust for your upload UI)
    upload_elem = browser.find_element(By.XPATH, "//input[@type='file']")
    excel_file_path = os.path.abspath("sample.xlsx")  # Create dummy .xlsx in same dir as script
    upload_elem.send_keys(excel_file_path)
    time.sleep(2)  # Wait for upload
    # Download check
    excel_link = browser.find_element(By.XPATH, "//a[contains(@href, '.xlsx')]")
    excel_link.click()
    time.sleep(2)
    files = os.listdir(DOWNLOAD_DIR)
    assert any(f.endswith('.xlsx') for f in files)

def test_only_allowed_file_types_upload(browser):
    login(browser, USERNAME, PASSWORD)
    browser.find_element(By.LINK_TEXT, "Document Library").click()
    browser.find_element(By.XPATH, "//div[contains(text(),'Vendor Management')]").click()
    upload_elem = browser.find_element(By.XPATH, "//input[@type='file']")
    # Try to upload an .exe file
    exe_file_path = os.path.abspath("malware.exe")  # Place a dummy file for test purposes
    upload_elem.send_keys(exe_file_path)
    time.sleep(1)
    # Look for error notification (adjust selector/message as needed)
    error_elem = browser.find_element(By.CLASS_NAME, "error-message")
    assert "unsupported" in error_elem.text.lower()
