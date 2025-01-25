Imports LMS.My
Imports LMS.QueryType

Public Class DashboardForm

    Private SELECTED_BOOKS As New SystemDataSets.DTBookDataTable
    Private SELECTED_STUDENTS As New SystemDataSets.DTStudentDataTable
    Private SELECTED_FACULTY As New SystemDataSets.DTFacultyDataTable
    Private ControlsMap As Dictionary(Of String, ControlMapping)

    Private Sub DashboardForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ControlsMap = New Dictionary(Of String, ControlMapping) From {
            {NameOf(GENRE), New ControlMapping With {.DG = DGGENRE, .LBLNEXT = LBLGENRENEXT, .LBLPREV = LBLGENREPREV, .TXTSEARCH = TXTGENRESEARCH, .DIALOG_NAME = GenreDialog.GetType(), .QUERY_TYPE = GENRE}},
            {NameOf(AUTHOR), New ControlMapping With {.DG = DGAUTHORS, .LBLNEXT = LBLAUTHORNEXT, .LBLPREV = LBLAUTHORPREV, .TXTSEARCH = TXTSEARCHAUTHOR, .DIALOG_NAME = AuthorDialog.GetType(), .QUERY_TYPE = AUTHOR}},
            {NameOf(PUBLISHER), New ControlMapping With {.DG = DGPUBLISHER, .LBLNEXT = LBLPUBLISHERNEXT, .LBLPREV = LBLPUBLISHERPREV, .TXTSEARCH = TXTPUBLISHERSEARCH, .DIALOG_NAME = PublisherDialog.GetType(), .QUERY_TYPE = PUBLISHER}},
            {NameOf(CLASSIFICATION), New ControlMapping With {.DG = DGCLASSIFICATIONS, .LBLNEXT = LBLCLASSIFICATIONNEXT, .LBLPREV = LBLCLASSIFICATIONPREV, .TXTSEARCH = TXTCLASSIFICATIONSEARCH, .DIALOG_NAME = ClassificationDialog.GetType(), .QUERY_TYPE = CLASSIFICATION}},
            {NameOf(LANGUAGES), New ControlMapping With {.DG = DGLANGUAGE, .LBLNEXT = LBLLANGUAGENEXT, .LBLPREV = LBLLANGUAGEPREV, .TXTSEARCH = TXTLANGUAGESEARCH, .DIALOG_NAME = LanguageDialog.GetType(), .QUERY_TYPE = LANGUAGES}},
            {NameOf(DONATOR), New ControlMapping With {.DG = DGDONATOR, .LBLNEXT = LBLDONATORNEXT, .LBLPREV = LBLDONATORRPREV, .TXTSEARCH = TXTDONATORSEARCH, .DIALOG_NAME = DonatorDialog.GetType(), .QUERY_TYPE = DONATOR}},
            {NameOf(SUPPLIER), New ControlMapping With {.DG = DGSUPPLIER, .LBLNEXT = LBLSUPPLIERNEXT, .LBLPREV = LBLSUPPLIERPREV, .TXTSEARCH = TXTSUPPLIERSEARCH, .DIALOG_NAME = SupplierDialog.GetType(), .QUERY_TYPE = SUPPLIER}},
            {NameOf(BOOK), New ControlMapping With {.DG = DGBOOKS, .LBLNEXT = LBLBOOKNEXT, .LBLPREV = LBLBOOKPREV, .TXTSEARCH = TXTBOOKSEARCH, .DIALOG_NAME = BookDialog.GetType(), .QUERY_TYPE = BOOK}}
        }


        BookInventoryPanels_SelectedIndexChanged(BookInventoryPanels, Nothing)
        DGTRANSACTION.Columns(NameOf(ColumnOverdueDate)).DisplayIndex = DGTRANSACTION.Columns.Count - 1
    End Sub

    Private Sub BTNLOGOUT_Click(sender As Object, e As EventArgs) Handles BTNLOGOUT.Click
        ' TODO LOG OUT LOGIC
        My.Settings.user_id = 0
        My.Settings.Save()
        Using Me
            LogInForm.Show()
        End Using
    End Sub

    Private Sub BTNADD_Click(sender As Object, e As EventArgs) Handles BTNADDGENRE.Click, BTNADDAUTHOR.Click, BTNADDPUBLISHER.Click, BTNADDCLASSIFICATION.Click,
            BTNADDLANGUAGE.Click, BTNADDDONATOR.Click, BTNADDSUPPLIER.Click, BTNADDBOOK.Click
        ControlsMap.Item(sender.Tag).OpenDialog()
    End Sub

    Private Sub MaintenancePanels_Selected(sender As Object, e As TabControlEventArgs) Handles MaintenancePanels.Selected
        ControlsMap.Item(sender.SelectedTab.Tag).Upate()
    End Sub

    Private Sub BTNNEXT_Click(sender As Object, e As EventArgs) Handles BTNGENRENEXT.Click, BTNAUTHORNEXT.Click, BTNPUBLISHERNEXT.Click,
            BTNCLASSIFICATIONNEXT.Click, BTNLANGUAGENEXT.Click, BTNDONATORNEXT.Click, BTNSUPPLIERNEXT.Click, BTNBOOKNEXT.Click
        ControlsMap.Item(sender.Tag).NextPage()
    End Sub

    Private Sub BTNPREV_Click(sender As Object, e As EventArgs) Handles BTNGENREPREV.Click, BTNAUTHORPREV.Click, BTNPUBLISHERPREV.Click,
            BTNCLASSIFICATIONPREV.Click, BTNLANGUAGEPREV.Click, BTNDONATORRPREV.Click, BTNSUPPLIERPREV.Click, BTNBOOKPREV.Click
        ControlsMap.Item(sender.Tag).PrevPage()
    End Sub

    '#Region "Genre Module"

    '    Private Sub DGGENRE_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGGENRE.CellMouseClick
    '        If e.ColumnIndex <> 0 AndAlso e.RowIndex <> -1 Then
    '            If DGGENRE.SelectedRows.Count > 0 Then
    '                Dim datarow As DataRowView = DGGENRE.SelectedRows.Item(0).DataBoundItem
    '                Using dialog As New GenreDialog(datarow)
    '                    dialog.ShowDialog()
    '                End Using
    '            End If
    '            DGGENRE.DataSource = BaseMaintenance.Fetch(QueryTableType.GENRE_QUERY_TABLE)
    '            LBLGENRENEXT.Text = BaseMaintenance.PMAX
    '            LBLGENREPREV.Text = BaseMaintenance.PPrev
    '        End If
    '    End Sub

    '    Private Sub TXTGENRESEARCH_TextChanged(sender As Object, e As EventArgs) Handles TXTGENRESEARCH.TextChanged
    '        SearchHelper(MaintenancePanels, GenresTab, DGGENRE, LBLGENRENEXT, LBLGENREPREV, QueryTableType.GENRE_QUERY_TABLE, TXTGENRESEARCH)
    '    End Sub
    '#End Region

    '#Region "Author Module"


    '    Private Sub DGAUTHOR_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGAUTHORS.CellMouseClick
    '        If e.ColumnIndex <> 0 AndAlso e.RowIndex <> -1 Then
    '            If DGAUTHORS.SelectedRows.Count > 0 Then
    '                Dim datarow As DataRowView = DGAUTHORS.SelectedRows.Item(0).DataBoundItem
    '                Using dialog As New AuthorDialog(datarow)
    '                    dialog.ShowDialog()
    '                End Using
    '            End If
    '            DGAUTHORS.DataSource = BaseMaintenance.Fetch(QueryTableType.AUTHOR_QUERY_TABLE)
    '            LBLAUTHORNEXT.Text = BaseMaintenance.PMAX
    '            LBLAUTHORPREV.Text = BaseMaintenance.PPrev
    '        End If
    '    End Sub

    '    Private Sub TXTAUTHORSEARCH_TextChanged(sender As Object, e As EventArgs) Handles TXTSEARCHAUTHOR.TextChanged
    '        SearchHelper(MaintenancePanels, AuthorTab, DGAUTHORS, LBLAUTHORNEXT, LBLAUTHORPREV, QueryTableType.AUTHOR_QUERY_TABLE, TXTSEARCHAUTHOR)
    '    End Sub
    '#End Region

    '#Region "Publisher Module"

    '    Private Sub DGPUBLISHER_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGPUBLISHER.CellMouseClick
    '        If e.ColumnIndex <> 0 AndAlso e.RowIndex <> -1 Then
    '            If DGPUBLISHER.SelectedRows.Count > 0 Then
    '                Dim datarow As DataRowView = DGPUBLISHER.SelectedRows.Item(0).DataBoundItem
    '                Using dialog As New PublisherDialog(datarow)
    '                    dialog.ShowDialog()
    '                End Using
    '            End If
    '            DGPUBLISHER.DataSource = BaseMaintenance.Fetch(QueryTableType.PUBLISHER_QUERY_TABLE)
    '            LBLPUBLISHERNEXT.Text = BaseMaintenance.PMAX
    '            LBLPUBLISHERPREV.Text = BaseMaintenance.PPrev
    '        End If
    '    End Sub

    '    Private Sub TXTPUBLSHERSEARCH_TextChanged(sender As Object, e As EventArgs) Handles TXTPUBLISHERSEARCH.TextChanged
    '        SearchHelper(MaintenancePanels, PublishhersTab, DGPUBLISHER, LBLPUBLISHERNEXT, LBLPUBLISHERPREV, QueryTableType.PUBLISHER_QUERY_TABLE, TXTPUBLISHERSEARCH)
    '    End Sub
    '#End Region

    '#Region "Classification Module"

    '    Private Sub DGCLASSIFICATION_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGCLASSIFICATIONS.CellMouseClick
    '        If e.ColumnIndex <> 0 AndAlso e.RowIndex <> -1 Then
    '            If DGCLASSIFICATIONS.SelectedRows.Count > 0 Then
    '                Dim datarow As DataRowView = DGCLASSIFICATIONS.SelectedRows.Item(0).DataBoundItem
    '                Using dialog As New ClassificationDialog(datarow)
    '                    dialog.ShowDialog()
    '                End Using
    '            End If
    '            DGCLASSIFICATIONS.DataSource = BaseMaintenance.Fetch(QueryTableType.CLASSIFICATION_QUERY_TABLE)
    '            LBLCLASSIFICATIONNEXT.Text = BaseMaintenance.PMAX
    '            LBLCLASSIFICATIONPREV.Text = BaseMaintenance.PPrev
    '        End If
    '    End Sub

    '    Private Sub TXTCLASSIFICATIONSEARCH_TextChanged(sender As Object, e As EventArgs) Handles TXTCLASSIFICATIONSEARCH.TextChanged
    '        SearchHelper(MaintenancePanels, ClassificationTab, DGCLASSIFICATIONS, LBLCLASSIFICATIONNEXT, LBLCLASSIFICATIONPREV, QueryTableType.CLASSIFICATION_QUERY_TABLE, TXTCLASSIFICATIONSEARCH)
    '    End Sub
    '#End Region

    '#Region "Donator Module"

    '    Private Sub DGDONATOR_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGDONATOR.CellMouseClick
    '        If e.ColumnIndex <> 0 AndAlso e.RowIndex <> -1 Then
    '            If DGDONATOR.SelectedRows.Count > 0 Then
    '                Dim datarow As DataRowView = DGDONATOR.SelectedRows.Item(0).DataBoundItem
    '                Using dialog As New DonatorDialog(datarow)
    '                    dialog.ShowDialog()
    '                End Using
    '            End If
    '            DGDONATOR.DataSource = BaseMaintenance.Fetch(QueryTableType.DONATOR_QUERY_TABLE)
    '            LBLDONATORNEXT.Text = BaseMaintenance.PMAX
    '            LBLDONATORRPREV.Text = BaseMaintenance.PPrev
    '        End If
    '    End Sub

    '    Private Sub TXTDONATORSEARCH_TextChanged(sender As Object, e As EventArgs) Handles TXTDONATORSEARCH.TextChanged
    '        SearchHelper(MaintenancePanels, DonatorsTab, DGDONATOR, LBLDONATORNEXT, LBLDONATORRPREV, QueryTableType.DONATOR_QUERY_TABLE, TXTDONATORSEARCH)
    '    End Sub
    '#End Region

    '#Region "Supplier Module"

    '    Private Sub DGSUPPLIER_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGSUPPLIER.CellMouseClick
    '        If e.ColumnIndex <> 0 AndAlso e.RowIndex <> -1 Then
    '            If DGSUPPLIER.SelectedRows.Count > 0 Then
    '                Dim datarow As DataRowView = DGSUPPLIER.SelectedRows.Item(0).DataBoundItem
    '                Using dialog As New SupplierDialog(datarow)
    '                    dialog.ShowDialog()
    '                End Using
    '            End If
    '            DGSUPPLIER.DataSource = BaseMaintenance.Fetch(QueryTableType.SUPPLIER_QUERY_TABLE)
    '            LBLSUPPLIERNEXT.Text = BaseMaintenance.PMAX
    '            LBLSUPPLIERPREV.Text = BaseMaintenance.PPrev
    '        End If
    '    End Sub

    '    Private Sub TXTSUPPLIERSEARCH_TextChanged(sender As Object, e As EventArgs) Handles TXTSUPPLIERSEARCH.TextChanged
    '        SearchHelper(MaintenancePanels, SuppliersTab, DGSUPPLIER, LBLSUPPLIERNEXT, LBLSUPPLIERPREV, QueryTableType.SUPPLIER_QUERY_TABLE, TXTSUPPLIERSEARCH)
    '    End Sub
    '#End Region

    '#Region "Department Module"

    '    Private Sub DGDEPARTMENT_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGDEPARTMENT.CellMouseClick
    '        If e.ColumnIndex <> 0 AndAlso e.RowIndex <> -1 Then
    '            If DGDEPARTMENT.SelectedRows.Count > 0 Then
    '                Dim datarow As DataRowView = DGDEPARTMENT.SelectedRows.Item(0).DataBoundItem
    '                Using dialog As New DepartmentDialog(datarow)
    '                    dialog.ShowDialog()
    '                End Using
    '            End If
    '            DGDEPARTMENT.DataSource = BaseMaintenance.Fetch(QueryTableType.DEPARTMENT_QUERY_TABLE)
    '            LBLDEPARTMENTNEXT.Text = BaseMaintenance.PMAX
    '            LBLDEPARTMENTPREV.Text = BaseMaintenance.PPrev
    '        End If
    '    End Sub

    '    Private Sub TXTDEPARTMENTSEARCH_TextChanged(sender As Object, e As EventArgs) Handles TXTDEPARTMENTSEARCH.TextChanged
    '        SearchHelper(AccountsPanel, DepartmentTab, DGDEPARTMENT, LBLDEPARTMENTNEXT, LBLDEPARTMENTPREV, QueryTableType.DEPARTMENT_QUERY_TABLE, TXTDEPARTMENTSEARCH)
    '    End Sub
    '#End Region

    '#Region "Year Level Module"

    '    Private Sub DGYEARLEVEL_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGYEARLEVEL.CellMouseClick
    '        If e.ColumnIndex <> 0 AndAlso e.RowIndex <> -1 Then
    '            If DGYEARLEVEL.SelectedRows.Count > 0 Then
    '                Dim datarow As DataRowView = DGYEARLEVEL.SelectedRows.Item(0).DataBoundItem
    '                Using dialog As New YearLevelDialog(datarow)
    '                    dialog.ShowDialog()
    '                End Using
    '            End If
    '            DGYEARLEVEL.DataSource = BaseMaintenance.Fetch(QueryTableType.YEARLEVEL_QUERY_TABLE)
    '            LBLYEARLEVELNEXT.Text = BaseMaintenance.PMAX
    '            LBLYEARLEVELPREV.Text = BaseMaintenance.PPrev
    '        End If
    '    End Sub

    '    Private Sub TXTYEARLEVELSEARCH_TextChanged(sender As Object, e As EventArgs) Handles TXTYEARLEVELSEARCH.TextChanged
    '        SearchHelper(AccountsPanel, YearLevelTab, DGYEARLEVEL, LBLYEARLEVELNEXT, LBLYEARLEVELPREV, QueryTableType.YEARLEVEL_QUERY_TABLE, TXTYEARLEVELSEARCH)
    '    End Sub
    '#End Region

    '#Region "Language Module"

    '    Private Sub DGLANGUAGE_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGLANGUAGE.CellMouseClick
    '        If e.ColumnIndex <> 0 AndAlso e.RowIndex <> -1 Then
    '            If DGLANGUAGE.SelectedRows.Count > 0 Then
    '                Dim datarow As DataRowView = DGLANGUAGE.SelectedRows.Item(0).DataBoundItem
    '                Using dialog As New LanguageDialog(datarow)
    '                    dialog.ShowDialog()
    '                End Using
    '            End If
    '            DGLANGUAGE.DataSource = BaseMaintenance.Fetch(QueryTableType.LANGUAGES_QUERY_TABLE)
    '            LBLLANGUAGENEXT.Text = BaseMaintenance.PMAX
    '            LBLLANGUAGEPREV.Text = BaseMaintenance.PPrev
    '        End If
    '    End Sub

    '    Private Sub TXLANGUAGESEARCH_TextChanged(sender As Object, e As EventArgs) Handles TXTLANGUAGESEARCH.TextChanged
    '        SearchHelper(MaintenancePanels, LanguagesTab, DGLANGUAGE, LBLLANGUAGENEXT, LBLLANGUAGEPREV, QueryTableType.LANGUAGES_QUERY_TABLE, TXTLANGUAGESEARCH)
    '    End Sub
    '#End Region

    '#Region "Book Module"
    '    Private Sub BTNADDBOOK_Click(sender As Object, e As EventArgs) Handles BTNADDBOOK.Click
    '        Using dialog = BookDialog
    '            dialog.ShowDialog()
    '        End Using
    '        If CMBBOOKFILTER.SelectedIndex = 0 Then
    '            DGBOOKS.DataSource = BaseMaintenance.Search(QueryTableType.BOOK_QUERY_TABLE, TXTBOOKSEARCH.Text)
    '            LBLBOOKNEXT.Text = BaseMaintenance.PMAX
    '            LBLBOOKPREV.Text = BaseMaintenance.PPrev
    '        Else
    '            DGBOOKS.DataSource = BaseMaintenance.SearchArchive(QueryTableType.BOOK_QUERY_TABLE, TXTBOOKSEARCH.Text)
    '            LBLBOOKNEXT.Text = BaseMaintenance.PMAX
    '            LBLBOOKPREV.Text = BaseMaintenance.PPrev
    '        End If
    '    End Sub

    '    Private Sub BTNBOOKNEXT_Click(sender As Object, e As EventArgs) Handles BTNBOOKNEXT.Click
    '        If BaseMaintenance.PPrev < BaseMaintenance.PMAX Then
    '            BaseMaintenance.PPrev += 1
    '            LBLBOOKPREV.Text = BaseMaintenance.PPrev
    '            If CMBBOOKFILTER.SelectedIndex = 0 Then
    '                DGBOOKS.DataSource = BaseMaintenance.Search(QueryTableType.BOOK_QUERY_TABLE, TXTBOOKSEARCH.Text)
    '            Else
    '                DGBOOKS.DataSource = BaseMaintenance.SearchArchive(QueryTableType.BOOK_QUERY_TABLE, TXTBOOKSEARCH.Text)
    '            End If
    '        End If

    '        ' Retain the previously selected rows
    '        For Each item As DataGridViewRow In DGBOOKS.Rows
    '            For Each drow As DataRow In SELECTED_BOOKS.Rows
    '                Dim boundItem As DataRowView = TryCast(item.DataBoundItem, DataRowView)
    '                If boundItem.Row.Item("id") = drow.Item("id") Then
    '                    item.Cells(NameOf(chckBoxBooks)).Value = True
    '                End If
    '            Next
    '        Next
    '        DGBOOKS.EndEdit()
    '    End Sub

    '    Private Sub BTNBOOKPREV_Click(sender As Object, e As EventArgs) Handles BTNBOOKPREV.Click
    '        If BaseMaintenance.PPrev > 1 Then
    '            BaseMaintenance.PPrev -= 1
    '            LBLBOOKPREV.Text = BaseMaintenance.PPrev
    '            If CMBBOOKFILTER.SelectedIndex = 0 Then
    '                DGBOOKS.DataSource = BaseMaintenance.Search(QueryTableType.BOOK_QUERY_TABLE, TXTBOOKSEARCH.Text)
    '            Else
    '                DGBOOKS.DataSource = BaseMaintenance.SearchArchive(QueryTableType.BOOK_QUERY_TABLE, TXTBOOKSEARCH.Text)
    '            End If
    '        End If

    '        ' Retain the previously selected rows
    '        For Each item As DataGridViewRow In DGBOOKS.Rows
    '            For Each drow As DataRow In SELECTED_BOOKS.Rows
    '                Dim boundItem As DataRowView = TryCast(item.DataBoundItem, DataRowView)
    '                If boundItem.Row.Item("id") = drow.Item("id") Then
    '                    item.Cells(NameOf(chckBoxBooks)).Value = True
    '                End If
    '            Next
    '        Next
    '        DGBOOKS.EndEdit()
    '    End Sub

    '    Private Sub DGBOOK_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGBOOKS.CellMouseClick
    '        If e.ColumnIndex <> 0 AndAlso e.RowIndex <> -1 Then
    '            If DGBOOKS.SelectedRows.Count > 0 Then
    '                Dim datarow As DataRowView = DGBOOKS.SelectedRows.Item(0).DataBoundItem
    '                Using dialog As New BookDialog(datarow)
    '                    dialog.ShowDialog()
    '                End Using
    '            End If
    '            If CMBBOOKFILTER.SelectedIndex = 0 Then
    '                DGBOOKS.DataSource = BaseMaintenance.Search(QueryTableType.BOOK_QUERY_TABLE, TXTBOOKSEARCH.Text)
    '            Else
    '                DGBOOKS.DataSource = BaseMaintenance.SearchArchive(QueryTableType.BOOK_QUERY_TABLE, TXTBOOKSEARCH.Text)
    '            End If
    '            LBLBOOKNEXT.Text = BaseMaintenance.PMAX
    '            LBLBOOKPREV.Text = BaseMaintenance.PPrev
    '        End If
    '    End Sub

    '    Private Sub TXBOOKSEARCH_TextChanged(sender As Object, e As EventArgs) Handles TXTBOOKSEARCH.TextChanged
    '        If MaintenancePanels.SelectedTab.Equals(BooksTab) Then
    '            BaseMaintenance.PPrev = 1
    '            If CMBBOOKFILTER.SelectedIndex = 0 Then
    '                DGBOOKS.DataSource = BaseMaintenance.Search(QueryTableType.BOOK_QUERY_TABLE, TXTBOOKSEARCH.Text)
    '            Else
    '                DGBOOKS.DataSource = BaseMaintenance.SearchArchive(QueryTableType.BOOK_QUERY_TABLE, TXTBOOKSEARCH.Text)
    '            End If
    '            LBLBOOKNEXT.Text = BaseMaintenance.PMAX
    '            LBLBOOKPREV.Text = BaseMaintenance.PPrev
    '        End If
    '    End Sub

    '    Private Sub CMBBOOKFILTER_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMBBOOKFILTER.SelectedIndexChanged
    '        If MaintenancePanels.SelectedTab.Equals(BooksTab) Then
    '            BaseMaintenance.PPrev = 1
    '            If CMBBOOKFILTER.SelectedIndex = 0 Then
    '                DGBOOKS.DataSource = BaseMaintenance.Search(QueryTableType.BOOK_QUERY_TABLE, TXTBOOKSEARCH.Text)
    '            Else
    '                DGBOOKS.DataSource = BaseMaintenance.SearchArchive(QueryTableType.BOOK_QUERY_TABLE, TXTBOOKSEARCH.Text)
    '            End If
    '            LBLBOOKNEXT.Text = BaseMaintenance.PMAX
    '            LBLBOOKPREV.Text = BaseMaintenance.PPrev
    '        End If
    '    End Sub

    '    Private Sub DGBOOKS_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGBOOKS.CellContentClick
    '        If e.ColumnIndex = chckBoxBooks.Index Then
    '            DGBOOKS.EndEdit()
    '            Dim boundItem As DataRowView = TryCast(DGBOOKS.Rows(e.RowIndex).DataBoundItem, DataRowView)
    '            If CBool(DGBOOKS.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) AndAlso Not SELECTED_BOOKS.Rows.Contains(boundItem.Row.Item("id")) Then
    '                SELECTED_BOOKS.Rows.Add(boundItem.Row.ItemArray)
    '            Else
    '                If SELECTED_BOOKS.Rows.Contains(boundItem.Row.Item("id")) Then
    '                    Dim row As DataRow = Nothing
    '                    For Each item As DataRow In SELECTED_BOOKS.Rows
    '                        If item.Item("id") = boundItem.Row.Item("id") Then
    '                            row = item
    '                            Exit For
    '                        End If
    '                    Next
    '                    SELECTED_BOOKS.Rows.Remove(row)
    '                End If
    '            End If
    '        End If
    '    End Sub
    '#End Region

