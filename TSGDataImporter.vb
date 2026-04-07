Imports System.Text
Imports System.Runtime.CompilerServices
  
Partial Class TSGDataImporterDataContext


    Public Function SaveImporterFileData(ByRef ownerForm As Main, dtExcel As DataTable, fileId As String, fileName As String, filePath As String, loanNoIndex As Integer, userId As Integer, colList() As Boolean) As ImportFileTab

        Dim importFileID = New Guid(fileId)

        'Store file properties in database
        Dim file = New ImportFile()
        file.ImportFileID = importFileID
        file.CreatedBy = userId
        file.CreatedOn = DateTime.Now
        file.FileName = fileName
        file.FilePath = filePath

        Me.ImportFiles.InsertOnSubmit(file)

        'Fetch the file data and parse into individual cells
        file.ExcelToDataSetCompletedOn = DateTime.Now
        Me.SubmitChanges()

        Dim columnIndex = 0
        Dim tabName = dtExcel.TableName
        Dim sbXMLString As New StringBuilder()

        'Save the tab and get back the ImportFileTabID
        Dim fileTab = New ImportFileTab()
        fileTab.ImportFileID = importFileID
        fileTab.TabName = tabName
        fileTab.TabSortOrder = 1
        Me.ImportFileTabs.InsertOnSubmit(fileTab)
        Me.SubmitChanges()

        'Save the Column Names based on the tab
        For Each col As DataColumn In dtExcel.Columns
            columnIndex += 1
            Dim fileColumn = New ImportFileColumn()
            fileColumn.ImportFileID = importFileID
            fileColumn.ImportFileTabID = fileTab.ImportFileTabID
            fileColumn.ColumnName = col.ColumnName
            fileColumn.ColumnIndex = columnIndex
            If (col.Ordinal + 1 = loanNoIndex) Then
                fileColumn.IsKeyColumn = True
            End If
            Me.ImportFileColumns.InsertOnSubmit(fileColumn)
        Next
        Me.SubmitChanges()

        'Transform the data to XML and store in database 
        Dim rowIndex = 0
        Dim colIndex = 0
        Dim saveBufferCount = 0
        Dim runningBufferCount = 0
        Dim totalCount = dtExcel.Rows.Count * dtExcel.Columns.Count

        'Start the root node of the xml string
        sbXMLString.Append("<root>")
        Dim msg As String = ""
        For Each row As DataRow In dtExcel.Rows
            rowIndex += 1
            colIndex = 0

            'Capture the cell data and store in the ImportFileData table
            For i As Integer = 0 To dtExcel.Columns.Count - 1
                colIndex += 1

                '  If Not String.IsNullOrEmpty(row(i).ToString()) Then
                If colList(colIndex) = True Then

                    sbXMLString.Append("<ImportFileData ")
                    sbXMLString.Append("ImportFileID=""" & importFileID.ToString & """ ")
                    sbXMLString.Append("ImportFileTabID=""" & fileTab.ImportFileTabID & """ ")
                    sbXMLString.Append("RowIndex=""" & rowIndex & """ ")
                    sbXMLString.Append("ColumnIndex=""" & colIndex & """ ")
                    sbXMLString.Append("CellValue=""" & row(i).ToString().ToXmlFriendlyString() & """ ")
                    'sbXMLString.Append("CellValueLoanReady=\"" + row[i].ToString() + " \ " ")
                    sbXMLString.Append("IsValid=""true"" ")

                    sbXMLString.Append(" />")

                    saveBufferCount += 1


                End If

            Next

            If saveBufferCount > 20000 Then
                'Finalize the root node of the xml string
                sbXMLString.Append("</root>")

                'Write the file data to the ImportFileData table
                InsertImportFileDataFromXML(sbXMLString.ToString())

                'Start a new xml group and buffer
                sbXMLString = New StringBuilder()
                sbXMLString.Append("<root>")

                ' progress bar
                runningBufferCount += saveBufferCount
                ownerForm.pbMain.Value = CInt((runningBufferCount / totalCount) * 100)

                saveBufferCount = 0
            End If
        Next
        'Clean up and save any data that did not get caught by the buffer
        sbXMLString.Append("</root>")

        InsertImportFileDataFromXML(sbXMLString.ToString())

        'Update Finished Upload time
        file.DatabaseCompletedOn = DateTime.Now
        Me.SubmitChanges()

        ownerForm.pbMain.Value = CInt(95)

        Return fileTab

    End Function


End Class


Module TsgDataImporter
    <Extension()>
    Public Function ToXmlFriendlyString(ByVal xml As String) As String
        xml = xml.Replace("&", "&amp;")
        xml = xml.Replace(">", "&gt;")
        xml = xml.Replace("<", "&lt;")

        Return xml
    End Function
End Module