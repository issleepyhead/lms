<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ImportDataDialog
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.BTNPREVIEW = New Guna.UI2.WinForms.Guna2Button()
        Me.BTNSELECTFILE = New Guna.UI2.WinForms.Guna2Button()
        Me.TXTPATH = New Guna.UI2.WinForms.Guna2TextBox()
        Me.DGDATA = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.Guna2Panel2 = New Guna.UI2.WinForms.Guna2Panel()
        Me.BTNCANCEL = New Guna.UI2.WinForms.Guna2Button()
        Me.BTNHIDE = New Guna.UI2.WinForms.Guna2Button()
        Me.BTNIMPORT = New Guna.UI2.WinForms.Guna2Button()
        Me.ImportBackground = New System.ComponentModel.BackgroundWorker()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Guna2Panel1.SuspendLayout()
        CType(Me.DGDATA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Guna2Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.DGDATA, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Guna2Panel2, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1304, 697)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.Controls.Add(Me.BTNPREVIEW)
        Me.Guna2Panel1.Controls.Add(Me.BTNSELECTFILE)
        Me.Guna2Panel1.Controls.Add(Me.TXTPATH)
        Me.Guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Guna2Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Padding = New System.Windows.Forms.Padding(20, 20, 20, 0)
        Me.Guna2Panel1.Size = New System.Drawing.Size(1304, 70)
        Me.Guna2Panel1.TabIndex = 0
        '
        'BTNPREVIEW
        '
        Me.BTNPREVIEW.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTNPREVIEW.BorderRadius = 4
        Me.BTNPREVIEW.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.BTNPREVIEW.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.BTNPREVIEW.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.BTNPREVIEW.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.BTNPREVIEW.Enabled = False
        Me.BTNPREVIEW.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BTNPREVIEW.ForeColor = System.Drawing.Color.White
        Me.BTNPREVIEW.Location = New System.Drawing.Point(1176, 23)
        Me.BTNPREVIEW.Name = "BTNPREVIEW"
        Me.BTNPREVIEW.Size = New System.Drawing.Size(105, 36)
        Me.BTNPREVIEW.TabIndex = 7
        Me.BTNPREVIEW.Text = "Preview"
        '
        'BTNSELECTFILE
        '
        Me.BTNSELECTFILE.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTNSELECTFILE.BorderRadius = 4
        Me.BTNSELECTFILE.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.BTNSELECTFILE.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.BTNSELECTFILE.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.BTNSELECTFILE.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.BTNSELECTFILE.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BTNSELECTFILE.ForeColor = System.Drawing.Color.White
        Me.BTNSELECTFILE.Location = New System.Drawing.Point(1065, 23)
        Me.BTNSELECTFILE.Name = "BTNSELECTFILE"
        Me.BTNSELECTFILE.Size = New System.Drawing.Size(105, 36)
        Me.BTNSELECTFILE.TabIndex = 6
        Me.BTNSELECTFILE.Text = "Select File"
        '
        'TXTPATH
        '
        Me.TXTPATH.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TXTPATH.BorderRadius = 4
        Me.TXTPATH.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TXTPATH.DefaultText = ""
        Me.TXTPATH.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.TXTPATH.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TXTPATH.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TXTPATH.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TXTPATH.Enabled = False
        Me.TXTPATH.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TXTPATH.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TXTPATH.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TXTPATH.Location = New System.Drawing.Point(20, 23)
        Me.TXTPATH.Name = "TXTPATH"
        Me.TXTPATH.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TXTPATH.PlaceholderText = "File Path"
        Me.TXTPATH.ReadOnly = True
        Me.TXTPATH.SelectedText = ""
        Me.TXTPATH.Size = New System.Drawing.Size(1036, 36)
        Me.TXTPATH.TabIndex = 5
        '
        'DGDATA
        '
        Me.DGDATA.AllowUserToAddRows = False
        Me.DGDATA.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.DGDATA.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGDATA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGDATA.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGDATA.ColumnHeadersHeight = 28
        Me.DGDATA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGDATA.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGDATA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGDATA.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DGDATA.Location = New System.Drawing.Point(20, 80)
        Me.DGDATA.Margin = New System.Windows.Forms.Padding(20, 10, 20, 10)
        Me.DGDATA.Name = "DGDATA"
        Me.DGDATA.ReadOnly = True
        Me.DGDATA.RowHeadersVisible = False
        Me.DGDATA.Size = New System.Drawing.Size(1264, 557)
        Me.DGDATA.TabIndex = 1
        Me.DGDATA.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.DGDATA.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.DGDATA.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.DGDATA.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.DGDATA.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.DGDATA.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.DGDATA.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DGDATA.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DGDATA.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DGDATA.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGDATA.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.DGDATA.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.DGDATA.ThemeStyle.HeaderStyle.Height = 28
        Me.DGDATA.ThemeStyle.ReadOnly = True
        Me.DGDATA.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.DGDATA.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DGDATA.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGDATA.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.DGDATA.ThemeStyle.RowsStyle.Height = 22
        Me.DGDATA.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DGDATA.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'Guna2Panel2
        '
        Me.Guna2Panel2.Controls.Add(Me.BTNCANCEL)
        Me.Guna2Panel2.Controls.Add(Me.BTNHIDE)
        Me.Guna2Panel2.Controls.Add(Me.BTNIMPORT)
        Me.Guna2Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Guna2Panel2.Location = New System.Drawing.Point(0, 647)
        Me.Guna2Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Guna2Panel2.Name = "Guna2Panel2"
        Me.Guna2Panel2.Padding = New System.Windows.Forms.Padding(20, 0, 20, 0)
        Me.Guna2Panel2.Size = New System.Drawing.Size(1304, 50)
        Me.Guna2Panel2.TabIndex = 2
        '
        'BTNCANCEL
        '
        Me.BTNCANCEL.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTNCANCEL.BorderRadius = 4
        Me.BTNCANCEL.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.BTNCANCEL.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.BTNCANCEL.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.BTNCANCEL.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.BTNCANCEL.FillColor = System.Drawing.SystemColors.ControlDark
        Me.BTNCANCEL.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BTNCANCEL.ForeColor = System.Drawing.Color.Black
        Me.BTNCANCEL.Location = New System.Drawing.Point(904, 7)
        Me.BTNCANCEL.Name = "BTNCANCEL"
        Me.BTNCANCEL.Size = New System.Drawing.Size(104, 36)
        Me.BTNCANCEL.TabIndex = 10
        Me.BTNCANCEL.Text = "Cancel"
        '
        'BTNHIDE
        '
        Me.BTNHIDE.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTNHIDE.BorderRadius = 4
        Me.BTNHIDE.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.BTNHIDE.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.BTNHIDE.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.BTNHIDE.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.BTNHIDE.FillColor = System.Drawing.SystemColors.ControlDark
        Me.BTNHIDE.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BTNHIDE.ForeColor = System.Drawing.Color.Black
        Me.BTNHIDE.Location = New System.Drawing.Point(1014, 7)
        Me.BTNHIDE.Name = "BTNHIDE"
        Me.BTNHIDE.Size = New System.Drawing.Size(104, 36)
        Me.BTNHIDE.TabIndex = 9
        Me.BTNHIDE.Text = "Hide"
        '
        'BTNIMPORT
        '
        Me.BTNIMPORT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTNIMPORT.BorderRadius = 4
        Me.BTNIMPORT.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.BTNIMPORT.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.BTNIMPORT.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.BTNIMPORT.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.BTNIMPORT.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BTNIMPORT.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BTNIMPORT.ForeColor = System.Drawing.Color.White
        Me.BTNIMPORT.Location = New System.Drawing.Point(1124, 7)
        Me.BTNIMPORT.Name = "BTNIMPORT"
        Me.BTNIMPORT.Size = New System.Drawing.Size(157, 36)
        Me.BTNIMPORT.TabIndex = 8
        Me.BTNIMPORT.Text = "Import"
        '
        'ImportBackground
        '
        Me.ImportBackground.WorkerReportsProgress = True
        Me.ImportBackground.WorkerSupportsCancellation = True
        '
        'ImportDataDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1304, 697)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ImportDataDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import Data"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Guna2Panel1.ResumeLayout(False)
        CType(Me.DGDATA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents BTNPREVIEW As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents BTNSELECTFILE As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents TXTPATH As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents DGDATA As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents Guna2Panel2 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents BTNIMPORT As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents BTNCANCEL As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents BTNHIDE As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents ImportBackground As System.ComponentModel.BackgroundWorker
End Class
