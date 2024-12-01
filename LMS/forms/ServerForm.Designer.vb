<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ServerForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.TXTSERVER = New Guna.UI2.WinForms.Guna2TextBox()
        Me.TXTUSERNAME = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2HtmlLabel2 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.TXTPASSWORD = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2HtmlLabel3 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.BtnConnect = New Guna.UI2.WinForms.Guna2Button()
        Me.CHKREMEMBER = New Guna.UI2.WinForms.Guna2CheckBox()
        Me.SuspendLayout()
        '
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(36, 26)
        Me.Guna2HtmlLabel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(61, 23)
        Me.Guna2HtmlLabel1.TabIndex = 0
        Me.Guna2HtmlLabel1.Text = "SERVER:"
        '
        'TXTSERVER
        '
        Me.TXTSERVER.BorderRadius = 4
        Me.TXTSERVER.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TXTSERVER.DefaultText = ""
        Me.TXTSERVER.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.TXTSERVER.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TXTSERVER.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TXTSERVER.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TXTSERVER.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TXTSERVER.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSERVER.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TXTSERVER.Location = New System.Drawing.Point(36, 49)
        Me.TXTSERVER.Margin = New System.Windows.Forms.Padding(0)
        Me.TXTSERVER.MaxLength = 16
        Me.TXTSERVER.Name = "TXTSERVER"
        Me.TXTSERVER.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TXTSERVER.PlaceholderText = "e.g. 127.0.0.1"
        Me.TXTSERVER.SelectedText = ""
        Me.TXTSERVER.Size = New System.Drawing.Size(306, 40)
        Me.TXTSERVER.TabIndex = 1
        '
        'TXTUSERNAME
        '
        Me.TXTUSERNAME.BorderRadius = 4
        Me.TXTUSERNAME.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TXTUSERNAME.DefaultText = ""
        Me.TXTUSERNAME.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.TXTUSERNAME.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TXTUSERNAME.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TXTUSERNAME.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TXTUSERNAME.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TXTUSERNAME.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.TXTUSERNAME.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TXTUSERNAME.Location = New System.Drawing.Point(36, 129)
        Me.TXTUSERNAME.Margin = New System.Windows.Forms.Padding(0)
        Me.TXTUSERNAME.MaxLength = 50
        Me.TXTUSERNAME.Name = "TXTUSERNAME"
        Me.TXTUSERNAME.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TXTUSERNAME.PlaceholderText = "e.g. username"
        Me.TXTUSERNAME.SelectedText = ""
        Me.TXTUSERNAME.Size = New System.Drawing.Size(306, 40)
        Me.TXTUSERNAME.TabIndex = 3
        '
        'Guna2HtmlLabel2
        '
        Me.Guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel2.Location = New System.Drawing.Point(36, 106)
        Me.Guna2HtmlLabel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Guna2HtmlLabel2.Name = "Guna2HtmlLabel2"
        Me.Guna2HtmlLabel2.Size = New System.Drawing.Size(88, 23)
        Me.Guna2HtmlLabel2.TabIndex = 2
        Me.Guna2HtmlLabel2.Text = "USERNAME:"
        '
        'TXTPASSWORD
        '
        Me.TXTPASSWORD.BorderRadius = 4
        Me.TXTPASSWORD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TXTPASSWORD.DefaultText = ""
        Me.TXTPASSWORD.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.TXTPASSWORD.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TXTPASSWORD.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TXTPASSWORD.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TXTPASSWORD.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TXTPASSWORD.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.TXTPASSWORD.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TXTPASSWORD.IconRight = Global.LMS.My.Resources.Resources.password_disable
        Me.TXTPASSWORD.IconRightOffset = New System.Drawing.Point(8, 0)
        Me.TXTPASSWORD.Location = New System.Drawing.Point(36, 209)
        Me.TXTPASSWORD.Margin = New System.Windows.Forms.Padding(0)
        Me.TXTPASSWORD.MaxLength = 50
        Me.TXTPASSWORD.Name = "TXTPASSWORD"
        Me.TXTPASSWORD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.TXTPASSWORD.PlaceholderText = "e.g. password"
        Me.TXTPASSWORD.SelectedText = ""
        Me.TXTPASSWORD.Size = New System.Drawing.Size(306, 40)
        Me.TXTPASSWORD.TabIndex = 5
        '
        'Guna2HtmlLabel3
        '
        Me.Guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel3.Location = New System.Drawing.Point(36, 186)
        Me.Guna2HtmlLabel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Guna2HtmlLabel3.Name = "Guna2HtmlLabel3"
        Me.Guna2HtmlLabel3.Size = New System.Drawing.Size(91, 23)
        Me.Guna2HtmlLabel3.TabIndex = 4
        Me.Guna2HtmlLabel3.Text = "PASSWORD:"
        '
        'BtnConnect
        '
        Me.BtnConnect.BorderRadius = 8
        Me.BtnConnect.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.BtnConnect.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.BtnConnect.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.BtnConnect.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.BtnConnect.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.BtnConnect.ForeColor = System.Drawing.Color.White
        Me.BtnConnect.Location = New System.Drawing.Point(36, 283)
        Me.BtnConnect.Name = "BtnConnect"
        Me.BtnConnect.Size = New System.Drawing.Size(306, 45)
        Me.BtnConnect.TabIndex = 6
        Me.BtnConnect.Text = "CONNECT"
        '
        'CHKREMEMBER
        '
        Me.CHKREMEMBER.AutoSize = True
        Me.CHKREMEMBER.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CHKREMEMBER.CheckedState.BorderRadius = 0
        Me.CHKREMEMBER.CheckedState.BorderThickness = 0
        Me.CHKREMEMBER.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CHKREMEMBER.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKREMEMBER.Location = New System.Drawing.Point(203, 252)
        Me.CHKREMEMBER.Name = "CHKREMEMBER"
        Me.CHKREMEMBER.Size = New System.Drawing.Size(143, 25)
        Me.CHKREMEMBER.TabIndex = 7
        Me.CHKREMEMBER.Text = "REMEMBER ME?"
        Me.CHKREMEMBER.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.CHKREMEMBER.UncheckedState.BorderRadius = 0
        Me.CHKREMEMBER.UncheckedState.BorderThickness = 0
        Me.CHKREMEMBER.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        '
        'ServerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 30.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(379, 355)
        Me.Controls.Add(Me.CHKREMEMBER)
        Me.Controls.Add(Me.BtnConnect)
        Me.Controls.Add(Me.TXTPASSWORD)
        Me.Controls.Add(Me.Guna2HtmlLabel3)
        Me.Controls.Add(Me.TXTUSERNAME)
        Me.Controls.Add(Me.Guna2HtmlLabel2)
        Me.Controls.Add(Me.TXTSERVER)
        Me.Controls.Add(Me.Guna2HtmlLabel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(395, 394)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(395, 394)
        Me.Name = "ServerForm"
        Me.ShowIcon = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SERVER CONFIGURATION"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents TXTSERVER As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents TXTUSERNAME As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2HtmlLabel2 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents TXTPASSWORD As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2HtmlLabel3 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents BtnConnect As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents CHKREMEMBER As Guna.UI2.WinForms.Guna2CheckBox
End Class
