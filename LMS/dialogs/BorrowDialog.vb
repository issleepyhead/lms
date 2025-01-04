Imports System.Windows.Forms
Imports LMS.My

Public Class BorrowDialog
    Private Sub BorrowDialog_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not String.IsNullOrEmpty(TXTSTUDENTLRN.Text) OrElse CMBFACULTY.SelectedIndex <> -1 Then
            If MessageBox.Show("Are you sure you want to discard changes?", "Discard Changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                MyApplication.DialogInstances.Remove("borrowdialog")
            Else
                e.Cancel = True
            End If
        Else
            MyApplication.DialogInstances.Remove("borrowdialog")
        End If
    End Sub
End Class