#Region "Section Module"
    Private Sub BTNADDSECTION_Click(sender As Object, e As EventArgs) Handles BTNADDSECTION.Click
        Using dialog = SectionDialog
            dialog.ShowDialog()
        End Using
        DGSECTIONS.DataSource = BaseMaintenance.Fetch(QueryTableType.SECTION_QUERY_TABLE)
        LBLSECTIONNEXT.Text = BaseMaintenance.PMAX
        LBLSECTIONPREV.Text = BaseMaintenance.PPrev
    End Sub

    Private Sub BTNSECTIONPNEXT_Click(sender As Object, e As EventArgs) Handles BTNSECTIONNEXT.Click
        NextPageHelper(LBLSECTIONPREV, LBLSECTIONNEXT, DGSECTIONS, QueryTableType.SECTION_QUERY_TABLE, TXTSECTIONSEARCH)
    End Sub

    Private Sub BTNSECTIONPPREV_Click(sender As Object, e As EventArgs) Handles BTNSECTIONPREV.Click
        PrevPageHelper(LBLSECTIONPREV, LBLSECTIONNEXT, DGSECTIONS, QueryTableType.SECTION_QUERY_TABLE, TXTSECTIONSEARCH)
    End Sub

    Private Sub DGSECTION_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGSECTIONS.CellMouseClick
        If e.ColumnIndex <> 0 AndAlso e.RowIndex <> -1 Then
            If DGSECTIONS.SelectedRows.Count > 0 Then
                Dim datarow As DataRowView = DGSECTIONS.SelectedRows.Item(0).DataBoundItem
                Using dialog As New SectionDialog(datarow)
                    dialog.ShowDialog()
                End Using
            End If
            DGSECTIONS.DataSource = BaseMaintenance.Fetch(QueryTableType.SECTION_QUERY_TABLE)
            LBLSECTIONNEXT.Text = BaseMaintenance.PMAX
            LBLSECTIONPREV.Text = BaseMaintenance.PPrev
        End If
    End Sub

    Private Sub TXTSECTIONSEARCH_TextChanged(sender As Object, e As EventArgs) Handles TXTSECTIONSEARCH.TextChanged
        SearchHelper(AccountsPanel, SectionTab, DGSECTIONS, LBLSECTIONNEXT, LBLSECTIONPREV, QueryTableType.SECTION_QUERY_TABLE, TXTSECTIONSEARCH)
    End Sub
