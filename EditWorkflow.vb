Imports System.Windows.Forms

Public Class EditWorkflow

    Private connectionString As String = Main.connectionString

    Private Sub EditWorkflow_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim cn As New SqlClient.SqlConnection(connectionString)

        Try

            cn.Open()

            Dim main As Main = Me.Owner
            Dim dealID As Integer = main.cmbDeal.SelectedValue
            Dim dealName As String = main.cmbDeal.Text

            If dealName = "{Create a New Workflow}" Then
                txtDealName.Text = "Add New Workflow Name"

                dgStatuses.AutoGenerateColumns = False

                'Get Statuses

                Dim dsStatuses As DataSet = Common.Data.GetDataSet("Get_LoanStatuses @DealID=0", cn)
                dsStatuses.Tables(0).DefaultView.Sort = "SortOrder"
                dgStatuses.DataSource = dsStatuses.Tables(0).DefaultView

            Else

                txtDealName.Text = dealName

                dgStatuses.AutoGenerateColumns = False

                'Get Statuses
                Dim dsStatuses As DataSet = Common.Data.GetDataSet("Get_LoanStatuses @DealID=" & dealID, cn)
                dsStatuses.Tables(0).DefaultView.Sort = "SortOrder"
                dgStatuses.DataSource = dsStatuses.Tables(0).DefaultView

            End If

        Catch ex As Exception
#If DEBUG Then
            MessageBox.Show(ex.ToString)
#End If
        Finally
            If cn.State <> ConnectionState.Closed Then cn.Close()
        End Try

    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtDealName_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDealName.Enter

        If txtDealName.Text = "Add New Workflow Name" Then
            txtDealName.Text = ""
        End If

    End Sub

    Private Sub txtDealName_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDealName.Leave

        If txtDealName.Text = "" Then
            txtDealName.Text = "Add New Workflow Name"
        End If

    End Sub

End Class
