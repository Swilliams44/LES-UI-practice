<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Replacement
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Replacement))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ColumnTranslateDataGridView = New System.Windows.Forms.DataGridView()
        Me.SourceValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TargetValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnTranslateBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.NavigatorDelete = New System.Windows.Forms.ToolStripButton()
        Me.NavigatorSaveClose = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.NavigatorSave = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnDeleteTranslation = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbColumn = New System.Windows.Forms.ComboBox()
        Me.txtTranslateColumn = New System.Windows.Forms.TextBox()
        Me.Panel2.SuspendLayout()
        CType(Me.ColumnTranslateDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ColumnTranslateBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ColumnTranslateBindingNavigator.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ColumnTranslateDataGridView)
        Me.Panel2.Controls.Add(Me.ColumnTranslateBindingNavigator)
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel2.Size = New System.Drawing.Size(607, 480)
        Me.Panel2.TabIndex = 6
        '
        'ColumnTranslateDataGridView
        '
        Me.ColumnTranslateDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ColumnTranslateDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SourceValue, Me.TargetValue})
        Me.ColumnTranslateDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ColumnTranslateDataGridView.Location = New System.Drawing.Point(5, 86)
        Me.ColumnTranslateDataGridView.Name = "ColumnTranslateDataGridView"
        Me.ColumnTranslateDataGridView.Size = New System.Drawing.Size(597, 364)
        Me.ColumnTranslateDataGridView.TabIndex = 0
        '
        'SourceValue
        '
        Me.SourceValue.DataPropertyName = "SourceValue"
        Me.SourceValue.HeaderText = "Search For Text"
        Me.SourceValue.Name = "SourceValue"
        Me.SourceValue.Width = 250
        '
        'TargetValue
        '
        Me.TargetValue.DataPropertyName = "TargetValue"
        Me.TargetValue.HeaderText = "Replace With Text"
        Me.TargetValue.Name = "TargetValue"
        Me.TargetValue.Width = 250
        '
        'ColumnTranslateBindingNavigator
        '
        Me.ColumnTranslateBindingNavigator.AddNewItem = Nothing
        Me.ColumnTranslateBindingNavigator.CountItem = Nothing
        Me.ColumnTranslateBindingNavigator.DeleteItem = Me.NavigatorDelete
        Me.ColumnTranslateBindingNavigator.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ColumnTranslateBindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ColumnTranslateBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NavigatorDelete, Me.NavigatorSaveClose, Me.ToolStripSeparator1, Me.NavigatorSave})
        Me.ColumnTranslateBindingNavigator.Location = New System.Drawing.Point(5, 450)
        Me.ColumnTranslateBindingNavigator.MoveFirstItem = Nothing
        Me.ColumnTranslateBindingNavigator.MoveLastItem = Nothing
        Me.ColumnTranslateBindingNavigator.MoveNextItem = Nothing
        Me.ColumnTranslateBindingNavigator.MovePreviousItem = Nothing
        Me.ColumnTranslateBindingNavigator.Name = "ColumnTranslateBindingNavigator"
        Me.ColumnTranslateBindingNavigator.PositionItem = Nothing
        Me.ColumnTranslateBindingNavigator.Size = New System.Drawing.Size(597, 25)
        Me.ColumnTranslateBindingNavigator.TabIndex = 6
        Me.ColumnTranslateBindingNavigator.Text = "BindingNavigator1"
        '
        'NavigatorDelete
        '
        Me.NavigatorDelete.Image = CType(resources.GetObject("NavigatorDelete.Image"), System.Drawing.Image)
        Me.NavigatorDelete.Name = "NavigatorDelete"
        Me.NavigatorDelete.RightToLeftAutoMirrorImage = True
        Me.NavigatorDelete.Size = New System.Drawing.Size(60, 22)
        Me.NavigatorDelete.Text = "Delete"
        '
        'NavigatorSaveClose
        '
        Me.NavigatorSaveClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.NavigatorSaveClose.Image = CType(resources.GetObject("NavigatorSaveClose.Image"), System.Drawing.Image)
        Me.NavigatorSaveClose.Name = "NavigatorSaveClose"
        Me.NavigatorSaveClose.Size = New System.Drawing.Size(96, 22)
        Me.NavigatorSaveClose.Text = "Save && Close"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'NavigatorSave
        '
        Me.NavigatorSave.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.NavigatorSave.Image = CType(resources.GetObject("NavigatorSave.Image"), System.Drawing.Image)
        Me.NavigatorSave.Name = "NavigatorSave"
        Me.NavigatorSave.Size = New System.Drawing.Size(51, 22)
        Me.NavigatorSave.Text = "Save"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(5, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(597, 81)
        Me.Panel1.TabIndex = 8
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnDeleteTranslation, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbColumn, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtTranslateColumn, 2, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(597, 81)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'btnDeleteTranslation
        '
        Me.btnDeleteTranslation.Location = New System.Drawing.Point(3, 30)
        Me.btnDeleteTranslation.Name = "btnDeleteTranslation"
        Me.btnDeleteTranslation.Size = New System.Drawing.Size(114, 21)
        Me.btnDeleteTranslation.TabIndex = 3
        Me.btnDeleteTranslation.Text = "Delete Replacement"
        Me.btnDeleteTranslation.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(361, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(233, 23)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "New Replace Column Name"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(123, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(232, 23)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Excel Column"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbColumn
        '
        Me.cmbColumn.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbColumn.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbColumn.DisplayMember = "ColumnID"
        Me.cmbColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbColumn.FormattingEnabled = True
        Me.cmbColumn.Location = New System.Drawing.Point(123, 30)
        Me.cmbColumn.Name = "cmbColumn"
        Me.cmbColumn.Size = New System.Drawing.Size(232, 21)
        Me.cmbColumn.TabIndex = 1
        Me.cmbColumn.ValueMember = "ColumnID"
        '
        'txtTranslateColumn
        '
        Me.txtTranslateColumn.Location = New System.Drawing.Point(361, 30)
        Me.txtTranslateColumn.Name = "txtTranslateColumn"
        Me.txtTranslateColumn.Size = New System.Drawing.Size(203, 20)
        Me.txtTranslateColumn.TabIndex = 2
        '
        'Replacement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(607, 480)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "Replacement"
        Me.ShowIcon = False
        Me.Text = "Replace Text within Columns"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.ColumnTranslateDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ColumnTranslateBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ColumnTranslateBindingNavigator.ResumeLayout(False)
        Me.ColumnTranslateBindingNavigator.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ColumnTranslateDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents ColumnTranslateBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents NavigatorDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents NavigatorSaveClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NavigatorSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnDeleteTranslation As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbColumn As System.Windows.Forms.ComboBox
    Friend WithEvents txtTranslateColumn As System.Windows.Forms.TextBox
    Friend WithEvents SourceValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TargetValue As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
