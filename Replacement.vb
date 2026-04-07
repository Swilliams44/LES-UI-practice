Public Class Replacement

    Private opener As Main
    Private dsTranslate As DataSet
    Private connectionString As String = Main.connectionString

    Private Sub Replace_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load

        opener = DirectCast(Me.Owner, Main)

        ColumnTranslateDataGridView.AutoGenerateColumns = False

        'Populate the List of Excel columns
        cmbColumn.Items.Clear()
        cmbColumn.Items.Add("<Select a Column>")

        For Each col As DataColumn In opener.dtCurrentExcelSheet.Columns
            cmbColumn.Items.Add(col.ColumnName)
        Next

        cmbColumn.Sorted = True
        cmbColumn.SelectedIndex = 0

        ColumnTranslateDataGridView.RowHeadersWidth = 90

    End Sub

    Private Sub cmbColumn_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbColumn.SelectedIndexChanged

        Dim cn As New SqlClient.SqlConnection(connectionString)

        Try
            cn.Open()


            'Update TaregetName textbox
            Dim dsTargetName As DataSet = Common.Data.GetDataSet("SELECT ReplaceTargetName FROM Import_Column WHERE CompanyID=" & opener.cmbClient.SelectedValue & " AND SourceName='" & cmbColumn.SelectedItem & "'", cn)

            For Each row As DataRow In dsTargetName.Tables(0).Rows
                txtTranslateColumn.Text = row("ReplaceTargetName").ToString
            Next

            'Load Replace data into a dataset
            dsTranslate = Common.Data.GetDataSet("SelectImportReplace @CompanyID=" & opener.cmbClient.SelectedValue & ",@ColumnName='" & cmbColumn.SelectedItem & "'", cn)

            ColumnTranslateDataGridView.DataSource = dsTranslate.Tables(0).DefaultView

            If cmbColumn.SelectedIndex <> 0 Then
                btnDeleteTranslation.Enabled = True
            Else
                btnDeleteTranslation.Enabled = False
            End If

        Catch ex As Exception
#If DEBUG Then
            MessageBox.Show(ex.ToString)
#End If
        Finally
            If cn.State <> ConnectionState.Closed Then cn.Close()
        End Try

    End Sub

    Private Sub Translate_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        'Dim ds As ACESXMLBuilder.STONEHILLDataSet = ColumnTranslateBindingSource.DataSource
        'Dim dt As ACESXMLBuilder.STONEHILLDataSet.ColumnTranslateDataTable = ds.ColumnTranslate

        'If ds.HasChanges() Then
        '    If MessageBox.Show("You have changes that have not been saved in the Column Translations.  Would you like to save your changes before exiting?", "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) = Windows.Forms.DialogResult.Yes Then
        '        NavigatorSave_Click(New Object, New EventArgs)
        '    End If
        'End If

    End Sub

    Private Sub NavigatorSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NavigatorSave.Click

        If txtTranslateColumn.Text <> "" Then

            Dim cn As New SqlClient.SqlConnection(connectionString)

            Try
                cn.Open()

                ColumnTranslateDataGridView.CommitEdit(DataGridViewDataErrorContexts.CurrentCellChange)

                'Check to see if ColumnID exists
                Dim columnID As Integer = 0
                Dim dsColumnCheck As DataSet = Common.Data.GetDataSet("SELECT ColumnID FROM Import_Column WHERE CompanyID=" & opener.cmbClient.SelectedValue & " AND SourceName='" & cmbColumn.SelectedItem & "'", cn)

                For Each rowColumn As DataRow In dsColumnCheck.Tables(0).Rows
                    columnID = rowColumn("ColumnID")
                Next

                If columnID = 0 Then 'Add new record.
                    'INSERT into Import_Column table
                    Dim dsColumn As DataSet = Common.Data.GetDataSet("INSERT INTO Import_Column (CompanyID,SourceName,ReplaceTargetName) " & _
                                                                     "VALUES (" & opener.cmbClient.SelectedValue & ",'" & cmbColumn.SelectedItem & "','" & txtTranslateColumn.Text & "');" & _
                                                                     "SELECT SCOPE_IDENTITY() AS ColumnID;", cn)
                    If dsColumn.Tables.Count > 0 AndAlso dsColumn.Tables(0).Rows.Count > 0 Then
                        columnID = Convert.ToInt32(dsColumn.Tables(0).Rows(0).Item("ColumnID"))
                    End If
                Else
                    'UPDATE Import_Column table
                    Common.Data.ModifyDB("UPDATE Import_Column " & _
                                         "SET ReplaceTargetName='" & txtTranslateColumn.Text & "' " & _
                                         "WHERE CompanyID = " & opener.cmbClient.SelectedValue & _
                                         "AND ColumnID = " & columnID, cn)
                End If


                For Each row As DataRow In dsTranslate.Tables(0).Select()

                    If CInt(Val(row("ColumnID").ToString)) = 0 Then 'This is a newly added row
                        'INSERT into Import_ColumnTranslate table
                        Dim dsColumn As DataSet = Common.Data.GetDataSet("INSERT INTO Import_ColumnReplace (CompanyID,ColumnID,SourceValue,TargetValue) " & _
                                             "VALUES (" & opener.cmbClient.SelectedValue & "," & columnID & ",'" & row("SourceValue").ToString & "','" & row("TargetValue").ToString & "');", cn)
                    Else
                        'UPDATE Import_ColumnTranslate table
                        Common.Data.ModifyDB("UPDATE Import_ColumnReplace " & _
                                             "SET TargetValue='" & row("TargetValue").ToString & "' " & _
                                             "WHERE CompanyID = " & opener.cmbClient.SelectedValue & " " & _
                                             "AND ColumnID = " & row("ColumnID") & " " & _
                                             "AND SourceValue='" & row("SourceValue").ToString & "'", cn)
                    End If

                Next

                cmbColumn_SelectedIndexChanged(sender, e)

            Catch ex As Exception
