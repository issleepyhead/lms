<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FacultyDialog
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
        Me.components = New System.ComponentModel.Container()
        Me.BTNSAVE = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2HtmlLabel13 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.TXTEMAIL = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2HtmlLabel15 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.TXTPHONE = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2HtmlLabel14 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.CMBGENDER = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Guna2HtmlLabel11 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel12 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.CMBDEPARTMENT = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Guna2HtmlLabel9 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel10 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.TXTADDRESS = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2HtmlLabel8 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel5 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.TXTFULLNAME = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2HtmlLabel6 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BTNSAVE
        '
        Me.BTNSAVE.BorderRadius = 8
        Me.BTNSAVE.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.BTNSAVE.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.BTNSAVE.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.BTNSAVE.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.BTNSAVE.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.BTNSAVE.ForeColor = System.Drawing.Color.White
        Me.BTNSAVE.Location = New System.Drawing.Point(548, 302)
        Me.BTNSAVE.Name = "BTNSAVE"
        Me.BTNSAVE.Size = New System.Drawing.Size(128, 48)
        Me.BTNSAVE.TabIndex = 87
        Me.BTNSAVE.Text = "Save"
        '
        'Guna2HtmlLabel13
        '
        Me.Guna2HtmlLabel13.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel13.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel13.ForeColor = System.Drawing.Color.Red
        Me.Guna2HtmlLabel13.Location = New System.Drawing.Point(82, 117)
        Me.Guna2HtmlLabel13.Margin = New System.Windows.Forms.Padding(0)
        Me.Guna2HtmlLabel13.Name = "Guna2HtmlLabel13"
        Me.Guna2HtmlLabel13.Size = New System.Drawing.Size(10, 23)
        Me.Guna2HtmlLabel13.TabIndex = 86
        Me.Guna2HtmlLabel13.Text = "*"
        '
        'TXTEMAIL
        '
        Me.TXTEMAIL.BorderRadius = 4
        Me.TXTEMAIL.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TXTEMAIL.DefaultText = ""
        Me.TXTEMAIL.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.TXTEMAIL.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TXTEMAIL.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TXTEMAIL.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TXTEMAIL.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TXTEMAIL.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTEMAIL.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TXTEMAIL.Location = New System.Drawing.Point(37, 145)
        Me.TXTEMAIL.Margin = New System.Windows.Forms.Padding(0)
        Me.TXTEMAIL.MaxLength = 45
        Me.TXTEMAIL.Name = "TXTEMAIL"
        Me.TXTEMAIL.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TXTEMAIL.PlaceholderText = "e.g., Junior High School"
        Me.TXTEMAIL.SelectedText = ""
        Me.TXTEMAIL.Size = New System.Drawing.Size(306, 48)
        Me.TXTEMAIL.TabIndex = 85
        '
        'Guna2HtmlLabel15
        '
        Me.Guna2HtmlLabel15.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel15.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel15.Location = New System.Drawing.Point(37, 118)
        Me.Guna2HtmlLabel15.Margin = New System.Windows.Forms.Padding(0)
        Me.Guna2HtmlLabel15.Name = "Guna2HtmlLabel15"
        Me.Guna2HtmlLabel15.Size = New System.Drawing.Size(45, 23)
        Me.Guna2HtmlLabel15.TabIndex = 84
        Me.Guna2HtmlLabel15.Text = "Email:"
        '
        'TXTPHONE
        '
        Me.TXTPHONE.BorderRadius = 4
        Me.TXTPHONE.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TXTPHONE.DefaultText = ""
        Me.TXTPHONE.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.TXTPHONE.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TXTPHONE.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TXTPHONE.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TXTPHONE.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TXTPHONE.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPHONE.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TXTPHONE.Location = New System.Drawing.Point(370, 142)
        Me.TXTPHONE.Margin = New System.Windows.Forms.Padding(0)
        Me.TXTPHONE.MaxLength = 45
        Me.TXTPHONE.Name = "TXTPHONE"
        Me.TXTPHONE.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TXTPHONE.PlaceholderText = "e.g., Junior High School"
        Me.TXTPHONE.SelectedText = ""
        Me.TXTPHONE.Size = New System.Drawing.Size(306, 48)
        Me.TXTPHONE.TabIndex = 83
        '
        'Guna2HtmlLabel14
        '
        Me.Guna2HtmlLabel14.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel14.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel14.Location = New System.Drawing.Point(370, 116)
        Me.Guna2HtmlLabel14.Margin = New System.Windows.Forms.Padding(0)
        Me.Guna2HtmlLabel14.Name = "Guna2HtmlLabel14"
        Me.Guna2HtmlLabel14.Size = New System.Drawing.Size(130, 23)
        Me.Guna2HtmlLabel14.TabIndex = 82
        Me.Guna2HtmlLabel14.Text = "Phone (Optional):"
        '
        'CMBGENDER
        '
        Me.CMBGENDER.BackColor = System.Drawing.Color.Transparent
        Me.CMBGENDER.BorderRadius = 4
        Me.CMBGENDER.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CMBGENDER.DropDownHeight = 280
        Me.CMBGENDER.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBGENDER.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CMBGENDER.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CMBGENDER.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.CMBGENDER.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.CMBGENDER.IntegralHeight = False
        Me.CMBGENDER.ItemHeight = 40
        Me.CMBGENDER.Items.AddRange(New Object() {"Male", "Female"})
        Me.CMBGENDER.Location = New System.Drawing.Point(37, 236)
        Me.CMBGENDER.MaxDropDownItems = 6
        Me.CMBGENDER.Name = "CMBGENDER"
        Me.CMBGENDER.Size = New System.Drawing.Size(306, 46)
        Me.CMBGENDER.StartIndex = 0
        Me.CMBGENDER.TabIndex = 81
        '
        'Guna2HtmlLabel11
        '
        Me.Guna2HtmlLabel11.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel11.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel11.ForeColor = System.Drawing.Color.Red
        Me.Guna2HtmlLabel11.Location = New System.Drawing.Point(100, 208)
        Me.Guna2HtmlLabel11.Margin = New System.Windows.Forms.Padding(0)
        Me.Guna2HtmlLabel11.Name = "Guna2HtmlLabel11"
        Me.Guna2HtmlLabel11.Size = New System.Drawing.Size(10, 23)
        Me.Guna2HtmlLabel11.TabIndex = 80
        Me.Guna2HtmlLabel11.Text = "*"
        '
        'Guna2HtmlLabel12
        '
        Me.Guna2HtmlLabel12.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel12.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel12.Location = New System.Drawing.Point(37, 210)
        Me.Guna2HtmlLabel12.Margin = New System.Windows.Forms.Padding(0)
        Me.Guna2HtmlLabel12.Name = "Guna2HtmlLabel12"
        Me.Guna2HtmlLabel12.Size = New System.Drawing.Size(61, 23)
        Me.Guna2HtmlLabel12.TabIndex = 79
        Me.Guna2HtmlLabel12.Text = "Gender:"
        '
        'CMBDEPARTMENT
        '
        Me.CMBDEPARTMENT.BackColor = System.Drawing.Color.Transparent
        Me.CMBDEPARTMENT.BorderRadius = 4
        Me.CMBDEPARTMENT.DisplayMember = "year_level"
        Me.CMBDEPARTMENT.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CMBDEPARTMENT.DropDownHeight = 280
        Me.CMBDEPARTMENT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBDEPARTMENT.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CMBDEPARTMENT.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CMBDEPARTMENT.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.CMBDEPARTMENT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.CMBDEPARTMENT.IntegralHeight = False
        Me.CMBDEPARTMENT.ItemHeight = 40
        Me.CMBDEPARTMENT.Location = New System.Drawing.Point(370, 52)
        Me.CMBDEPARTMENT.MaxDropDownItems = 6
        Me.CMBDEPARTMENT.Name = "CMBDEPARTMENT"
        Me.CMBDEPARTMENT.Size = New System.Drawing.Size(306, 46)
        Me.CMBDEPARTMENT.TabIndex = 78
        Me.CMBDEPARTMENT.ValueMember = "id"
        '
        'Guna2HtmlLabel9
        '
        Me.Guna2HtmlLabel9.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel9.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel9.ForeColor = System.Drawing.Color.Red
        Me.Guna2HtmlLabel9.Location = New System.Drawing.Point(467, 26)
        Me.Guna2HtmlLabel9.Margin = New System.Windows.Forms.Padding(0)
        Me.Guna2HtmlLabel9.Name = "Guna2HtmlLabel9"
        Me.Guna2HtmlLabel9.Size = New System.Drawing.Size(10, 23)
        Me.Guna2HtmlLabel9.TabIndex = 77
        Me.Guna2HtmlLabel9.Text = "*"
        '
        'Guna2HtmlLabel10
        '
        Me.Guna2HtmlLabel10.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel10.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel10.Location = New System.Drawing.Point(370, 26)
        Me.Guna2HtmlLabel10.Margin = New System.Windows.Forms.Padding(0)
        Me.Guna2HtmlLabel10.Name = "Guna2HtmlLabel10"
        Me.Guna2HtmlLabel10.Size = New System.Drawing.Size(95, 23)
        Me.Guna2HtmlLabel10.TabIndex = 76
        Me.Guna2HtmlLabel10.Text = "Department:"
        '
        'TXTADDRESS
        '
        Me.TXTADDRESS.BorderRadius = 4
        Me.TXTADDRESS.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TXTADDRESS.DefaultText = ""
        Me.TXTADDRESS.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.TXTADDRESS.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TXTADDRESS.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TXTADDRESS.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TXTADDRESS.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TXTADDRESS.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTADDRESS.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TXTADDRESS.Location = New System.Drawing.Point(370, 235)
        Me.TXTADDRESS.Margin = New System.Windows.Forms.Padding(0)
        Me.TXTADDRESS.MaxLength = 45
        Me.TXTADDRESS.Name = "TXTADDRESS"
        Me.TXTADDRESS.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TXTADDRESS.PlaceholderText = "e.g., Junior High School"
        Me.TXTADDRESS.SelectedText = ""
        Me.TXTADDRESS.Size = New System.Drawing.Size(306, 48)
        Me.TXTADDRESS.TabIndex = 72
        '
        'Guna2HtmlLabel8
        '
        Me.Guna2HtmlLabel8.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel8.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel8.Location = New System.Drawing.Point(370, 208)
        Me.Guna2HtmlLabel8.Margin = New System.Windows.Forms.Padding(0)
        Me.Guna2HtmlLabel8.Name = "Guna2HtmlLabel8"
        Me.Guna2HtmlLabel8.Size = New System.Drawing.Size(144, 23)
        Me.Guna2HtmlLabel8.TabIndex = 71
        Me.Guna2HtmlLabel8.Text = "Address (Optional):"
        '
        'Guna2HtmlLabel5
        '
        Me.Guna2HtmlLabel5.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel5.ForeColor = System.Drawing.Color.Red
        Me.Guna2HtmlLabel5.Location = New System.Drawing.Point(117, 24)
        Me.Guna2HtmlLabel5.Margin = New System.Windows.Forms.Padding(0)
        Me.Guna2HtmlLabel5.Name = "Guna2HtmlLabel5"
        Me.Guna2HtmlLabel5.Size = New System.Drawing.Size(10, 23)
        Me.Guna2HtmlLabel5.TabIndex = 70
        Me.Guna2HtmlLabel5.Text = "*"
        '
        'TXTFULLNAME
        '
        Me.TXTFULLNAME.BorderRadius = 4
        Me.TXTFULLNAME.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TXTFULLNAME.DefaultText = ""
        Me.TXTFULLNAME.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.TXTFULLNAME.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TXTFULLNAME.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TXTFULLNAME.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TXTFULLNAME.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TXTFULLNAME.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFULLNAME.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TXTFULLNAME.Location = New System.Drawing.Point(37, 52)
        Me.TXTFULLNAME.Margin = New System.Windows.Forms.Padding(0)
        Me.TXTFULLNAME.MaxLength = 45
        Me.TXTFULLNAME.Name = "TXTFULLNAME"
        Me.TXTFULLNAME.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TXTFULLNAME.PlaceholderText = "e.g., Junior High School"
        Me.TXTFULLNAME.SelectedText = ""
        Me.TXTFULLNAME.Size = New System.Drawing.Size(306, 48)
        Me.TXTFULLNAME.TabIndex = 69
        '
        'Guna2HtmlLabel6
        '
        Me.Guna2HtmlLabel6.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel6.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel6.Location = New System.Drawing.Point(37, 25)
        Me.Guna2HtmlLabel6.Margin = New System.Windows.Forms.Padding(0)
        Me.Guna2HtmlLabel6.Name = "Guna2HtmlLabel6"
        Me.Guna2HtmlLabel6.Size = New System.Drawing.Size(79, 23)
        Me.Guna2HtmlLabel6.TabIndex = 68
        Me.Guna2HtmlLabel6.Text = "Full Name:"
        '
        'errProvider
        '
        Me.errProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.errProvider.ContainerControl = Me
        '
        'FacultyDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(712, 365)
        Me.Controls.Add(Me.BTNSAVE)
        Me.Controls.Add(Me.Guna2HtmlLabel13)
        Me.Controls.Add(Me.TXTEMAIL)
        Me.Controls.Add(Me.Guna2HtmlLabel15)
        Me.Controls.Add(Me.TXTPHONE)
        Me.Controls.Add(Me.Guna2HtmlLabel14)
        Me.Controls.Add(Me.CMBGENDER)
        Me.Controls.Add(Me.Guna2HtmlLabel11)
        Me.Controls.Add(Me.Guna2HtmlLabel12)
        Me.Controls.Add(Me.CMBDEPARTMENT)
        Me.Controls.Add(Me.Guna2HtmlLabel9)
        Me.Controls.Add(Me.Guna2HtmlLabel10)
        Me.Controls.Add(Me.TXTADDRESS)
        Me.Controls.Add(Me.Guna2HtmlLabel8)
        Me.Controls.Add(Me.Guna2HtmlLabel5)
        Me.Controls.Add(Me.TXTFULLNAME)
        Me.Controls.Add(Me.Guna2HtmlLabel6)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FacultyDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FacultyDialog"
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BTNSAVE As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2HtmlLabel13 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents TXTEMAIL As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2HtmlLabel15 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents TXTPHONE As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2HtmlLabel14 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents CMBGENDER As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Guna2HtmlLabel11 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel12 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents CMBDEPARTMENT As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Guna2HtmlLabel9 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel10 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents TXTADDRESS As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2HtmlLabel8 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel5 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents TXTFULLNAME As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2HtmlLabel6 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents errProvider As ErrorProvider
End Class