#End Region

#Region "Student Module"
    Private Sub BTNADDSTUDENTS_Click(sender As Object, e As EventArgs) Handles BTNADDSTUDENTS.Click
        Using dialog = StudentDialog
            dialog.ShowDialog()
        End Using
        If AccountsPanel.SelectedTab.Equals(StudentsTab) Then
            If CMBSTUDENTFILTER.SelectedIndex = 0 Then
                DGSTUDENT.DataSource = BaseMaintenance.Search(QueryTableType.STUDENT_QUERY_TABLE, TXTSTUDENTSEARCH.Text)
            Else
                DGSTUDENT.DataSource = BaseMaintenance.SearchArchive(QueryTableType.STUDENT_QUERY_TABLE, TXTSTUDENTSEARCH.Text)
            End If
            LBLSTUDENTNEXT.Text = BaseMaintenance.PMAX
            LBLSTUDENTPREV.Text = BaseMaintenance.PPrev
        End If
    End Sub

    Private Sub BTNSTUDENTNEXT_Click(sender As Object, e As EventArgs) Handles BTNSTUDENTNEXT.Click
        If BaseMaintenance.PPrev < BaseMaintenance.PMAX Then
            BaseMaintenance.PPrev += 1
            If AccountsPanel.SelectedTab.Equals(StudentsTab) Then
                If CMBSTUDENTFILTER.SelectedIndex = 0 Then
                    DGSTUDENT.DataSource = BaseMaintenance.Search(QueryTableType.STUDENT_QUERY_TABLE, TXTSTUDENTSEARCH.Text)
                Else
                    DGSTUDENT.DataSource = BaseMaintenance.SearchArchive(QueryTableType.STUDENT_QUERY_TABLE, TXTSTUDENTSEARCH.Text)
                End If
                LBLSTUDENTNEXT.Text = BaseMaintenance.PMAX
                LBLSTUDENTPREV.Text = BaseMaintenance.PPrev
            End If
        End If

        ' Retain the previously selected rows
        For Each item As DataGridViewRow In DGSTUDENT.Rows
            For Each drow As DataRow In SELECTED_STUDENTS.Rows
                Dim boundItem As DataRowView = TryCast(item.DataBoundItem, DataRowView)
                If boundItem.Row.Item("id") = drow.Item("id") Then
                    item.Cells(NameOf(chckBoxStudent)).Value = True
                End If
            Next
        Next
    End Sub

    Private Sub BTNSTUDENTPREV_Click(sender As Object, e As EventArgs) Handles BTNSTUDENTPREV.Click
        If BaseMaintenance.PPrev > 1 Then
            BaseMaintenance.PPrev -= 1
            If AccountsPanel.SelectedTab.Equals(StudentsTab) Then
                If CMBSTUDENTFILTER.SelectedIndex = 0 Then
                    DGSTUDENT.DataSource = BaseMaintenance.Search(QueryTableType.STUDENT_QUERY_TABLE, TXTSTUDENTSEARCH.Text)
                Else
                    DGSTUDENT.DataSource = BaseMaintenance.SearchArchive(QueryTableType.STUDENT_QUERY_TABLE, TXTSTUDENTSEARCH.Text)
                End If
                LBLSTUDENTNEXT.Text = BaseMaintenance.PMAX
                LBLSTUDENTPREV.Text = BaseMaintenance.PPrev
            End If
        End If

        ' Retain the previously selected rows
        For Each item As DataGridViewRow In DGSTUDENT.Rows
            For Each drow As DataRow In SELECTED_STUDENTS.Rows
                Dim boundItem As DataRowView = TryCast(item.DataBoundItem, DataRowView)
                If boundItem.Row.Item("id") = drow.Item("id") Then
                    item.Cells(NameOf(chckBoxStudent)).Value = True
                End If
            Next
        Next
    End Sub

    Private Sub DGSTUDENT_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGSTUDENT.CellMouseClick
        If e.ColumnIndex <> 0 AndAlso e.RowIndex <> -1 Then
            If DGSTUDENT.SelectedRows.Count > 0 Then
                Dim datarow As DataRowView = DGSTUDENT.SelectedRows.Item(0).DataBoundItem
                Using dialog As New StudentDialog(datarow)
                    dialog.ShowDialog()
                End Using
            End If
            DGSTUDENT.DataSource = BaseMaintenance.Fetch(QueryTableType.STUDENT_QUERY_TABLE)
            LBLSTUDENTNEXT.Text = BaseMaintenance.PMAX
            LBLSTUDENTPREV.Text = BaseMaintenance.PPrev
        End If
    End Sub

    Private Sub TXTSTUDENTSEARCH_TextChanged(sender As Object, e As EventArgs) Handles TXTSTUDENTSEARCH.TextChanged
        If AccountsPanel.SelectedTab.Equals(StudentsTab) Then
            BaseMaintenance.PPrev = 1
            If CMBSTUDENTFILTER.SelectedIndex = 0 Then
                DGSTUDENT.DataSource = BaseMaintenance.Search(QueryTableType.STUDENT_QUERY_TABLE, TXTSTUDENTSEARCH.Text)
            Else
                DGSTUDENT.DataSource = BaseMaintenance.SearchArchive(QueryTableType.STUDENT_QUERY_TABLE, TXTSTUDENTSEARCH.Text)
            End If
            LBLSTUDENTNEXT.Text = BaseMaintenance.PMAX
            LBLSTUDENTPREV.Text = BaseMaintenance.PPrev
        End If
    End Sub

    Private Sub DGSTUDENT_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGSTUDENT.CellContentClick
        If e.ColumnIndex = chckBoxStudent.Index Then
            DGSTUDENT.EndEdit()
            Dim boundItem As DataRowView = TryCast(DGSTUDENT.Rows(e.RowIndex).DataBoundItem, DataRowView)
            If CBool(DGSTUDENT.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) AndAlso Not SELECTED_STUDENTS.Rows.Contains(boundItem.Row.Item("id")) Then
                SELECTED_STUDENTS.Rows.Add(boundItem.Row.Item("id"))
            Else
                If SELECTED_STUDENTS.Rows.Contains(boundItem.Row.Item("id")) Then
                    Dim row As DataRow = Nothing
                    For Each item As DataRow In SELECTED_STUDENTS.Rows
                        If item.Item("id") = boundItem.Row.Item("id") Then
                            row = item
                            Exit For
                        End If
                    Next
                    SELECTED_STUDENTS.Rows.Remove(row)
                End If
            End If
        End If
    End Sub

    Private Sub CMBSTUDENTFILTER_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMBSTUDENTFILTER.SelectedIndexChanged
        If AccountsPanel.SelectedTab.Equals(StudentsTab) Then
            BaseMaintenance.PPrev = 1
            If CMBSTUDENTFILTER.SelectedIndex = 0 Then
                DGSTUDENT.DataSource = BaseMaintenance.Search(QueryTableType.STUDENT_QUERY_TABLE, TXTSTUDENTSEARCH.Text)
            Else
                DGSTUDENT.DataSource = BaseMaintenance.SearchArchive(QueryTableType.STUDENT_QUERY_TABLE, TXTSTUDENTSEARCH.Text)
            End If
            LBLSTUDENTNEXT.Text = BaseMaintenance.PMAX
            LBLSTUDENTPREV.Text = BaseMaintenance.PPrev
        End If
    End Sub
#End Region

