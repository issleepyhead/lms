<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SearchBooksDialog
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.TXTBOOKSEARCH = New Guna.UI2.WinForms.Guna2TextBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Guna2Panel2 = New Guna.UI2.WinForms.Guna2Panel()
        Me.DGBOOKS = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Guna2Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Guna2Panel2.SuspendLayout()
        CType(Me.DGBOOKS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.Controls.Add(Me.TXTBOOKSEARCH)
        Me.Guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Guna2Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Padding = New System.Windows.Forms.Padding(20, 0, 20, 0)
        Me.Guna2Panel1.Size = New System.Drawing.Size(922, 60)
        Me.Guna2Panel1.TabIndex = 0
        '
        'TXTBOOKSEARCH
        '
        Me.TXTBOOKSEARCH.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TXTBOOKSEARCH.BorderColor = System.Drawing.Color.Gray
        Me.TXTBOOKSEARCH.BorderRadius = 4
        Me.TXTBOOKSEARCH.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TXTBOOKSEARCH.DefaultText = ""
        Me.TXTBOOKSEARCH.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.TXTBOOKSEARCH.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TXTBOOKSEARCH.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TXTBOOKSEARCH.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TXTBOOKSEARCH.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TXTBOOKSEARCH.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.TXTBOOKSEARCH.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TXTBOOKSEARCH.IconRight = Global.LMS.My.Resources.Resources.search
        Me.TXTBOOKSEARCH.IconRightOffset = New System.Drawing.Point(8, 0)
        Me.TXTBOOKSEARCH.Location = New System.Drawing.Point(644, 10)
        Me.TXTBOOKSEARCH.Margin = New System.Windows.Forms.Padding(0)
        Me.TXTBOOKSEARCH.MaxLength = 15
        Me.TXTBOOKSEARCH.Name = "TXTBOOKSEARCH"
        Me.TXTBOOKSEARCH.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TXTBOOKSEARCH.PlaceholderText = "Search Book Copy"
        Me.TXTBOOKSEARCH.SelectedText = ""
        Me.TXTBOOKSEARCH.ShortcutsEnabled = False
        Me.TXTBOOKSEARCH.Size = New System.Drawing.Size(258, 40)
        Me.TXTBOOKSEARCH.TabIndex = 7
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Guna2Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Guna2Panel2, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(922, 545)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'Guna2Panel2
        '
        Me.Guna2Panel2.Controls.Add(Me.DGBOOKS)
        Me.Guna2Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Guna2Panel2.Location = New System.Drawing.Point(0, 60)
        Me.Guna2Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Guna2Panel2.Name = "Guna2Panel2"
        Me.Guna2Panel2.Padding = New System.Windows.Forms.Padding(20)
        Me.Guna2Panel2.Size = New System.Drawing.Size(922, 485)
        Me.Guna2Panel2.TabIndex = 1
        '
        'DGBOOKS
        '
        Me.DGBOOKS.AllowUserToAddRows = False
        Me.DGBOOKS.AllowUserToDeleteRows = False
        Me.DGBOOKS.AllowUserToResizeColumns = False
        Me.DGBOOKS.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.DGBOOKS.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGBOOKS.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(181, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGBOOKS.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGBOOKS.ColumnHeadersHeight = 48
        Me.DGBOOKS.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column3, Me.Column4})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(239, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(205, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGBOOKS.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGBOOKS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGBOOKS.GridColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(201, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.DGBOOKS.Location = New System.Drawing.Point(20, 20)
        Me.DGBOOKS.Margin = New System.Windows.Forms.Padding(0)
        Me.DGBOOKS.Name = "DGBOOKS"
        Me.DGBOOKS.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.DGBOOKS.RowHeadersVisible = False
        Me.DGBOOKS.RowTemplate.Height = 48
        Me.DGBOOKS.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGBOOKS.Size = New System.Drawing.Size(882, 445)
        Me.DGBOOKS.TabIndex = 1
        Me.DGBOOKS.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Indigo
        Me.DGBOOKS.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.DGBOOKS.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.DGBOOKS.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.DGBOOKS.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.DGBOOKS.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.DGBOOKS.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.DGBOOKS.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(201, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.DGBOOKS.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.DGBOOKS.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.DGBOOKS.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGBOOKS.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.DGBOOKS.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DGBOOKS.ThemeStyle.HeaderStyle.Height = 48
        Me.DGBOOKS.ThemeStyle.ReadOnly = False
        Me.DGBOOKS.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.DGBOOKS.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DGBOOKS.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGBOOKS.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black
        Me.DGBOOKS.ThemeStyle.RowsStyle.Height = 48
        Me.DGBOOKS.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.DGBOOKS.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "id"
        Me.Column1.HeaderText = "id"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column1.Visible = False
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "accession_no"
        Me.Column3.HeaderText = "Accession No."
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "title"
        Me.Column4.HeaderText = "Title"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'SearchBooksDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(922, 545)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SearchBooksDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Search Books"
        Me.Guna2Panel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Guna2Panel2.ResumeLayout(False)
        CType(Me.DGBOOKS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents TXTBOOKSEARCH As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Guna2Panel2 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents DGBOOKS As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
End Class
