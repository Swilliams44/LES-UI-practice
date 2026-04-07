Imports Common
Imports System.Collections.Specialized
Imports System.Data.OleDb
Imports System.Deployment.Application
Imports System.IO
Imports System.Web
Imports GenericParsing
Imports System.Configuration

Public Class Main

    '=========================================================================================================================
    '   Author:         SQMR, Inc.
    '   Create Date:    11/15/2009
    '   Modifications:  
    '       Date        Name                Comment
    '
    '
    '=========================================================================================================================

    '=========================================================================================================================
    '   Workflow:
    '       1.  User receives an XLS file from the Client (this is received by bank uploading XLS to an FTP site)
    '       2.  User opens the file with this application
    '       3.  User corrects all mappings of Excel to LES
    '       4.  User imports data associated with Excel spreadsheet to LES
    '
    '
    '=========================================================================================================================

    Private userID As Integer = 1
    Private serviceID As Integer = 4  'Default to Fulfillment
    Private serviceType As String = "Fulfillment"  'Default to Fulfillment
    Private currentFilePath As String
    Private dsExcelSheets As DataSet
    Friend dtCurrentExcelSheet As DataTable
    Private WithEvents dgCurrentExcelSheet As DataGridView
    Private dsXMLMapping As New DataSet("XML")
    Private dsOldMappings As New DataSet
    Private dtNewMappings As New DataTable
    Private setID As Integer
    Private arMapping As New ArrayList
    Friend exportPath As String
    Private requiredAspectText As String = "The following fields are required for this export to work properly.  Please make sure all of these columns are mapped correctly." & _
                            vbCrLf & _
                            vbCrLf & "1) Loan Number" & _
                            vbCrLf & "     In addition to the mapping, your primary loan number field must be mapped to the field named Loan Number in LES" & _
                            vbCrLf & "2) Borrower Last Name" & _
                            vbCrLf & _
                            vbCrLf & "Also check to ensure that you have not set 2 columns to the same field."

    Private _isOriginalDestination As Boolean = False
    Private _isActualDestination As Boolean = False
    Private _runMERSConditionRoutine As Boolean = False

    '{{{{{{  Production Variables  }}}}}}
    Friend Shared connectionString As String = "Data Source=shgatldb4;Initial Catalog=TSGProduction;Persist Security Info=True;User ID=tsguser;Password=P@$$w0rd"
    Friend Const defaultFieldSetURL As String = "https://www.stonehillgroup.com/TSGCA/Level1Services/DefaultFieldSet.asmx"

    '{{{{{{  Stage Variables  }}}}}
    'Friend Const connectionString As String = "Data Source=shgatldb4;Initial Catalog=TSGProductionDEMO;Persist Security Info=True;User ID=tsguser;Password=P@$$w0rd"
    'Friend Const defaultFieldSetURL As String = "https://www.stonehillgroupqa.com/LESDEmo/Level1Services/DefaultFieldSet.asmx"

    '{{{{{{  Testing Variables  }}}}}
    'Friend Const connectionString As String = "Data Source=shgatldb4;Initial Catalog=TSGProduction;Persist Security Info=True;User ID=tsguser;Password=P@$$w0rd"
    'Friend defaultFieldSetURL As String = "https://www.stonehillgroupqa.com/TSGCA/Level1Services/DefaultFieldSet.asmx"

    '{{{{{{  Development Variables  }}}}}
    'Friend Const connectionString As String = "Data Source=shgdcdev\WEBDEV;Initial Catalog=TSGProdMirror4;Persist Security Info=True;User ID=tsguser;Password=P@$$w0rd"
    'Friend defaultFieldSetURL As String = "http://localhost:8181/Level1Services/DefaultFieldSet.asmx"


    Private Sub Main_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        connectionString = ConfigurationManager.ConnectionStrings("LESDataImporter.My.MySettings.TSGProductionQATESTConnectionString").ConnectionString
        'Get settings from the user's input
        Dim sp As New StartingProperties()
        If sp.ShowDialog = Windows.Forms.DialogResult.OK Then

            'If 1 = 1 Then
            '    _isOriginalDestination = True

            'Set Global variables
            If sp.radImportOrigNormal.Checked OrElse sp.radImportOrigMERS.Checked Then
                _isOriginalDestination = True
            ElseIf sp.radImportActualMERS.Checked Then
                _isActualDestination = True
            End If

            If sp.radImportOrigMERS.Checked OrElse sp.radImportActualMERS.Checked Then
                _runMERSConditionRoutine = True
                'chkOverrideValues.Visible = False
            ElseIf sp.radImportOrigNormal.Checked Then
                _runMERSConditionRoutine = False
            End If
            'End If


            Dim cn As New SqlClient.SqlConnection(connectionString)
            Dim sql As String = ""

            Try

                cn.Open()

                'Bind Customer Data
                Dim dsClient As DataSet = Common.Data.GetDataSet("SELECT CompanyID, Name FROM Company WHERE CompanyTypeID = 1 AND IsActive=1;", cn)
                dsClient.Tables(0).Rows.Add(New Object() {-1, "<Select a Client>"})
                dsClient.Tables(0).DefaultView.Sort = "Name"

                cmbClient.BeginUpdate()
                cmbClient.DataSource = dsClient.Tables(0).DefaultView
                cmbClient.DisplayMember = "Name"
                cmbClient.ValueMember = "CompanyID"
                cmbClient.EndUpdate()

                cmbDestinationField.SelectedIndex = 0

                'Set Mapping Properties
                dgXMLMapping.Columns("ExcelColumn").DataPropertyName = "ExcelColumn"
                dgXMLMapping.Columns("XMLColumn").DataPropertyName = "FieldID"

                dgXMLMapping.AutoGenerateColumns = False
                dgXMLMapping.AllowUserToAddRows = False
                dgXMLMapping.AllowUserToDeleteRows = False

                'Get Query Parameters
                Dim queryParams As NameValueCollection = Me.GetQueryStringParameters()
                If queryParams("UID") IsNot Nothing Then
                    userID = queryParams("UID")
                End If
                If queryParams("SID") IsNot Nothing Then
                    serviceID = queryParams("SID")
                End If
                If queryParams("SNm") IsNot Nothing Then
                    serviceType = queryParams("SNm")
                    Me.Text &= "; Service: " & queryParams("SNm")
                End If

                'Get Build Info
                Dim myBuildInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(Application.ExecutablePath)

                If (ApplicationDeployment.IsNetworkDeployed) Then
                    Dim AD As ApplicationDeployment = ApplicationDeployment.CurrentDeployment
                    Me.Text &= " (Version " & AD.CurrentVersion.ToString & ")"
                End If

                cmbClient.Focus()

            Catch ex As Exception
#If DEBUG Then
                '     MessageBox.Show(ex.ToString)
