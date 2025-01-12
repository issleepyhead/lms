<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BorrowDialog
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BTNSEARCHBOOKS = New Guna.UI2.WinForms.Guna2Button()
        Me.TXTISBN = New Guna.UI2.WinForms.Guna2TextBox()
        Me.RBFACULTY = New Guna.UI2.WinForms.Guna2RadioButton()
        Me.RBSTUDENT = New Guna.UI2.WinForms.Guna2RadioButton()
        Me.BTNBORROWBOOKS = New Guna.UI2.WinForms.Guna2Button()
        Me.LBLFACULTYREQUIRED = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.LBLSTUDENTREQUIRED = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.BTNADDBOOKS = New Guna.UI2.WinForms.Guna2Button()
        Me.BTNSEARCHFACULTY = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2HtmlLabel2 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.CMBFACULTY = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.BTNSEARCHSTUDENT = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.TXTSTUDENTLRN = New Guna.UI2.WinForms.Guna2TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BTNSEARCHBOOKS)
        Me.GroupBox1.Controls.Add(Me.TXTISBN)
        Me.GroupBox1.Controls.Add(Me.RBFACULTY)
        Me.GroupBox1.Controls.Add(Me.RBSTUDENT)
        Me.GroupBox1.Controls.Add(Me.BTNBORROWBOOKS)
        Me.GroupBox1.Controls.Add(Me.LBLFACULTYREQUIRED)
        Me.GroupBox1.Controls.Add(Me.LBLSTUDENTREQUIRED)
        Me.GroupBox1.Controls.Add(Me.BTNADDBOOKS)
        Me.GroupBox1.Controls.Add(Me.BTNSEARCHFACULTY)
        Me.GroupBox1.Controls.Add(Me.Guna2HtmlLabel2)
        Me.GroupBox1.Controls.Add(Me.CMBFACULTY)
        Me.GroupBox1.Controls.Add(Me.BTNSEARCHSTUDENT)
        Me.GroupBox1.Controls.Add(Me.Guna2HtmlLabel1)
        Me.GroupBox1.Controls.Add(Me.TXTSTUDENTLRN)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(20)
        Me.GroupBox1.Size = New System.Drawing.Size(392, 392)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'BTNSEARCHBOOKS
        '
        Me.BTNSEARCHBOOKS.BorderRadius = 4
        Me.BTNSEARCHBOOKS.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.BTNSEARCHBOOKS.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.BTNSEARCHBOOKS.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.BTNSEARCHBOOKS.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.BTNSEARCHBOOKS.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BTNSEARCHBOOKS.ForeColor = System.Drawing.Color.White
        Me.BTNSEARCHBOOKS.Location = New System.Drawing.Point(262, 236)
        Me.BTNSEARCHBOOKS.Margin = New System.Windows.Forms.Padding(0)
        Me.BTNSEARCHBOOKS.Name = "BTNSEARCHBOOKS"
        Me.BTNSEARCHBOOKS.Size = New System.Drawing.Size(110, 40)
        Me.BTNSEARCHBOOKS.TabIndex = 132
        Me.BTNSEARCHBOOKS.Text = "Search Book"
        '
        'TXTISBN
        '
        Me.TXTISBN.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.TXTISBN.BorderColor = System.Drawing.Color.Gray
        Me.TXTISBN.BorderRadius = 4
        Me.TXTISBN.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TXTISBN.DefaultText = ""
        Me.TXTISBN.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.TXTISBN.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TXTISBN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TXTISBN.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TXTISBN.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TXTISBN.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.TXTISBN.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TXTISBN.Location = New System.Drawing.Point(20, 236)
        Me.TXTISBN.Margin = New System.Windows.Forms.Padding(0, 0, 0, 8)
        Me.TXTISBN.MaxLength = 20
        Me.TXTISBN.Name = "TXTISBN"
        Me.TXTISBN.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TXTISBN.PlaceholderForeColor = System.Drawing.Color.DarkGray
        Me.TXTISBN.PlaceholderText = "Scan or type accession number"
        Me.TXTISBN.SelectedText = ""
        Me.TXTISBN.ShortcutsEnabled = False
        Me.TXTISBN.Size = New System.Drawing.Size(238, 40)
        Me.TXTISBN.TabIndex = 131
        '
        'RBFACULTY
        '
        Me.RBFACULTY.AutoSize = True
        Me.RBFACULTY.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.RBFACULTY.CheckedState.BorderThickness = 0
        Me.RBFACULTY.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.RBFACULTY.CheckedState.InnerColor = System.Drawing.Color.White
        Me.RBFACULTY.CheckedState.InnerOffset = -4
        Me.RBFACULTY.Location = New System.Drawing.Point(90, 199)
        Me.RBFACULTY.Margin = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.RBFACULTY.Name = "RBFACULTY"
        Me.RBFACULTY.Size = New System.Drawing.Size(59, 17)
        Me.RBFACULTY.TabIndex = 130
        Me.RBFACULTY.Text = "Faculty"
        Me.RBFACULTY.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.RBFACULTY.UncheckedState.BorderThickness = 2
        Me.RBFACULTY.UncheckedState.FillColor = System.Drawing.Color.Transparent
        Me.RBFACULTY.UncheckedState.InnerColor = System.Drawing.Color.Transparent
        '
        'RBSTUDENT
        '
        Me.RBSTUDENT.AutoSize = True
        Me.RBSTUDENT.Checked = True
        Me.RBSTUDENT.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.RBSTUDENT.CheckedState.BorderThickness = 0
        Me.RBSTUDENT.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.RBSTUDENT.CheckedState.InnerColor = System.Drawing.Color.White
        Me.RBSTUDENT.CheckedState.InnerOffset = -4
        Me.RBSTUDENT.Location = New System.Drawing.Point(20, 199)
        Me.RBSTUDENT.Margin = New System.Windows.Forms.Padding(0, 0, 8, 16)
        Me.RBSTUDENT.Name = "RBSTUDENT"
        Me.RBSTUDENT.Size = New System.Drawing.Size(62, 17)
        Me.RBSTUDENT.TabIndex = 129
        Me.RBSTUDENT.TabStop = True
        Me.RBSTUDENT.Text = "Student"
        Me.RBSTUDENT.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.RBSTUDENT.UncheckedState.BorderThickness = 2
        Me.RBSTUDENT.UncheckedState.FillColor = System.Drawing.Color.Transparent
        Me.RBSTUDENT.UncheckedState.InnerColor = System.Drawing.Color.Transparent
        '
        'BTNBORROWBOOKS
        '
        Me.BTNBORROWBOOKS.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.BTNBORROWBOOKS.BorderRadius = 4
        Me.BTNBORROWBOOKS.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.BTNBORROWBOOKS.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.BTNBORROWBOOKS.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.BTNBORROWBOOKS.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.BTNBORROWBOOKS.FillColor = System.Drawing.Color.Green
        Me.BTNBORROWBOOKS.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BTNBORROWBOOKS.ForeColor = System.Drawing.Color.White
        Me.BTNBORROWBOOKS.Location = New System.Drawing.Point(20, 332)
        Me.BTNBORROWBOOKS.Margin = New System.Windows.Forms.Padding(0)
        Me.BTNBORROWBOOKS.Name = "BTNBORROWBOOKS"
        Me.BTNBORROWBOOKS.Size = New System.Drawing.Size(352, 40)
        Me.BTNBORROWBOOKS.TabIndex = 128
        Me.BTNBORROWBOOKS.Text = "Borrow Books"
        '
        'LBLFACULTYREQUIRED
        '
        Me.LBLFACULTYREQUIRED.BackColor = System.Drawing.Color.Transparent
        Me.LBLFACULTYREQUIRED.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLFACULTYREQUIRED.ForeColor = System.Drawing.Color.Red
        Me.LBLFACULTYREQUIRED.Location = New System.Drawing.Point(151, 116)
        Me.LBLFACULTYREQUIRED.Margin = New System.Windows.Forms.Padding(0)
        Me.LBLFACULTYREQUIRED.Name = "LBLFACULTYREQUIRED"
        Me.LBLFACULTYREQUIRED.Size = New System.Drawing.Size(10, 23)
        Me.LBLFACULTYREQUIRED.TabIndex = 127
        Me.LBLFACULTYREQUIRED.Text = "*"
        '
        'LBLSTUDENTREQUIRED
        '
        Me.LBLSTUDENTREQUIRED.BackColor = System.Drawing.Color.Transparent
        Me.LBLSTUDENTREQUIRED.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLSTUDENTREQUIRED.ForeColor = System.Drawing.Color.Red
        Me.LBLSTUDENTREQUIRED.Location = New System.Drawing.Point(158, 33)
        Me.LBLSTUDENTREQUIRED.Margin = New System.Windows.Forms.Padding(0)
        Me.LBLSTUDENTREQUIRED.Name = "LBLSTUDENTREQUIRED"
        Me.LBLSTUDENTREQUIRED.Size = New System.Drawing.Size(10, 23)
        Me.LBLSTUDENTREQUIRED.TabIndex = 126
        Me.LBLSTUDENTREQUIRED.Text = "*"
        '
        'BTNADDBOOKS
        '
        Me.BTNADDBOOKS.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.BTNADDBOOKS.BorderRadius = 4
        Me.BTNADDBOOKS.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.BTNADDBOOKS.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.BTNADDBOOKS.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.BTNADDBOOKS.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.BTNADDBOOKS.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BTNADDBOOKS.ForeColor = System.Drawing.Color.White
        Me.BTNADDBOOKS.Location = New System.Drawing.Point(20, 284)
        Me.BTNADDBOOKS.Margin = New System.Windows.Forms.Padding(0, 0, 0, 8)
        Me.BTNADDBOOKS.Name = "BTNADDBOOKS"
        Me.BTNADDBOOKS.Size = New System.Drawing.Size(352, 40)
        Me.BTNADDBOOKS.TabIndex = 125
        Me.BTNADDBOOKS.Text = "View Books"
        '
        'BTNSEARCHFACULTY
        '
        Me.BTNSEARCHFACULTY.BorderRadius = 4
        Me.BTNSEARCHFACULTY.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.BTNSEARCHFACULTY.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.BTNSEARCHFACULTY.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.BTNSEARCHFACULTY.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.BTNSEARCHFACULTY.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BTNSEARCHFACULTY.ForeColor = System.Drawing.Color.White
        Me.BTNSEARCHFACULTY.Location = New System.Drawing.Point(262, 143)
        Me.BTNSEARCHFACULTY.Margin = New System.Windows.Forms.Padding(0)
        Me.BTNSEARCHFACULTY.Name = "BTNSEARCHFACULTY"
        Me.BTNSEARCHFACULTY.Size = New System.Drawing.Size(110, 40)
        Me.BTNSEARCHFACULTY.TabIndex = 124
        Me.BTNSEARCHFACULTY.Text = "Search"
        '
        'Guna2HtmlLabel2
        '
        Me.Guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel2.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel2.Location = New System.Drawing.Point(20, 116)
        Me.Guna2HtmlLabel2.Margin = New System.Windows.Forms.Padding(0, 0, 0, 4)
        Me.Guna2HtmlLabel2.Name = "Guna2HtmlLabel2"
        Me.Guna2HtmlLabel2.Size = New System.Drawing.Size(131, 23)
        Me.Guna2HtmlLabel2.TabIndex = 123
        Me.Guna2HtmlLabel2.Text = "Borrower Faculty:"
        '
        'CMBFACULTY
        '
        Me.CMBFACULTY.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CMBFACULTY.BackColor = System.Drawing.Color.Transparent
        Me.CMBFACULTY.BorderColor = System.Drawing.Color.Gray
        Me.CMBFACULTY.BorderRadius = 4
        Me.CMBFACULTY.DisplayMember = "Full Name"
        Me.CMBFACULTY.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CMBFACULTY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBFACULTY.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CMBFACULTY.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CMBFACULTY.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.CMBFACULTY.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.CMBFACULTY.ItemHeight = 34
        Me.CMBFACULTY.Location = New System.Drawing.Point(20, 143)
        Me.CMBFACULTY.Margin = New System.Windows.Forms.Padding(0, 0, 0, 16)
        Me.CMBFACULTY.Name = "CMBFACULTY"
        Me.CMBFACULTY.Size = New System.Drawing.Size(238, 40)
        Me.CMBFACULTY.TabIndex = 122
        Me.CMBFACULTY.ValueMember = "id"
        '
        'BTNSEARCHSTUDENT
        '
        Me.BTNSEARCHSTUDENT.BorderRadius = 4
        Me.BTNSEARCHSTUDENT.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.BTNSEARCHSTUDENT.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.BTNSEARCHSTUDENT.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.BTNSEARCHSTUDENT.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.BTNSEARCHSTUDENT.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BTNSEARCHSTUDENT.ForeColor = System.Drawing.Color.White
        Me.BTNSEARCHSTUDENT.Location = New System.Drawing.Point(262, 60)
        Me.BTNSEARCHSTUDENT.Margin = New System.Windows.Forms.Padding(0)
        Me.BTNSEARCHSTUDENT.Name = "BTNSEARCHSTUDENT"
        Me.BTNSEARCHSTUDENT.Size = New System.Drawing.Size(110, 40)
        Me.BTNSEARCHSTUDENT.TabIndex = 121
        Me.BTNSEARCHSTUDENT.Text = "Search"
        '
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(20, 33)
        Me.Guna2HtmlLabel1.Margin = New System.Windows.Forms.Padding(0, 0, 0, 4)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(138, 23)
        Me.Guna2HtmlLabel1.TabIndex = 120
        Me.Guna2HtmlLabel1.Text = "Borrower Student:"
        '
        'TXTSTUDENTLRN
        '
        Me.TXTSTUDENTLRN.BorderColor = System.Drawing.Color.Gray
        Me.TXTSTUDENTLRN.BorderRadius = 4
        Me.TXTSTUDENTLRN.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TXTSTUDENTLRN.DefaultText = ""
        Me.TXTSTUDENTLRN.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.TXTSTUDENTLRN.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TXTSTUDENTLRN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TXTSTUDENTLRN.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TXTSTUDENTLRN.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TXTSTUDENTLRN.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.TXTSTUDENTLRN.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TXTSTUDENTLRN.Location = New System.Drawing.Point(20, 60)
        Me.TXTSTUDENTLRN.Margin = New System.Windows.Forms.Padding(0, 0, 0, 16)
        Me.TXTSTUDENTLRN.MaxLength = 30
        Me.TXTSTUDENTLRN.Name = "TXTSTUDENTLRN"
        Me.TXTSTUDENTLRN.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TXTSTUDENTLRN.PlaceholderForeColor = System.Drawing.Color.DarkGray
        Me.TXTSTUDENTLRN.PlaceholderText = "Scan or type LRN/Student No."
        Me.TXTSTUDENTLRN.SelectedText = ""
        Me.TXTSTUDENTLRN.ShortcutsEnabled = False
        Me.TXTSTUDENTLRN.Size = New System.Drawing.Size(238, 40)
        Me.TXTSTUDENTLRN.TabIndex = 119
        '
        'BorrowDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(392, 392)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BorrowDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Borrow Form"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RBFACULTY As Guna.UI2.WinForms.Guna2RadioButton
    Friend WithEvents RBSTUDENT As Guna.UI2.WinForms.Guna2RadioButton
    Friend WithEvents BTNBORROWBOOKS As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents LBLFACULTYREQUIRED As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents LBLSTUDENTREQUIRED As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents BTNADDBOOKS As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents BTNSEARCHFACULTY As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2HtmlLabel2 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents CMBFACULTY As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents BTNSEARCHSTUDENT As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents TXTSTUDENTLRN As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents TXTISBN As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents BTNSEARCHBOOKS As Guna.UI2.WinForms.Guna2Button
End Class