#Region "Faculty/Teacher Module"
    Private Sub BTNADDFACULTY_Click(sender As Object, e As EventArgs) Handles BTNADDFACULTY.Click
        Using dialog = FacultyDialog
            dialog.ShowDialog()
        End Using
        DGFACULTY.DataSource = BaseMaintenance.Fetch(QueryTableType.FACULTY_QUERY_TABLE)
        LBLFACULTYNEXT.Text = BaseMaintenance.PMAX
        LBLFACULTYPREV.Text = BaseMaintenance.PPrev
    End Sub

    Private Sub BTNFACULTYNEXT_Click(sender As Object, e As EventArgs) Handles BTNFACULTYNEXT.Click
        If BaseMaintenance.PPrev < BaseMaintenance.PMAX Then
            BaseMaintenance.PPrev += 1
            LBLFACULTYPREV.Text = BaseMaintenance.PPrev
            DGFACULTY.DataSource = BaseMaintenance.Fetch(QueryTableType.FACULTY_QUERY_TABLE)
        End If

        ' Retain the previously selected rows
        For Each item As DataGridViewRow In DGFACULTY.Rows
            For Each drow As DataRow In SELECTED_FACULTY.Rows
                Dim boundItem As DataRowView = TryCast(item.DataBoundItem, DataRowView)
                If boundItem.Row.Item("id") = drow.Item("id") Then
                    item.Cells(NameOf(chckBoxFaculty)).Value = True
                End If
            Next
        Next
    End Sub

    Private Sub BTNFACULTYPREV_Click(sender As Object, e As EventArgs) Handles BTNFACULTYPREV.Click
        If BaseMaintenance.PPrev > 1 Then
            BaseMaintenance.PPrev -= 1
            LBLFACULTYPREV.Text = BaseMaintenance.PPrev
            DGFACULTY.DataSource = BaseMaintenance.Fetch(QueryTableType.FACULTY_QUERY_TABLE)
        End If

        ' Retain the previously selected rows
        For Each item As DataGridViewRow In DGFACULTY.Rows
            For Each drow As DataRow In SELECTED_FACULTY.Rows
                Dim boundItem As DataRowView = TryCast(item.DataBoundItem, DataRowView)
                If boundItem.Row.Item("id") = drow.Item("id") Then
                    item.Cells(NameOf(chckBoxFaculty)).Value = True
                End If
            Next
        Next
    End Sub

    Private Sub DGFACULTY_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGFACULTY.CellMouseClick
        If e.ColumnIndex <> 0 AndAlso e.RowIndex <> -1 Then
            If DGFACULTY.SelectedRows.Count > 0 Then
                Dim datarow As DataRowView = DGFACULTY.SelectedRows.Item(0).DataBoundItem
                Using dialog As New FacultyDialog(datarow)
                    dialog.ShowDialog()
                End Using
            End If
            DGFACULTY.DataSource = BaseMaintenance.Fetch(QueryTableType.FACULTY_QUERY_TABLE)
            LBLFACULTYNEXT.Text = BaseMaintenance.PMAX
            LBLFACULTYPREV.Text = BaseMaintenance.PPrev
        End If
    End Sub

    Private Sub TXTFACULTYSEARCH_TextChanged(sender As Object, e As EventArgs) Handles TXTFACULTYSEARCH.TextChanged
        If AccountsPanel.SelectedTab.Equals(FacultyTab) Then
            BaseMaintenance.PPrev = 1
            If CMBFACULTYFILTER.SelectedIndex = 0 Then
                DGFACULTY.DataSource = BaseMaintenance.Search(QueryTableType.FACULTY_QUERY_TABLE, TXTFACULTYSEARCH.Text)
            Else
                DGFACULTY.DataSource = BaseMaintenance.SearchArchive(QueryTableType.FACULTY_QUERY_TABLE, TXTFACULTYSEARCH.Text)
            End If
            LBLFACULTYNEXT.Text = BaseMaintenance.PMAX
            LBLFACULTYPREV.Text = BaseMaintenance.PPrev
        End If
    End Sub
    Private Sub DGFACULTY_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGFACULTY.CellContentClick
        If e.ColumnIndex = chckBoxFaculty.Index Then
            DGFACULTY.EndEdit()
            Dim boundItem As DataRowView = TryCast(DGFACULTY.Rows(e.RowIndex).DataBoundItem, DataRowView)
            If CBool(DGFACULTY.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) AndAlso Not SELECTED_FACULTY.Rows.Contains(boundItem.Row.Item("id")) Then
                SELECTED_FACULTY.Rows.Add(boundItem.Row.Item("id"))
            Else
                If SELECTED_FACULTY.Rows.Contains(boundItem.Row.Item("id")) Then
                    Dim row As DataRow = Nothing
                    For Each item As DataRow In SELECTED_FACULTY.Rows
                        If item.Item("id") = boundItem.Row.Item("id") Then
                            row = item
                            Exit For
                        End If
                    Next
                    SELECTED_FACULTY.Rows.Remove(row)
                End If
            End If
        End If
    End Sub
    Private Sub CMBFACULTYFILTER_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMBFACULTYFILTER.SelectedIndexChanged
        If AccountsPanel.SelectedTab.Equals(FacultyTab) Then
            BaseMaintenance.PPrev = 1
            If CMBFACULTYFILTER.SelectedIndex = 0 Then
                DGFACULTY.DataSource = BaseMaintenance.Search(QueryTableType.FACULTY_QUERY_TABLE, TXTFACULTYSEARCH.Text)
            Else
                DGFACULTY.DataSource = BaseMaintenance.SearchArchive(QueryTableType.FACULTY_QUERY_TABLE, TXTFACULTYSEARCH.Text)
            End If
            LBLFACULTYNEXT.Text = BaseMaintenance.PMAX
            LBLFACULTYPREV.Text = BaseMaintenance.PPrev
        End If
    End Sub
#End Region

    Public Sub SelectionHelper(dg As Object, chckName As String)
        For Each item As DataGridViewRow In dg.Rows
            item.Cells(chckName).Value = True
        Next
        dg.EndEdit()
    End Sub

    Public Sub UnselectHelper(dg As Object, chckName As String)
        For Each item As DataGridViewRow In dg.Rows
            item.Cells(chckName).Value = False
        Next
        dg.EndEdit()
    End Sub

#Region "Select All Datagrid"
    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        ' TODO REFACTOR THIS
        If MainFormPanels.SelectedTab.Equals(MaintenanceTab) Then
            Dim tabs As TabPage() = {GenresTab, AuthorTab, PublishhersTab, DonatorsTab, SuppliersTab, ClassificationTab, LanguagesTab}
            Dim dgs As Object() = {DGGENRE, DGAUTHORS, DGPUBLISHER, DGDONATOR, DGSUPPLIER, DGCLASSIFICATIONS, DGLANGUAGE}
            Dim checkBoxes As String() = {NameOf(chckBoxGenre), NameOf(chckBoxAuthor), NameOf(chckBoxPublisher), NameOf(chckBoxDonator), NameOf(chckBoxSupplier), NameOf(chckBoxClassification), NameOf(chckBoxLanguage)}
            For i As Integer = 0 To tabs.Length - 1
                If MainFormPanels.SelectedTab.Equals(tabs(i)) Then
                    SelectionHelper(dgs(i), checkBoxes(i))
                End If
            Next
        Else
            Dim tabs As TabPage() = {DepartmentTab, YearLevelTab, SectionTab}
            Dim dgs As Object() = {DGDEPARTMENT, DGYEARLEVEL, DGSECTIONS}
            Dim checkBoxes As String() = {NameOf(chckBoxDepartment), NameOf(chckBoxYearLevel), NameOf(chckBoxSection)}
            For i As Integer = 0 To tabs.Length - 1
                If AccountsPanel.SelectedTab.Equals(tabs(i)) Then
                    SelectionHelper(dgs(i), checkBoxes(i))
                End If
            Next
        End If
    End Sub
#End Region

#Region "Unselect All"
    Private Sub UnselectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnselectAllToolStripMenuItem.Click
        If MainFormPanels.SelectedTab.Equals(MaintenanceTab) Then
            Dim tabs As TabPage() = {GenresTab, AuthorTab, PublishhersTab, DonatorsTab, SuppliersTab, ClassificationTab, LanguagesTab}
            Dim dgs As Object() = {DGGENRE, DGAUTHORS, DGPUBLISHER, DGDONATOR, DGSUPPLIER, DGCLASSIFICATIONS, DGLANGUAGE}
            Dim checkBoxes As String() = {NameOf(chckBoxGenre), NameOf(chckBoxAuthor), NameOf(chckBoxPublisher), NameOf(chckBoxDonator), NameOf(chckBoxSupplier), NameOf(chckBoxClassification), NameOf(chckBoxLanguage)}
            For i As Integer = 0 To tabs.Length - 1
                If MainFormPanels.SelectedTab.Equals(tabs(i)) Then
                    UnselectHelper(dgs(i), checkBoxes(i))
                End If
            Next
        Else
            Dim tabs As TabPage() = {DepartmentTab, YearLevelTab, SectionTab}
            Dim dgs As Object() = {DGDEPARTMENT, DGYEARLEVEL, DGSECTIONS}
            Dim checkBoxes As String() = {NameOf(chckBoxDepartment), NameOf(chckBoxYearLevel), NameOf(chckBoxSection)}
            For i As Integer = 0 To tabs.Length - 1
                If AccountsPanel.SelectedTab.Equals(tabs(i)) Then
                    UnselectHelper(dgs(i), checkBoxes(i))
                End If
            Next
        End If
    End Sub
#End Region

#Region "Remove Selected"
    Private Sub RemoveSelectedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        ' TODO PERFORM A CHECK BEFORE DELETING THE DATA
        If MainFormPanels.SelectedTab.Equals(MaintenanceTab) Then
            Select Case True
                Case MaintenancePanels.SelectedTab.Equals(GenresTab)
                    DeleteHelper(DGGENRE, QueryTableType.GENRE_QUERY_TABLE, NameOf(chckBoxGenre), NameOf(ColumnGenreID))

                Case MaintenancePanels.SelectedTab.Equals(AuthorTab)
                    DeleteHelper(DGAUTHORS, QueryTableType.AUTHOR_QUERY_TABLE, NameOf(chckBoxAuthor), NameOf(ColumnAuthorID))

                Case MaintenancePanels.SelectedTab.Equals(PublishhersTab)
                    DeleteHelper(DGPUBLISHER, QueryTableType.PUBLISHER_QUERY_TABLE, NameOf(chckBoxPublisher), NameOf(ColumnPublisherID))

                Case MaintenancePanels.SelectedTab.Equals(ClassificationTab)
                    DeleteHelper(DGCLASSIFICATIONS, QueryTableType.CLASSIFICATION_QUERY_TABLE, NameOf(chckBoxClassification), NameOf(ColumnClassificationID))

                Case MaintenancePanels.SelectedTab.Equals(LanguagesTab)
                    DeleteHelper(DGLANGUAGE, QueryTableType.LANGUAGES_QUERY_TABLE, NameOf(chckBoxLanguage), NameOf(ColumnLanguageID))

                Case MaintenancePanels.SelectedTab.Equals(DonatorsTab)
                    DeleteHelper(DGDONATOR, QueryTableType.DONATOR_QUERY_TABLE, NameOf(chckBoxDonator), NameOf(ColumnDonatorID))

                Case MaintenancePanels.SelectedTab.Equals(SuppliersTab)
                    DeleteHelper(DGSUPPLIER, QueryTableType.SUPPLIER_QUERY_TABLE, NameOf(chckBoxSupplier), NameOf(ColumnSupplierID))
            End Select
        Else
            Select Case True
                Case AccountsPanel.SelectedTab.Equals(DepartmentTab)
                    DeleteHelper(DGDEPARTMENT, QueryTableType.DEPARTMENT_QUERY_TABLE, NameOf(chckBoxDepartment), NameOf(ColumnDepartmentID))
                Case AccountsPanel.SelectedTab.Equals(YearLevelTab)
                    DeleteHelper(DGYEARLEVEL, QueryTableType.YEARLEVEL_QUERY_TABLE, NameOf(chckBoxYearLevel), NameOf(ColumnYearLevelID))
                Case AccountsPanel.SelectedTab.Equals(SectionTab)
                    DeleteHelper(DGSECTIONS, QueryTableType.SECTION_QUERY_TABLE, NameOf(chckBoxSection), NameOf(ColumnSectionID))
            End Select
        End If
    End Sub
#End Region

