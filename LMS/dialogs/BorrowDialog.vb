Imports System.Windows.Forms
Imports LMS.My

Public Class BorrowDialog
    Public bookList As New List(Of Dictionary(Of String, String))
    Private Sub BorrowDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim fborrower As DataTable = FetchFacultyBorrower()
        Dim newRow As DataRow = fborrower.NewRow()
        newRow("id") = 0
        newRow("Full Name") = "None"
        fborrower.Rows.InsertAt(newRow, 0)
        CMBFACULTY.DataSource = fborrower
    End Sub

    Private Sub BorrowDialog_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not String.IsNullOrEmpty(TXTSTUDENTLRN.Text) OrElse CMBFACULTY.SelectedIndex <> -1 Then
            If MessageBox.Show("Are you sure you want to discard changes?", "Discard Changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                MyApplication.DialogInstances.Remove(NameOf(BorrowDialog))
            Else
                e.Cancel = True
            End If
        Else
            MyApplication.DialogInstances.Remove(NameOf(BorrowDialog))
        End If
    End Sub

    Private Sub RBSTUDENT_CheckedChanged(sender As Object, e As EventArgs) Handles RBSTUDENT.CheckedChanged
        If sender.Checked Then
            LBLSTUDENTREQUIRED.Visible = True
            TXTSTUDENTLRN.Enabled = True
            BTNSEARCHSTUDENT.Enabled = True
            LBLFACULTYREQUIRED.Visible = False
            CMBFACULTY.Enabled = False
            BTNSEARCHFACULTY.Enabled = False
        Else
            TXTSTUDENTLRN.Clear()
            LBLSTUDENTREQUIRED.Visible = False
            TXTSTUDENTLRN.Enabled = False
            BTNSEARCHSTUDENT.Enabled = False
            LBLFACULTYREQUIRED.Visible = True
            CMBFACULTY.Enabled = True
            BTNSEARCHFACULTY.Enabled = True
        End If
    End Sub

    Private Sub RBFACULTY_CheckedChanged(sender As Object, e As EventArgs) Handles RBFACULTY.CheckedChanged
        If sender.Checked Then
            LBLFACULTYREQUIRED.Visible = True
            CMBFACULTY.Enabled = True
            BTNSEARCHFACULTY.Enabled = True
        Else
            LBLFACULTYREQUIRED.Visible = False
            CMBFACULTY.Enabled = False
            BTNSEARCHFACULTY.Enabled = False
        End If
    End Sub

    Private Sub BTNSEARCHSTUDENT_Click(sender As Object, e As EventArgs) Handles BTNSEARCHSTUDENT.Click
        Using dialog As New SearchAccountDailog(Me)
            dialog.ShowDialog()
        End Using
    End Sub

    Private Sub BTNSEARCHFACULTY_Click(sender As Object, e As EventArgs) Handles BTNSEARCHFACULTY.Click
        Using dialog As New SearchAccountDailog(Me)
            dialog.ShowDialog()
        End Using
    End Sub

    Private Sub BTNBORROWBOOKS_Click(sender As Object, e As EventArgs) Handles BTNBORROWBOOKS.Click
        If RBSTUDENT.Checked Then
            If CheckStudent(TXTSTUDENTLRN.Text) > 0 Then
                MsgBox("exists!")
            Else
                MsgBox("doesnt")
            End If
        Else
            If CMBFACULTY.SelectedValue = 0 Then
                MsgBox("Choose a faculty")
            Else
                MsgBox("passed")
            End If
        End If
    End Sub

    Private Sub BTNSEARCHBOOKS_Click(sender As Object, e As EventArgs) Handles BTNSEARCHBOOKS.Click
        Using dialog As New SearchBooksDialog(Me)
            dialog.ShowDialog()
        End Using
    End Sub

    Private Sub BTNADDBOOKS_Click(sender As Object, e As EventArgs) Handles BTNADDBOOKS.Click
        Using dialog As New ViewBooksDialog(Me)

        End Using
    End Sub
End Class
