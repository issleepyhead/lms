Imports System.Windows.Forms
Imports LMS.My

Public Class ImportBookDialog
    Private path As String
    Private Sub BTNSELECTFILE_Click(sender As Object, e As EventArgs) Handles BTNSELECTFILE.Click
        Using dialog As New OpenFileDialog
            If dialog.ShowDialog = DialogResult.OK Then
                path = dialog.FileName
                TXTPATH.Text = path
            End If
        End Using
    End Sub

    Private Sub BTNPREVIEW_Click(sender As Object, e As EventArgs) Handles BTNPREVIEW.Click
        DGBOOK.DataSource = ReadData(path).Item("genres")
    End Sub

    Private Sub ImportBookDialog_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not String.IsNullOrEmpty(path) OrElse Not IsNothing(DGBOOK.DataSource) Then
            If MessageBox.Show("Are you sure you want to discard changes?", "Discard Changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                MyApplication.DialogInstances.Remove("importbook")
            Else
                e.Cancel = True
            End If
        End If
    End Sub
End Class