#Region "Import Module"
    Private Sub BTNIMPORTS_Click(sender As Object, e As EventArgs) Handles BTNIMPORTBOOKS.Click, BTNIMPORTFACULTY.Click, BTNIMPORTSTUDENTS.Click
        Select Case True
            Case sender.Equals(BTNIMPORTBOOKS)
                Dim dialog As New ImportDataDialog(New BookImport, NameOf(BookDialog))
                If Not MyApplication.DialogInstances.ContainsKey(NameOf(BookDialog)) Then
                    MyApplication.DialogInstances.Add(NameOf(BookDialog), dialog)
                    dialog.Show()
                Else
                    MyApplication.DialogInstances.Item(NameOf(BookDialog)).Show()
                End If
            Case sender.Equals(BTNIMPORTFACULTY)
                Dim dialog As New ImportDataDialog(New AccountImport(QueryTableType.FACULTY_QUERY_TABLE), NameOf(FacultyDialog))
                If Not MyApplication.DialogInstances.ContainsKey(NameOf(FacultyDialog)) Then
                    MyApplication.DialogInstances.Add(NameOf(FacultyDialog), dialog)
                    dialog.Show()
                Else
                    MyApplication.DialogInstances.Item(NameOf(FacultyDialog)).Show()
                End If
            Case sender.Equals(BTNIMPORTSTUDENTS)
                Dim dialog As New ImportDataDialog(New AccountImport(QueryTableType.STUDENT_QUERY_TABLE), NameOf(StudentDialog))
                If Not MyApplication.DialogInstances.ContainsKey(NameOf(StudentDialog)) Then
                    MyApplication.DialogInstances.Add(NameOf(StudentDialog), dialog)
                    dialog.Show()
                Else
                    MyApplication.DialogInstances.Item(NameOf(StudentDialog)).Show()
                End If
        End Select
    End Sub
#End Region

#Region "Admin Module"
    Private Sub BTNADMINPNEXT_Click(sender As Object, e As EventArgs) Handles BTNADMINNEXT.Click
        NextPageHelper(LBLADMINPREV, LBLADMINNEXT, DGADMINISTRATOR, QueryTableType.ADMIN_QUERY_TABLE, TXTADMINSEARCH)
    End Sub

    Private Sub BTNADMINPPREV_Click(sender As Object, e As EventArgs) Handles BTNADMINPREV.Click
        PrevPageHelper(LBLADMINPREV, LBLADMINNEXT, DGADMINISTRATOR, QueryTableType.ADMIN_QUERY_TABLE, TXTADMINSEARCH)
    End Sub

    Private Sub TXTADMINISTRATORSEARCH_TextChanged(sender As Object, e As EventArgs) Handles TXTADMINSEARCH.TextChanged
        SearchHelper(AccountsPanel, AdminTab, DGADMINISTRATOR, LBLADMINNEXT, LBLADMINPREV, QueryTableType.ADMIN_QUERY_TABLE, TXTADMINSEARCH)
    End Sub
#End Region

#Region "Account Panel"
    Private Sub AccountsPanel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AccountsPanel.SelectedIndexChanged
        Select Case True
            Case AccountsPanel.SelectedTab.Equals(DepartmentTab)
                LoadTabData(DGDEPARTMENT, LBLDEPARTMENTPREV, LBLDEPARTMENTNEXT, QueryTableType.DEPARTMENT_QUERY_TABLE, TXTDEPARTMENTSEARCH)

            Case AccountsPanel.SelectedTab.Equals(YearLevelTab)
                LoadTabData(DGYEARLEVEL, LBLYEARLEVELPREV, LBLYEARLEVELNEXT, QueryTableType.YEARLEVEL_QUERY_TABLE, TXTYEARLEVELSEARCH)

            Case AccountsPanel.SelectedTab.Equals(SectionTab)
                LoadTabData(DGSECTIONS, LBLSECTIONPREV, LBLSECTIONNEXT, QueryTableType.SECTION_QUERY_TABLE, TXTSECTIONSEARCH)

            Case AccountsPanel.SelectedTab.Equals(StudentsTab)
                SELECTED_STUDENTS = New SystemDataSets.DTStudentDataTable
                LoadTabData(DGSTUDENT, LBLSTUDENTPREV, LBLSTUDENTNEXT, QueryTableType.STUDENT_QUERY_TABLE, TXTSTUDENTSEARCH)

            Case AccountsPanel.SelectedTab.Equals(FacultyTab)
                SELECTED_FACULTY = New SystemDataSets.DTFacultyDataTable
                LoadTabData(DGFACULTY, LBLFACULTYPREV, LBLFACULTYNEXT, QueryTableType.FACULTY_QUERY_TABLE, TXTFACULTYSEARCH)

            Case AccountsPanel.SelectedTab.Equals(AdminTab)
                LoadTabData(DGADMINISTRATOR, LBLADMINPREV, LBLADMINNEXT, QueryTableType.ADMIN_QUERY_TABLE, TXTADMINSEARCH)

        End Select
    End Sub
#End Region

#Region "Book Copies"
    Private Sub TXTCOPIESSEARCH_TextChanged(sender As Object, e As EventArgs) Handles TXTCOPIESSEARCH.TextChanged
        If BookInventoryPanels.SelectedTab.Equals(CopiesTab) Then
            If Not String.IsNullOrEmpty(TXTCOPIESSEARCH.Text) Then
                DGBOOKCOPIES.DataSource = BaseMaintenance.Search(QueryTableType.BOOKCOPIES_QUERY_TABLE, TXTCOPIESSEARCH.Text)
                LBLCOPIESNEXT.Text = BaseMaintenance.PMAX
                LBLCOPIESPREV.Text = BaseMaintenance.PPrev
            Else
                DGBOOKCOPIES.DataSource = BaseMaintenance.Fetch(QueryTableType.BOOKCOPIES_QUERY_TABLE)
                LBLCOPIESNEXT.Text = BaseMaintenance.PMAX
                LBLCOPIESPREV.Text = BaseMaintenance.PPrev
            End If
        End If
    End Sub

    Private Sub BTNCOPIESPREV_Click(sender As Object, e As EventArgs) Handles BTNCOPIESPREV.Click
        If BaseMaintenance.PPrev > 1 Then
            BaseMaintenance.PPrev -= 1
            LBLCOPIESPREV.Text = BaseMaintenance.PPrev
            If String.IsNullOrEmpty(TXTCOPIESSEARCH.Text) Then
                DGBOOKCOPIES.DataSource = BaseMaintenance.Fetch(QueryTableType.BOOKCOPIES_QUERY_TABLE)
            Else
                DGBOOKCOPIES.DataSource = BaseMaintenance.Search(QueryTableType.BOOKCOPIES_QUERY_TABLE, TXTCOPIESSEARCH.Text)
            End If
        End If
    End Sub

    Private Sub BTNCOPIESNEXT_Click(sender As Object, e As EventArgs) Handles BTNCOPIESNEXT.Click
        If BaseMaintenance.PPrev < BaseMaintenance.PMAX Then
            BaseMaintenance.PPrev += 1
            LBLCOPIESPREV.Text = BaseMaintenance.PPrev
            If String.IsNullOrEmpty(TXTCOPIESSEARCH.Text) Then
                DGBOOKCOPIES.DataSource = BaseMaintenance.Fetch(QueryTableType.BOOKCOPIES_QUERY_TABLE)
            Else
                DGBOOKCOPIES.DataSource = BaseMaintenance.Search(QueryTableType.BOOKCOPIES_QUERY_TABLE, TXTCOPIESSEARCH.Text)
            End If
        End If
    End Sub
#End Region

#Region "BookInventory Panels"
    Private Sub BookInventoryPanels_SelectedIndexChanged(sender As Object, e As EventArgs) Handles BookInventoryPanels.SelectedIndexChanged
        Select Case True
            Case BookInventoryPanels.SelectedTab.Equals(CopiesTab)
                DGBOOKCOPIES.DataSource = BaseMaintenance.Fetch(QueryTableType.BOOKCOPIES_QUERY_TABLE)
                LBLCOPIESPREV.Text = BaseMaintenance.PPrev
                LBLCOPIESNEXT.Text = BaseMaintenance.PMAX

                Dim dtDonator As DataTable = BaseMaintenance.FetchAll(QueryTableType.DONATOR_QUERY_TABLE)
                Dim newRow As DataRow = dtDonator.NewRow()
                newRow("id") = 0
                newRow("name") = "None"
                dtDonator.Rows.InsertAt(newRow, 0)

                Dim dtSupplier As DataTable = BaseMaintenance.FetchAll(QueryTableType.SUPPLIER_QUERY_TABLE)
                newRow = dtSupplier.NewRow()
                newRow("id") = 0
                newRow("name") = "None"
                dtSupplier.Rows.InsertAt(newRow, 0)

                TXTACCESSION.Text = GenerateAccession()

                CMBDONATORCOPIES.DataSource = dtDonator
                CMBSUPPLIERCOPIES.DataSource = dtSupplier
            Case BookInventoryPanels.SelectedTab.Equals(InventoryTab)
                DGINVENTORY.DataSource = BaseMaintenance.Fetch(QueryTableType.BOOKINVENTORY_QUERY_TABLE)
                LBLINVENTORYPREV.Text = BaseMaintenance.PPrev
                LBLINVENTORYNEXT.Text = BaseMaintenance.PMAX
        End Select
    End Sub
#End Region

