Public Class ControlMapping
    Property QUERY_TYPE As QueryType
    Property DG As Guna.UI2.WinForms.Guna2DataGridView
    Property LBLPREV As Guna.UI2.WinForms.Guna2HtmlLabel
    Property LBLNEXT As Guna.UI2.WinForms.Guna2HtmlLabel
    Property TXTSEARCH As Guna.UI2.WinForms.Guna2TextBox
    Property DIALOG_NAME As Type

    Public Sub OpenDialog(Optional filter As STATUSTYPE = STATUSTYPE.ACTIVE)
        Using dialog As Form = Activator.CreateInstance(DIALOG_NAME)
            dialog.ShowDialog()
            Me.Update(filter)
        End Using
    End Sub

    Public Sub Update(Optional filter As STATUSTYPE = STATUSTYPE.ACTIVE)
        DBOperations.QUERY_SEARCH = TXTSEARCH.Text
        If filter = STATUSTYPE.INACTIVE Then
            DG.DataSource = DBOperations.SearchArchive(QUERY_TYPE)
        Else
            DG.DataSource = DBOperations.Search(QUERY_TYPE)
        End If
        LBLNEXT.Text = DBOperations.NEXT_PAGE_NUMBER
        LBLPREV.Text = DBOperations.PREV_PAGE_NUMBER
    End Sub

    Public Sub NextPage(Optional filter As STATUSTYPE = STATUSTYPE.ACTIVE, Optional CallBack As Action = Nothing)
        If DBOperations.PREV_PAGE_NUMBER < DBOperations.NEXT_PAGE_NUMBER Then
            DBOperations.PREV_PAGE_NUMBER += 1
            Me.Update(filter)
            If Not IsNothing(CallBack) Then
                CallBack.Invoke()
            End If
        End If
    End Sub

    Public Sub PrevPage(Optional filter As STATUSTYPE = STATUSTYPE.ACTIVE, Optional CallBack As Action = Nothing)
        If DBOperations.PREV_PAGE_NUMBER > 1 Then
            DBOperations.PREV_PAGE_NUMBER -= 1
            Me.Update(filter)
            If Not IsNothing(CallBack) Then
                CallBack.Invoke()
            End If
        End If
    End Sub

    Public Sub CellClick(e As DataGridViewCellEventArgs, Optional filter As STATUSTYPE = STATUSTYPE.ACTIVE)
        If e.ColumnIndex <> 0 AndAlso e.RowIndex <> -1 Then
            If DG.SelectedRows.Count > 0 Then
                Dim datarow As DataRowView = DG.SelectedRows.Item(0).DataBoundItem
                Using dialog As Form = Activator.CreateInstance(DIALOG_NAME, datarow)
                    dialog.ShowDialog()
                    Me.Update(filter)
                End Using
            End If
        End If
    End Sub
End Class