#End If
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
            End Try

        End If

    End Sub

    Private Sub cmbClient_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbClient.SelectedIndexChanged

        If cmbClient.SelectedValue.ToString <> "System.Data.DataRowView" Then

            If cmbClient.SelectedValue = -1 Then
                lblDeal.Enabled = False
                cmbDeal.Enabled = False
                btnEditDeal.Enabled = False
                btnExcelBrowse.Enabled = False
            Else

                Dim cn As New SqlClient.SqlConnection(connectionString)
                Dim sql As String = ""

                Try

                    cn.Open()

                    'Get Existing Mappings
                    dsOldMappings = GetExistingMappings(cn)

                    'Store the SetID
                    Dim dsSet As DataSet = Common.Data.GetDataSet("SELECT TOP 1 SetID FROM CompanyFieldSets WHERE CompanyID = " & cmbClient.SelectedValue, cn)

                    If dsSet IsNot Nothing AndAlso dsSet.Tables.Count > 0 Then
                        If dsSet.Tables(0).Rows.Count > 0 Then
                            setID = dsSet.Tables(0).Rows(0).Item("SetID")
                        Else
                            setID = 0
                        End If
                    End If

                    BindDealComboBox(cn)

                    lblDeal.Enabled = True
                    cmbDeal.Enabled = True
                    btnEditDeal.Enabled = True

                    'Create Mapping Drop Down List
                    Dim dgvc As DataGridViewComboBoxColumn = DirectCast(dgXMLMapping.Columns("XMLColumn"), DataGridViewComboBoxColumn)

                    sql = "SELECT   F.FieldID, COALESCE(FS.ClientFieldName,F.FieldNm) AS FieldNm " & _
                            "FROM   Fields F " & _
                            "JOIN   FieldSets FS " & _
                            "ON     FS.FieldID = F.FieldID " & _
                            "JOIN   CompanyFieldSets CFS " & _
                            "ON     CFS.SetID = FS.SetID " & _
                            "WHERE  CFS.CompanyID = " & cmbClient.SelectedValue & " " & _
                            "AND    COALESCE(FS.IsDeleted,0) = 0 " & _
                            "UNION	" & _
                            "SELECT	F.FieldID, F.FieldNm " & _
                            "FROM	Fields F " & _
                            "WHERE	F.FieldID = 3690;"

                    Dim dsColumns As DataSet = Common.Data.GetDataSet(sql, cn)
                    dsColumns.Tables(0).Rows.Add(New Object() {0, "<Skip on Import>"})

                    dsColumns.Tables(0).DefaultView.Sort = "FieldNm"

                    dgvc.DataSource = dsColumns.Tables(0).DefaultView
                    dgvc.DisplayMember = "FieldNm"
                    dgvc.ValueMember = "FieldID"

                Catch ex As Exception
#If DEBUG Then
                    MessageBox.Show(ex.ToString)
