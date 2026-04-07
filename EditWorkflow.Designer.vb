<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditWorkflow
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDealName = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.StatusTab = New System.Windows.Forms.TabPage()
        Me.dgStatuses = New System.Windows.Forms.DataGridView()
        Me.SortOrder = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsUsed = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.IsTrigger = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.StatusTab.SuspendLayout()
        CType(Me.dgStatuses, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(412, 457)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Save"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Workflow Name"
        '
        'txtDealName
        '
        Me.txtDealName.Location = New System.Drawing.Point(101, 30)
        Me.txtDealName.Name = "txtDealName"
        Me.txtDealName.Size = New System.Drawing.Size(454, 20)
        Me.txtDealName.TabIndex = 2
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.StatusTab)
        Me.TabControl1.Location = New System.Drawing.Point(15, 67)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(540, 381)
        Me.TabControl1.TabIndex = 3
        '
        'StatusTab
        '
        Me.StatusTab.Controls.Add(Me.dgStatuses)
        Me.StatusTab.Location = New System.Drawing.Point(4, 22)
        Me.StatusTab.Name = "StatusTab"
        Me.StatusTab.Padding = New System.Windows.Forms.Padding(3)
        Me.StatusTab.Size = New System.Drawing.Size(532, 355)
        Me.StatusTab.TabIndex = 0
        Me.StatusTab.Text = "Status Selection"
        Me.StatusTab.UseVisualStyleBackColor = True
        '
        'dgStatuses
        '
        Me.dgStatuses.AllowUserToAddRows = False
        Me.dgStatuses.AllowUserToDeleteRows = False
        Me.dgStatuses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgStatuses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgStatuses.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SortOrder, Me.StatusName, Me.IsUsed, Me.IsTrigger})
        Me.dgStatuses.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgStatuses.Location = New System.Drawing.Point(3, 3)
        Me.dgStatuses.Name = "dgStatuses"
        Me.dgStatuses.RowHeadersVisible = False
        Me.dgStatuses.Size = New System.Drawing.Size(526, 349)
        Me.dgStatuses.TabIndex = 0
        '
        'SortOrder
        '
        Me.SortOrder.DataPropertyName = "SortOrder"
        Me.SortOrder.FillWeight = 16.03809!
        Me.SortOrder.HeaderText = "Order"
        Me.SortOrder.Name = "SortOrder"
        Me.SortOrder.ReadOnly = True
        Me.SortOrder.Width = 56
        '
        'StatusName
        '
        Me.StatusName.DataPropertyName = "LoanStatusName"
        Me.StatusName.FillWeight = 206.5583!
        Me.StatusName.HeaderText = "Status"
        Me.StatusName.Name = "StatusName"
        Me.StatusName.Width = 60
        '
        'IsUsed
        '
        Me.IsUsed.DataPropertyName = "IsSelected"
        Me.IsUsed.FillWeight = 101.5228!
        Me.IsUsed.HeaderText = "Selected?"
        Me.IsUsed.Name = "IsUsed"
        Me.IsUsed.Width = 59
        '
        'IsTrigger
        '
        Me.IsTrigger.DataPropertyName = "IsTrigger"
        Me.IsTrigger.FillWeight = 75.88074!
        Me.IsTrigger.HeaderText = "Is Trigger?"
        Me.IsTrigger.Name = "IsTrigger"
        Me.IsTrigger.Width = 61
        '
        'EditWorkflow
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(570, 498)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.txtDealName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EditWorkflow"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Edit Workflow"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.StatusTab.ResumeLayout(False)
        CType(Me.dgStatuses, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDealName As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents StatusTab As System.Windows.Forms.TabPage
    Friend WithEvents dgStatuses As System.Windows.Forms.DataGridView
    Friend WithEvents SortOrder As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsUsed As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents IsTrigger As System.Windows.Forms.DataGridViewCheckBoxColumn

End Class
