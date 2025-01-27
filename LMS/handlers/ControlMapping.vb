Public Class ControlMapping

    Private Delegate Sub UpdateHandler()
    Private Event UpdateEvent As UpdateHandler

    Property QUERY_TYPE As QueryType
    Property DG As Guna.UI2.WinForms.Guna2DataGridView
    Property LBLPREV As Guna.UI2.WinForms.Guna2HtmlLabel
    Property LBLNEXT As Guna.UI2.WinForms.Guna2HtmlLabel
    Property TXTSEARCH As Guna.UI2.WinForms.Guna2TextBox
    Property DIALOG_NAME As Type

    Public Sub OpenDialog(Optional CallBack As Action = Nothing)
        Using dialog As Form = Activator.CreateInstance(DIALOG_NAME)
            dialog.ShowDialog()
            If Not IsNothing(CallBack) Then
                CallBack.Invoke()
            Else
                RaiseEvent UpdateEvent()
            End If
        End Using
    End Sub

    Public Sub Upate(Optional filter As STATUSTYPE = STATUSTYPE.ACTIVE) Handles Me.UpdateEvent
        DBOperations.QUERY_SEARCH = TXTSEARCH.Text
        If filter = STATUSTYPE.INACTIVE Then
            DG.DataSource = DBOperations.SearchArchive(QUERY_TYPE)
        Else
            DG.DataSource = DBOperations.Search(QUERY_TYPE)
        End If
        LBLNEXT.Text = DBOperations.NEXT_PAGE_NUMBER
        LBLPREV.Text = DBOperations.PREV_PAGE_NUMBER
    End Sub

    Public Sub NextPage(Optional CallBack As Action = Nothing)
        If DBOperations.PREV_PAGE_NUMBER < DBOperations.NEXT_PAGE_NUMBER Then
            DBOperations.PREV_PAGE_NUMBER += 1
            If Not IsNothing(CallBack) Then
                CallBack.Invoke()
            Else
                RaiseEvent UpdateEvent()
            End If

        End If
    End Sub

    Public Sub PrevPage(Optional CallBack As Action = Nothing)
        If DBOperations.PREV_PAGE_NUMBER > 1 Then
            DBOperations.PREV_PAGE_NUMBER -= 1
            If Not IsNothing(CallBack) Then
                CallBack.Invoke()
            Else
                RaiseEvent UpdateEvent()
            End If
        End If
    End Sub

    Public Sub CellClick(e As DataGridViewCellEventArgs, Optional CallBack As Action = Nothing)
        If e.ColumnIndex <> 0 AndAlso e.RowIndex <> -1 Then
            If DG.SelectedRows.Count > 0 Then
                Dim datarow As DataRowView = DG.SelectedRows.Item(0).DataBoundItem
                Using dialog As Form = Activator.CreateInstance(DIALOG_NAME, datarow)
                    dialog.ShowDialog()
                    If Not IsNothing(CallBack) Then
                        CallBack.Invoke()
                    Else
                        RaiseEvent UpdateEvent()
                    End If
                End Using
            End If
        End If
    End Sub
End Class