#End If
                Finally
                    If cn.State <> ConnectionState.Closed Then cn.Close()
                End Try

            End If
        End If

    End Sub
    Private Sub cmbDeal_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDeal.SelectedIndexChanged

        If cmbDeal.SelectedValue.ToString <> "System.Data.DataRowView" Then
            If cmbDeal.SelectedValue > 0 Then

                'Excel Restrictions
                btnExcelBrowse.Enabled = True
                btnExcelBrowse.Focus()
                If txtExcelPath.Text <> "" Then
                    BuildExcelDataSet(txtExcelPath.Text)
                    btnExcelOpen.Enabled = True
                    btnXMLGenerate.Enabled = True
                    SplitContainer1.Enabled = True
                End If

                Dim targetValueColumn As String = ""

                If _isOriginalDestination Then
                    targetValueColumn = "Original Values"
                Else
                    targetValueColumn = "Actual Values"
                End If

                btnXMLGenerate.Text = "Import Loan Data for " & cmbDeal.Text & " into " & targetValueColumn
            Else
                btnXMLGenerate.Text = "Import Loan Data into LES into "
                If cmbDeal.SelectedValue = -1 Then
                    btnEditDeal_Click(sender, e)
                End If
            End If
        End If

    End Sub

    Private Sub chkOverrideValues_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOverrideValues.CheckedChanged

        If chkOverrideValues.Checked Then
            If MessageBox.Show("Checking this will override existing data in the system and you will not be able to recover the data.  Are you sure you want to do this?", "Possible Loss of Data Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then
                chkOverrideValues.Checked = False
            End If
        End If

    End Sub

    Private Sub btnExcelBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcelBrowse.Click

        If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then

            Me.Cursor = Cursors.WaitCursor
            ToolStripStatusLabel1.Text = "Opening File...Please Wait"

            '   Try
            currentFilePath = ofd.FileName
            'Add Excel File to DataSet
            BuildExcelDataSet(currentFilePath)

            btnExcelOpen.Enabled = True
            'btnXMLGenerate.Enabled = True
            SplitContainer1.Enabled = True
            '        Catch ex As Exception
            'MessageBox.Show(ex.ToString(), "General Error")
            '     Finally
            'Me.Cursor = Cursors.Default
            '     ToolStripStatusLabel1.Text = "Ready"
            '     End Try

        End If

    End Sub
    Private Sub btnExcelOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcelOpen.Click

        Process.Start(currentFilePath)

    End Sub
    Private Sub BuildExcelDataSet(ByVal filePath As String, Optional ByVal spreadSheetName As String = "")

        Dim cn As OleDbConnection = Nothing
        Dim ds As New DataSet
        Dim cmd As New OleDbCommand
        Dim da As New OleDbDataAdapter

        Try


            Select Case filePath.Remove(0, filePath.LastIndexOf(".") + 1)
                Case "csv"

                    Dim strID As String
                    Dim strName As String
                    Dim strStatus As String

                    'Dim parser As New GenericParserAdapter()
                    'parser.SetDataSource(filePath)

                    'parser.ColumnDelimiter = ","
                    'parser.FirstRowHasHeader = True
                    'parser.MaxBufferSize = 4096
                    'parser.MaxRows = 5000
                    'parser.TextQualifier = """"

                    'ds = parser.GetDataSet()

                Case Else

                    cn = New OleDbConnection(GetExcelConnectionString(filePath))
                    cn.Open()

                    txtExcelPath.Text = filePath

                    If spreadSheetName = "" Then

                        Dim dt As New DataTable
                        dt = cn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, "Table"})
                        cmd.CommandTimeout = 0
                        Dim sheetName As String

                        For Each row As DataRow In dt.Rows
                            Dim dtSheet As New DataTable(row("TABLE_NAME").ToString)
                            sheetName = row("TABLE_NAME").ToString()
                            If sheetName.Contains("FilterDatabase") Or Not (sheetName.EndsWith("$")) Then
                                Continue For
                            End If

                            cmd = New OleDbCommand("SELECT * FROM [" & row("TABLE_NAME").ToString & "]", cn)
                            da = New OleDbDataAdapter(cmd)
                            da.Fill(dtSheet)
                            ds.Tables.Add(dtSheet)
                        Next
                    Else
                        cmd = New OleDbCommand("SELECT * FROM [" & spreadSheetName & "$]", cn)
                        da = New OleDbDataAdapter(cmd)
                        da.Fill(ds)
                        ds.Tables(0).TableName = spreadSheetName
                    End If

            End Select

        Catch ex As Exception
            MsgBox(ex.ToString())
        Finally
            da.Dispose()
            cmd.Dispose()
            ds.Dispose()
            If cn IsNot Nothing Then
                cn.Close()
                cn.Dispose()
            End If
        End Try

        'Set data table variable for later use
        dsExcelSheets = ds

        If Not dsExcelSheets Is Nothing Then

            Try
                tabExcelSheets.TabPages.Clear()
            Catch
            End Try

            For Each dtExcelSheet As DataTable In dsExcelSheets.Tables

                Dim tabExcelSheet As New TabPage
                Dim dgExcelSheet As New DataGridView

                dgExcelSheet.AllowUserToAddRows = False
                dgExcelSheet.AllowUserToDeleteRows = False
                'dgExcelSheet.AutoGenerateColumns = False
                dgExcelSheet.DataSource = dtExcelSheet.DefaultView
                dgExcelSheet.Dock = DockStyle.Fill
                dgExcelSheet.ReadOnly = True
                dgExcelSheet.RowHeadersVisible = False

                tabExcelSheet.Controls.Add(dgExcelSheet)

                tabExcelSheet.Tag = dtExcelSheet.TableName
                tabExcelSheet.Text = dtExcelSheet.TableName

                tabExcelSheets.TabPages.Add(tabExcelSheet)

            Next

            tabExcelSheets_SelectedIndexChanged(New Object, New EventArgs)

            HasRequiredAspects()

        End If

    End Sub

    Private Sub tabExcelSheets_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabExcelSheets.SelectedIndexChanged

        If tabExcelSheets.TabPages.Count > 0 Then

            Dim cn As New SqlClient.SqlConnection(connectionString)

            'Try

            cn.Open()

            Dim tabCurrent As TabPage = tabExcelSheets.SelectedTab
            dgCurrentExcelSheet = DirectCast(tabCurrent.Controls(0), DataGridView)
            dtCurrentExcelSheet = dsExcelSheets.Tables(tabCurrent.Tag)

            For Each col As DataColumn In dtCurrentExcelSheet.Columns
                col.ColumnName = Trim(col.ColumnName)
            Next

            'Add any Translation columns
            Dim sourceColumnName = ""
            Dim targetColumnName = ""
            Dim newColumns As New ArrayList
            Dim excelColumns As New ArrayList
            Dim columnCount As Integer = 0
            Dim dtNewMappings As New DataTable
            Dim dsColumns As DataSet

            If dtCurrentExcelSheet.Columns.Count > 0 Then

                dtNewMappings.Columns.Add("FieldSetID", GetType(Integer))
                dtNewMappings.Columns.Add("ExcelColumn", GetType(String))
                dtNewMappings.Columns.Add("FieldID", GetType(Integer))
                dtNewMappings.Columns.Add("SortOrder", GetType(Integer))

                For Each col As DataColumn In dtCurrentExcelSheet.Columns

                    excelColumns.Add(Trim(col.ColumnName))

                    '{{{{{{{{{{  Add Translate & Replace Columns  }}}}}}}}}}
                    dsColumns = Common.Data.GetDataSet("SelectImportColumn @CompanyID=" & cmbClient.SelectedValue, cn)
                    For Each rowColumn As DataRow In dsColumns.Tables(0).Select("CompanyID=" & cmbClient.SelectedValue.ToString & " AND SourceName='" & col.ColumnName & "'")

                        'Store Translate Column Information
                        newColumns.Add(New KeyValueList(rowColumn("TargetName").ToString & "|" & rowColumn("ReplaceTargetName").ToString & "|" & col.ColumnName, rowColumn("ColumnID").ToString))

                    Next

                    '{{{{{{{{{{  Add Mapping Columns  }}}}}}}}}}
                    Dim rowsMapping As DataRow() = dsOldMappings.Tables(0).Select("ClientMappingName = '" & col.ColumnName & "'")

                    If rowsMapping.Length > 0 Then
                        'Add existing Mapping
                        dtNewMappings.Rows.Add(New Object() {rowsMapping(0)("FieldSetID"), col.ColumnName, rowsMapping(0)("FieldID").ToString, columnCount})
                    Else
                        'Add row without Mapping
                        dtNewMappings.Rows.Add(New Object() {0, col.ColumnName, 0, columnCount})
                    End If

                    columnCount += 1

                Next

                dgXMLMapping.DataSource = dtNewMappings.DefaultView

            End If

            HasRequiredAspects()

            '{{{{{{{{{{{  Create and populate Translate Columns  }}}}}}}}}}}
            Dim addcount As Integer = 1

            For Each kv As KeyValueList In newColumns

                'Add the New columns
                Dim translateTargetName As String = Split(kv.Key, "|")(0).ToString
                Dim replaceTargetName As String = Split(kv.Key, "|")(1).ToString
                Dim sourceName As String = Split(kv.Key, "|")(2).ToString

                'Insert new column for replacements
                If replaceTargetName <> "" Then
                    If Not dtCurrentExcelSheet.Columns.Contains(replaceTargetName) Then
                        Dim dc As New DataColumn(replaceTargetName, GetType(String))
                        dtCurrentExcelSheet.Columns.Add(dc)
                        Dim sourceIndex As Integer = dgCurrentExcelSheet.Columns(sourceName).Index

                        Dim dgvc As New DataGridViewTextBoxColumn
                        dgvc.DataPropertyName = replaceTargetName
                        dgvc.DefaultCellStyle.BackColor = Color.LightYellow
                        dgvc.HeaderCell.Style.BackColor = Color.LightYellow
                        dgvc.DefaultCellStyle.NullValue = "# No Replacement #"
                        dgvc.HeaderText = replaceTargetName
                        If Not dgvc.CellTemplate Is Nothing Then
                            dgCurrentExcelSheet.Columns.Insert(sourceIndex + addcount, dgvc)
                        End If

                    End If
                End If

                'Insert new column for translations
                If translateTargetName <> "" Then
                    If Not dtCurrentExcelSheet.Columns.Contains(translateTargetName) Then
                        Dim dc As New DataColumn(translateTargetName, GetType(String))
                        dtCurrentExcelSheet.Columns.Add(dc)
                        Dim sourceIndex As Integer = dgCurrentExcelSheet.Columns(sourceName).Index

                        Dim dgvc As New DataGridViewTextBoxColumn
                        dgvc.DataPropertyName = translateTargetName
                        dgvc.DefaultCellStyle.BackColor = Color.LightYellow
                        dgvc.HeaderCell.Style.BackColor = Color.LightYellow
                        dgvc.DefaultCellStyle.NullValue = "# No Translation #"
                        dgvc.HeaderText = translateTargetName
                        If Not dgvc.CellTemplate Is Nothing Then
                            dgCurrentExcelSheet.Columns.Insert(sourceIndex + addcount, dgvc)
                        End If

                    End If
                End If

                'Add New Column to XML Mapping for replacement columns
                If replaceTargetName <> "" Then
                    Dim rowsMappingReplace As DataRow() = dsOldMappings.Tables(0).Select("ClientMappingName = '" & replaceTargetName & "'")

                    If rowsMappingReplace.Length > 0 Then
                        'Add existing Mapping
                        dtNewMappings.Rows.Add(New Object() {rowsMappingReplace(0)("FieldSetID"), Trim(replaceTargetName), rowsMappingReplace(0)("FieldID").ToString, columnCount})
                    Else
                        'Add row without Mapping
                        dtNewMappings.Rows.Add(New Object() {0, Trim(replaceTargetName), 0, "-1"})
                    End If
                End If


                'Add New Column to XML Mapping for translation columns
                If translateTargetName <> "" Then
                    Dim rowsMappingTranslate As DataRow() = dsOldMappings.Tables(0).Select("ClientMappingName = '" & translateTargetName & "'")

                    If rowsMappingTranslate.Length > 0 Then
                        'Add existing Mapping
                        dtNewMappings.Rows.Add(New Object() {rowsMappingTranslate(0)("FieldSetID"), Trim(translateTargetName), rowsMappingTranslate(0)("FieldID").ToString, columnCount})
                    Else
                        'Add row without Mapping
                        dtNewMappings.Rows.Add(New Object() {0, Trim(translateTargetName), 0, "-1"})
                    End If
                End If


                Dim clientID As Integer = cmbClient.SelectedValue
                Dim columnID As Integer = kv.Value
                tslTransalationAlert.Visible = False

                'Replace the data for Replacement Columns
                If replaceTargetName <> "" Then
                    For Each rowView As DataGridViewRow In dgCurrentExcelSheet.Rows

                        Dim sourceColIndex As Integer = dgCurrentExcelSheet.Columns(sourceName).Index
                        Dim targetColIndex As Integer = dgCurrentExcelSheet.Columns(replaceTargetName).Index
                        Dim sourceValue As String = rowView.Cells(sourceColIndex).Value.ToString

                        'Validate based on date/time
                        If IsDate(sourceValue) Then
                            sourceValue = Convert.ToDateTime(sourceValue).ToShortDateString 'Translate to date only
                        End If

                        'Validate based on numeric
                        If IsNumeric(sourceValue) Then

                        End If

                        Dim dsColumnReplace As DataSet = Common.Data.GetDataSet("SelectImportReplace @CompanyID=" & clientID & ",@ColumnName='" & sourceName & "'", cn)

                        For Each rowReplace As DataRow In dsColumnReplace.Tables(0).Rows

                            Dim existingSourceValue As String = sourceValue
                            If rowView.Cells(targetColIndex).Value.ToString <> "" Then
                                existingSourceValue = rowView.Cells(targetColIndex).Value
                            End If

                            Dim oldReplaceValue As String = rowReplace("SourceValue").ToString
                            Dim newReplaceValue As String = rowReplace("TargetValue").ToString

                            rowView.Cells(targetColIndex).Value = existingSourceValue.Replace(oldReplaceValue, newReplaceValue)

                        Next


                    Next

                    addcount += 1

                End If


                'Translate the Data for Translation Columns
                If translateTargetName <> "" Then
                    For Each rowView As DataGridViewRow In dgCurrentExcelSheet.Rows

                        Dim sourceColIndex As Integer = dgCurrentExcelSheet.Columns(sourceName).Index
                        Dim targetColIndex As Integer = dgCurrentExcelSheet.Columns(translateTargetName).Index
                        Dim sourceValue As String = rowView.Cells(sourceColIndex).Value.ToString

                        'Validate based on date/time
                        If IsDate(sourceValue) Then
                            sourceValue = Convert.ToDateTime(sourceValue).ToShortDateString 'Translate to date only
                        End If

                        'Validate based on numeric
                        If IsNumeric(sourceValue) Then

                        End If

                        Dim dsColumnTranslate As DataSet = Common.Data.GetDataSet("SelectImportTranslation @CompanyID=" & clientID & ",@ColumnName='" & sourceName & "'", cn)
                        Dim rowTranslations As DataRow() = dsColumnTranslate.Tables(0).Select("SourceValue='" & sourceValue & "'")

                        If rowTranslations.Length > 0 Then
                            rowView.Cells(targetColIndex).Value = rowTranslations(0).Item("TargetValue").ToString
                        Else
                            tslTransalationAlert.Visible = True
                        End If

                    Next

                    addcount += 1
                End If

            Next


            '{{{{{{{{{{  Finish with datagrid settings  }}}}}}}}}}
            dgXMLMapping.Rows(0).Cells(0).Selected = True
            dgXMLMapping.Focus()

            '            Catch ex As Exception
            '#If DEBUG Then
            '                MessageBox.Show(ex.ToString)
            '#End If
            '            Finally
            If cn.State <> ConnectionState.Closed Then cn.Close()
            'End Try

        End If

    End Sub

    Private Sub dgCurrentExcelSheet_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgCurrentExcelSheet.CellPainting

        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex

        If CStr(e.FormattedValue) = "# No Translation #" Then
            e.CellStyle.BackColor = Color.Tomato
        End If

    End Sub

    Private Sub dgXMLMapping_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgXMLMapping.CellValueChanged
        HasRequiredAspects()
    End Sub

    Private Sub btnTranslateValidate_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTranslateValidate.ButtonClick

        'Me.ColumnTableAdapter.Fill(Me.STONEHILLDataSet.Column)
        'Me.ColumnTranslateTableAdapter.Fill(Me.STONEHILLDataSet.ColumnTranslate)
        'Me.ColumnValidateTableAdapter.Fill(Me.STONEHILLDataSet.ColumnValidate)

        tslTransalationAlert.Visible = False
        BuildExcelDataSet(currentFilePath)

    End Sub
    Private Sub btnEditTranslations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditTranslations.Click

        Me.Cursor = Cursors.WaitCursor

        Translate.Show(Me)

        Me.Cursor = Cursors.Default

    End Sub
    Private Sub btnEditReplacements_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditReplacements.Click

        Me.Cursor = Cursors.WaitCursor

        Replacement.Show(Me)

        Me.Cursor = Cursors.Default

    End Sub
    Private Sub btnEditValidations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditValidations.Click

        Me.Cursor = Cursors.WaitCursor

        'ValidValues.Show(Me)

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub btnXMLGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXMLGenerate.Click

        Dim isSuccessful As Boolean = False
        Dim sql As String = ""
        Dim isExistingLoan As Boolean = False

        Me.Cursor = Cursors.WaitCursor
        pbMain.Value = 0
        pbMain.Visible = True
        lblStatusMain.Text = "Generating XML File..."
        Application.DoEvents()

        Dim stringWriter As New StringWriter

        Dim cn As New SqlClient.SqlConnection(connectionString)

        '       Try

        cn.Open()

        Dim tabCurrent As TabPage = tabExcelSheets.SelectedTab
        Dim count As Integer = dsExcelSheets.Tables(tabCurrent.Tag).rows.count
        Dim i As Integer = 1

        'Validate that all required columns are present.
        If Not HasRequiredAspects() Then
            MessageBox.Show(requiredAspectText, "Required Columns Missing", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If


        '{{{{{{{{{{  Create new Company Set if needed  }}}}}}}}}}}
        sql = "SELECT TOP 1 SetID FROM CompanyFieldSets WHERE CompanyID=" & cmbClient.SelectedValue

        Dim setID As Integer = 0
        Dim dsSet As DataSet = Common.Data.GetDataSet(sql, cn)

        For Each rowSet As DataRow In dsSet.Tables(0).Rows
            setID = IIf(rowSet("SetID") Is DBNull.Value, 0, Convert.ToInt32(rowSet("SetID")))
        Next

        If setID = 0 Then 'Create new Deal
            'INSERT a new Deals record
            sql = "INSERT INTO Sets " & _
                    "(SetName,Descriptions,ModifiedBy,ModifiedOn) " & _
                    "VALUES ('SYSGEN','System Generated'," & userID & ",'" & Now & "'); " & _
                    "SELECT SCOPE_IDENTITY() AS SetID;"

            dsSet = Common.Data.GetDataSet(sql, cn)

            'Set LoanID from scope identity
            For Each rowSet As DataRow In dsSet.Tables(0).Rows
                setID = rowSet("SetID")
            Next

            ''INSERT a new ComapnyDeals record
            'sql = "INSERT INTO CompanyDeals " & _
            '        "(CompanyID,DealID) " & _
            '        "VALUES (" & cmbClient.SelectedValue & "," & cmbDeal.SelectedValue & "); "

            'Common.Data.ModifyDB(sql, cn) 'Creates Duplicates of set Prokofiy Klochko comment this code.

        End If


        '{{{{{{{{{{  Create new Deal if needed  }}}}}}}}}}}
        'sql = "SELECT DealID FROM CompanyDeals WHERE CompanyID=" & cmbClient.SelectedValue

        Dim importFileID As Guid = Guid.NewGuid()
        Dim dealID As Integer = cmbDeal.SelectedValue
        Dim targetFieldValueName As String
        If _isOriginalDestination Then
            targetFieldValueName = "OriginalValueTxt"
        Else
            targetFieldValueName = "ActualValueTxt"
        End If
        Dim loanNoName As String = Lookup_ExcelColumnName(3691)
        Dim loanNoIndex As String = Lookup_ExcelColumnIndex(loanNoName)

        Dim dueDateName As String = Lookup_ExcelColumnName(3690)
        Dim dueDateIndex As Integer = 0
        If dueDateName <> "" Then
            dueDateIndex = Lookup_ExcelColumnIndex(dueDateName)
        End If

        Dim borrowerName As String = Lookup_ExcelColumnName(3631)
        Dim borrowerIndex As Integer = 0
        If borrowerName <> "" Then
            borrowerIndex = Lookup_ExcelColumnIndex(borrowerName)
        End If

        dtNewMappings = DirectCast(dgXMLMapping.DataSource, DataView).Table

        'Decide if this is a MERS Scrub or Normal Routine
        If _runMERSConditionRoutine Then

            Dim dc As New TSGDataImporterDataContext(connectionString)
            dc.CommandTimeout = 0 '10 minutes

            'Save excel data to database
            lblStatusMain.Text = "Uploading and Creating Loans..."
            Dim fileName As String = Mid(currentFilePath, currentFilePath.LastIndexOf("\") + 2)
            Dim fileTabID As Integer = 0

            Dim isVal(dgXMLMapping.Rows.Count) As Boolean

            For ctr = 1 To dgXMLMapping.Rows.Count
                If dgXMLMapping.Rows(ctr - 1).Cells(1).Value = 0 Then
                    isVal(ctr) = False
                Else
                    isVal(ctr) = True
                End If


            Next
            Dim fileTab As ImportFileTab = dc.SaveImporterFileData(Me, dsExcelSheets.Tables(tabCurrent.Tag), importFileID.ToString, fileName, currentFilePath, loanNoIndex, userID, isVal)
            fileTabID = fileTab.ImportFileTabID

            'Convert and save excel data into loan data
            If targetFieldValueName = "OriginalValueTxt" Then
                dc.SaveLoanDataFromImportFileDataOriginal(dealID, importFileID, fileTabID, loanNoIndex, userID, dueDateIndex, borrowerIndex)
                lblStatusMain.Text = "Saving Original Values for Loans..."
            ElseIf targetFieldValueName = "ActualValueTxt" Then
                lblStatusMain.Text = "Saving Actual Values for Loans..."
                dc.SaveLoanDataFromImportFileDataActual(dealID, importFileID, fileTabID, loanNoIndex, userID)
                'Create exceptions based on simple process
                lblStatusMain.Text = "Running Exceptions..."
                dc.SaveLoanDataExceptionsSimple(dealID)
            End If

        Else

            '{{{{{{{{{{  Save Spreadsheet Data  }}}}}}}}}}}
            For Each rowData As DataRow In dsExcelSheets.Tables(tabCurrent.Tag).rows

                'Check to make sure row has required data
                If HasRequiredAspectData(rowData) Then

                    '{{{{{{{{{{  Save new Loans  }}}}}}}}}}}
                    Dim loanID As Integer = 0

                    '   If Loan number does not exist in the Deal (Client for Fulfillment), then create new loan record 
                    Dim dsLoan As DataSet = Common.Data.GetDataSet("SELECT L.LoanID FROM Loans L JOIN DealLoans DL ON DL.LoanID = L.LoanID WHERE L.LoanNo='" & rowData(loanNoName).ToString & "' AND DL.DealID=" & dealID, cn)
                    'Dim dsLoan As DataSet = Common.Data.GetDataSet("SELECT LoanID FROM Loans WHERE LoanNo='" & rowData(loanNoName) & "'",cn)

                    If dsLoan IsNot Nothing AndAlso dsLoan.Tables.Count > 0 Then
                        If dsLoan.Tables(0).Rows.Count > 0 Then
                            'Get Existing LoanID
                            loanID = dsLoan.Tables(0).Rows(0).Item("LoanID")
                            isExistingLoan = True

                            If dueDateName IsNot Nothing AndAlso dueDateName <> "" Then
                                'UPDATE Due Date on Loan Record
                                sql = "UPDATE Loans " & _
                                        "SET DueDate ='" & rowData(dueDateName) & "' " & _
                                        "WHERE LoanID = " & loanID & ";"

                                Common.Data.ModifyDB(sql, cn)
                            End If

                        Else
                            'INSERT a new Loan record
                            Dim loanNumberValue As String = ""
                            Dim dueDateValue As String = ""
                            isExistingLoan = False
                            If loanNoName IsNot Nothing AndAlso loanNoName.ToString <> "" Then
                                loanNumberValue = rowData(loanNoName)
                            Else
                                loanNumberValue = count
                            End If

                            If dueDateName IsNot Nothing AndAlso dueDateName.ToString <> "" Then
                                dueDateValue = rowData(dueDateName)
                            Else
                                dueDateValue = Now.AddDays(30)
                            End If

                            sql = "INSERT INTO Loans " & _
                                    "(PortalID,DealID,LoanNo,DueDate,CreatedBy,CreatedOn) " & _
                                    "VALUES (1," & dealID & ",'" & rowData(loanNoName) & "','" & dueDateValue & "'," & userID & ",'" & Now & "'); " & _
                                    "SELECT SCOPE_IDENTITY() AS LoanID;"

                            dsLoan = Common.Data.GetDataSet(sql, cn)

                            'Set LoanID from scope identity
                            For Each rowFieldData As DataRow In dsLoan.Tables(0).Rows
                                loanID = rowFieldData("LoanID")
                            Next

                            'INSERT a new DealLoans record
                            sql = "INSERT INTO DealLoans " & _
                                    "(DealID,LoanID) " & _
                                    "VALUES (" & dealID & "," & loanID & "); "

                            Common.Data.ModifyDB(sql, cn)

                        End If
                    End If

                    '{{{{{{{{{{  Save Loan Data from Excel Spreadsheet  }}}}}}}}}}}
                    '   Loop through every field in the client's (company) fieldset
                    Dim dsCurrentMappings As DataSet = Common.Data.GetDataSet("SelectMultipleFieldSets @SetID=" & setID, cn)

                    For Each rowMappingAll As DataRow In dsCurrentMappings.Tables(0).Rows

                        'Get Value from spreadsheet data
                        Dim newValue As String = ""

                        For Each rowMappingImport As DataRow In dtNewMappings.Select("FieldSetID=" & rowMappingAll("FieldSetID"))
                            newValue = Replace(rowData(rowMappingImport("ExcelColumn").ToString).ToString, "'", "''")
                        Next

                        'Get Value from data in the database for this FieldSet
                        Dim fieldDataID As Integer = 0
                        Dim oldValue As String = ""
                        Dim dsFieldData As DataSet = Common.Data.GetDataSet("SELECT D.FieldDataID, D.OriginalValueTxt, D.ActualValueTxt " & _
                                                                            "FROM	FieldSets F " & _
                                                                            "JOIN	FieldDataMappings M " & _
                                                                            "ON		M.FieldSetID = F.FieldSetID " & _
                                                                            "JOIN	FieldsData D " & _
                                                                            "ON		D.FieldDataID = M.FieldDataID " & _
                                                                            "WHERE  M.FieldSetID = " & rowMappingAll("FieldSetID") & _
                                                                            "AND    D.LoanID = " & loanID, cn)


                        For Each rowFieldData As DataRow In dsFieldData.Tables(0).Rows
                            fieldDataID = Val(rowFieldData("FieldDataID").ToString)
                            If (cmbDestinationField.SelectedIndex = 0) Then
                                oldValue = rowFieldData("OriginalValueTxt").ToString
                            Else
                                oldValue = rowFieldData("ActualValueTxt").ToString
                            End If
                        Next

                        If fieldDataID = 0 Then
                            'INSERT a new FieldsData record
                            If (cmbDestinationField.SelectedIndex = 0) Then
                                sql = "INSERT INTO FieldsData " & _
                                        "(LoanID,OriginalValueTxt,ModifiedBy,ModifiedOn) " & _
                                        "VALUES (" & loanID & ",'" & Trim(newValue) & "'," & userID & ",'" & Now & "'); " & _
                                        "SELECT SCOPE_IDENTITY() AS FieldDataID;"
                            Else
                                sql = "INSERT INTO FieldsData " & _
                                        "(LoanID,ActualValueTxt,ModifiedBy,ModifiedOn) " & _
                                        "VALUES (" & loanID & ",'" & Trim(newValue) & "'," & userID & ",'" & Now & "'); " & _
                                        "SELECT SCOPE_IDENTITY() AS FieldDataID;"
                            End If
                            dsFieldData = Common.Data.GetDataSet(sql, cn)

                            For Each rowFieldData As DataRow In dsFieldData.Tables(0).Rows
                                fieldDataID = rowFieldData("FieldDataID")
                            Next

                            'INSERT a new FieldDataMappings record
                            sql = "INSERT INTO FieldDataMappings " & _
                                    "(FieldDataID,FieldSetID) " & _
                                    "VALUES (" & fieldDataID & "," & rowMappingAll("FieldSetID") & ")"
                            Common.Data.ModifyDB(sql, cn)

                            'Evaluate and throw any "business rule" exceptions for the new field data
                            If (dealID <> 91) Then  'Found that Fairway PC Review and Data Scrub was taking too long and did not need this routine
                                Try
                                    Dim dfs As New DefaultFieldSetWS.DefaultFieldSet1
                                    dfs.Url = defaultFieldSetURL
                                    dfs.Evaluate(rowMappingAll("FieldSetID"), loanID, userID)
                                Catch ex As Exception
                                End Try
                            End If

                        ElseIf oldValue = "" OrElse chkOverrideValues.Checked Then
                            'UPDATE FieldsData Record
                            If newValue <> "" Then
                                If (cmbDestinationField.SelectedIndex = 0) Then
                                    sql = "UPDATE FieldsData " & _
                                            "SET OriginalValueTxt= '" & Trim(newValue) & "', " & _
                                            "   ModifiedBy=" & userID & "," & _
                                            "   ModifiedOn='" & Now & "' " & _
                                            "WHERE loanID = " & loanID & " AND FieldDataID = " & fieldDataID & ";"
                                Else
                                    sql = "UPDATE FieldsData " & _
                                            "SET ActualValueTxt= '" & Trim(newValue) & "', " & _
                                            "   ModifiedBy=" & userID & "," & _
                                            "   ModifiedOn='" & Now & "' " & _
                                            "WHERE loanID = " & loanID & " AND FieldDataID = " & fieldDataID & ";"
                                End If
                                Common.Data.GetDataSet(sql, cn)
                            End If

                            'Evaluate and throw any "business rule" exceptions for the new field data
                            If (dealID <> 91) Then 'Found that Fairway PC Review and Data Scrub was taking too long and did not need this routine
                                Try
                                    'If (cmbDestinationField.SelectedIndex = 0) Then
                                    '    Dim dfs As New DefaultFieldSetWS.DefaultFieldSet1
                                    '    dfs.Url = defaultFieldSetURL
                                    '    dfs.Evaluate(rowMappingAll("FieldSetID"), loanID, userID)
                                    'Else
                                    Dim dfs As New DefaultFieldSetWS.DefaultFieldSet1
                                    dfs.Url = defaultFieldSetURL
                                    dfs.EvaluateAfterActualUpdate(rowMappingAll("FieldSetID"), loanID, userID)
                                    'End If
                                Catch ex As Exception
                                End Try
                            End If

                        End If

                    Next

                    'INSERT a new record into the LoanStatusHistory Table.
                    If Not isExistingLoan AndAlso loanID <> 0 Then
                        sql = "INSERT INTO LoanStatusHistory " & _
                                "(LoanID,LoanStatusID,ModifiedBy,ModifiedOn,IsArchived) " & _
                                "VALUES (" & loanID & ",1," & userID & ",'" & Now & "',0); "
                        Common.Data.ModifyDB(sql, cn)

                    End If

                End If

                ' progress bar
                pbMain.Value = CInt((i / count) * 100)
                i += 1

            Next

        End If

        isSuccessful = True

        MessageBox.Show("Data was successfully imported.", "Import Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

        'Catch ex As Exception
        '    MessageBox.Show(ex.ToString)
        '    isSuccessful = False
        'Finally
        If cn.State <> ConnectionState.Closed Then cn.Close()
        pbMain.Visible = False
        lblStatusMain.Text = "Ready"
        Me.Cursor = Cursors.Default
        stringWriter.Close()

        '     End Try

    End Sub

    Private Sub btnXMLSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXMLSave.Click

        Me.Cursor = Cursors.WaitCursor

        Dim cn As New SqlClient.SqlConnection(connectionString)
        Dim sql As String

        Try

            cn.Open()

            dgXMLMapping.EndEdit()

            dtNewMappings = DirectCast(dgXMLMapping.DataSource, DataView).Table

            Dim clientColumnName As String = ""
            If _isOriginalDestination Then
                clientColumnName = "ClientMappingName"
            Else
                clientColumnName = "ClientMappingNameActual"
            End If

            'Clear all Mappings in database for the given SetID
            '    If this is not cleared, it may leave older mappings in place that will not allow the user to change the mapping
            sql = "UPDATE FieldSets" & _
                    " SET    " & clientColumnName & " = NULL" & _
                    " WHERE  SetID = " & setID

            Common.Data.ModifyDB(sql, cn)

            'Save Grid of Translations
            For Each row As DataRow In dtNewMappings.Rows

                If row("FieldID") <> 0 Then

                    Dim fieldsetid As Integer = 0
                    Dim dsFieldSets As DataSet = Common.Data.GetDataSet("SELECT FieldSetID FROM FieldSets WHERE FieldID=" & row("FieldID") & " AND SetID=" & setID, cn)

                    For Each rowFieldSet As DataRow In dsFieldSets.Tables(0).Rows
                        fieldsetid = rowFieldSet("FieldSetID")
                    Next

                    If fieldsetid <> 0 Then
                        'UPDATE record
                        sql = "UPDATE FieldSets" & _
                                " SET    " & clientColumnName & " = '" & row("ExcelColumn").ToString & "'" & _
                                " WHERE  FieldSetID = " & fieldsetid

                        Common.Data.ModifyDB(sql, cn)
                    Else
                        'INSERT record
                        sql = "INSERT INTO FieldSets " & _
                                "(SetID,FieldID," & clientColumnName & ",ModifiedBy,ModifiedOn) " & _
                                "VALUES (" & setID & "," & row("FieldID") & ",'" & row("ExcelColumn").ToString & "'," & userID & ",'" & Now & "');" & _
                                "SELECT SCOPE_IDENTITY() AS FieldSetID;"

                        dsFieldSets = Common.Data.GetDataSet(sql, cn)

                        For Each rowFieldSet As DataRow In dsFieldSets.Tables(0).Rows
                            fieldsetid = rowFieldSet("FieldSetID")
                        Next

                        If fieldsetid <> 0 Then

                            'Lookup the original field category
                            Dim dsFieldCategories As DataSet = Common.Data.GetDataSet("SELECT CategoryID FROM FieldCategories WHERE FieldID=" & row("FieldID"), cn)
                            Dim categoryid As Integer = 0

                            For Each rowCategory As DataRow In dsFieldCategories.Tables(0).Rows
                                categoryid = rowCategory("CategoryID")
                            Next

                            If categoryid <> 0 Then
                                sql = "INSERT INTO FieldSetCategories " & _
                                        "(FieldSetID,CategoryID) " & _
                                        "VALUES (" & fieldsetid & "," & categoryid & ")"

                                Common.Data.ModifyDB(sql, cn)
                            End If
                        End If

                    End If

                End If

            Next

            dsOldMappings = GetExistingMappings(cn)
            tabExcelSheets_SelectedIndexChanged(sender, e)

        Catch ex As Exception
        Finally
            If cn.State <> ConnectionState.Closed Then cn.Close()
            Me.Cursor = Cursors.Default
        End Try

    End Sub

#Region " HELPER METHODS "

    Private Shared Function GetExcelConnectionString(ByVal filePath As String) As String

        GetExcelConnectionString = ""

        Select Case filePath.Remove(0, filePath.LastIndexOf(".") + 1)
            Case "csv"
                GetExcelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & filePath & ";Extended Properties=""text;HDR=Yes;FMT=Delimited(,);"""
            Case "xls"
                GetExcelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & filePath & ";Extended Properties=""Excel 8.0;HDR=YES;IMEX=1;"""
            Case "xlsx"
                GetExcelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & filePath & ";Extended Properties=""Excel 12.0;HDR=YES;IMEX=1;"""
        End Select

    End Function

    Private Function Lookup_ExcelColumnName(ByVal fieldID As Integer) As String

        dtNewMappings = DirectCast(dgXMLMapping.DataSource, DataView).Table

        For Each row As DataRow In dtNewMappings.Select("FieldID = " & fieldID)
            Return Trim(row("ExcelColumn").ToString)
        Next

        Return Nothing

    End Function
    Private Function Lookup_ExcelColumnIndex(ByVal columnName As String) As Integer

        Dim tabCurrent As TabPage = tabExcelSheets.SelectedTab
        Return dsExcelSheets.Tables(tabCurrent.Tag.ToString).Columns(columnName).Ordinal + 1

        Return Nothing

    End Function

    Private Function HasRequiredAspects() As Boolean

        If Not dtCurrentExcelSheet Is Nothing Then
            Dim requiredCount As Integer = 0 'Should be set to zero initially

            For Each colRequired As DataColumn In dtCurrentExcelSheet.Columns

                'Find Field Name
                dtNewMappings = DirectCast(dgXMLMapping.DataSource, DataView).Table

                Dim fieldRows As DataRow() = dtNewMappings.Select("ExcelColumn='" & colRequired.ColumnName & "'")
                Dim fieldRow As DataRow = Nothing

                If Not fieldRows Is Nothing AndAlso fieldRows.Length > 0 Then
                    fieldRow = fieldRows(0)

                    If Not fieldRow Is Nothing Then

                        Select Case fieldRow("FieldID")
                            Case 3691 'Loan Number
                                requiredCount += 1
                            Case 3631 'Borrower Last Name
                                requiredCount += 2
                                'Case "LOANSTATUSCODE"
                                '    requiredCount += 4
                                'Case "LOANSTATUSDESCRIPTION"
                                '    requiredCount += 8
                                'Case "LOANSTATUSDATE"
                                '    requiredCount += 16
                            Case Else

                        End Select

                    End If
                End If

            Next

            If requiredCount = 3 Then
                lblRequiredAspects.BackColor = Color.Green
                lblRequiredAspects.Text = "Meets Import Requirements"
                tt.SetToolTip(lblRequiredAspects, "Meets all import requirements for the LES Import.")
                btnXMLGenerate.Enabled = True
                Return True
            Else
                lblRequiredAspects.BackColor = Color.Red
                lblRequiredAspects.Text = "Does Not Meet Import Requirements"
                tt.SetToolTip(lblRequiredAspects, requiredAspectText)
                btnXMLGenerate.Enabled = False
                Return False
            End If
        End If

    End Function

    Private Function HasRequiredAspectData(ByVal row As DataRow) As Boolean

        'If row(Lookup_ExcelColumnName("LoanNumber")).ToString = "" Then
        '    Return False
        'End If

        'If row(Lookup_ExcelColumnName("PrimaryBorrowerLastName")).ToString = "" Then
        '    Return False
        'End If

        'If row(Lookup_ExcelColumnName("LoanStatusCode")).ToString = "" Then
        '    Return False
        'End If

        'If row(Lookup_ExcelColumnName("LoanStatusDescription")).ToString = "" Then
        '    Return False
        'End If

        'If row(Lookup_ExcelColumnName("LoanStatusDate")).ToString = "" Then
        '    Return False
        'End If

        Return True

    End Function

    Private Function GetExistingMappings(ByVal cn As SqlClient.SqlConnection) As DataSet


        Dim clientColumnName As String = ""
        If _isOriginalDestination Then
            clientColumnName = "ClientMappingName"
        Else
            clientColumnName = "ClientMappingNameActual"
        End If


        Dim sql As String = "SELECT	FieldSetID, FieldID, ClientFieldName, " & clientColumnName & " AS ClientMappingName " & _
                            "FROM	FieldSets F " & _
                            "JOIN	CompanyFieldSets CF " & _
                            "ON		CF.SetID = F.SetID " & _
                            "WHERE  CF.CompanyID = " & cmbClient.SelectedValue & ";"

        Dim ds As DataSet = Common.Data.GetDataSet(sql, cn)

        Return ds

    End Function
    Private Sub AddAspectsToFieldTable()

        'Dim rowField As STONEHILLDataSet.FieldRow = Nothing

        ''Add Row for <Skip Aspect> row
        'rowField = STONEHILLDataSet.Field.NewFieldRow

        'rowField("FieldName") = "-1"
        'rowField("FieldDescription") = "< Skip Aspect >"
        'rowField("BelongsToNode") = "None"
        'rowField("IsRequired") = False
        'rowField("IsActive") = True

        'Me.STONEHILLDataSet.Field.AddFieldRow(rowField)

        ''Add all other Aspects from the ACES DB
        'For Each rowAspect As ACESDataSet.ASPECTSRow In Me.ACESDataSet.ASPECTS.Rows

        '    Dim rowsField As DataRow() = STONEHILLDataSet.Field.Select("FieldName='" & rowAspect.FieldCode & "'")

        '    If rowsField.Length < 1 Then
        '        rowField = STONEHILLDataSet.Field.NewFieldRow

        '        rowField("FieldName") = rowAspect("FieldCode").ToString
        '        rowField("FieldDescription") = Trim(rowAspect("FieldName").ToString)
        '        rowField("BelongsToNode") = "Aspect"
        '        rowField("IsRequired") = False
        '        rowField("IsActive") = True

        '        Me.STONEHILLDataSet.Field.AddFieldRow(rowField)
        '    End If

        'Next

    End Sub

#End Region

    Private Sub btnEditDeal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditDeal.Click

        Dim editWorkflow As New EditWorkflow

        If editWorkflow.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then

            Dim cn As New SqlClient.SqlConnection(connectionString)
            Dim dealID As Integer = cmbDeal.SelectedValue

            Try

                cn.Open()

                'Save Deal Data
                If dealID = -1 Then
                    Dim sql As String = "InsertDeal"
                    Dim params As New ArrayList
                    params.Add(New Common.KeyValueList("DealNo", ""))
                    params.Add(New Common.KeyValueList("DealName", editWorkflow.txtDealName.Text))
                    params.Add(New Common.KeyValueList("DealStatusID", 1))
                    params.Add(New Common.KeyValueList("IsActive", 1))
                    Dim paramOut As New SqlClient.SqlParameter("DealID", SqlDbType.Int)
                    paramOut.Direction = ParameterDirection.Output

                    dealID = Common.Data.ModifyDB(sql, params, paramOut, cn)


                    'Insert record into CompanyDeals table
                    sql = "InsertCompanyDeals"
                    params = New ArrayList
                    params.Add(New Common.KeyValueList("DealID", dealID))
                    params.Add(New Common.KeyValueList("CompanyID", cmbClient.SelectedValue))

                    Common.Data.ModifyDB(sql, params, cn)

                    'Insert Record into DealServices table
                    sql = "InsertDealServices"
                    params = New ArrayList
                    params.Add(New Common.KeyValueList("DealID", dealID))
                    params.Add(New Common.KeyValueList("ServiceID", serviceID))

                    Common.Data.ModifyDB(sql, params, cn)

                Else
                    Common.Data.ModifyDB("UpdateDeal @DealID=" & cmbDeal.SelectedValue & "," & _
                                         "@DealNo=''," & _
                                         "@DealName='" & editWorkflow.txtDealName.Text & "'," & _
                                         "@DealStatusID=1", cn)

                End If

                'Save Status Data
                Common.Data.ModifyDB("DeleteDealLoanStatus @DealID=" & dealID, cn)

                For Each row As DataGridViewRow In editWorkflow.dgStatuses.Rows

                    Dim chkBox As DataGridViewCheckBoxCell = DirectCast(row.Cells(2), DataGridViewCheckBoxCell)
                    Dim drv As DataRowView = DirectCast(row.DataBoundItem, DataRowView)

                    If chkBox.Value Then
                        Common.Data.ModifyDB("InsertDealLoanStatus @DealID=" & dealID & ",@LoanStatusID=" & drv("LoanStatusID").ToString & ",@IsTrigger=" & Common.StringFunction.FormatBoolean(drv("IsTrigger").ToString), cn)
                        'Common.Data.ModifyDB("InsertDealLoanStatus @DealID=" & dealID & ",@LoanStatusID=" & drv("LoanStatusID").ToString, cn)
                    End If

                Next

                BindDealComboBox(cn)

                cmbDeal.SelectedValue = dealID

            Catch ex As Exception
                '#If DEBUG Then
                '                MessageBox.Show(ex.ToString)
                '#End If
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
            End Try

        End If

    End Sub

    Private Sub BindDealComboBox(ByRef cn As SqlClient.SqlConnection)

        'Bind Deal Data
        Dim sqlDeal As String = "SELECT D.DealID, D.DealName, 1 AS SortOrder " & _
                                "FROM   Deals D " & _
                                "JOIN   CompanyDeals CD ON CD.DealID = D.DealID " & _
                                "JOIN   DealServices DS ON DS.DealID = D.DealID " & _
                                "WHERE  CD.CompanyID=" & cmbClient.SelectedValue & " " & _
                                "AND    D.IsActive=1 " & _
                                "AND    DS.ServiceID = " & serviceID & ";"

        Dim dsDeal As DataSet = Common.Data.GetDataSet(sqlDeal, cn)

        'Change Deal/Project/Workflow Name
        Select Case serviceID
            Case 4  'Fulfillment
                lblDeal.Text = "Workflow"
                dsDeal.Tables(0).Rows.Add(New Object() {-2, "<Select a Workflow>", -2})
                dsDeal.Tables(0).Rows.Add(New Object() {-1, "{Create a New Workflow}", -1})
            Case 7  'Quality Control
                lblDeal.Text = "Audit"
                dsDeal.Tables(0).Rows.Add(New Object() {-2, "<Select a Audit>", -2})
                dsDeal.Tables(0).Rows.Add(New Object() {-1, "{Create a New Audit}", -1})
            Case Else  'Due Diligence
                lblDeal.Text = "Deal"
                dsDeal.Tables(0).Rows.Add(New Object() {-2, "<Select a Deal>", -2})
                dsDeal.Tables(0).Rows.Add(New Object() {-1, "{Create a New Deal}", -1})
        End Select

        dsDeal.Tables(0).DefaultView.Sort = "SortOrder,DealName"

        cmbDeal.BeginUpdate()
        cmbDeal.DataSource = dsDeal.Tables(0).DefaultView
        cmbDeal.DisplayMember = "DealName"
        cmbDeal.ValueMember = "DealID"
        cmbDeal.EndUpdate()

    End Sub

    Private Sub dgXMLMapping_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgXMLMapping.DataError

    End Sub

    Private Function GetQueryStringParameters() As NameValueCollection
        Dim NameValueTable As New NameValueCollection()

        If (ApplicationDeployment.IsNetworkDeployed) Then
            Dim QueryString As String = ApplicationDeployment.CurrentDeployment.ActivationUri.Query
            NameValueTable = HttpUtility.ParseQueryString(QueryString)
        End If

        GetQueryStringParameters = NameValueTable
    End Function

    Private Sub MenuStrip2_ItemClicked(sender As System.Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip2.ItemClicked

    End Sub
End Class

'{{{{{ KeyValueList - Used with an ArrayList, it gives the developer a light-weight key/value pair intended for (but not limited to) use with Stored Procedure Paramater lists }}}}}
Public Class KeyValueList

    Private str_KeyIn As String
    Private str_ValueIn As Object

    Public Sub New(ByVal str_Key As String, ByVal objValue As Object)
        MyBase.New()
        Me.str_KeyIn = str_Key
        Me.str_ValueIn = objValue
    End Sub

    Public ReadOnly Property Key() As String
        Get
            Return str_KeyIn
        End Get
    End Property

    Public ReadOnly Property Value() As Object
        Get
            Return str_ValueIn
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return Me.str_KeyIn & " - " & Me.str_ValueIn.ToString
    End Function

End Class
