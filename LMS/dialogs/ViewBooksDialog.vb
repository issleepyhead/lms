Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class ViewBooksDialog
    Private Class BookCopy
        Public Property id As Integer
        Public Property title As String
        Public Property accession_no As String
    End Class
    Private _window As BorrowDialog
    Private bindingList As New BindingList(Of BookCopy)
    Sub New()
        InitializeComponent()
    End Sub

    Sub New(window As BorrowDialog)
        InitializeComponent()
        _window = window
    End Sub

    Private Sub ViewBooksDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DGBOOKS.DataSource = bindingList
        For Each item In _window.bookListData
            bindingList.Add(New BookCopy With {.id = item.Item("id"), .title = item.Item("title"), .accession_no = item.Item("accession_no")})
        Next
        bindingList.ResetBindings()
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        For Each item As DataGridViewRow In DGBOOKS.Rows
            item.Cells(NameOf(chckBoxCopy)).Value = True
        Next
        DGBOOKS.EndEdit()
    End Sub

    Private Sub UnselectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnselectAllToolStripMenuItem.Click
        For Each item As DataGridViewRow In DGBOOKS.Rows
            item.Cells(NameOf(chckBoxCopy)).Value = False
        Next
        DGBOOKS.EndEdit()
    End Sub

    Private Sub RemoveSelectedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveAllToolStripMenuItem.Click
        DGBOOKS.EndEdit()
        For Each row As DataGridViewRow In DGBOOKS.Rows
            If CBool(row.Cells(NameOf(chckBoxCopy)).Value) Then
                Dim rm As BookCopy = Nothing
                Dim id As Integer = row.Cells(NameOf(ColumnBookID)).Value
                For Each item In bindingList
                    If item.id = id Then
                        rm = item
                        Exit For
                    End If
                Next
                bindingList.Remove(rm)

                Dim drrm As DataRow = Nothing
                For Each drow As DataRow In _window.bookListData
                    If drow.Item("id") = id Then
                        drrm = drow
                        Exit For
                    End If
                Next
                _window.bookListData.Remove(drrm)
            End If
        Next
        bindingList.ResetBindings()
    End Sub

    Private Sub TXTBOOKSEARCH_TextChanged(sender As Object, e As EventArgs) Handles TXTBOOKSEARCH.TextChanged
        If Not String.IsNullOrEmpty(TXTBOOKSEARCH.Text) Then
            Dim res As New ObservableCollection(Of BookCopy)
            For Each item As BookCopy In bindingList
                If item.accession_no = TXTBOOKSEARCH.Text OrElse item.title.ToLower() = TXTBOOKSEARCH.Text.ToLower Then
                    res.Add(item)
                End If
            Next
            DGBOOKS.DataSource = res
        Else
            DGBOOKS.DataSource = bindingList
        End If
    End Sub
End Class