#If DEBUG Then
                MessageBox.Show(ex.ToString)
#End If
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
            End Try

        End If

    End Sub

    Private Sub NavigatorSaveClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NavigatorSaveClose.Click
        NavigatorSave_Click(sender, e)
        Me.Close()
    End Sub

    Private Sub btnClearList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If MessageBox.Show("Clearing this replacement list results in a permanently removal.  Are you sure you want to delete the list? ", "Delete Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
            'Delete all items associated with this translation.
            'UPDATE Import_ColumnTranslate table
            Dim cn As New SqlClient.SqlConnection(connectionString)

            Try
                cn.Open()

                Common.Data.ModifyDB("DELETE FROM Import_ColumnReplace " & _
                                     "WHERE CompanyID = " & opener.cmbClient.SelectedValue & " " & _
                                     "AND ColumnID = ( SELECT ColumnID FROM Import_Column WHERE TargetName = '" & txtTranslateColumn.Text & "') ", cn)

                'Clear the items in the grid.
                cmbColumn_SelectedIndexChanged(cmbColumn, New EventArgs)

            Catch ex As Exception
#If DEBUG Then
                MessageBox.Show(ex.ToString)
#End If
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
            End Try

        End If

    End Sub

    Private Sub btnDeleteTranslation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteTranslation.Click

        If MessageBox.Show("Deleting this replacement results in a permanently removal, including all the items in the list.  Are you sure you want to delete the translation? ", "Delete Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
            'Delete all items associated with this translation and the translation.
            'UPDATE Import_ColumnTranslate table

            Dim cn As New SqlClient.SqlConnection(connectionString)

            Try
                cn.Open()

                Dim sqlString As String = ""

                sqlString = "DELETE FROM Import_ColumnTranslate " & _
                            "WHERE CompanyID = " & opener.cmbClient.SelectedValue & " " & _
                            "AND ColumnID = ( SELECT Top 1 ColumnID FROM Import_Column WHERE ReplaceTargetName = '" & txtTranslateColumn.Text & "');"

                sqlString += "DELETE FROM Import_Column " & _
                            "WHERE CompanyID = " & opener.cmbClient.SelectedValue & " " & _
                            "AND TargetName IS NULL " & _
                            "AND ReplaceTargetName = '" & txtTranslateColumn.Text & "';"

                sqlString += "UPDATE Import_Column " & _
                            "SET ReplaceTargetName = NULL " & _
                            "WHERE CompanyID = " & opener.cmbClient.SelectedValue & " " & _
                            "AND ReplaceTargetName = '" & txtTranslateColumn.Text & "';"

                Common.Data.ModifyDB(sqlString, cn)


                'Clear the items in the grid.
                cmbColumn_SelectedIndexChanged(cmbColumn, New EventArgs)

            Catch ex As Exception
#If DEBUG Then
                MessageBox.Show(ex.ToString)
#End If
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
            End Try
        End If

    End Sub

    Private Sub NavigatorDelete_Click(sender As System.Object, e As System.EventArgs) Handles NavigatorDelete.Click

    End Sub
End Class