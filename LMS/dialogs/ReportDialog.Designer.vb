<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReportDialog
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
        Me.RPViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'RPViewer
        '
        Me.RPViewer.ActiveViewIndex = -1
        Me.RPViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RPViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.RPViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RPViewer.Location = New System.Drawing.Point(0, 0)
        Me.RPViewer.Name = "RPViewer"
        Me.RPViewer.Size = New System.Drawing.Size(1253, 687)
        Me.RPViewer.TabIndex = 0
        '
        'ReportDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1253, 687)
        Me.Controls.Add(Me.RPViewer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ReportDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "View Report"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents RPViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
