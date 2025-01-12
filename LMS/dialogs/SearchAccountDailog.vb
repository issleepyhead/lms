Imports System.Windows.Forms

Public Class SearchAccountDailog
    Private ReadOnly _window As BorrowDialog

    Sub New()
        InitializeComponent()
    End Sub

    Sub New(window As BorrowDialog)
        InitializeComponent()
        _window = window
    End Sub

    Private Sub SearchAccountDailog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _window.RBSTUDENT.Checked Then
            DGACCOUNT.DataSource = FetchStudentBorrower()
        Else
            DGACCOUNT.DataSource = FetchFacultyBorrower()
        End If

        For Each col As DataGridViewColumn In DGACCOUNT.Columns
            col.ReadOnly = True
            col.DefaultCellStyle.NullValue = "None"
            If col.HeaderText = "id" Then
                col.Visible = False
            End If
        Next
    End Sub

    Private Sub DGACCOUNT_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGACCOUNT.CellClick
        Dim bound As DataRowView = TryCast(DGACCOUNT.Rows(e.RowIndex).DataBoundItem, DataRowView)
        If _window.RBSTUDENT.Checked Then
            _window.TXTSTUDENTLRN.Text = bound.Row.Item("Student No.")
        Else
            _window.CMBFACULTY.SelectedValue = bound.Row.Item("id")
        End If
        Close()
    End Sub
End Class
