<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class YearLevelDialog
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
        Me.BTNSAVE = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2HtmlLabel3 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.TXTNAME = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.CMBDEPARTMENT = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Guna2HtmlLabel5 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel6 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BTNSAVE
        '
        Me.BTNSAVE.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTNSAVE.BorderRadius = 4
        Me.BTNSAVE.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.BTNSAVE.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.BTNSAVE.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.BTNSAVE.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.BTNSAVE.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.BTNSAVE.ForeColor = System.Drawing.Color.White
        Me.BTNSAVE.Location = New System.Drawing.Point(197, 182)
        Me.BTNSAVE.Name = "BTNSAVE"
        Me.BTNSAVE.Size = New System.Drawing.Size(128, 40)
        Me.BTNSAVE.TabIndex = 26
        Me.BTNSAVE.Text = "Save"
        '
        'Guna2HtmlLabel3
        '
        Me.Guna2HtmlLabel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel3.ForeColor = System.Drawing.Color.Red
        Me.Guna2HtmlLabel3.Location = New System.Drawing.Point(105, 99)
        Me.Guna2HtmlLabel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Guna2HtmlLabel3.Name = "Guna2HtmlLabel3"
        Me.Guna2HtmlLabel3.Size = New System.Drawing.Size(10, 23)
        Me.Guna2HtmlLabel3.TabIndex = 23
        Me.Guna2HtmlLabel3.Text = "*"
        '
        'TXTNAME
        '
        Me.TXTNAME.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TXTNAME.BorderRadius = 4
        Me.TXTNAME.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TXTNAME.DefaultText = ""
        Me.TXTNAME.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.TXTNAME.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TXTNAME.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TXTNAME.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TXTNAME.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TXTNAME.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNAME.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TXTNAME.Location = New System.Drawing.Point(20, 122)
        Me.TXTNAME.Margin = New System.Windows.Forms.Padding(0, 0, 0, 16)
        Me.TXTNAME.MaxLength = 45
        Me.TXTNAME.Name = "TXTNAME"
        Me.TXTNAME.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TXTNAME.PlaceholderText = "e.g., 7-12"
        Me.TXTNAME.SelectedText = ""
        Me.TXTNAME.Size = New System.Drawing.Size(305, 40)
        Me.TXTNAME.TabIndex = 22
        '
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(20, 99)
        Me.Guna2HtmlLabel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(81, 23)
        Me.Guna2HtmlLabel1.TabIndex = 21
        Me.Guna2HtmlLabel1.Text = "Year Level:"
        '
        'CMBDEPARTMENT
        '
        Me.CMBDEPARTMENT.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.CMBDEPARTMENT.BackColor = System.Drawing.Color.Transparent
        Me.CMBDEPARTMENT.BorderRadius = 4
        Me.CMBDEPARTMENT.DisplayMember = "department_name"
        Me.CMBDEPARTMENT.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CMBDEPARTMENT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBDEPARTMENT.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CMBDEPARTMENT.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CMBDEPARTMENT.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.CMBDEPARTMENT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.CMBDEPARTMENT.ItemHeight = 34
        Me.CMBDEPARTMENT.Location = New System.Drawing.Point(20, 43)
        Me.CMBDEPARTMENT.Margin = New System.Windows.Forms.Padding(0, 0, 0, 16)
        Me.CMBDEPARTMENT.Name = "CMBDEPARTMENT"
        Me.CMBDEPARTMENT.Size = New System.Drawing.Size(305, 40)
        Me.CMBDEPARTMENT.TabIndex = 29
        Me.CMBDEPARTMENT.ValueMember = "id"
        '
        'Guna2HtmlLabel5
        '
        Me.Guna2HtmlLabel5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel5.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel5.ForeColor = System.Drawing.Color.Red
        Me.Guna2HtmlLabel5.Location = New System.Drawing.Point(117, 21)
        Me.Guna2HtmlLabel5.Margin = New System.Windows.Forms.Padding(0)
        Me.Guna2HtmlLabel5.Name = "Guna2HtmlLabel5"
        Me.Guna2HtmlLabel5.Size = New System.Drawing.Size(10, 23)
        Me.Guna2HtmlLabel5.TabIndex = 28
        Me.Guna2HtmlLabel5.Text = "*"
        '
        'Guna2HtmlLabel6
        '
        Me.Guna2HtmlLabel6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel6.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel6.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel6.Location = New System.Drawing.Point(20, 20)
        Me.Guna2HtmlLabel6.Margin = New System.Windows.Forms.Padding(0)
        Me.Guna2HtmlLabel6.Name = "Guna2HtmlLabel6"
        Me.Guna2HtmlLabel6.Size = New System.Drawing.Size(95, 23)
        Me.Guna2HtmlLabel6.TabIndex = 27
        Me.Guna2HtmlLabel6.Text = "Department:"
        '
        'errProvider
        '
        Me.errProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.errProvider.ContainerControl = Me
        '
        'YearLevelDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(348, 245)
        Me.Controls.Add(Me.CMBDEPARTMENT)
        Me.Controls.Add(Me.Guna2HtmlLabel5)
        Me.Controls.Add(Me.Guna2HtmlLabel6)
        Me.Controls.Add(Me.BTNSAVE)
        Me.Controls.Add(Me.Guna2HtmlLabel3)
        Me.Controls.Add(Me.TXTNAME)
        Me.Controls.Add(Me.Guna2HtmlLabel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "YearLevelDialog"
        Me.Padding = New System.Windows.Forms.Padding(20)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Year Level Form"
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BTNSAVE As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2HtmlLabel3 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents TXTNAME As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents CMBDEPARTMENT As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Guna2HtmlLabel5 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel6 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents errProvider As ErrorProvider
End Class
