<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClassificationDialog
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
        Me.Guna2HtmlLabel3 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.TXTDEWEYNUMBER = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel2 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.TXTDEWEYNAME = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2HtmlLabel4 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.BTNSAVE = New Guna.UI2.WinForms.Guna2Button()
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Guna2HtmlLabel3
        '
        Me.Guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel3.ForeColor = System.Drawing.Color.Red
        Me.Guna2HtmlLabel3.Location = New System.Drawing.Point(138, 20)
        Me.Guna2HtmlLabel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Guna2HtmlLabel3.Name = "Guna2HtmlLabel3"
        Me.Guna2HtmlLabel3.Size = New System.Drawing.Size(10, 23)
        Me.Guna2HtmlLabel3.TabIndex = 9
        Me.Guna2HtmlLabel3.TabStop = False
        Me.Guna2HtmlLabel3.Text = "*"
        '
        'TXTDEWEYNUMBER
        '
        Me.TXTDEWEYNUMBER.BorderColor = System.Drawing.Color.Gray
        Me.TXTDEWEYNUMBER.BorderRadius = 4
        Me.TXTDEWEYNUMBER.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TXTDEWEYNUMBER.DefaultText = ""
        Me.TXTDEWEYNUMBER.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.TXTDEWEYNUMBER.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TXTDEWEYNUMBER.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TXTDEWEYNUMBER.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TXTDEWEYNUMBER.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TXTDEWEYNUMBER.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.TXTDEWEYNUMBER.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TXTDEWEYNUMBER.Location = New System.Drawing.Point(20, 47)
        Me.TXTDEWEYNUMBER.Margin = New System.Windows.Forms.Padding(0, 0, 0, 16)
        Me.TXTDEWEYNUMBER.MaxLength = 10
        Me.TXTDEWEYNUMBER.Name = "TXTDEWEYNUMBER"
        Me.TXTDEWEYNUMBER.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TXTDEWEYNUMBER.PlaceholderText = "e.g., Novel"
        Me.TXTDEWEYNUMBER.SelectedText = ""
        Me.TXTDEWEYNUMBER.Size = New System.Drawing.Size(306, 48)
        Me.TXTDEWEYNUMBER.TabIndex = 8
        '
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(20, 20)
        Me.Guna2HtmlLabel1.Margin = New System.Windows.Forms.Padding(0, 0, 0, 4)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(118, 23)
        Me.Guna2HtmlLabel1.TabIndex = 7
        Me.Guna2HtmlLabel1.TabStop = False
        Me.Guna2HtmlLabel1.Text = "Dewey Decimal:"
        '
        'Guna2HtmlLabel2
        '
        Me.Guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel2.ForeColor = System.Drawing.Color.Red
        Me.Guna2HtmlLabel2.Location = New System.Drawing.Point(175, 111)
        Me.Guna2HtmlLabel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Guna2HtmlLabel2.Name = "Guna2HtmlLabel2"
        Me.Guna2HtmlLabel2.Size = New System.Drawing.Size(10, 23)
        Me.Guna2HtmlLabel2.TabIndex = 12
        Me.Guna2HtmlLabel2.TabStop = False
        Me.Guna2HtmlLabel2.Text = "*"
        '
        'TXTDEWEYNAME
        '
        Me.TXTDEWEYNAME.BorderColor = System.Drawing.Color.Gray
        Me.TXTDEWEYNAME.BorderRadius = 4
        Me.TXTDEWEYNAME.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TXTDEWEYNAME.DefaultText = ""
        Me.TXTDEWEYNAME.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.TXTDEWEYNAME.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TXTDEWEYNAME.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TXTDEWEYNAME.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TXTDEWEYNAME.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TXTDEWEYNAME.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.TXTDEWEYNAME.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TXTDEWEYNAME.Location = New System.Drawing.Point(20, 138)
        Me.TXTDEWEYNAME.Margin = New System.Windows.Forms.Padding(0, 0, 0, 16)
        Me.TXTDEWEYNAME.MaxLength = 50
        Me.TXTDEWEYNAME.Name = "TXTDEWEYNAME"
        Me.TXTDEWEYNAME.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TXTDEWEYNAME.PlaceholderText = "e.g., Novel"
        Me.TXTDEWEYNAME.SelectedText = ""
        Me.TXTDEWEYNAME.Size = New System.Drawing.Size(306, 48)
        Me.TXTDEWEYNAME.TabIndex = 11
        '
        'Guna2HtmlLabel4
        '
        Me.Guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel4.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel4.Location = New System.Drawing.Point(20, 111)
        Me.Guna2HtmlLabel4.Margin = New System.Windows.Forms.Padding(0, 0, 0, 4)
        Me.Guna2HtmlLabel4.Name = "Guna2HtmlLabel4"
        Me.Guna2HtmlLabel4.Size = New System.Drawing.Size(155, 23)
        Me.Guna2HtmlLabel4.TabIndex = 10
        Me.Guna2HtmlLabel4.TabStop = False
        Me.Guna2HtmlLabel4.Text = "Dewey Classification:"
        '
        'BTNSAVE
        '
        Me.BTNSAVE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTNSAVE.BorderRadius = 4
        Me.BTNSAVE.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.BTNSAVE.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.BTNSAVE.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.BTNSAVE.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.BTNSAVE.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.BTNSAVE.ForeColor = System.Drawing.Color.White
        Me.BTNSAVE.Location = New System.Drawing.Point(198, 205)
        Me.BTNSAVE.Name = "BTNSAVE"
        Me.BTNSAVE.Size = New System.Drawing.Size(128, 40)
        Me.BTNSAVE.TabIndex = 13
        Me.BTNSAVE.Text = "Save"
        '
        'errProvider
        '
        Me.errProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.errProvider.ContainerControl = Me
        '
        'ClassificationDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(353, 258)
        Me.Controls.Add(Me.BTNSAVE)
        Me.Controls.Add(Me.Guna2HtmlLabel2)
        Me.Controls.Add(Me.TXTDEWEYNAME)
        Me.Controls.Add(Me.Guna2HtmlLabel4)
        Me.Controls.Add(Me.Guna2HtmlLabel3)
        Me.Controls.Add(Me.TXTDEWEYNUMBER)
        Me.Controls.Add(Me.Guna2HtmlLabel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ClassificationDialog"
        Me.Padding = New System.Windows.Forms.Padding(20, 20, 20, 10)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Classification Form"
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Guna2HtmlLabel3 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents TXTDEWEYNUMBER As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel2 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents TXTDEWEYNAME As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2HtmlLabel4 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents BTNSAVE As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents errProvider As ErrorProvider
End Class
