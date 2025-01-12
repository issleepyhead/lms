Imports System.Windows.Forms

Public Class ViewBooksDialog
    Private _window As BorrowDialog
    Sub New()
        InitializeComponent()
    End Sub

    Sub New(window As BorrowDialog)
        InitializeComponent()
        _window = window
    End Sub


End Class
