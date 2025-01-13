Imports System.Windows.Forms

Public Class SearchBooksDialog
    Private _window As BorrowDialog
    Sub New()
        InitializeComponent()
    End Sub

    Sub New(window As BorrowDialog)
        InitializeComponent()
        _window = window
    End Sub

    Private Sub SearchBooksDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DGBOOKS.DataSource = SearchBooksCopies(TXTBOOKSEARCH.Text)

        For Each col As DataGridViewColumn In DGBOOKS.Columns
            col.ReadOnly = True
            col.DefaultCellStyle.NullValue = "None"
            If col.HeaderText = "id" Then
                col.Visible = False
            End If
        Next
    End Sub

    Private Sub TXTBOOKSEARCH_TextChanged(sender As Object, e As EventArgs) Handles TXTBOOKSEARCH.TextChanged
        Validator.NotAllowed(sender, ALPHANUMERIC_PATTERN)
        DGBOOKS.DataSource = SearchBooksCopies(TXTBOOKSEARCH.Text)
    End Sub

    Private Sub DGBOOKS_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGBOOKS.CellClick
        If e.RowIndex <> -1 Then
            Dim boundItem As DataRowView = TryCast(DGBOOKS.Rows(e.RowIndex).DataBoundItem, DataRowView)
            Dim exists As Boolean = False
            For Each item In _window.bookListData
                If item.Item("title") = boundItem.Row.Item("title") Then
                    exists = True
                End If
            Next

            If Not exists Then
                _window.bookListData.Add(boundItem.Row)
                Close()
            Else
                MessageBox.Show("You can only borrow one copy of this book.", "Book Exists", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub
End Class
