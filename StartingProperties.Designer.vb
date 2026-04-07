<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StartingProperties
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
        Me.radImportOrigNormal = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.radImportOrigMERS = New System.Windows.Forms.RadioButton()
        Me.radImportActualMERS = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(359, 347)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(76, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Continue"
        '
        'radImportOrigNormal
        '
        Me.radImportOrigNormal.AutoSize = True
        Me.radImportOrigNormal.Checked = True
        Me.radImportOrigNormal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radImportOrigNormal.Location = New System.Drawing.Point(30, 71)
        Me.radImportOrigNormal.Name = "radImportOrigNormal"
        Me.radImportOrigNormal.Size = New System.Drawing.Size(148, 17)
        Me.radImportOrigNormal.TabIndex = 1
        Me.radImportOrigNormal.TabStop = True
        Me.radImportOrigNormal.Text = "Import Into Original Values"
        Me.radImportOrigNormal.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(489, 37)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Please choose from one of the following settings.  These settings will determine " & _
            "how your import will be loaded into the LES application."
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(50, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(452, 29)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "This option will import the loans and run conditions in a normal format into Orig" & _
            "inal Values."
        '
        'radImportOrigMERS
        '
        Me.radImportOrigMERS.AutoSize = True
        Me.radImportOrigMERS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radImportOrigMERS.Location = New System.Drawing.Point(30, 158)
        Me.radImportOrigMERS.Name = "radImportOrigMERS"
        Me.radImportOrigMERS.Size = New System.Drawing.Size(147, 17)
        Me.radImportOrigMERS.TabIndex = 4
        Me.radImportOrigMERS.TabStop = True
        Me.radImportOrigMERS.Text = "Import into Original Values"
        Me.radImportOrigMERS.UseVisualStyleBackColor = True
        '
        'radImportActualMERS
        '
        Me.radImportActualMERS.AutoSize = True
        Me.radImportActualMERS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radImportActualMERS.Location = New System.Drawing.Point(30, 213)
        Me.radImportActualMERS.Name = "radImportActualMERS"
        Me.radImportActualMERS.Size = New System.Drawing.Size(134, 17)
        Me.radImportActualMERS.TabIndex = 5
        Me.radImportActualMERS.TabStop = True
        Me.radImportActualMERS.Text = "Import to Actual Values"
        Me.radImportActualMERS.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(407, 20)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "MERS Scrub Imports"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(407, 18)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Normal Imports"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(50, 233)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(452, 37)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "This option will import the loans in a normal format into the Actual Values, but " & _
            "conditions will be run using a specific MERS comparison routine." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(50, 178)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(452, 37)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "This option will import the loans in a normal format into the Original Values, bu" & _
            "t conditions will be run using a specific MERS comparison routine." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'StartingProperties
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(517, 388)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.radImportActualMERS)
        Me.Controls.Add(Me.radImportOrigMERS)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.radImportOrigNormal)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "StartingProperties"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import Settings"
        Me.TopMost = True
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents radImportOrigNormal As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents radImportOrigMERS As System.Windows.Forms.RadioButton
    Friend WithEvents radImportActualMERS As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label

End Class
