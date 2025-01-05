<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PublisherDialog
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
        Me.TXTPUBLISHERNAME = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
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
        Me.Guna2HtmlLabel3.Location = New System.Drawing.Point(141, 20)
        Me.Guna2HtmlLabel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Guna2HtmlLabel3.Name = "Guna2HtmlLabel3"
        Me.Guna2HtmlLabel3.Size = New System.Drawing.Size(10, 23)
        Me.Guna2HtmlLabel3.TabIndex = 12
        Me.Guna2HtmlLabel3.TabStop = False
        Me.Guna2HtmlLabel3.Text = "*"
        '
        'TXTPUBLISHERNAME
        '
        Me.TXTPUBLISHERNAME.BorderColor = System.Drawing.Color.Gray
        Me.TXTPUBLISHERNAME.BorderRadius = 4
        Me.TXTPUBLISHERNAME.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TXTPUBLISHERNAME.DefaultText = ""
        Me.TXTPUBLISHERNAME.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.TXTPUBLISHERNAME.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TXTPUBLISHERNAME.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TXTPUBLISHERNAME.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TXTPUBLISHERNAME.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TXTPUBLISHERNAME.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.TXTPUBLISHERNAME.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TXTPUBLISHERNAME.Location = New System.Drawing.Point(20, 47)
        Me.TXTPUBLISHERNAME.Margin = New System.Windows.Forms.Padding(0, 0, 0, 16)
        Me.TXTPUBLISHERNAME.MaxLength = 45
        Me.TXTPUBLISHERNAME.Name = "TXTPUBLISHERNAME"
        Me.TXTPUBLISHERNAME.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TXTPUBLISHERNAME.PlaceholderText = "e.g., ACME Publisher."
        Me.TXTPUBLISHERNAME.SelectedText = ""
        Me.TXTPUBLISHERNAME.Size = New System.Drawing.Size(306, 47)
        Me.TXTPUBLISHERNAME.TabIndex = 1
        '
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(20, 20)
        Me.Guna2HtmlLabel1.Margin = New System.Windows.Forms.Padding(0, 0, 0, 4)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(121, 23)
        Me.Guna2HtmlLabel1.TabIndex = 10
        Me.Guna2HtmlLabel1.TabStop = False
        Me.Guna2HtmlLabel1.Text = "Publisher Name:"
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
        Me.BTNSAVE.Location = New System.Drawing.Point(198, 110)
        Me.BTNSAVE.Margin = New System.Windows.Forms.Padding(0)
        Me.BTNSAVE.Name = "BTNSAVE"
        Me.BTNSAVE.Size = New System.Drawing.Size(128, 40)
        Me.BTNSAVE.TabIndex = 2
        Me.BTNSAVE.Text = "Save"
        '
        'errProvider
        '
        Me.errProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.errProvider.ContainerControl = Me
        '
        'PublisherDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(346, 160)
        Me.Controls.Add(Me.BTNSAVE)
        Me.Controls.Add(Me.Guna2HtmlLabel3)
        Me.Controls.Add(Me.TXTPUBLISHERNAME)
        Me.Controls.Add(Me.Guna2HtmlLabel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PublisherDialog"
        Me.Padding = New System.Windows.Forms.Padding(20, 20, 20, 10)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Publisher Form"
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Guna2HtmlLabel3 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents TXTPUBLISHERNAME As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents BTNSAVE As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents errProvider As ErrorProvider
End Class
