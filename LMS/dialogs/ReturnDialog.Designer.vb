<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReturnDialog
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Guna2Panel2 = New Guna.UI2.WinForms.Guna2Panel()
        Me.BTNSAVE = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.LBLSTATUS = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.LBLBORROWDATE = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.LBLDUEDATE = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.LBLOVERDUEDAYS = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.LBLISSUEDBY = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.LBLPENALTY = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.LBLBORROWER = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.LBLCIRCULATION = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel12 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel11 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel10 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel9 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel8 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel3 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel5 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel6 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel7 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel4 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel2 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel27 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Guna2Panel3 = New Guna.UI2.WinForms.Guna2Panel()
        Me.DGBORROWEDCOPIES = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.DGBORROWEDCOPIESMENUSTRIP = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnselectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReturnAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NoteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnReturnCond = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnBorrowedCond = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chckBoxBorrowCopies = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnBorrowedCondition = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Guna2Panel2.SuspendLayout()
        Me.Guna2Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Guna2Panel3.SuspendLayout()
        CType(Me.DGBORROWEDCOPIES, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DGBORROWEDCOPIESMENUSTRIP.SuspendLayout()
        Me.SuspendLayout()
        '
        'Guna2Panel2
        '
        Me.Guna2Panel2.Controls.Add(Me.BTNSAVE)
        Me.Guna2Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Guna2Panel2.Location = New System.Drawing.Point(0, 637)
        Me.Guna2Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Guna2Panel2.Name = "Guna2Panel2"
        Me.Guna2Panel2.Size = New System.Drawing.Size(1304, 60)
        Me.Guna2Panel2.TabIndex = 1
        '
        'BTNSAVE
        '
        Me.BTNSAVE.BorderRadius = 4
        Me.BTNSAVE.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.BTNSAVE.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.BTNSAVE.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.BTNSAVE.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.BTNSAVE.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.BTNSAVE.ForeColor = System.Drawing.Color.White
        Me.BTNSAVE.Location = New System.Drawing.Point(1116, 10)
        Me.BTNSAVE.Margin = New System.Windows.Forms.Padding(0)
        Me.BTNSAVE.Name = "BTNSAVE"
        Me.BTNSAVE.Size = New System.Drawing.Size(168, 40)
        Me.BTNSAVE.TabIndex = 43
        Me.BTNSAVE.Text = "Return All"
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.Controls.Add(Me.LBLSTATUS)
        Me.Guna2Panel1.Controls.Add(Me.LBLBORROWDATE)
        Me.Guna2Panel1.Controls.Add(Me.LBLDUEDATE)
        Me.Guna2Panel1.Controls.Add(Me.LBLOVERDUEDAYS)
        Me.Guna2Panel1.Controls.Add(Me.LBLISSUEDBY)
        Me.Guna2Panel1.Controls.Add(Me.LBLPENALTY)
        Me.Guna2Panel1.Controls.Add(Me.LBLBORROWER)
        Me.Guna2Panel1.Controls.Add(Me.LBLCIRCULATION)
        Me.Guna2Panel1.Controls.Add(Me.Guna2HtmlLabel12)
        Me.Guna2Panel1.Controls.Add(Me.Guna2HtmlLabel11)
        Me.Guna2Panel1.Controls.Add(Me.Guna2HtmlLabel10)
        Me.Guna2Panel1.Controls.Add(Me.Guna2HtmlLabel9)
        Me.Guna2Panel1.Controls.Add(Me.Guna2HtmlLabel8)
        Me.Guna2Panel1.Controls.Add(Me.Guna2HtmlLabel3)
        Me.Guna2Panel1.Controls.Add(Me.Guna2HtmlLabel5)
        Me.Guna2Panel1.Controls.Add(Me.Guna2HtmlLabel6)
        Me.Guna2Panel1.Controls.Add(Me.Guna2HtmlLabel7)
        Me.Guna2Panel1.Controls.Add(Me.Guna2HtmlLabel4)
        Me.Guna2Panel1.Controls.Add(Me.Guna2HtmlLabel2)
        Me.Guna2Panel1.Controls.Add(Me.Guna2HtmlLabel1)
        Me.Guna2Panel1.Controls.Add(Me.Guna2HtmlLabel27)
        Me.Guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Guna2Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Padding = New System.Windows.Forms.Padding(20)
        Me.Guna2Panel1.Size = New System.Drawing.Size(1304, 200)
        Me.Guna2Panel1.TabIndex = 0
        '
        'LBLSTATUS
        '
        Me.LBLSTATUS.BackColor = System.Drawing.Color.Transparent
        Me.LBLSTATUS.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLSTATUS.Location = New System.Drawing.Point(1216, 162)
        Me.LBLSTATUS.Margin = New System.Windows.Forms.Padding(0)
        Me.LBLSTATUS.Name = "LBLSTATUS"
        Me.LBLSTATUS.Size = New System.Drawing.Size(9, 23)
        Me.LBLSTATUS.TabIndex = 140
        Me.LBLSTATUS.Text = "-"
        '
        'LBLBORROWDATE
        '
        Me.LBLBORROWDATE.BackColor = System.Drawing.Color.Transparent
        Me.LBLBORROWDATE.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLBORROWDATE.Location = New System.Drawing.Point(1109, 101)
        Me.LBLBORROWDATE.Margin = New System.Windows.Forms.Padding(0)
        Me.LBLBORROWDATE.Name = "LBLBORROWDATE"
        Me.LBLBORROWDATE.Size = New System.Drawing.Size(9, 23)
        Me.LBLBORROWDATE.TabIndex = 139
        Me.LBLBORROWDATE.Text = "-"
        '
        'LBLDUEDATE
        '
        Me.LBLDUEDATE.BackColor = System.Drawing.Color.Transparent
        Me.LBLDUEDATE.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLDUEDATE.Location = New System.Drawing.Point(1110, 46)
        Me.LBLDUEDATE.Margin = New System.Windows.Forms.Padding(0)
        Me.LBLDUEDATE.Name = "LBLDUEDATE"
        Me.LBLDUEDATE.Size = New System.Drawing.Size(9, 23)
        Me.LBLDUEDATE.TabIndex = 138
        Me.LBLDUEDATE.Text = "-"
        '
        'LBLOVERDUEDAYS
        '
        Me.LBLOVERDUEDAYS.BackColor = System.Drawing.Color.Transparent
        Me.LBLOVERDUEDAYS.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLOVERDUEDAYS.Location = New System.Drawing.Point(189, 160)
        Me.LBLOVERDUEDAYS.Margin = New System.Windows.Forms.Padding(0)
        Me.LBLOVERDUEDAYS.Name = "LBLOVERDUEDAYS"
        Me.LBLOVERDUEDAYS.Size = New System.Drawing.Size(9, 23)
        Me.LBLOVERDUEDAYS.TabIndex = 137
        Me.LBLOVERDUEDAYS.Text = "-"
        '
        'LBLISSUEDBY
        '
        Me.LBLISSUEDBY.BackColor = System.Drawing.Color.Transparent
        Me.LBLISSUEDBY.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLISSUEDBY.Location = New System.Drawing.Point(189, 125)
        Me.LBLISSUEDBY.Margin = New System.Windows.Forms.Padding(0)
        Me.LBLISSUEDBY.Name = "LBLISSUEDBY"
        Me.LBLISSUEDBY.Size = New System.Drawing.Size(9, 23)
        Me.LBLISSUEDBY.TabIndex = 136
        Me.LBLISSUEDBY.Text = "-"
        '
        'LBLPENALTY
        '
        Me.LBLPENALTY.BackColor = System.Drawing.Color.Transparent
        Me.LBLPENALTY.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLPENALTY.Location = New System.Drawing.Point(189, 90)
        Me.LBLPENALTY.Margin = New System.Windows.Forms.Padding(0)
        Me.LBLPENALTY.Name = "LBLPENALTY"
        Me.LBLPENALTY.Size = New System.Drawing.Size(9, 23)
        Me.LBLPENALTY.TabIndex = 135
        Me.LBLPENALTY.Text = "-"
        '
        'LBLBORROWER
        '
        Me.LBLBORROWER.BackColor = System.Drawing.Color.Transparent
        Me.LBLBORROWER.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLBORROWER.Location = New System.Drawing.Point(189, 55)
        Me.LBLBORROWER.Margin = New System.Windows.Forms.Padding(0)
        Me.LBLBORROWER.Name = "LBLBORROWER"
        Me.LBLBORROWER.Size = New System.Drawing.Size(9, 23)
        Me.LBLBORROWER.TabIndex = 134
        Me.LBLBORROWER.Text = "-"
        '
        'LBLCIRCULATION
        '
        Me.LBLCIRCULATION.BackColor = System.Drawing.Color.Transparent
        Me.LBLCIRCULATION.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCIRCULATION.Location = New System.Drawing.Point(189, 20)
        Me.LBLCIRCULATION.Margin = New System.Windows.Forms.Padding(0)
        Me.LBLCIRCULATION.Name = "LBLCIRCULATION"
        Me.LBLCIRCULATION.Size = New System.Drawing.Size(9, 23)
        Me.LBLCIRCULATION.TabIndex = 133
        Me.LBLCIRCULATION.Text = "-"
        '
        'Guna2HtmlLabel12
        '
        Me.Guna2HtmlLabel12.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel12.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel12.Location = New System.Drawing.Point(174, 160)
        Me.Guna2HtmlLabel12.Margin = New System.Windows.Forms.Padding(0)
        Me.Guna2HtmlLabel12.Name = "Guna2HtmlLabel12"
        Me.Guna2HtmlLabel12.Size = New System.Drawing.Size(7, 23)
        Me.Guna2HtmlLabel12.TabIndex = 132
        Me.Guna2HtmlLabel12.Text = ":"
        '
        'Guna2HtmlLabel11
        '
        Me.Guna2HtmlLabel11.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel11.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel11.Location = New System.Drawing.Point(174, 125)
        Me.Guna2HtmlLabel11.Margin = New System.Windows.Forms.Padding(0)
        Me.Guna2HtmlLabel11.Name = "Guna2HtmlLabel11"
        Me.Guna2HtmlLabel11.Size = New System.Drawing.Size(7, 23)
        Me.Guna2HtmlLabel11.TabIndex = 131
        Me.Guna2HtmlLabel11.Text = ":"
        '
        'Guna2HtmlLabel10
        '
        Me.Guna2HtmlLabel10.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel10.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel10.Location = New System.Drawing.Point(174, 90)
        Me.Guna2HtmlLabel10.Margin = New System.Windows.Forms.Padding(0)
        Me.Guna2HtmlLabel10.Name = "Guna2HtmlLabel10"
        Me.Guna2HtmlLabel10.Size = New System.Drawing.Size(7, 23)
        Me.Guna2HtmlLabel10.TabIndex = 130
        Me.Guna2HtmlLabel10.Text = ":"
        '
        'Guna2HtmlLabel9
        '
        Me.Guna2HtmlLabel9.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel9.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel9.Location = New System.Drawing.Point(174, 55)
        Me.Guna2HtmlLabel9.Margin = New System.Windows.Forms.Padding(0)
        Me.Guna2HtmlLabel9.Name = "Guna2HtmlLabel9"
        Me.Guna2HtmlLabel9.Size = New System.Drawing.Size(7, 23)
        Me.Guna2HtmlLabel9.TabIndex = 129
        Me.Guna2HtmlLabel9.Text = ":"
        '
        'Guna2HtmlLabel8
        '
        Me.Guna2HtmlLabel8.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel8.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel8.Location = New System.Drawing.Point(174, 20)
        Me.Guna2HtmlLabel8.Margin = New System.Windows.Forms.Padding(0)
        Me.Guna2HtmlLabel8.Name = "Guna2HtmlLabel8"
        Me.Guna2HtmlLabel8.Size = New System.Drawing.Size(7, 23)
        Me.Guna2HtmlLabel8.TabIndex = 128
        Me.Guna2HtmlLabel8.Text = ":"
        '
        'Guna2HtmlLabel3
        '
        Me.Guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel3.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel3.Location = New System.Drawing.Point(20, 160)
        Me.Guna2HtmlLabel3.Margin = New System.Windows.Forms.Padding(0, 0, 0, 16)
        Me.Guna2HtmlLabel3.Name = "Guna2HtmlLabel3"
        Me.Guna2HtmlLabel3.Size = New System.Drawing.Size(104, 23)
        Me.Guna2HtmlLabel3.TabIndex = 127
        Me.Guna2HtmlLabel3.Text = "Overdue Days"
        '
        'Guna2HtmlLabel5
        '
        Me.Guna2HtmlLabel5.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel5.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel5.Location = New System.Drawing.Point(20, 125)
        Me.Guna2HtmlLabel5.Margin = New System.Windows.Forms.Padding(0, 0, 0, 12)
        Me.Guna2HtmlLabel5.Name = "Guna2HtmlLabel5"
        Me.Guna2HtmlLabel5.Size = New System.Drawing.Size(72, 23)
        Me.Guna2HtmlLabel5.TabIndex = 125
        Me.Guna2HtmlLabel5.Text = "Issued By"
        '
        'Guna2HtmlLabel6
        '
        Me.Guna2HtmlLabel6.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel6.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel6.Location = New System.Drawing.Point(23, 90)
        Me.Guna2HtmlLabel6.Margin = New System.Windows.Forms.Padding(0, 0, 0, 12)
        Me.Guna2HtmlLabel6.Name = "Guna2HtmlLabel6"
        Me.Guna2HtmlLabel6.Size = New System.Drawing.Size(56, 23)
        Me.Guna2HtmlLabel6.TabIndex = 123
        Me.Guna2HtmlLabel6.Text = "Penalty"
        '
        'Guna2HtmlLabel7
        '
        Me.Guna2HtmlLabel7.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel7.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel7.Location = New System.Drawing.Point(23, 55)
        Me.Guna2HtmlLabel7.Margin = New System.Windows.Forms.Padding(0, 0, 0, 12)
        Me.Guna2HtmlLabel7.Name = "Guna2HtmlLabel7"
        Me.Guna2HtmlLabel7.Size = New System.Drawing.Size(119, 23)
        Me.Guna2HtmlLabel7.TabIndex = 121
        Me.Guna2HtmlLabel7.Text = "Borrower Name"
        '
        'Guna2HtmlLabel4
        '
        Me.Guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel4.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel4.Location = New System.Drawing.Point(1233, 134)
        Me.Guna2HtmlLabel4.Name = "Guna2HtmlLabel4"
        Me.Guna2HtmlLabel4.Size = New System.Drawing.Size(48, 23)
        Me.Guna2HtmlLabel4.TabIndex = 119
        Me.Guna2HtmlLabel4.Text = "Status"
        '
        'Guna2HtmlLabel2
        '
        Me.Guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel2.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel2.Location = New System.Drawing.Point(1170, 77)
        Me.Guna2HtmlLabel2.Name = "Guna2HtmlLabel2"
        Me.Guna2HtmlLabel2.Size = New System.Drawing.Size(114, 23)
        Me.Guna2HtmlLabel2.TabIndex = 117
        Me.Guna2HtmlLabel2.Text = "Borrowed Date"
        '
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(1214, 20)
        Me.Guna2HtmlLabel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(70, 23)
        Me.Guna2HtmlLabel1.TabIndex = 115
        Me.Guna2HtmlLabel1.Text = "Due Date"
        '
        'Guna2HtmlLabel27
        '
        Me.Guna2HtmlLabel27.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel27.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel27.Location = New System.Drawing.Point(20, 20)
        Me.Guna2HtmlLabel27.Margin = New System.Windows.Forms.Padding(0, 0, 0, 12)
        Me.Guna2HtmlLabel27.Name = "Guna2HtmlLabel27"
        Me.Guna2HtmlLabel27.Size = New System.Drawing.Size(145, 23)
        Me.Guna2HtmlLabel27.TabIndex = 113
        Me.Guna2HtmlLabel27.Text = "Circulation Number"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Guna2Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Guna2Panel2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Guna2Panel3, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1304, 697)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Guna2Panel3
        '
        Me.Guna2Panel3.Controls.Add(Me.DGBORROWEDCOPIES)
        Me.Guna2Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Guna2Panel3.Location = New System.Drawing.Point(0, 200)
        Me.Guna2Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Guna2Panel3.Name = "Guna2Panel3"
        Me.Guna2Panel3.Padding = New System.Windows.Forms.Padding(20, 0, 20, 0)
        Me.Guna2Panel3.Size = New System.Drawing.Size(1304, 437)
        Me.Guna2Panel3.TabIndex = 2
        '
        'DGBORROWEDCOPIES
        '
        Me.DGBORROWEDCOPIES.AllowUserToAddRows = False
        Me.DGBORROWEDCOPIES.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.DGBORROWEDCOPIES.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(181, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(181, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGBORROWEDCOPIES.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGBORROWEDCOPIES.ColumnHeadersHeight = 32
        Me.DGBORROWEDCOPIES.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.ColumnReturnCond, Me.ColumnBorrowedCond, Me.chckBoxBorrowCopies, Me.Column7, Me.Column5, Me.Column4, Me.ColumnBorrowedCondition, Me.Column2})
        Me.DGBORROWEDCOPIES.ContextMenuStrip = Me.DGBORROWEDCOPIESMENUSTRIP
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(239, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(205, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGBORROWEDCOPIES.DefaultCellStyle = DataGridViewCellStyle4
        Me.DGBORROWEDCOPIES.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGBORROWEDCOPIES.GridColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(201, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.DGBORROWEDCOPIES.Location = New System.Drawing.Point(20, 0)
        Me.DGBORROWEDCOPIES.Margin = New System.Windows.Forms.Padding(0)
        Me.DGBORROWEDCOPIES.Name = "DGBORROWEDCOPIES"
        Me.DGBORROWEDCOPIES.RowHeadersVisible = False
        Me.DGBORROWEDCOPIES.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DGBORROWEDCOPIES.RowTemplate.Height = 32
        Me.DGBORROWEDCOPIES.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGBORROWEDCOPIES.Size = New System.Drawing.Size(1264, 437)
        Me.DGBORROWEDCOPIES.TabIndex = 3
        Me.DGBORROWEDCOPIES.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Indigo
        Me.DGBORROWEDCOPIES.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.DGBORROWEDCOPIES.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.DGBORROWEDCOPIES.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.DGBORROWEDCOPIES.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.DGBORROWEDCOPIES.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.DGBORROWEDCOPIES.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.DGBORROWEDCOPIES.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(201, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.DGBORROWEDCOPIES.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.DGBORROWEDCOPIES.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DGBORROWEDCOPIES.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGBORROWEDCOPIES.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.DGBORROWEDCOPIES.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DGBORROWEDCOPIES.ThemeStyle.HeaderStyle.Height = 32
        Me.DGBORROWEDCOPIES.ThemeStyle.ReadOnly = False
        Me.DGBORROWEDCOPIES.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.DGBORROWEDCOPIES.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DGBORROWEDCOPIES.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGBORROWEDCOPIES.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black
        Me.DGBORROWEDCOPIES.ThemeStyle.RowsStyle.Height = 32
        Me.DGBORROWEDCOPIES.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.DGBORROWEDCOPIES.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black
        '
        'DGBORROWEDCOPIESMENUSTRIP
        '
        Me.DGBORROWEDCOPIESMENUSTRIP.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectAllToolStripMenuItem, Me.UnselectAllToolStripMenuItem, Me.ReturnAllToolStripMenuItem, Me.NoteToolStripMenuItem})
        Me.DGBORROWEDCOPIESMENUSTRIP.Name = "DGBORROWEDCOPIESMENUSTRIP"
        Me.DGBORROWEDCOPIESMENUSTRIP.Size = New System.Drawing.Size(157, 92)
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select All"
        '
        'UnselectAllToolStripMenuItem
        '
        Me.UnselectAllToolStripMenuItem.Name = "UnselectAllToolStripMenuItem"
        Me.UnselectAllToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.UnselectAllToolStripMenuItem.Text = "Unselect All"
        '
        'ReturnAllToolStripMenuItem
        '
        Me.ReturnAllToolStripMenuItem.Name = "ReturnAllToolStripMenuItem"
        Me.ReturnAllToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.ReturnAllToolStripMenuItem.Text = "Return Selected"
        '
        'NoteToolStripMenuItem
        '
        Me.NoteToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.ViewToolStripMenuItem})
        Me.NoteToolStripMenuItem.Name = "NoteToolStripMenuItem"
        Me.NoteToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.NoteToolStripMenuItem.Text = "Note"
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(99, 22)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(99, 22)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "id"
        Me.Column1.HeaderText = "id"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        '
        'ColumnReturnCond
        '
        Me.ColumnReturnCond.DataPropertyName = "returned_condition"
        Me.ColumnReturnCond.HeaderText = "return_cond"
        Me.ColumnReturnCond.Name = "ColumnReturnCond"
        Me.ColumnReturnCond.Visible = False
        '
        'ColumnBorrowedCond
        '
        Me.ColumnBorrowedCond.DataPropertyName = "borrowed_condition"
        Me.ColumnBorrowedCond.HeaderText = "borrow_cond"
        Me.ColumnBorrowedCond.Name = "ColumnBorrowedCond"
        Me.ColumnBorrowedCond.Visible = False
        '
        'chckBoxBorrowCopies
        '
        Me.chckBoxBorrowCopies.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.chckBoxBorrowCopies.HeaderText = ""
        Me.chckBoxBorrowCopies.Name = "chckBoxBorrowCopies"
        Me.chckBoxBorrowCopies.Width = 40
        '
        'Column7
        '
        Me.Column7.DataPropertyName = "accession_no"
        Me.Column7.HeaderText = "Accession Number"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.DataPropertyName = "title"
        Me.Column5.HeaderText = "Title"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "isbn"
        Me.Column4.HeaderText = "ISBN"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'ColumnBorrowedCondition
        '
        Me.ColumnBorrowedCondition.HeaderText = "Borrowed Condition"
        Me.ColumnBorrowedCondition.Name = "ColumnBorrowedCondition"
        Me.ColumnBorrowedCondition.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "returned_date"
        DataGridViewCellStyle3.NullValue = "Not Returned"
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column2.HeaderText = "Return Date"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'ReturnDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1304, 697)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ReturnDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Borrow Information"
        Me.Guna2Panel2.ResumeLayout(False)
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Guna2Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Guna2Panel3.ResumeLayout(False)
        CType(Me.DGBORROWEDCOPIES, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DGBORROWEDCOPIESMENUSTRIP.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Guna2Panel2 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2HtmlLabel3 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel5 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel6 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel7 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel4 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel2 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel27 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Guna2HtmlLabel12 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel11 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel10 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel9 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel8 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents LBLOVERDUEDAYS As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents LBLISSUEDBY As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents LBLPENALTY As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents LBLBORROWER As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents LBLCIRCULATION As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents LBLSTATUS As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents LBLBORROWDATE As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents LBLDUEDATE As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2Panel3 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents BTNSAVE As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents DGBORROWEDCOPIES As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents DGBORROWEDCOPIESMENUSTRIP As ContextMenuStrip
    Friend WithEvents SelectAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UnselectAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReturnAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NoteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents ColumnReturnCond As DataGridViewTextBoxColumn
    Friend WithEvents ColumnBorrowedCond As DataGridViewTextBoxColumn
    Friend WithEvents chckBoxBorrowCopies As DataGridViewCheckBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents ColumnBorrowedCondition As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
End Class
