<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlExcel = New System.Windows.Forms.Panel()
        Me.chkOverrideValues = New System.Windows.Forms.CheckBox()
        Me.btnEditDeal = New System.Windows.Forms.Button()
        Me.cmbDeal = New System.Windows.Forms.ComboBox()
        Me.lblDeal = New System.Windows.Forms.Label()
        Me.btnExcelOpen = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbClient = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnExcelBrowse = New System.Windows.Forms.Button()
        Me.txtExcelPath = New System.Windows.Forms.TextBox()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.InstructionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.btnXMLGenerate = New System.Windows.Forms.ToolStripButton()
        Me.cmbDestinationField = New System.Windows.Forms.ToolStripComboBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.tabExcelSheets = New System.Windows.Forms.TabControl()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.UseThisSectionToLoacteAnExcelFileThatYouWouldLikeToTranslateToAnACESImportFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.btnTranslateValidate = New System.Windows.Forms.ToolStripSplitButton()
        Me.btnEditTranslations = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnEditReplacements = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnEditValidations = New System.Windows.Forms.ToolStripMenuItem()
        Me.tslTransalationAlert = New System.Windows.Forms.ToolStripLabel()
        Me.tslValidationAlert = New System.Windows.Forms.ToolStripLabel()
        Me.dgXMLMapping = New System.Windows.Forms.DataGridView()
        Me.ExcelColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.XMLColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblRequiredAspects = New System.Windows.Forms.Label()
        Me.MenuStrip3 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.btnXMLSave = New System.Windows.Forms.ToolStripButton()
        Me.tt = New System.Windows.Forms.ToolTip(Me.components)
        Me.ofd = New System.Windows.Forms.OpenFileDialog()
        Me.lblStatusMain = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ss = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pbMain = New System.Windows.Forms.ToolStripProgressBar()
        Me.pnlExcel.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgXMLMapping, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.MenuStrip3.SuspendLayout()
        Me.ss.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlExcel
        '
        Me.pnlExcel.Controls.Add(Me.chkOverrideValues)
        Me.pnlExcel.Controls.Add(Me.btnEditDeal)
        Me.pnlExcel.Controls.Add(Me.cmbDeal)
        Me.pnlExcel.Controls.Add(Me.lblDeal)
        Me.pnlExcel.Controls.Add(Me.btnExcelOpen)
        Me.pnlExcel.Controls.Add(Me.Label2)
        Me.pnlExcel.Controls.Add(Me.cmbClient)
        Me.pnlExcel.Controls.Add(Me.Label1)
        Me.pnlExcel.Controls.Add(Me.btnExcelBrowse)
        Me.pnlExcel.Controls.Add(Me.txtExcelPath)
        Me.pnlExcel.Controls.Add(Me.MenuStrip2)
        Me.pnlExcel.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlExcel.Location = New System.Drawing.Point(0, 0)
        Me.pnlExcel.Name = "pnlExcel"
        Me.pnlExcel.Size = New System.Drawing.Size(1008, 87)
        Me.pnlExcel.TabIndex = 2
        '
        'chkOverrideValues
        '
        Me.chkOverrideValues.AutoSize = True
        Me.chkOverrideValues.Location = New System.Drawing.Point(789, 34)
        Me.chkOverrideValues.Name = "chkOverrideValues"
        Me.chkOverrideValues.Size = New System.Drawing.Size(207, 17)
        Me.chkOverrideValues.TabIndex = 3
        Me.chkOverrideValues.TabStop = False
        Me.chkOverrideValues.Text = "Allow import to override existing values"
        Me.chkOverrideValues.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.chkOverrideValues.UseVisualStyleBackColor = True
        '
        'btnEditDeal
        '
        Me.btnEditDeal.Enabled = False
        Me.btnEditDeal.Location = New System.Drawing.Point(639, 32)
        Me.btnEditDeal.Name = "btnEditDeal"
        Me.btnEditDeal.Size = New System.Drawing.Size(90, 23)
        Me.btnEditDeal.TabIndex = 2
        Me.btnEditDeal.TabStop = False
        Me.btnEditDeal.Text = "Edit Selected"
        Me.btnEditDeal.UseVisualStyleBackColor = True
        '
        'cmbDeal
        '
        Me.cmbDeal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbDeal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbDeal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbDeal.Enabled = False
        Me.cmbDeal.FormattingEnabled = True
        Me.cmbDeal.Location = New System.Drawing.Point(399, 33)
        Me.cmbDeal.Name = "cmbDeal"
        Me.cmbDeal.Size = New System.Drawing.Size(233, 21)
        Me.cmbDeal.TabIndex = 1
        '
        'lblDeal
        '
        Me.lblDeal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDeal.AutoSize = True
        Me.lblDeal.Enabled = False
        Me.lblDeal.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblDeal.Location = New System.Drawing.Point(340, 36)
        Me.lblDeal.Name = "lblDeal"
        Me.lblDeal.Size = New System.Drawing.Size(29, 13)
        Me.lblDeal.TabIndex = 9
        Me.lblDeal.Text = "Deal"
        '
        'btnExcelOpen
        '
        Me.btnExcelOpen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExcelOpen.Enabled = False
        Me.btnExcelOpen.Image = CType(resources.GetObject("btnExcelOpen.Image"), System.Drawing.Image)
        Me.btnExcelOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcelOpen.Location = New System.Drawing.Point(938, 57)
        Me.btnExcelOpen.Name = "btnExcelOpen"
        Me.btnExcelOpen.Size = New System.Drawing.Size(67, 23)
        Me.btnExcelOpen.TabIndex = 6
        Me.btnExcelOpen.TabStop = False
        Me.btnExcelOpen.Text = "Open..."
        Me.btnExcelOpen.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcelOpen.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Client"
        '
        'cmbClient
        '
        Me.cmbClient.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbClient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbClient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbClient.FormattingEnabled = True
        Me.cmbClient.Location = New System.Drawing.Point(70, 32)
        Me.cmbClient.Name = "cmbClient"
        Me.cmbClient.Size = New System.Drawing.Size(233, 21)
        Me.cmbClient.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Excel File"
        '
        'btnExcelBrowse
        '
        Me.btnExcelBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExcelBrowse.Enabled = False
        Me.btnExcelBrowse.Image = CType(resources.GetObject("btnExcelBrowse.Image"), System.Drawing.Image)
        Me.btnExcelBrowse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcelBrowse.Location = New System.Drawing.Point(863, 57)
        Me.btnExcelBrowse.Name = "btnExcelBrowse"
        Me.btnExcelBrowse.Size = New System.Drawing.Size(69, 23)
        Me.btnExcelBrowse.TabIndex = 5
        Me.btnExcelBrowse.Text = "Find..."
        Me.btnExcelBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcelBrowse.UseVisualStyleBackColor = True
        '
        'txtExcelPath
        '
        Me.txtExcelPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtExcelPath.Location = New System.Drawing.Point(70, 59)
        Me.txtExcelPath.Name = "txtExcelPath"
        Me.txtExcelPath.ReadOnly = True
        Me.txtExcelPath.Size = New System.Drawing.Size(787, 20)
        Me.txtExcelPath.TabIndex = 4
        Me.txtExcelPath.TabStop = False
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripLabel4, Me.btnXMLGenerate, Me.cmbDestinationField})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(1008, 27)
        Me.MenuStrip2.TabIndex = 5
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InstructionsToolStripMenuItem})
        Me.ToolStripMenuItem1.Image = CType(resources.GetObject("ToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(28, 23)
        Me.ToolStripMenuItem1.ToolTipText = "Click here to get quick help on this section."
        '
        'InstructionsToolStripMenuItem
        '
        Me.InstructionsToolStripMenuItem.Name = "InstructionsToolStripMenuItem"
        Me.InstructionsToolStripMenuItem.Size = New System.Drawing.Size(465, 22)
        Me.InstructionsToolStripMenuItem.Text = "Use this section to locate an Excel file that you will import its data into LES."
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.AutoSize = False
        Me.ToolStripLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(300, 20)
        Me.ToolStripLabel4.Text = "Choose Client && Excel File"
        Me.ToolStripLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnXMLGenerate
        '
        Me.btnXMLGenerate.Enabled = False
        Me.btnXMLGenerate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnXMLGenerate.ForeColor = System.Drawing.Color.Green
        Me.btnXMLGenerate.Image = CType(resources.GetObject("btnXMLGenerate.Image"), System.Drawing.Image)
        Me.btnXMLGenerate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnXMLGenerate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnXMLGenerate.Name = "btnXMLGenerate"
        Me.btnXMLGenerate.Size = New System.Drawing.Size(137, 20)
        Me.btnXMLGenerate.Tag = "f"
        Me.btnXMLGenerate.Text = "Import Loan Data"
        '
        'cmbDestinationField
        '
        Me.cmbDestinationField.Items.AddRange(New Object() {"Original Values", "Actual Values"})
        Me.cmbDestinationField.MaxDropDownItems = 2
        Me.cmbDestinationField.Name = "cmbDestinationField"
        Me.cmbDestinationField.Size = New System.Drawing.Size(121, 23)
        Me.cmbDestinationField.Visible = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Enabled = False
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 86)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.tabExcelSheets)
        Me.SplitContainer1.Panel1.Controls.Add(Me.MenuStrip1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgXMLMapping)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.MenuStrip3)
        Me.SplitContainer1.Size = New System.Drawing.Size(1008, 633)
        Me.SplitContainer1.SplitterDistance = 648
        Me.SplitContainer1.TabIndex = 3
        '
        'tabExcelSheets
        '
        Me.tabExcelSheets.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabExcelSheets.Location = New System.Drawing.Point(0, 27)
        Me.tabExcelSheets.Name = "tabExcelSheets"
        Me.tabExcelSheets.SelectedIndex = 0
        Me.tabExcelSheets.Size = New System.Drawing.Size(648, 606)
        Me.tabExcelSheets.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2, Me.ToolStripLabel3, Me.btnTranslateValidate, Me.tslTransalationAlert, Me.tslValidationAlert})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(648, 27)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripMenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UseThisSectionToLoacteAnExcelFileThatYouWouldLikeToTranslateToAnACESImportFileToolStripMenuItem})
        Me.ToolStripMenuItem2.Image = CType(resources.GetObject("ToolStripMenuItem2.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(28, 23)
        Me.ToolStripMenuItem2.Text = "Help"
        Me.ToolStripMenuItem2.ToolTipText = "Click here to get quick help on this section."
        '
        'UseThisSectionToLoacteAnExcelFileThatYouWouldLikeToTranslateToAnACESImportFileToolStripMenuItem
        '
        Me.UseThisSectionToLoacteAnExcelFileThatYouWouldLikeToTranslateToAnACESImportFileToolStripMenuItem.Name = "UseThisSectionToLoacteAnExcelFileThatYouWouldLikeToTranslateToAnACESImportFileToo" & _
    "lStripMenuItem"
        Me.UseThisSectionToLoacteAnExcelFileThatYouWouldLikeToTranslateToAnACESImportFileToolStripMenuItem.Size = New System.Drawing.Size(366, 22)
        Me.UseThisSectionToLoacteAnExcelFileThatYouWouldLikeToTranslateToAnACESImportFileToolStripMenuItem.Text = "Use this section to preview data that is in your Excel file."
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(148, 20)
        Me.ToolStripLabel3.Text = "Review Excel Data"
        Me.ToolStripLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnTranslateValidate
        '
        Me.btnTranslateValidate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnTranslateValidate.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnEditTranslations, Me.btnEditReplacements, Me.btnEditValidations})
        Me.btnTranslateValidate.Image = CType(resources.GetObject("btnTranslateValidate.Image"), System.Drawing.Image)
        Me.btnTranslateValidate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnTranslateValidate.Name = "btnTranslateValidate"
        Me.btnTranslateValidate.Size = New System.Drawing.Size(144, 20)
        Me.btnTranslateValidate.Text = "Translate && Replace"
        '
        'btnEditTranslations
        '
        Me.btnEditTranslations.Name = "btnEditTranslations"
        Me.btnEditTranslations.Size = New System.Drawing.Size(191, 22)
        Me.btnEditTranslations.Text = "Edit Translate Values..."
        '
        'btnEditReplacements
        '
        Me.btnEditReplacements.Name = "btnEditReplacements"
        Me.btnEditReplacements.Size = New System.Drawing.Size(191, 22)
        Me.btnEditReplacements.Text = "Edit Replace Values..."
        '
        'btnEditValidations
        '
        Me.btnEditValidations.Name = "btnEditValidations"
        Me.btnEditValidations.Size = New System.Drawing.Size(191, 22)
        Me.btnEditValidations.Text = "Edit Validate Values..."
        Me.btnEditValidations.Visible = False
        '
        'tslTransalationAlert
        '
        Me.tslTransalationAlert.AutoSize = False
        Me.tslTransalationAlert.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tslTransalationAlert.ForeColor = System.Drawing.Color.Tomato
        Me.tslTransalationAlert.Name = "tslTransalationAlert"
        Me.tslTransalationAlert.Size = New System.Drawing.Size(150, 20)
        Me.tslTransalationAlert.Text = "Invalid Translation"
        Me.tslTransalationAlert.ToolTipText = "This is a data warning.  You should review the spreadsheet for data that did not " & _
    "translate."
        Me.tslTransalationAlert.Visible = False
        '
        'tslValidationAlert
        '
        Me.tslValidationAlert.AccessibleDescription = ""
        Me.tslValidationAlert.AutoSize = False
        Me.tslValidationAlert.BackColor = System.Drawing.SystemColors.Control
        Me.tslValidationAlert.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tslValidationAlert.ForeColor = System.Drawing.Color.Red
        Me.tslValidationAlert.Name = "tslValidationAlert"
        Me.tslValidationAlert.Size = New System.Drawing.Size(150, 20)
        Me.tslValidationAlert.Text = "Invalid Data"
        Me.tslValidationAlert.ToolTipText = "This is data warning.  You should review the spreadsheet for data that is conside" & _
    "red invalid."
        Me.tslValidationAlert.Visible = False
        '
        'dgXMLMapping
        '
        Me.dgXMLMapping.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgXMLMapping.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgXMLMapping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgXMLMapping.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ExcelColumn, Me.XMLColumn})
        Me.dgXMLMapping.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgXMLMapping.Location = New System.Drawing.Point(0, 46)
        Me.dgXMLMapping.MultiSelect = False
        Me.dgXMLMapping.Name = "dgXMLMapping"
        Me.dgXMLMapping.RowHeadersVisible = False
        Me.dgXMLMapping.Size = New System.Drawing.Size(356, 587)
        Me.dgXMLMapping.TabIndex = 0
        '
        'ExcelColumn
        '
        Me.ExcelColumn.HeaderText = "Excel Column"
        Me.ExcelColumn.Name = "ExcelColumn"
        Me.ExcelColumn.ReadOnly = True
        Me.ExcelColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.ExcelColumn.Width = 96
        '
        'XMLColumn
        '
        Me.XMLColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.XMLColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.XMLColumn.HeaderText = "LES Column"
        Me.XMLColumn.MaxDropDownItems = 20
        Me.XMLColumn.Name = "XMLColumn"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblRequiredAspects)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 26)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(356, 20)
        Me.Panel1.TabIndex = 3
        '
        'lblRequiredAspects
        '
        Me.lblRequiredAspects.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblRequiredAspects.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRequiredAspects.ForeColor = System.Drawing.Color.White
        Me.lblRequiredAspects.Location = New System.Drawing.Point(0, 0)
        Me.lblRequiredAspects.Name = "lblRequiredAspects"
        Me.lblRequiredAspects.Size = New System.Drawing.Size(356, 20)
        Me.lblRequiredAspects.TabIndex = 0
        Me.lblRequiredAspects.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MenuStrip3
        '
        Me.MenuStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem3, Me.ToolStripLabel2, Me.btnXMLSave})
        Me.MenuStrip3.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip3.Name = "MenuStrip3"
        Me.MenuStrip3.Size = New System.Drawing.Size(356, 26)
        Me.MenuStrip3.TabIndex = 0
        Me.MenuStrip3.Text = "MenuStrip3"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripMenuItem3.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem4})
        Me.ToolStripMenuItem3.Image = CType(resources.GetObject("ToolStripMenuItem3.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(28, 22)
        Me.ToolStripMenuItem3.Text = "Help"
        Me.ToolStripMenuItem3.ToolTipText = "Click here to get quick help on this section."
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(443, 22)
        Me.ToolStripMenuItem4.Text = "Use this section to map all columns from the Excel spreadsheet to LES."
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(142, 19)
        Me.ToolStripLabel2.Text = "Map Excel to LES"
        '
        'btnXMLSave
        '
        Me.btnXMLSave.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnXMLSave.Image = CType(resources.GetObject("btnXMLSave.Image"), System.Drawing.Image)
        Me.btnXMLSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnXMLSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnXMLSave.Name = "btnXMLSave"
        Me.btnXMLSave.Size = New System.Drawing.Size(146, 19)
        Me.btnXMLSave.Text = "Save Column Mapping"
        '
        'ofd
        '
        Me.ofd.DefaultExt = "xls,csv"
        Me.ofd.FileName = "OpenFileDialog1"
        Me.ofd.Filter = "Excel Workbook|*.xlsx"
        '
        'lblStatusMain
        '
        Me.lblStatusMain.Name = "lblStatusMain"
        Me.lblStatusMain.Size = New System.Drawing.Size(908, 17)
        Me.lblStatusMain.Spring = True
        Me.lblStatusMain.Text = "Ready"
        Me.lblStatusMain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ss
        '
        Me.ss.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.pbMain})
        Me.ss.Location = New System.Drawing.Point(0, 720)
        Me.ss.Name = "ss"
        Me.ss.Size = New System.Drawing.Size(1008, 22)
        Me.ss.TabIndex = 4
        Me.ss.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(993, 17)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.Text = "Ready"
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pbMain
        '
        Me.pbMain.Name = "pbMain"
        Me.pbMain.Size = New System.Drawing.Size(100, 16)
        Me.pbMain.Step = 1
        Me.pbMain.Visible = False
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 742)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ss)
        Me.Controls.Add(Me.pnlExcel)
        Me.Name = "Main"
        Me.ShowIcon = False
        Me.Text = "LES Data Importer"
        Me.pnlExcel.ResumeLayout(False)
        Me.pnlExcel.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgXMLMapping, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.MenuStrip3.ResumeLayout(False)
        Me.MenuStrip3.PerformLayout()
        Me.ss.ResumeLayout(False)
        Me.ss.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlExcel As System.Windows.Forms.Panel
    Friend WithEvents btnExcelOpen As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbClient As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnExcelBrowse As System.Windows.Forms.Button
    Friend WithEvents txtExcelPath As System.Windows.Forms.TextBox
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InstructionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents btnXMLGenerate As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents tabExcelSheets As System.Windows.Forms.TabControl
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UseThisSectionToLoacteAnExcelFileThatYouWouldLikeToTranslateToAnACESImportFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents btnTranslateValidate As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents btnEditTranslations As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnEditValidations As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tslTransalationAlert As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tslValidationAlert As System.Windows.Forms.ToolStripLabel
    Friend WithEvents dgXMLMapping As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblRequiredAspects As System.Windows.Forms.Label
    Friend WithEvents MenuStrip3 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents btnXMLSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tt As System.Windows.Forms.ToolTip
    Friend WithEvents ofd As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblStatusMain As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ss As System.Windows.Forms.StatusStrip
    Friend WithEvents pbMain As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ExcelColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents XMLColumn As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents cmbDeal As System.Windows.Forms.ComboBox
    Friend WithEvents lblDeal As System.Windows.Forms.Label
    Friend WithEvents btnEditDeal As System.Windows.Forms.Button
    Friend WithEvents cmbDestinationField As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents btnEditReplacements As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkOverrideValues As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel

End Class
