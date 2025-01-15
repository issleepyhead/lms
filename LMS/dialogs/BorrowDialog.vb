Imports System.Windows.Forms
Imports LMS.My

Public Class BorrowDialog
    Public bookListData As New List(Of DataRow)
    Public sid As Integer = 0 ' student id lol!
    Private Sub BorrowDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim fborrower As DataTable = FetchFacultyBorrower()
        Dim newRow As DataRow = fborrower.NewRow()
        newRow("id") = 0
        newRow("Full Name") = "None"
        fborrower.Rows.InsertAt(newRow, 0)
        CMBFACULTY.DataSource = fborrower
    End Sub

    Private Sub BorrowDialog_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not String.IsNullOrEmpty(TXTSTUDENTLRN.Text) OrElse CMBFACULTY.SelectedIndex <> 0 OrElse bookListData.Count > 0 Then
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
            sid = 0
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
            CMBFACULTY.SelectedValue = 0
            BTNSEARCHFACULTY.Enabled = False
            sid = 0
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
        If bookListData.Count = 0 Then
            MessageBox.Show("No items in the borrow list." & vbLf & "Please add book copies in the borrow list first.", "Empty Borrow List!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim header As New Dictionary(Of String, String) From {
            {"@isby", My.Settings.user_id},
            {"@cno", GenerateCirculation()},
            {"@odate", DateTime.Now.AddDays(5).ToString("yyyy-MM-dd HH:mm:ss")},
            {"@bdate", Date.Now.ToString("yyyy-MM-dd HH:mm:ss")}
        }

        If RBSTUDENT.Checked Then
            If CheckStudent(TXTSTUDENTLRN.Text) > 0 Then
                header.Add("@sid", sid)
                header.Add("@fid", String.Empty)
            Else
                MessageBox.Show("Account not found." & vbLf & "Please check your details and try again.", "Account Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        Else
            If CMBFACULTY.SelectedValue = 0 Then
                MessageBox.Show("Please select a faculty.", "No Faculty Selected!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                header.Add("@sid", String.Empty)
                header.Add("@fid", CMBFACULTY.SelectedValue)
            End If
        End If

        Dim copies As New List(Of Dictionary(Of String, String))
        For Each item As DataRow In bookListData
            copies.Add(New Dictionary(Of String, String) From {{"@cid", item.Item("id")}})
        Next

        If InsertBorrow(header, copies) Then
            MessageBox.Show("Books have been successfully borrowed.", "Borrowing Complete!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            bookListData.Clear()
            sid = 0
            TXTSTUDENTLRN.Clear()
            CMBFACULTY.SelectedValue = 0
            Close()
        Else
            MessageBox.Show("An error occured please try again.", "Borrowing Failed!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub BTNSEARCHBOOKS_Click(sender As Object, e As EventArgs) Handles BTNSEARCHBOOKS.Click
        Using dialog As New SearchBooksDialog(Me)
            dialog.ShowDialog()
        End Using
    End Sub

    Private Sub BTNADDBOOKS_Click(sender As Object, e As EventArgs) Handles BTNADDBOOKS.Click
        Using dialog As New ViewBooksDialog(Me)
            dialog.ShowDialog()
        End Using
    End Sub

    Private Sub TXTISBN_TextChanged(sender As Object, e As EventArgs) Handles TXTISBN.TextChanged
        If TXTISBN.Text.Length = 10 Then
            Dim dt As DataTable = SearchBooksAccession(TXTISBN.Text)
            If dt.Rows.Count > 0 Then
                bookListData.Add(dt.Rows.Item(0))
                TXTISBN.Clear()
            Else
                MessageBox.Show("The book copy you are attempting to borrow is either unavailable or doesn't exists.", "Not found!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub
End Class