#Region "Student Menu Strip"
    Private Sub PromoteAsAssistLibrarianToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PromoteAsAssistLibrarianToolStripMenuItem.Click
        If SELECTED_STUDENTS.Rows.Count = 0 Then
            MessageBox.Show("Please select an item to continue.", "No Item Selected!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            If MessageBox.Show("Are you sure you want to add the selected item(s) as assistant librarian?", "Archive Selected?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) <> DialogResult.Yes Then
                Exit Sub
            End If

            Dim collection As New List(Of Dictionary(Of String, String))
            For Each item As DataRow In SELECTED_STUDENTS.Rows
                collection.Add(New Dictionary(Of String, String) From {{"@sid", item.Item("id")}, {"@fid", ""}})
            Next
            If AddAssistantLibrarian(collection) Then
                MessageBox.Show("Added Successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Action failed.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
        DGSTUDENT.EndEdit()
        CMBSTUDENTFILTER_SelectedIndexChanged(CMBSTUDENTFILTER, Nothing)
        SELECTED_STUDENTS = New SystemDataSets.DTStudentDataTable
    End Sub

    Private Sub SelectAllToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem2.Click
        For Each item As DataGridViewRow In DGSTUDENT.Rows
            item.Cells(NameOf(chckBoxStudent)).Value = True
            Dim boundItem As DataRowView = TryCast(item.DataBoundItem, DataRowView)
            If Not SELECTED_STUDENTS.Rows.Contains(boundItem.Row.Item("id")) Then
                SELECTED_STUDENTS.Rows.Add(boundItem.Row.Item("id"))
            End If
        Next
        DGBOOKS.EndEdit()
    End Sub

    Private Sub UnselectAllToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles UnselectAllToolStripMenuItem2.Click
        For Each item As DataGridViewRow In DGSTUDENT.Rows
            item.Cells(NameOf(chckBoxStudent)).Value = False
        Next
        SELECTED_STUDENTS = New SystemDataSets.DTStudentDataTable
        DGSTUDENT.EndEdit()
    End Sub

    Private Sub ArchiveSelectedToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ArchiveSelectedToolStripMenuItem1.Click
        If SELECTED_STUDENTS.Rows.Count = 0 Then
            MessageBox.Show("Please select an item to continue.", "No Item Selected!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            If MessageBox.Show("Are you sure you want to archive the selected item(s)?", "Archive Selected?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) <> DialogResult.Yes Then
                Exit Sub
            End If

            Dim collection As New List(Of Dictionary(Of String, String))
            For Each item As DataRow In SELECTED_STUDENTS.Rows
                collection.Add(New Dictionary(Of String, String) From {{"@id", item.Item("id")}})
            Next
            If ExecTransactionNonQuery(ARCHIVE_STUDENT_QUERY, collection) Then
                MessageBox.Show("Archived Successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Archiving failed.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
        DGSTUDENT.EndEdit()
        CMBSTUDENTFILTER_SelectedIndexChanged(CMBSTUDENTFILTER, Nothing)
        SELECTED_STUDENTS = New SystemDataSets.DTStudentDataTable
    End Sub

    Private Sub UnarchiveSelectedToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles UnarchiveSelectedToolStripMenuItem1.Click
        If SELECTED_STUDENTS.Rows.Count = 0 Then
            MessageBox.Show("Please select an item to continue.", "No Item Selected!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else

            Dim collection As New List(Of Dictionary(Of String, String))
            For Each item As DataRow In SELECTED_STUDENTS.Rows
                collection.Add(New Dictionary(Of String, String) From {{"@id", item.Item("id")}})
            Next
            If ExecTransactionNonQuery(UNARCHIVE_STUDENT_QUERY, collection) Then
                MessageBox.Show("Unarchived Successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Unarchive failed.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
        CMBSTUDENTFILTER_SelectedIndexChanged(CMBSTUDENTFILTER, Nothing)
        SELECTED_STUDENTS = New SystemDataSets.DTStudentDataTable
    End Sub

    Private Sub DeleteSelectedToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DeleteSelectedToolStripMenuItem1.Click
        If SELECTED_STUDENTS.Rows.Count = 0 Then
            MessageBox.Show("Please select an item to continue.", "No Item Selected!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If MessageBox.Show("Deleting these items will also delete the existing book copies." & vbLf & "Are you sure you want to delete the selected item(s)?", "Delete Selected?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        Dim collection As New List(Of Dictionary(Of String, String))

        For Each item As DataRow In SELECTED_STUDENTS.Rows
            collection.Add(New Dictionary(Of String, String) From {{"@id", item.Item("id")}})
        Next

        If BaseMaintenance.Delete(QueryTableType.STUDENT_QUERY_TABLE, collection) Then
            MessageBox.Show("Deleted Successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Cannot delete the selected items. Some items are being used to other resources. Please remove the them before deleting.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        CMBSTUDENTFILTER_SelectedIndexChanged(CMBSTUDENTFILTER, Nothing)
        SELECTED_STUDENTS = New SystemDataSets.DTStudentDataTable
    End Sub

    Private Sub PrintLibraryCardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintLibraryCardToolStripMenuItem.Click

    End Sub
#End Region

#Region "Faculty Menu Strip"

    Private Sub SelectAllToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem3.Click
        For Each item As DataGridViewRow In DGFACULTY.Rows
            item.Cells(NameOf(chckBoxFaculty)).Value = True
            Dim boundItem As DataRowView = TryCast(item.DataBoundItem, DataRowView)
            If Not SELECTED_FACULTY.Rows.Contains(boundItem.Row.Item("id")) Then
                SELECTED_FACULTY.Rows.Add(boundItem.Row.Item("id"))
            End If
        Next
        DGBOOKS.EndEdit()
    End Sub

    Private Sub UnselectAllToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles UnselectAllToolStripMenuItem3.Click
        For Each item As DataGridViewRow In DGFACULTY.Rows
            item.Cells(NameOf(chckBoxFaculty)).Value = False
        Next
        SELECTED_FACULTY = New SystemDataSets.DTFacultyDataTable
        DGFACULTY.EndEdit()
    End Sub

    Private Sub DeleteSelectedToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles DeleteSelectedToolStripMenuItem2.Click
        If SELECTED_FACULTY.Rows.Count = 0 Then
            MessageBox.Show("Please select an item to continue.", "No Item Selected!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If MessageBox.Show("Deleting these items will also delete the existing book copies." & vbLf & "Are you sure you want to delete the selected item(s)?", "Delete Selected?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        Dim collection As New List(Of Dictionary(Of String, String))

        For Each item As DataRow In SELECTED_FACULTY.Rows
            collection.Add(New Dictionary(Of String, String) From {{"@id", item.Item("id")}})
        Next

        If BaseMaintenance.Delete(QueryTableType.FACULTY_QUERY_TABLE, collection) Then
            MessageBox.Show("Deleted Successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Cannot delete the selected items. Some items are being used to other resources. Please remove the them before deleting.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        CMBFACULTYFILTER_SelectedIndexChanged(CMBFACULTYFILTER, Nothing)
        SELECTED_FACULTY = New SystemDataSets.DTFacultyDataTable
    End Sub

    Private Sub ArchiveSelectedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArchiveSelectedToolStripMenuItem.Click
        If SELECTED_FACULTY.Rows.Count = 0 Then
            MessageBox.Show("Please select an item to continue.", "No Item Selected!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            If MessageBox.Show("Are you sure you want to archive the selected item(s)?", "Archive Selected?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) <> DialogResult.Yes Then
                Exit Sub
            End If

            Dim collection As New List(Of Dictionary(Of String, String))
            For Each item As DataRow In SELECTED_FACULTY.Rows
                collection.Add(New Dictionary(Of String, String) From {{"@id", item.Item("id")}})
            Next
            If ExecTransactionNonQuery(ARCHIVE_FACULTY_QUERY, collection) Then
                MessageBox.Show("Archived Successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Archiving failed.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
        DGFACULTY.EndEdit()
        CMBFACULTYFILTER_SelectedIndexChanged(CMBFACULTYFILTER, Nothing)
        SELECTED_FACULTY = New SystemDataSets.DTFacultyDataTable
    End Sub

    Private Sub UnarchiveSelectedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnarchiveSelectedToolStripMenuItem.Click
        If SELECTED_FACULTY.Rows.Count = 0 Then
            MessageBox.Show("Please select an item to continue.", "No Item Selected!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else

            Dim collection As New List(Of Dictionary(Of String, String))
            For Each item As DataRow In SELECTED_FACULTY.Rows
                collection.Add(New Dictionary(Of String, String) From {{"@id", item.Item("id")}})
            Next
            If ExecTransactionNonQuery(UNARCHIVE_FACULTY_QUERY, collection) Then
                MessageBox.Show("Unarchived Successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Unarchive failed.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
        CMBFACULTYFILTER_SelectedIndexChanged(CMBFACULTYFILTER, Nothing)
        SELECTED_FACULTY = New SystemDataSets.DTFacultyDataTable
    End Sub

    Private Sub SuperAdminToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SuperAdminToolStripMenuItem.Click

    End Sub

    Private Sub AssistLibrarianToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AssistLibrarianToolStripMenuItem.Click
        If SELECTED_FACULTY.Rows.Count = 0 Then
            MessageBox.Show("Please select an item to continue.", "No Item Selected!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            If MessageBox.Show("Are you sure you want to add the selected item(s) as assistant librarian?", "Archive Selected?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) <> DialogResult.Yes Then
                Exit Sub
            End If

            Dim collection As New List(Of Dictionary(Of String, String))
            For Each item As DataRow In SELECTED_FACULTY.Rows
                collection.Add(New Dictionary(Of String, String) From {{"@sid", ""}, {"@fid", item.Item("id")}})
            Next
            If AddAssistantLibrarian(collection) Then
                MessageBox.Show("Added Successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Action failed.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
        DGFACULTY.EndEdit()
        CMBFACULTYFILTER_SelectedIndexChanged(CMBFACULTYFILTER, Nothing)
        SELECTED_FACULTY = New SystemDataSets.DTFacultyDataTable
    End Sub
#End Region

#Region "Book Copies Module"
    Private Sub ArchiveSelectedToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ArchiveSelectedToolStripMenuItem2.Click
        If SELECTED_BOOKS.Rows.Count = 0 Then
            MessageBox.Show("Please select an item to continue.", "No Item Selected!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            If MessageBox.Show("Archiving the selected item(s) will make the copies unavailable to inventory." & vbLf & "Are you sure you want to archive the selected item(s)?", "Archive Selected?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) <> DialogResult.Yes Then
                Exit Sub
            End If

            Dim collection As New List(Of Dictionary(Of String, String))
            For Each item As DataRow In SELECTED_BOOKS.Rows
                collection.Add(New Dictionary(Of String, String) From {{"@id", item.Item("id")}})
            Next
            If ExecTransactionNonQuery(ARCHIVE_BOOKS_QUERY, collection) Then
                MessageBox.Show("Archived Successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Archiving failed.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
        DGBOOKS.EndEdit()
        'CMBBOOKFILTER_SelectedIndexChanged(CMBBOOKFILTER, Nothing)
        SELECTED_BOOKS = New SystemDataSets.DTBookDataTable
    End Sub

    Private Sub UnarchiveSelectedToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles UnarchiveSelectedToolStripMenuItem2.Click
        If SELECTED_BOOKS.Rows.Count = 0 Then
            MessageBox.Show("Please select an item to continue.", "No Item Selected!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else

            Dim collection As New List(Of Dictionary(Of String, String))
            For Each item As DataRow In SELECTED_BOOKS.Rows
                collection.Add(New Dictionary(Of String, String) From {{"@id", item.Item("id")}})
            Next
            If ExecTransactionNonQuery(UNARCHIVE_BOOKS_QUERY, collection) Then
                MessageBox.Show("Unarchived Successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Unarchive failed.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
        DGBOOKS.EndEdit()
        'CMBBOOKFILTER_SelectedIndexChanged(CMBBOOKFILTER, Nothing)
        SELECTED_BOOKS = New SystemDataSets.DTBookDataTable
    End Sub

    Private Sub DeleteSelectedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteSelectedToolStripMenuItem.Click

        If SELECTED_BOOKS.Rows.Count = 0 Then
            MessageBox.Show("Please select an item to continue.", "No Item Selected!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If MessageBox.Show("Deleting these items will also delete the existing book copies." & vbLf & "Are you sure you want to delete the selected item(s)?", "Delete Selected?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        Dim collection As New List(Of Dictionary(Of String, String))

        For Each item As DataRow In SELECTED_BOOKS.Rows
            collection.Add(New Dictionary(Of String, String) From {{"@id", item.Item("id")}})
        Next

        If BaseMaintenance.Delete(QueryTableType.BOOK_QUERY_TABLE, collection) Then
            MessageBox.Show("Deleted Successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Cannot delete the selected items. Some items are being used to other resources. Please remove the them before deleting.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        'CMBBOOKFILTER_SelectedIndexChanged(CMBBOOKFILTER, Nothing)
        SELECTED_BOOKS = New SystemDataSets.DTBookDataTable
    End Sub



    Private Sub SelectAllToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem1.Click
        For Each item As DataGridViewRow In DGBOOKS.Rows
            item.Cells(NameOf(chckBoxBooks)).Value = True
            Dim boundItem As DataRowView = TryCast(item.DataBoundItem, DataRowView)
            If Not SELECTED_BOOKS.Rows.Contains(boundItem.Row.Item("id")) Then
                SELECTED_BOOKS.Rows.Add(boundItem.Row.ItemArray)
            End If
        Next
        DGBOOKS.EndEdit()
    End Sub

    Private Sub UnselectAllToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles UnselectAllToolStripMenuItem1.Click
        For Each item As DataGridViewRow In DGGENRE.Rows
            item.Cells(NameOf(chckBoxGenre)).Value = False
        Next
        SELECTED_BOOKS = New SystemDataSets.DTBookDataTable
        DGBOOKS.EndEdit()
    End Sub

    Private Sub BTNADDCOPIES_Click(sender As Object, e As EventArgs) Handles BTNADDCOPIES.Click
        ' TODO ADD SANITIZE THIS

        Dim price_copy As String = If(String.IsNullOrEmpty(TXTPRICECOPIES.Text), "0", TXTPRICECOPIES.Text)
        Dim hasErrors As Boolean = False
        If Not Validator.MatchPattern(TXTQUANTITY.Text, "^\d+$") Then
            errProvider.SetError(TXTQUANTITY, "Invalid number format.")
            hasErrors = True
        End If

        If Not Validator.MatchPattern(price_copy, "^\d+\.?\d*$") Then
            errProvider.SetError(TXTPRICECOPIES, "Invalid number format.")
            hasErrors = True
        End If

        If Not hasErrors AndAlso CInt(TXTQUANTITY.Text) < 1 Then
            errProvider.SetError(TXTQUANTITY, "Quantity should be greater than 0.")
            hasErrors = True
        End If

        If hasErrors Then
            Exit Sub
        End If


        If MessageBox.Show($"Are you sure you want to add {CInt(TXTQUANTITY.Text)} copies of {TXTISBNCOPIES.Text}?", "Add Copies?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
            AddCopies(CInt(TXTQUANTITY.Text), TXTISBNCOPIES.Text, If(String.IsNullOrEmpty(TXTPRICECOPIES.Text), 0, CInt(price_copy)), CMBDONATORCOPIES.SelectedValue, CMBSUPPLIERCOPIES.SelectedValue)
        End If
        TXTQUANTITY.Text = String.Empty
        TXTISBNCOPIES.Text = String.Empty
        'CMBDONATORCOPIES.Text = "None"
        'CMBSUPPLIERCOPIES.Text = "None"
    End Sub

    Private Sub CHCKBOXDONATED_CheckedChanged(sender As Object, e As EventArgs) Handles CHCKBOXDONATED.CheckedChanged
        If CHCKBOXDONATED.Checked Then
            CMBSUPPLIERCOPIES.Enabled = False
            CMBDONATORCOPIES.Enabled = True
        Else
            CMBDONATORCOPIES.Enabled = False
            CMBSUPPLIERCOPIES.Enabled = True
        End If
    End Sub

    Private Sub BTNADDTRANSACTION_Click(sender As Object, e As EventArgs) Handles BTNADDTRANSACTION.Click
        Dim dialog As New BorrowDialog()
        If Not MyApplication.DialogInstances.ContainsKey(NameOf(BorrowDialog)) Then
            MyApplication.DialogInstances.Add(NameOf(BorrowDialog), dialog)
            dialog.Show()
        Else
            MyApplication.DialogInstances.Item(NameOf(BorrowDialog)).Show()
        End If
    End Sub
#End Region

#Region "Helper Functions"
    Private Sub DeleteHelper(dg As Object, qtype As QueryTableType, cboxName As String, cellName As String)
        dg.EndEdit()
        Dim params As New List(Of Dictionary(Of String, String))
        For Each data As DataGridViewRow In dg.Rows
            If data.Cells(cboxName).Value Then
                Dim temp As New Dictionary(Of String, String) From {
                    {"@id", data.Cells(cellName).Value.ToString}
                }
                params.Add(temp)
            End If
        Next

        If params.Count = 0 Then
            MessageBox.Show("Please select an item to continue.", "No Item Selected!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If MessageBox.Show("Are you sure you want to delete the selected item(s)?", "Delete Selected Items?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        If BaseMaintenance.Delete(qtype, params) Then
            MessageBox.Show("Deleted Successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Cannot delete the selected items. Some items are being used to other resources. Please remove the them before deleting.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        dg.DataSource = BaseMaintenance.Fetch(qtype)
    End Sub

    Private Sub LoadTabData(dg As Object, lblPrev As Object, lblNext As Object, qtype As QueryTableType, txtSearch As Object)
        txtSearch.Clear()
        dg.DataSource = BaseMaintenance.Fetch(qtype)
        lblPrev.Text = BaseMaintenance.PPrev
        lblNext.Text = BaseMaintenance.PMAX
    End Sub

    Private Sub NextPageHelper(lblPrev As Object, lblNext As Object, dg As Object, qtype As QueryTableType, txtSearch As Object)
        If BaseMaintenance.PPrev < BaseMaintenance.PMAX Then
            BaseMaintenance.PPrev += 1
            lblPrev.Text = BaseMaintenance.PPrev
            If Not String.IsNullOrEmpty(txtSearch.Text) Then
                BaseMaintenance.PPrev = 1
                dg.DataSource = BaseMaintenance.Search(qtype, txtSearch.Text)
            Else
                dg.DataSource = BaseMaintenance.Fetch(qtype)
            End If
            lblNext.Text = BaseMaintenance.PMAX
            lblPrev.Text = BaseMaintenance.PPrev
        End If
    End Sub

    Private Sub PrevPageHelper(lblPrev As Object, lblNext As Object, dg As Object, qtype As QueryTableType, txtSearch As Object)
        If BaseMaintenance.PPrev > 1 Then
            BaseMaintenance.PPrev -= 1
            lblPrev.Text = BaseMaintenance.PPrev
            If Not String.IsNullOrEmpty(txtSearch.Text) Then
                BaseMaintenance.PPrev = 1
                dg.DataSource = BaseMaintenance.Search(qtype, txtSearch.Text)
            Else
                dg.DataSource = BaseMaintenance.Fetch(qtype)
            End If
            lblNext.Text = BaseMaintenance.PMAX
            lblPrev.Text = BaseMaintenance.PPrev
        End If
    End Sub

    Private Sub SearchHelper(panel As Object, tab As Object, dg As Object, lblNext As Object, lblPrev As Object, qtype As QueryTableType, txtSearch As Object)
        If panel.SelectedTab.Equals(tab) Then
            BaseMaintenance.PPrev = 1
            If Not String.IsNullOrEmpty(txtSearch.Text) Then
                dg.DataSource = BaseMaintenance.Search(qtype, txtSearch.Text)
            Else
                dg.DataSource = BaseMaintenance.Fetch(qtype)
            End If
            lblNext.Text = BaseMaintenance.PMAX
            lblPrev.Text = BaseMaintenance.PPrev
        End If
    End Sub
#End Region

#Region "Refresh Buttons"
    Private Sub BTNREFRESH_Click(sender As Object, e As EventArgs) Handles BTNGENREREFRESH.Click, BTNADMINREFRESH.Click, BTNAUTHORREFRESH.Click, BTNBOOKREFRESH.Click,
            BTNBOOKREPORTREFRESH.Click, BTNBORROWEDREPORTREFRESH.Click, BTNBORROWERREPORTREFRESH.Click, BTNCLASSIFICATIONREFRESH.Click, BTNDEPARTMENTREFRESH.Click,
            BTNDONATORREFRESH.Click, BTNEXPENDITUREREPORTREFRESH.Click, BTNFACULTYREFRESH.Click, BTNFINESREPORTREFRESH.Click, BTNLANGUAGEREFRESH.Click, BTNPUBLISHERREFRESH.Click,
            BTNSECTIONREFRESH.Click, BTNSTUDENTREFRESH.Click, BTNSUPPLIERREFRESH.Click, BTNTRANSACTIONREFRESH.Click, BTNYEARLEVELREFRESH.Click
        ' TODO ADD ALL THE NECESSARY REFRESH
        AccountsPanel_SelectedIndexChanged(AccountsPanel, Nothing)
        'MaintenancePanels_SelectedIndexChanged(MaintenancePanels, Nothing)
        BookInventoryPanels_SelectedIndexChanged(BookInventoryPanels, Nothing)
    End Sub


#End Region

#Region "Mainform Panel"
    ' TODO LOL U GOTTA FIX THIS !
    Private Sub MainFormPanels_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MainFormPanels.SelectedIndexChanged
        Select Case True
            Case MainFormPanels.SelectedTab.Equals(BookTransactionTab)
                BaseMaintenance.PPrev = 1
                CMBTRANSACTIONFILTER.SelectedIndex = 0
                TXTTRANSACTIONSEARCH.Clear()
                DGTRANSACTION.DataSource = FetchTransactions(1)
                LBLTRANSACTIONNEXT.Text = BaseMaintenance.PMAX
                LBLTRANSACTIONPREV.Text = BaseMaintenance.PPrev
            Case MainFormPanels.SelectedTab.Equals(BookInventoryTab)
                DGBOOKCOPIES.DataSource = BaseMaintenance.Fetch(QueryTableType.BOOKCOPIES_QUERY_TABLE)
                LBLCOPIESPREV.Text = BaseMaintenance.PPrev
                LBLCOPIESNEXT.Text = BaseMaintenance.PMAX

                Dim dtDonator As DataTable = BaseMaintenance.FetchAll(QueryTableType.DONATOR_QUERY_TABLE)
                Dim newRow As DataRow = dtDonator.NewRow()
                newRow("id") = 0
                newRow("name") = "None"
                dtDonator.Rows.InsertAt(newRow, 0)

                Dim dtSupplier As DataTable = BaseMaintenance.FetchAll(QueryTableType.SUPPLIER_QUERY_TABLE)
                newRow = dtSupplier.NewRow()
                newRow("id") = 0
                newRow("name") = "None"
                dtSupplier.Rows.InsertAt(newRow, 0)

                TXTACCESSION.Text = GenerateAccession()

                CMBDONATORCOPIES.DataSource = dtDonator
                CMBSUPPLIERCOPIES.DataSource = dtSupplier
            Case MainFormPanels.SelectedTab.Equals(SettingsTab)
                Dim dt As DataTable = ExecFetch("SELECT * FROM tblappsettings")

                If dt.Rows.Count = 0 Then
                    Return
                End If
                With dt.Rows.Item(0)
                    CHCKSETNOTIF.Checked = If(.Item("enable_notification") > 0, True, False)
                    CHCKSETGLOBALP.Checked = If(.Item("gpenalty") > 0, True, False)
                    TXTSETSPENALTY.Text = .Item("spenalty")
                    TXTSETFPENALTY.Text = .Item("fpenalty")
                    TXTSETSDAYS.Text = .Item("sdays")
                    TXTSETFDAYS.Text = .Item("fdays")
                    TXTSETSCOUNT.Text = .Item("s_count")
                    TXTSETFCOUNT.Text = .Item("f_count")
                End With
            Case MainFormPanels.SelectedTab.Equals(AccountTab)
                Try
                    If ExecScalar("SELECT COUNT(*) FROM tblstudents WHERE lrn = @lrn", New Dictionary(Of String, String) From {{"@lrn", My.Settings.user_username}}) > 0 Then
                        Dim dt As DataTable = ExecFetch("SELECT full_name FROM tblstudents WHERE lrn = @lrn", New Dictionary(Of String, String) From {{"@lrn", My.Settings.user_username}})
                        LBLPROFILENAME.Text = dt.Rows(0).Item("full_name")
                        If ExecScalar("SELECT COUNT(*) FROM tbladmins WHERE student_id = @id", New Dictionary(Of String, String) From {{"@id", My.Settings.user_id}}) Then
                            LBLPROFILEROLE.Text = "Assistant Admin"
                        End If
                    Else
                        Dim dt As DataTable = ExecFetch("SELECT full_name FROM tblfaculties WHERE username = @uname", New Dictionary(Of String, String) From {{"@uname", My.Settings.user_username}})
                        LBLPROFILENAME.Text = dt.Rows(0).Item("full_name")
                        If ExecScalar("SELECT COUNT(*) FROM tbladmins WHERE faculty_id = @id", New Dictionary(Of String, String) From {{"@id", My.Settings.user_id}}) Then
                            If dt.Rows(0).Item("role") = 0 Then
                                LBLPROFILEROLE.Text = "Superadmin"
                            Else
                                LBLPROFILEROLE.Text = "Assistant Admin"
                            End If
                        End If
                    End If
                Catch ex As Exception

                End Try
        End Select
    End Sub
#End Region

#Region "Settings Panel"

    Private Sub BTNSAVEGENSET_Click(sender As Object, e As EventArgs) Handles BTNSAVEGENSET.Click
        Dim params As New Dictionary(Of String, String) From {
            {"@gp", If(CHCKSETGLOBALP.Checked, 1, 0)},
            {"@en", If(CHCKSETNOTIF.Checked, 1, 0)},
            {"@sp", TXTSETFPENALTY.Text},
            {"@fp", TXTSETFPENALTY.Text},
            {"@sd", TXTSETSDAYS.Text},
            {"@fd", TXTSETFDAYS.Text},
            {"@sc", TXTSETSCOUNT.Text},
            {"@fc", TXTSETFCOUNT.Text}
        }
        If ExecNonQuery("UPDATE tblappsettings SET gpenalty = @gp, spenalty = @sp, fpenalty = @fp, s_count = @sc, f_count = @fc, enable_notification = @en, sdays = @sd, fdays = @fd WHERE id > 0", params) > 0 Then
            MessageBox.Show("General settings has been updated.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Failed to update General settings.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub



    Private Sub BTNEMAILSET_Click(sender As Object, e As EventArgs) Handles BTNEMAILSET.Click
        Dim params As New Dictionary(Of String, String) From {
            {"@email", TXTEMAILSETTINGS.Text},
            {"@pass", TXTEMAILPASSWORDSETTINGS.Text},
            {"@overdue", TXTSETOVERDUE.Text},
            {"@borrow", TXTSETBORROW.Text},
            {"@before", TXTSETBEFORE.Text},
            {"@return", TXTSETRETURN.Text}
        }

        If ExecNonQuery("UPDATE tblappsettings SET app_email = @email, e_pass = @pass, return_message = @return, overdue_message = @overdue, borrow_message = @borrow, boverdue_message = @before WHERE id > 0", params) > 0 Then
            MessageBox.Show("Email settings has been updated.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Failed to update Email settings.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub BTNSAVEPATH_Click(sender As Object, e As EventArgs) Handles BTNSAVEPATH.Click
        Using dialog As New FolderBrowserDialog()
            If dialog.ShowDialog() = DialogResult.OK Then
                My.Settings.backup_folder = dialog.SelectedPath
                TXTSETPATH.Text = dialog.SelectedPath
            End If
        End Using
    End Sub

    Private Sub BTNSETSERVER_Click(sender As Object, e As EventArgs) Handles BTNSETSERVER.Click
        MsgBox(My.Settings.server_password)
        If TestConnection(TXTSETIP.Text, TXTSETUSERNAME.Text, TXTSETPORT.Text, TXTSETSERPASS.Text) Then
            My.Settings.server_name = TXTSETIP.Text
            My.Settings.server_username = TXTSETUSERNAME.Text
            My.Settings.server_password = TXTSETSERPASS.Text
            My.Settings.server_port = TXTSETPORT.Text
            My.Settings.Save()
            MessageBox.Show("Server Settings has been updated.", "Successs!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Faild to update server settings.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub
    Private Sub SettingsPanels_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SettingsPanels.SelectedIndexChanged
        Dim dt As DataTable = ExecFetch("SELECT * FROM tblappsettings")

        If dt.Rows.Count = 0 Then
            Return
        End If
        With dt.Rows.Item(0)
            Select Case True
                Case SettingsPanels.SelectedTab.Equals(GeneralSettingsTab)

                    CHCKSETNOTIF.Checked = If(.Item("enable_notification") > 0, True, False)
                    CHCKSETGLOBALP.Checked = If(.Item("gpenalty") > 0, True, False)
                    TXTSETSPENALTY.Text = .Item("spenalty")
                    TXTSETFPENALTY.Text = .Item("fpenalty")
                    TXTSETSDAYS.Text = .Item("sdays")
                    TXTSETFDAYS.Text = .Item("fdays")
                    TXTSETSCOUNT.Text = .Item("s_count")
                    TXTSETFCOUNT.Text = .Item("f_count")
                Case SettingsPanels.SelectedTab.Equals(EmailSettingsTab)
                    TXTEMAILPASSWORDSETTINGS.Text = .Item("e_pass")
                    TXTSETRETURN.Text = .Item("return_message")
                    TXTSETOVERDUE.Text = .Item("overdue_message")
                    TXTSETBORROW.Text = .Item("borrow_message")
                    TXTEMAILSETTINGS.Text = .Item("app_email")
                    TXTSETBEFORE.Text = .Item("boverdue_message")
                Case SettingsPanels.SelectedTab.Equals(ServerSettingsTab)
                    TXTSETIP.Text = My.Settings.server_name
                    TXTSETUSERNAME.Text = My.Settings.server_username
                    TXTSETSERPASS.Text = My.Settings.server_password
                    TXTSETPORT.Text = My.Settings.server_port

            End Select
        End With
    End Sub
#End Region

#Region "Report Module"

    Private Sub BTNREPORTBORROWED_Click(sender As Object, e As EventArgs) Handles BTNREPORTBORROWED.Click
        Using dialog As New ReportDialog(1)
            dialog.ShowDialog()
        End Using
    End Sub
    Private Sub ReportsPanel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ReportsPanel.SelectedIndexChanged
        Select Case True
            Case ReportsPanel.SelectedTab.Equals(BooksReportTab)
                LoadTabData(DGBOOKREPORT, LBLBOOKREPORTPREV, LBLBOOKREPORTNEXT, QueryTableType.BORROWED_BOOKS_REPORT, TXTBOOKREPORTSEARCH)
            Case ReportsPanel.SelectedTab.Equals(ExpenditureReportTab)
                LoadTabData(DGEXPENDITUREREPORT, LBLEXPENDITUREREPORTPREV, LBLEXPENDITUREREPORTNEXT, QueryTableType.EXPENDITURE_REPORT, TXTEXPENDITUREREPORTSEARCH)
            Case ReportsPanel.SelectedTab.Equals(FinesReportTab)
                LoadTabData(DGFINESREPORT, LBLFINESREPORTPREV, LBLFINESREPORTNEXT, QueryTableType.FINES_REPORT, TXTFINESREPORTSSEARCH)
        End Select
    End Sub
#End Region

#Region "Transaction Module"
    Private Sub CMBTRANSACTIONFILTER_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMBTRANSACTIONFILTER.SelectedIndexChanged
        Select Case True
            Case MainFormPanels.SelectedTab.Equals(BookTransactionTab)
                If CMBTRANSACTIONFILTER.Text = "Active" Then
                    DGTRANSACTION.DataSource = FetchTransactions(1, TXTTRANSACTIONSEARCH.Text)
                ElseIf CMBTRANSACTIONFILTER.Text = "Overdue" Then
                    DGTRANSACTION.DataSource = FetchTransactions(2, TXTTRANSACTIONSEARCH.Text)
                Else
                    DGTRANSACTION.DataSource = FetchTransactions(0, TXTTRANSACTIONSEARCH.Text)
                End If
                LBLTRANSACTIONNEXT.Text = BaseMaintenance.PMAX
                LBLTRANSACTIONPREV.Text = BaseMaintenance.PPrev
        End Select
    End Sub

    Private Sub DGTRANSACTION_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGTRANSACTION.CellClick
        If DGTRANSACTION.SelectedRows.Count > 0 AndAlso e.RowIndex <> -1 Then
            Dim boundItem As DataRowView = TryCast(DGTRANSACTION.SelectedRows(0).DataBoundItem, DataRowView)
            Using dialog As New ReturnDialog(boundItem.Row.Item("id"))
                dialog.ShowDialog()
            End Using
        End If
    End Sub
    Private Sub TXTTRANSACTIONSEARCH_TextChanged(sender As Object, e As EventArgs) Handles TXTTRANSACTIONSEARCH.TextChanged
        Select Case True
            Case MainFormPanels.SelectedTab.Equals(BookTransactionTab)
                'TransactionTimer.Enabled = True
                'TransactionTimer.Start()
                If CMBTRANSACTIONFILTER.Text = "Active" Then
                    DGTRANSACTION.DataSource = FetchTransactions(1, TXTTRANSACTIONSEARCH.Text)
                ElseIf CMBTRANSACTIONFILTER.Text = "Overdue" Then
                    DGTRANSACTION.DataSource = FetchTransactions(2, TXTTRANSACTIONSEARCH.Text)
                Else
                    DGTRANSACTION.DataSource = FetchTransactions(0, TXTTRANSACTIONSEARCH.Text)
                End If
                LBLTRANSACTIONNEXT.Text = BaseMaintenance.PMAX
                LBLTRANSACTIONPREV.Text = BaseMaintenance.PPrev
            Case Else
                'TransactionTimer.Enabled = False
                'TransactionTimer.Stop()
        End Select
    End Sub

    Private Sub BTNTRANSACTIONSEARCH_Click(sender As Object, e As EventArgs) Handles BTNTRANSACTIONSEARCH.Click
        Select Case True
            Case MainFormPanels.SelectedTab.Equals(BookTransactionTab)
                If CMBTRANSACTIONFILTER.Text = "Active" Then
                    DGTRANSACTION.DataSource = FetchTransactions(1, TXTTRANSACTIONSEARCH.Text, DTTRANSACTIONS.Value, DTTRANSACTIONE.Value)
                ElseIf CMBTRANSACTIONFILTER.Text = "Overdue" Then
                    DGTRANSACTION.DataSource = FetchTransactions(2, TXTTRANSACTIONSEARCH.Text, DTTRANSACTIONS.Value, DTTRANSACTIONE.Value)
                Else
                    DGTRANSACTION.DataSource = FetchTransactions(0, TXTTRANSACTIONSEARCH.Text, DTTRANSACTIONS.Value, DTTRANSACTIONE.Value)
                End If
                LBLTRANSACTIONNEXT.Text = BaseMaintenance.PMAX
                LBLTRANSACTIONPREV.Text = BaseMaintenance.PPrev
        End Select
    End Sub
#End Region

#Region "Book Inventory Module"
    Private Sub BTNINVENTORYPREV_Click(sender As Object, e As EventArgs) Handles BTNINVENTORYPREV.Click
        If BaseMaintenance.PPrev > 1 Then
            BaseMaintenance.PPrev -= 1
            LBLINVENTORYPREV.Text = BaseMaintenance.PPrev
            DGINVENTORY.DataSource = BaseMaintenance.Search(QueryTableType.BOOKINVENTORY_QUERY_TABLE, TXTINVENTORYSEARCH.Text)
        End If
    End Sub

    Private Sub BTNINVENTORYNEXT_Click(sender As Object, e As EventArgs) Handles BTNINVENTORYNEXT.Click
        If BaseMaintenance.PPrev < BaseMaintenance.PMAX Then
            BaseMaintenance.PPrev += 1
            LBLINVENTORYPREV.Text = BaseMaintenance.PPrev
            If String.IsNullOrEmpty(TXTINVENTORYSEARCH.Text) Then
                DGINVENTORY.DataSource = BaseMaintenance.Fetch(QueryTableType.BOOKINVENTORY_QUERY_TABLE)
            Else
                DGINVENTORY.DataSource = BaseMaintenance.Search(QueryTableType.BOOKINVENTORY_QUERY_TABLE, TXTINVENTORYSEARCH.Text)
            End If
        End If
    End Sub

    Private Sub DGINVENTORY_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGINVENTORY.CellClick
        If e.ColumnIndex <> chckBoxInventory.Index AndAlso e.RowIndex <> -1 Then
            Dim boundItem As DataRowView = TryCast(DGINVENTORY.Rows(e.RowIndex).DataBoundItem, DataRowView)
            LBLINVACCESSION.Text = boundItem.Item("accession_no")
            LBLINVDONATOR.Text = If(IsDBNull(boundItem.Item("donator_name")), "None", boundItem.Item("donator_name"))
            LBLINVISBN.Text = boundItem.Item("isbn")
            LBLINVSUPPLIER.Text = If(IsDBNull(boundItem.Item("supplier_name")), "None", boundItem.Item("supplier_name"))
            TXTINVPRICE.Text = If(IsDBNull(boundItem.Item("price")), Nothing, boundItem.Item("price"))
        End If
    End Sub


#End Region

End Class