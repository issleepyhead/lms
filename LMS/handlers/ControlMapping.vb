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

    Public Sub Update(filter As TRANSACTIONSTATE, Optional sdate As Date = Nothing, Optional edate As Date = Nothing)
        DBOperations.QUERY_SEARCH = TXTSEARCH.Text
        DBOperations.ADVANCE_SEARCH_QUERIES = New Dictionary(Of String, String) From {
            {"@stat", filter}
        }

        If sdate = Date.MinValue Then
            DG.DataSource = DBOperations.Search(QUERY_TYPE)
        Else
            ADVANCE_SEARCH_QUERIES.Add("@sdate", sdate.ToString("yyyy-MM-dd"))
            ADVANCE_SEARCH_QUERIES.Add("@edate", edate.ToString("yyyy-MM-dd"))
            DG.DataSource = DBOperations.AdvanceSearch(QUERY_TYPE)
        End If
        LBLNEXT.Text = DBOperations.NEXT_PAGE_NUMBER
        LBLPREV.Text = DBOperations.PREV_PAGE_NUMBER
    End Sub

    'Private Sub GetCMBName()
    '    For Each item As DataGridViewColumn In DG.Columns
    '        If item.GetType() Is GetType(DataGridViewCheckBoxColumn) Then
    '            'CHECKBOX_NAME = item.Name
    '        End If
    '    Next
    'End Sub

    Public Sub Delete(action As Action(Of List(Of Dictionary(Of String, String)), QueryType))
        DG.EndEdit()
        Dim cboxName As String = Nothing
        Dim cellName As String = Nothing
        Dim params As New List(Of Dictionary(Of String, String))

        For Each item As DataGridViewColumn In DG.Columns
            If item.GetType() Is GetType(DataGridViewCheckBoxColumn) Then
                cboxName = item.Name
            End If

            If item.DataPropertyName = "id" Then
                cellName = item.Name
            End If
        Next

        For Each data As DataGridViewRow In DG.Rows
            If data.Cells(cboxName).Value Then
                Dim temp As New Dictionary(Of String, String) From {
                    {"@id", data.Cells(cellName).Value.ToString}
                }
                params.Add(temp)
            End If
        Next

        If Not IsNothing(action) Then
            action.Invoke(params, QUERY_TYPE)
        End If

        Update()
    End Sub
End Class
