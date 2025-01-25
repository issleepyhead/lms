Public Class ControlMapping

    Private Delegate Sub UpdateHandler()
    Private Event UpdateEvent As UpdateHandler

    Property QUERY_TYPE As QueryType
    Property DG As Guna.UI2.WinForms.Guna2DataGridView
    Property LBLPREV As Guna.UI2.WinForms.Guna2HtmlLabel
    Property LBLNEXT As Guna.UI2.WinForms.Guna2HtmlLabel
    Property TXTSEARCH As Guna.UI2.WinForms.Guna2TextBox
    Property DIALOG_NAME As Type

    Public Sub OpenDialog()
        Using dialog As Form = Activator.CreateInstance(DIALOG_NAME)
            dialog.ShowDialog()
            RaiseEvent UpdateEvent()
        End Using
    End Sub

    Public Sub Upate() Handles Me.UpdateEvent
        DBOperations.QUERY_SEARCH = TXTSEARCH.Text
        DG.DataSource = DBOperations.Search(QUERY_TYPE)
        LBLNEXT.Text = DBOperations.NEXT_PAGE_NUMBER
        LBLPREV.Text = DBOperations.PREV_PAGE_NUMBER
    End Sub

    Public Sub NextPage(Optional CallBack As Action = Nothing)
        If DBOperations.PREV_PAGE_NUMBER < DBOperations.NEXT_PAGE_NUMBER Then
            DBOperations.PREV_PAGE_NUMBER += 1
            If Not IsNothing(CallBack) Then
                CallBack.Invoke()
            End If
            RaiseEvent UpdateEvent()
        End If
    End Sub

    Public Sub PrevPage(Optional CallBack As Action = Nothing)
        If DBOperations.PREV_PAGE_NUMBER > 1 Then
            DBOperations.PREV_PAGE_NUMBER -= 1
            If Not IsNothing(CallBack) Then
                CallBack.Invoke()
            End If
            RaiseEvent UpdateEvent()
        End If
    End Sub
End Class
