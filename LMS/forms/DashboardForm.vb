Imports LMS.My

Public Class DashboardForm

    Private SELECTED_BOOKS As New SystemDataSets.DTBookDataTable

    Private Sub DashboardForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub BTNLOGOUT_Click(sender As Object, e As EventArgs) Handles BTNLOGOUT.Click
        ' TODO LOG OUT LOGIC
        My.Settings.user_id = 0
        My.Settings.Save()
        Using Me
            LogInForm.Show()
        End Using
    End Sub

#Region "Genre Module"
    Private Sub BTNADDGENRE_Click(sender As Object, e As EventArgs) Handles BTNADDGENRE.Click
        Using dialog = GenreDialog
            dialog.ShowDialog()
        End Using
        DGGENRE.DataSource = BaseMaintenance.Fetch(QueryTableType.GENRE_QUERY_TABLE)
        LBLGENRENEXT.Text = BaseMaintenance.PMAX
        LBLGENREPREV.Text = BaseMaintenance.PPrev
    End Sub

    Private Sub BTNGENRENEXT_Click(sender As Object, e As EventArgs) Handles BTNGENRENEXT.Click
        If BaseMaintenance.PPrev < BaseMaintenance.PMAX Then
            BaseMaintenance.PPrev += 1
            LBLGENREPREV.Text = BaseMaintenance.PPrev
            DGGENRE.DataSource = BaseMaintenance.Fetch(QueryTableType.GENRE_QUERY_TABLE)
        End If
    End Sub

    Private Sub BTNGENREPREV_Click(sender As Object, e As EventArgs) Handles BTNGENREPREV.Click
        If BaseMaintenance.PPrev > 1 Then
            BaseMaintenance.PPrev -= 1
            LBLGENREPREV.Text = BaseMaintenance.PPrev
            DGGENRE.DataSource = BaseMaintenance.Fetch(QueryTableType.GENRE_QUERY_TABLE)
        End If
    End Sub

    Private Sub DGGENRE_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGGENRE.CellMouseClick
        If e.ColumnIndex <> 0 Then
            If DGGENRE.SelectedRows.Count > 0 Then
                Dim datarow As DataRowView = DGGENRE.SelectedRows.Item(0).DataBoundItem
                Using dialog As New GenreDialog(datarow)
                    dialog.ShowDialog()
                End Using
            End If
            DGGENRE.DataSource = BaseMaintenance.Fetch(QueryTableType.GENRE_QUERY_TABLE)
            LBLGENRENEXT.Text = BaseMaintenance.PMAX
            LBLGENREPREV.Text = BaseMaintenance.PPrev
        End If
    End Sub

    Private Sub TXTGENRESEARCH_TextChanged(sender As Object, e As EventArgs) Handles TXTGENRESEARCH.TextChanged
        If MaintenancePanels.SelectedTab.Equals(GenresTab) Then
            If Not String.IsNullOrEmpty(TXTGENRESEARCH.Text) Then
                DGGENRE.DataSource = BaseMaintenance.Search(QueryTableType.GENRE_QUERY_TABLE, TXTGENRESEARCH.Text)
                LBLGENRENEXT.Text = BaseMaintenance.PMAX
                LBLGENREPREV.Text = BaseMaintenance.PPrev
            Else
                DGGENRE.DataSource = BaseMaintenance.Fetch(QueryTableType.GENRE_QUERY_TABLE)
                LBLGENRENEXT.Text = BaseMaintenance.PMAX
                LBLGENREPREV.Text = BaseMaintenance.PPrev
            End If
        End If
    End Sub
#End Region

#Region "Author Module"
    Private Sub BTNADDAUTHOR_Click(sender As Object, e As EventArgs) Handles BTNADDAUTHOR.Click
        Using dialog = New AuthorDialog
            dialog.ShowDialog()
        End Using
        LBLAUTHORNEXT.Text = BaseMaintenance.PMAX
        LBLAUTHORPREV.Text = BaseMaintenance.PPrev
        DGAUTHORS.DataSource = BaseMaintenance.Fetch(QueryTableType.AUTHOR_QUERY_TABLE)
    End Sub

    Private Sub BTNAUTHORPNEXT_Click(sender As Object, e As EventArgs) Handles BTNAUTHORNEXT.Click
        If BaseMaintenance.PPrev < BaseMaintenance.PMAX Then
            BaseMaintenance.PPrev += 1
            LBLAUTHORPREV.Text = BaseMaintenance.PPrev
            DGAUTHORS.DataSource = BaseMaintenance.Fetch(QueryTableType.AUTHOR_QUERY_TABLE)
        End If
    End Sub

    Private Sub DGAUTHOR_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGAUTHORS.CellMouseClick
        If e.ColumnIndex <> 0 Then
            If DGAUTHORS.SelectedRows.Count > 0 Then
                Dim datarow As DataRowView = DGAUTHORS.SelectedRows.Item(0).DataBoundItem
                Using dialog As New AuthorDialog(datarow)
                    dialog.ShowDialog()
                End Using
            End If
            DGAUTHORS.DataSource = BaseMaintenance.Fetch(QueryTableType.AUTHOR_QUERY_TABLE)
            LBLAUTHORNEXT.Text = BaseMaintenance.PMAX
            LBLAUTHORPREV.Text = BaseMaintenance.PPrev
        End If
    End Sub

    Private Sub TXTAUTHORSEARCH_TextChanged(sender As Object, e As EventArgs) Handles TXTSEARCHAUTHOR.TextChanged
        If MaintenancePanels.SelectedTab.Equals(AuthorTab) Then
            If Not String.IsNullOrEmpty(TXTSEARCHAUTHOR.Text) Then
                DGAUTHORS.DataSource = BaseMaintenance.Search(QueryTableType.AUTHOR_QUERY_TABLE, TXTSEARCHAUTHOR.Text)
                LBLAUTHORNEXT.Text = BaseMaintenance.PMAX
                LBLAUTHORPREV.Text = BaseMaintenance.PPrev
            Else
                DGAUTHORS.DataSource = BaseMaintenance.Fetch(QueryTableType.AUTHOR_QUERY_TABLE)
                LBLAUTHORNEXT.Text = BaseMaintenance.PMAX
                LBLAUTHORPREV.Text = BaseMaintenance.PPrev
            End If
        End If
    End Sub

    Private Sub BTNAUTHORPREV_Click(sender As Object, e As EventArgs) Handles BTNAUTHORPREV.Click
        If BaseMaintenance.PPrev > 1 Then
            BaseMaintenance.PPrev -= 1
            LBLAUTHORPREV.Text = BaseMaintenance.PPrev
            DGAUTHORS.DataSource = BaseMaintenance.Fetch(QueryTableType.AUTHOR_QUERY_TABLE)
        End If
    End Sub
#End Region

#Region "Publisher Module"
    Private Sub BTNADDPUBLISHER_Click(sender As Object, e As EventArgs) Handles BTNADDPUBLISHER.Click
        Using dialog = PublisherDialog
            dialog.ShowDialog()
        End Using
        DGPUBLISHER.DataSource = BaseMaintenance.Fetch(QueryTableType.PUBLISHER_QUERY_TABLE)
        LBLPUBLISHERNEXT.Text = BaseMaintenance.PMAX
        LBLPUBLISHERPREV.Text = BaseMaintenance.PPrev
    End Sub

    Private Sub BTNPUBLISHERNEXT_Click(sender As Object, e As EventArgs) Handles BTNPUBLISHERNEXT.Click
        If BaseMaintenance.PPrev < BaseMaintenance.PMAX Then
            BaseMaintenance.PPrev += 1
            LBLPUBLISHERPREV.Text = BaseMaintenance.PPrev
            DGPUBLISHER.DataSource = BaseMaintenance.Fetch(QueryTableType.PUBLISHER_QUERY_TABLE)
        End If
    End Sub

    Private Sub BTNPUBLISHERPREV_Click(sender As Object, e As EventArgs) Handles BTNPUBLISHERPREV.Click
        If BaseMaintenance.PPrev > 1 Then
            BaseMaintenance.PPrev -= 1
            LBLPUBLISHERPREV.Text = BaseMaintenance.PPrev
            DGPUBLISHER.DataSource = BaseMaintenance.Fetch(QueryTableType.PUBLISHER_QUERY_TABLE)
        End If
    End Sub

    Private Sub DGPUBLISHER_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGPUBLISHER.CellMouseClick
        If e.ColumnIndex <> 0 Then
            If DGPUBLISHER.SelectedRows.Count > 0 Then
                Dim datarow As DataRowView = DGPUBLISHER.SelectedRows.Item(0).DataBoundItem
                Using dialog As New PublisherDialog(datarow)
                    dialog.ShowDialog()
                End Using
            End If
            DGPUBLISHER.DataSource = BaseMaintenance.Fetch(QueryTableType.PUBLISHER_QUERY_TABLE)
            LBLPUBLISHERNEXT.Text = BaseMaintenance.PMAX
            LBLPUBLISHERPREV.Text = BaseMaintenance.PPrev
        End If
    End Sub

    Private Sub TXTPUBLSHERSEARCH_TextChanged(sender As Object, e As EventArgs) Handles TXTPUBLISHERSEARCH.TextChanged
        If MaintenancePanels.SelectedTab.Equals(PublishhersTab) Then
            If Not String.IsNullOrEmpty(TXTPUBLISHERSEARCH.Text) Then
                DGPUBLISHER.DataSource = BaseMaintenance.Search(QueryTableType.PUBLISHER_QUERY_TABLE, TXTPUBLISHERSEARCH.Text)
                LBLPUBLISHERNEXT.Text = BaseMaintenance.PMAX
                LBLPUBLISHERPREV.Text = BaseMaintenance.PPrev
            Else
                DGPUBLISHER.DataSource = BaseMaintenance.Fetch(QueryTableType.PUBLISHER_QUERY_TABLE)
                LBLPUBLISHERNEXT.Text = BaseMaintenance.PMAX
                LBLPUBLISHERPREV.Text = BaseMaintenance.PPrev
            End If
        End If
    End Sub
#End Region

#Region "Classification Module"
    Private Sub BTNADDCLASSIFICATION_Click(sender As Object, e As EventArgs) Handles BTNADDCLASSIFICATION.Click
        Using dialog = ClassificationDialog
            dialog.ShowDialog()
        End Using
        DGCLASSIFICATIONS.DataSource = BaseMaintenance.Fetch(QueryTableType.CLASSIFICATION_QUERY_TABLE)
        LBLCLASSIFICATIONNEXT.Text = BaseMaintenance.PMAX
        LBLCLASSIFICATIONPREV.Text = BaseMaintenance.PPrev
    End Sub

    Private Sub BTNCLASSIFICATIONNEXT_Click(sender As Object, e As EventArgs) Handles BTNCLASSIFICATIONNEXT.Click
        If BaseMaintenance.PPrev < BaseMaintenance.PMAX Then
            BaseMaintenance.PPrev += 1
            LBLCLASSIFICATIONPREV.Text = BaseMaintenance.PPrev
            DGCLASSIFICATIONS.DataSource = BaseMaintenance.Fetch(QueryTableType.CLASSIFICATION_QUERY_TABLE)
        End If
    End Sub

    Private Sub BTNCLASSIFICATIONPREV_Click(sender As Object, e As EventArgs) Handles BTNCLASSIFICATIONPREV.Click
        If BaseMaintenance.PPrev > 1 Then
            BaseMaintenance.PPrev -= 1
            LBLCLASSIFICATIONPREV.Text = BaseMaintenance.PPrev
            DGCLASSIFICATIONS.DataSource = BaseMaintenance.Fetch(QueryTableType.CLASSIFICATION_QUERY_TABLE)
        End If
    End Sub

    Private Sub DGCLASSIFICATION_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGCLASSIFICATIONS.CellMouseClick
        If e.ColumnIndex <> 0 Then
            If DGCLASSIFICATIONS.SelectedRows.Count > 0 Then
                Dim datarow As DataRowView = DGCLASSIFICATIONS.SelectedRows.Item(0).DataBoundItem
                Using dialog As New ClassificationDialog(datarow)
                    dialog.ShowDialog()
                End Using
            End If
            DGCLASSIFICATIONS.DataSource = BaseMaintenance.Fetch(QueryTableType.CLASSIFICATION_QUERY_TABLE)
            LBLCLASSIFICATIONNEXT.Text = BaseMaintenance.PMAX
            LBLCLASSIFICATIONPREV.Text = BaseMaintenance.PPrev
        End If
    End Sub

    Private Sub TXTCLASSIFICATIONSEARCH_TextChanged(sender As Object, e As EventArgs) Handles TXTCLASSIFICATIONSEARCH.TextChanged
        If MaintenancePanels.SelectedTab.Equals(ClassificationTab) Then
            If Not String.IsNullOrEmpty(TXTCLASSIFICATIONSEARCH.Text) Then
                DGCLASSIFICATIONS.DataSource = BaseMaintenance.Search(QueryTableType.CLASSIFICATION_QUERY_TABLE, TXTCLASSIFICATIONSEARCH.Text)
                LBLCLASSIFICATIONNEXT.Text = BaseMaintenance.PMAX
                LBLCLASSIFICATIONPREV.Text = BaseMaintenance.PPrev
            Else
                DGCLASSIFICATIONS.DataSource = BaseMaintenance.Fetch(QueryTableType.CLASSIFICATION_QUERY_TABLE)
                LBLCLASSIFICATIONNEXT.Text = BaseMaintenance.PMAX
                LBLCLASSIFICATIONPREV.Text = BaseMaintenance.PPrev
            End If
        End If
    End Sub
#End Region

#Region "Donator Module"
    Private Sub BTNADDDONATOR_Click(sender As Object, e As EventArgs) Handles BTNADDDONATOR.Click
        Using dialog = DonatorDialog
            dialog.ShowDialog()
        End Using
        DGDONATOR.DataSource = BaseMaintenance.Fetch(QueryTableType.DONATOR_QUERY_TABLE)
        LBLDONATORNEXT.Text = BaseMaintenance.PMAX
        LBLDONATORRPREV.Text = BaseMaintenance.PPrev
    End Sub

    Private Sub BTNDONATORNEXT_Click(sender As Object, e As EventArgs) Handles BTNDONATORNEXT.Click
        If BaseMaintenance.PPrev < BaseMaintenance.PMAX Then
            BaseMaintenance.PPrev += 1
            LBLDONATORRPREV.Text = BaseMaintenance.PPrev
            DGDONATOR.DataSource = BaseMaintenance.Fetch(QueryTableType.DONATOR_QUERY_TABLE)
        End If
    End Sub

    Private Sub BTNDONATORPREV_Click(sender As Object, e As EventArgs) Handles BTNDONATORRPREV.Click
        If BaseMaintenance.PPrev > 1 Then
            BaseMaintenance.PPrev -= 1
            LBLDONATORRPREV.Text = BaseMaintenance.PPrev
            DGDONATOR.DataSource = BaseMaintenance.Fetch(QueryTableType.DONATOR_QUERY_TABLE)
        End If
    End Sub

    Private Sub DGDONATOR_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGDONATOR.CellMouseClick
        If e.ColumnIndex <> 0 Then
            If DGDONATOR.SelectedRows.Count > 0 Then
                Dim datarow As DataRowView = DGDONATOR.SelectedRows.Item(0).DataBoundItem
                Using dialog As New DonatorDialog(datarow)
                    dialog.ShowDialog()
                End Using
            End If
            DGDONATOR.DataSource = BaseMaintenance.Fetch(QueryTableType.DONATOR_QUERY_TABLE)
            LBLDONATORNEXT.Text = BaseMaintenance.PMAX
            LBLDONATORRPREV.Text = BaseMaintenance.PPrev
        End If
    End Sub

    Private Sub TXTDONATORSEARCH_TextChanged(sender As Object, e As EventArgs) Handles TXTDONATORSEARCH.TextChanged
        If MaintenancePanels.SelectedTab.Equals(DonatorsTab) Then
            If Not String.IsNullOrEmpty(TXTDONATORSEARCH.Text) Then
                DGDONATOR.DataSource = BaseMaintenance.Search(QueryTableType.DONATOR_QUERY_TABLE, TXTDONATORSEARCH.Text)
                LBLDONATORNEXT.Text = BaseMaintenance.PMAX
                LBLDONATORRPREV.Text = BaseMaintenance.PPrev
            Else
                DGDONATOR.DataSource = BaseMaintenance.Fetch(QueryTableType.DONATOR_QUERY_TABLE)
                LBLDONATORNEXT.Text = BaseMaintenance.PMAX
                LBLDONATORRPREV.Text = BaseMaintenance.PPrev
            End If
        End If
    End Sub
#End Region

#Region "Supplier Module"
    Private Sub BTNADDSUPPLIER_Click(sender As Object, e As EventArgs) Handles BTNADDSUPPLIER.Click
        Using dialog = SupplierDialog
            dialog.ShowDialog()
        End Using
        DGSUPPLIER.DataSource = BaseMaintenance.Fetch(QueryTableType.SUPPLIER_QUERY_TABLE)
        LBLSUPPLIERNEXT.Text = BaseMaintenance.PMAX
        LBLSUPPLIERPREV.Text = BaseMaintenance.PPrev
    End Sub

    Private Sub BTNSUPPLIERNEXT_Click(sender As Object, e As EventArgs) Handles BTNSUPPLIERNEXT.Click
        If BaseMaintenance.PPrev < BaseMaintenance.PMAX Then
            BaseMaintenance.PPrev += 1
            LBLSUPPLIERPREV.Text = BaseMaintenance.PPrev
            DGSUPPLIER.DataSource = BaseMaintenance.Fetch(QueryTableType.SUPPLIER_QUERY_TABLE)
        End If
    End Sub

    Private Sub BTNSUPPLIERPREV_Click(sender As Object, e As EventArgs) Handles BTNSUPPLIERPREV.Click
        If BaseMaintenance.PPrev > 1 Then
            BaseMaintenance.PPrev -= 1
            LBLSUPPLIERPREV.Text = BaseMaintenance.PPrev
            DGSUPPLIER.DataSource = BaseMaintenance.Fetch(QueryTableType.SUPPLIER_QUERY_TABLE)
        End If
    End Sub

    Private Sub DGSUPPLIER_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGSUPPLIER.CellMouseClick
        If e.ColumnIndex <> 0 Then
            If DGSUPPLIER.SelectedRows.Count > 0 Then
                Dim datarow As DataRowView = DGSUPPLIER.SelectedRows.Item(0).DataBoundItem
                Using dialog As New SupplierDialog(datarow)
                    dialog.ShowDialog()
                End Using
            End If
            DGSUPPLIER.DataSource = BaseMaintenance.Fetch(QueryTableType.SUPPLIER_QUERY_TABLE)
            LBLSUPPLIERNEXT.Text = BaseMaintenance.PMAX
            LBLSUPPLIERPREV.Text = BaseMaintenance.PPrev
        End If
    End Sub

    Private Sub TXTSUPPLIERSEARCH_TextChanged(sender As Object, e As EventArgs) Handles TXTSUPPLIERSEARCH.TextChanged
        If MaintenancePanels.SelectedTab.Equals(SuppliersTab) Then
            If Not String.IsNullOrEmpty(TXTSUPPLIERSEARCH.Text) Then
                DGSUPPLIER.DataSource = BaseMaintenance.Search(QueryTableType.SUPPLIER_QUERY_TABLE, TXTSUPPLIERSEARCH.Text)
                LBLSUPPLIERNEXT.Text = BaseMaintenance.PMAX
                LBLSUPPLIERPREV.Text = BaseMaintenance.PPrev
            Else
                DGSUPPLIER.DataSource = BaseMaintenance.Fetch(QueryTableType.SUPPLIER_QUERY_TABLE)
                LBLSUPPLIERNEXT.Text = BaseMaintenance.PMAX
                LBLSUPPLIERPREV.Text = BaseMaintenance.PPrev
            End If
        End If
    End Sub
#End Region

#Region "Department Module"
    Private Sub BTNADDDEPARTMENT_Click(sender As Object, e As EventArgs) Handles BTNADDDEPARTMENT.Click
        Using dialog = DepartmentDialog
            dialog.ShowDialog()
        End Using
        DGDEPARTMENT.DataSource = BaseMaintenance.Fetch(QueryTableType.DEPARTMENT_QUERY_TABLE)
        LBLDEPARTMENTNEXT.Text = BaseMaintenance.PMAX
        LBLDEPARTMENTPREV.Text = BaseMaintenance.PPrev
    End Sub

    Private Sub BTNDEPARTMENTNEXT_Click(sender As Object, e As EventArgs) Handles BTNDEPARTMENTNEXT.Click
        If BaseMaintenance.PPrev < BaseMaintenance.PMAX Then
            BaseMaintenance.PPrev += 1
            LBLDEPARTMENTPREV.Text = BaseMaintenance.PPrev
            DGDEPARTMENT.DataSource = BaseMaintenance.Fetch(QueryTableType.DEPARTMENT_QUERY_TABLE)
        End If
    End Sub

    Private Sub BTNDEPARTMENTPREV_Click(sender As Object, e As EventArgs) Handles BTNDEPARTMENTPREV.Click
        If BaseMaintenance.PPrev > 1 Then
            BaseMaintenance.PPrev -= 1
            LBLDEPARTMENTPREV.Text = BaseMaintenance.PPrev
            DGDEPARTMENT.DataSource = BaseMaintenance.Fetch(QueryTableType.DEPARTMENT_QUERY_TABLE)
        End If
    End Sub

    Private Sub DGDEPARTMENT_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGDEPARTMENT.CellMouseClick
        If e.ColumnIndex <> 0 Then
            If DGDEPARTMENT.SelectedRows.Count > 0 Then
                Dim datarow As DataRowView = DGDEPARTMENT.SelectedRows.Item(0).DataBoundItem
                Using dialog As New DepartmentDialog(datarow)
                    dialog.ShowDialog()
                End Using
            End If
            DGDEPARTMENT.DataSource = BaseMaintenance.Fetch(QueryTableType.DEPARTMENT_QUERY_TABLE)
            LBLDEPARTMENTNEXT.Text = BaseMaintenance.PMAX
            LBLDEPARTMENTPREV.Text = BaseMaintenance.PPrev
        End If
    End Sub

    Private Sub TXTDEPARTMENTSEARCH_TextChanged(sender As Object, e As EventArgs) Handles TXTDEPARTMENTSEARCH.TextChanged
        If AccountsPanel.SelectedTab.Equals(DepartmentTab) Then
            If Not String.IsNullOrEmpty(TXTDEPARTMENTSEARCH.Text) Then
                DGDEPARTMENT.DataSource = BaseMaintenance.Search(QueryTableType.DEPARTMENT_QUERY_TABLE, TXTDEPARTMENTSEARCH.Text)
                LBLDEPARTMENTNEXT.Text = BaseMaintenance.PMAX
                LBLGENREPREV.Text = BaseMaintenance.PPrev
            Else
                DGDEPARTMENT.DataSource = BaseMaintenance.Fetch(QueryTableType.DEPARTMENT_QUERY_TABLE)
                LBLDEPARTMENTNEXT.Text = BaseMaintenance.PMAX
                LBLDEPARTMENTPREV.Text = BaseMaintenance.PPrev
            End If
        End If
    End Sub
#End Region

#Region "Year Level Module"
    Private Sub BTNADDYEARLEVEL_Click(sender As Object, e As EventArgs) Handles BTNADDYEARLEVEL.Click
        Using dialog = YearLevelDialog
            dialog.ShowDialog()
        End Using
        DGYEARLEVEL.DataSource = BaseMaintenance.Fetch(QueryTableType.YEARLEVEL_QUERY_TABLE)
        LBLYEARLEVELNEXT.Text = BaseMaintenance.PMAX
        LBLYEARLEVELPREV.Text = BaseMaintenance.PPrev
    End Sub

    Private Sub BTNYEARLEVELNEXT_Click(sender As Object, e As EventArgs) Handles BTNYEARLEVELNEXT.Click
        If BaseMaintenance.PPrev < BaseMaintenance.PMAX Then
            BaseMaintenance.PPrev += 1
            LBLYEARLEVELPREV.Text = BaseMaintenance.PPrev
            DGYEARLEVEL.DataSource = BaseMaintenance.Fetch(QueryTableType.YEARLEVEL_QUERY_TABLE)
        End If
    End Sub

    Private Sub BTNYEARLEVELPREV_Click(sender As Object, e As EventArgs) Handles BTNYEARLEVELPREV.Click
        If BaseMaintenance.PPrev > 1 Then
            BaseMaintenance.PPrev -= 1
            LBLYEARLEVELPREV.Text = BaseMaintenance.PPrev
            DGYEARLEVEL.DataSource = BaseMaintenance.Fetch(QueryTableType.YEARLEVEL_QUERY_TABLE)
        End If
    End Sub

    Private Sub DGYEARLEVEL_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGYEARLEVEL.CellMouseClick
        If e.ColumnIndex <> 0 Then
            If DGYEARLEVEL.SelectedRows.Count > 0 Then
                Dim datarow As DataRowView = DGYEARLEVEL.SelectedRows.Item(0).DataBoundItem
                Using dialog As New YearLevelDialog(datarow)
                    dialog.ShowDialog()
                End Using
            End If
            DGYEARLEVEL.DataSource = BaseMaintenance.Fetch(QueryTableType.YEARLEVEL_QUERY_TABLE)
            LBLYEARLEVELNEXT.Text = BaseMaintenance.PMAX
            LBLYEARLEVELPREV.Text = BaseMaintenance.PPrev
        End If
    End Sub

    Private Sub TXTYEARLEVELSEARCH_TextChanged(sender As Object, e As EventArgs) Handles TXTYEARLEVELSEARCH.TextChanged
        If AccountsPanel.SelectedTab.Equals(YearLevelTab) Then
            If Not String.IsNullOrEmpty(TXTYEARLEVELSEARCH.Text) Then
                DGYEARLEVEL.DataSource = BaseMaintenance.Search(QueryTableType.YEARLEVEL_QUERY_TABLE, TXTYEARLEVELSEARCH.Text)
                LBLYEARLEVELNEXT.Text = BaseMaintenance.PMAX
                LBLYEARLEVELPREV.Text = BaseMaintenance.PPrev
            Else
                DGYEARLEVEL.DataSource = BaseMaintenance.Fetch(QueryTableType.YEARLEVEL_QUERY_TABLE)
                LBLYEARLEVELNEXT.Text = BaseMaintenance.PMAX
                LBLYEARLEVELPREV.Text = BaseMaintenance.PPrev
            End If
        End If
    End Sub
#End Region

#Region "Language Module"
    Private Sub BTNADDLANGUAGE_Click(sender As Object, e As EventArgs) Handles BTNADDLANGUAGE.Click
        Using dialog = LanguageDialog
            dialog.ShowDialog()
        End Using
        DGLANGUAGE.DataSource = BaseMaintenance.Fetch(QueryTableType.LANGUAGES_QUERY_TABLE)
        LBLLANGUAGENEXT.Text = BaseMaintenance.PMAX
        LBLLANGUAGEPREV.Text = BaseMaintenance.PPrev
    End Sub

    Private Sub BTNLANGUAGENEXT_Click(sender As Object, e As EventArgs) Handles BTNLANGUAGENEXT.Click
        If BaseMaintenance.PPrev < BaseMaintenance.PMAX Then
            BaseMaintenance.PPrev += 1
            LBLLANGUAGEPREV.Text = BaseMaintenance.PPrev
            DGLANGUAGE.DataSource = BaseMaintenance.Fetch(QueryTableType.LANGUAGES_QUERY_TABLE)
        End If
    End Sub

    Private Sub BTNLANGUAGEPREV_Click(sender As Object, e As EventArgs) Handles BTNLANGUAGEPREV.Click
        If BaseMaintenance.PPrev > 1 Then
            BaseMaintenance.PPrev -= 1
            LBLLANGUAGEPREV.Text = BaseMaintenance.PPrev
            DGLANGUAGE.DataSource = BaseMaintenance.Fetch(QueryTableType.LANGUAGES_QUERY_TABLE)
        End If
    End Sub

    Private Sub DGLANGUAGE_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGLANGUAGE.CellMouseClick
        If e.ColumnIndex <> 0 Then
            If DGLANGUAGE.SelectedRows.Count > 0 Then
                Dim datarow As DataRowView = DGLANGUAGE.SelectedRows.Item(0).DataBoundItem
                Using dialog As New LanguageDialog(datarow)
                    dialog.ShowDialog()
                End Using
            End If
            DGLANGUAGE.DataSource = BaseMaintenance.Fetch(QueryTableType.LANGUAGES_QUERY_TABLE)
            LBLLANGUAGENEXT.Text = BaseMaintenance.PMAX
            LBLLANGUAGEPREV.Text = BaseMaintenance.PPrev
        End If
    End Sub

    Private Sub TXLANGUAGESEARCH_TextChanged(sender As Object, e As EventArgs) Handles TXTLANGUAGESEARCH.TextChanged
        If MaintenancePanels.SelectedTab.Equals(LanguagesTab) Then
            If Not String.IsNullOrEmpty(TXTLANGUAGESEARCH.Text) Then
                DGLANGUAGE.DataSource = BaseMaintenance.Search(QueryTableType.LANGUAGES_QUERY_TABLE, TXTLANGUAGESEARCH.Text)
                LBLLANGUAGENEXT.Text = BaseMaintenance.PMAX
                LBLLANGUAGEPREV.Text = BaseMaintenance.PPrev
            Else
                DGLANGUAGE.DataSource = BaseMaintenance.Fetch(QueryTableType.LANGUAGES_QUERY_TABLE)
                LBLLANGUAGENEXT.Text = BaseMaintenance.PMAX
                LBLLANGUAGEPREV.Text = BaseMaintenance.PPrev
            End If
        End If
    End Sub
#End Region

#Region "Book Module"
    ' TODO create an algo for unselecting, the item should be removed from the selected items
    Private Sub BTNADDBOOK_Click(sender As Object, e As EventArgs) Handles BTNADDBOOK.Click
        Using dialog = BookDialog
            dialog.ShowDialog()
        End Using
        DGBOOKS.DataSource = BaseMaintenance.Fetch(QueryTableType.BOOK_QUERY_TABLE)
        LBLBOOKNEXT.Text = BaseMaintenance.PMAX
        LBLBOOKPREV.Text = BaseMaintenance.PPrev
    End Sub

    Private Sub BTNBOOKNEXT_Click(sender As Object, e As EventArgs) Handles BTNBOOKNEXT.Click
        ' Before going to next page fetch all the selected values that are not in the select collection
        For Each item As DataGridViewRow In DGBOOKS.Rows
            Dim boundItem As DataRowView = TryCast(item.DataBoundItem, DataRowView)
            If item.Cells(NameOf(chckBoxBooks)).Value AndAlso Not SELECTED_BOOKS.Rows.Contains(boundItem.Row.Item("id")) Then
                SELECTED_BOOKS.Rows.Add(boundItem.Row.ItemArray)
            End If
        Next

        If BaseMaintenance.PPrev < BaseMaintenance.PMAX Then
            BaseMaintenance.PPrev += 1
            LBLBOOKPREV.Text = BaseMaintenance.PPrev
            DGBOOKS.DataSource = BaseMaintenance.Fetch(QueryTableType.BOOK_QUERY_TABLE)
        End If

        DGBOOKS.BeginEdit(True)
        ' Retain the previously selected rows
        For Each item As DataGridViewRow In DGBOOKS.Rows
            For Each drow As DataRow In SELECTED_BOOKS.Rows
                Dim boundItem As DataRowView = TryCast(item.DataBoundItem, DataRowView)
                If boundItem.Row.Item("id") = drow.Item("id") Then
                    item.Cells(NameOf(chckBoxBooks)).Value = True
                End If
            Next
        Next
        DGBOOKS.EndEdit()
    End Sub

    Private Sub BTNBOOKPREV_Click(sender As Object, e As EventArgs) Handles BTNBOOKPREV.Click
        ' Before going to prev page fetch all the selected values that are not in the select collection
        For Each item As DataGridViewRow In DGBOOKS.Rows
            Dim boundItem As DataRowView = TryCast(item.DataBoundItem, DataRowView)
            If item.Cells(NameOf(chckBoxBooks)).Value AndAlso Not SELECTED_BOOKS.Rows.Contains(boundItem.Row.Item("id")) Then
                SELECTED_BOOKS.Rows.Add(boundItem.Row.ItemArray)
            End If
        Next

        If BaseMaintenance.PPrev > 1 Then
            BaseMaintenance.PPrev -= 1
            LBLBOOKPREV.Text = BaseMaintenance.PPrev
            DGBOOKS.DataSource = BaseMaintenance.Fetch(QueryTableType.BOOK_QUERY_TABLE)
        End If

        DGBOOKS.BeginEdit(True)
        ' Retain the previously selected rows
        For Each item As DataGridViewRow In DGBOOKS.Rows
            For Each drow As DataRow In SELECTED_BOOKS.Rows
                Dim boundItem As DataRowView = TryCast(item.DataBoundItem, DataRowView)
                If boundItem.Row.Item("id") = drow.Item("id") Then
                    item.Cells(NameOf(chckBoxBooks)).Value = True
                End If
            Next
        Next
        DGBOOKS.EndEdit()
    End Sub

    Private Sub DGBOOK_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGBOOKS.CellMouseClick
        If e.ColumnIndex <> 0 Then
            If DGBOOKS.SelectedRows.Count > 0 Then
                Dim datarow As DataRowView = DGBOOKS.SelectedRows.Item(0).DataBoundItem
                Using dialog As New BookDialog(datarow)
                    dialog.ShowDialog()
                End Using
            End If
            DGBOOKS.DataSource = BaseMaintenance.Fetch(QueryTableType.BOOK_QUERY_TABLE)
            LBLBOOKNEXT.Text = BaseMaintenance.PMAX
            LBLBOOKPREV.Text = BaseMaintenance.PPrev
        End If
    End Sub

    Private Sub TXBOOKSEARCH_TextChanged(sender As Object, e As EventArgs) Handles TXTBOOKSEARCH.TextChanged
        If MaintenancePanels.SelectedTab.Equals(BooksTab) Then
            If Not String.IsNullOrEmpty(TXTBOOKSEARCH.Text) Then
                DGBOOKS.DataSource = BaseMaintenance.Search(QueryTableType.BOOK_QUERY_TABLE, TXTBOOKSEARCH.Text)
                LBLBOOKNEXT.Text = BaseMaintenance.PMAX
                LBLBOOKPREV.Text = BaseMaintenance.PPrev
            Else
                DGBOOKS.DataSource = BaseMaintenance.Fetch(QueryTableType.BOOK_QUERY_TABLE)
                LBLBOOKNEXT.Text = BaseMaintenance.PMAX
                LBLBOOKPREV.Text = BaseMaintenance.PPrev
            End If
        End If
    End Sub
#End Region

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
        If BaseMaintenance.PPrev < BaseMaintenance.PMAX Then
            BaseMaintenance.PPrev += 1
            LBLSECTIONPREV.Text = BaseMaintenance.PPrev
            DGSECTIONS.DataSource = BaseMaintenance.Fetch(QueryTableType.SECTION_QUERY_TABLE)
        End If
    End Sub

    Private Sub BTNSECTIONPPREV_Click(sender As Object, e As EventArgs) Handles BTNSECTIONPREV.Click
        If BaseMaintenance.PPrev > 1 Then
            BaseMaintenance.PPrev -= 1
            LBLSECTIONPREV.Text = BaseMaintenance.PPrev
            DGSECTIONS.DataSource = BaseMaintenance.Fetch(QueryTableType.SECTION_QUERY_TABLE)
        End If
    End Sub

    Private Sub DGSECTION_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGSECTIONS.CellMouseClick
        If e.ColumnIndex <> 0 Then
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
        If AccountsPanel.SelectedTab.Equals(SectionTab) Then
            If Not String.IsNullOrEmpty(TXTSECTIONSEARCH.Text) Then
                DGSECTIONS.DataSource = BaseMaintenance.Search(QueryTableType.SECTION_QUERY_TABLE, TXTSECTIONSEARCH.Text)
                LBLSECTIONNEXT.Text = BaseMaintenance.PMAX
                LBLSECTIONPREV.Text = BaseMaintenance.PPrev
            Else
                DGSECTIONS.DataSource = BaseMaintenance.Fetch(QueryTableType.SECTION_QUERY_TABLE)
                LBLSECTIONNEXT.Text = BaseMaintenance.PMAX
                LBLSECTIONPREV.Text = BaseMaintenance.PPrev
            End If
        End If
    End Sub
#End Region

#Region "Student Module"
    Private Sub BTNADDSTUDENTS_Click(sender As Object, e As EventArgs) Handles BTNADDSTUDENTS.Click
        Using dialog = StudentDialog
            dialog.ShowDialog()
        End Using
        DGSTUDENT.DataSource = BaseMaintenance.Fetch(QueryTableType.STUDENT_QUERY_TABLE)
        LBLSTUDENTNEXT.Text = BaseMaintenance.PMAX
        LBLSTUDENTPREV.Text = BaseMaintenance.PPrev
    End Sub

    Private Sub BTNSTUDENTNEXT_Click(sender As Object, e As EventArgs) Handles BTNSTUDENTNEXT.Click
        If BaseMaintenance.PPrev < BaseMaintenance.PMAX Then
            BaseMaintenance.PPrev += 1
            LBLSTUDENTPREV.Text = BaseMaintenance.PPrev
            DGSTUDENT.DataSource = BaseMaintenance.Fetch(QueryTableType.STUDENT_QUERY_TABLE)
        End If
    End Sub

    Private Sub BTNSTUDENTPREV_Click(sender As Object, e As EventArgs) Handles BTNSTUDENTPREV.Click
        If BaseMaintenance.PPrev > 1 Then
            BaseMaintenance.PPrev -= 1
            LBLSTUDENTPREV.Text = BaseMaintenance.PPrev
            DGSTUDENT.DataSource = BaseMaintenance.Fetch(QueryTableType.STUDENT_QUERY_TABLE)
        End If
    End Sub

    Private Sub DGSTUDENT_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGSTUDENT.CellMouseClick
        If e.ColumnIndex <> 0 Then
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
            If Not String.IsNullOrEmpty(TXTSTUDENTSEARCH.Text) Then
                DGSTUDENT.DataSource = BaseMaintenance.Search(QueryTableType.STUDENT_QUERY_TABLE, TXTSTUDENTSEARCH.Text)
                LBLSTUDENTNEXT.Text = BaseMaintenance.PMAX
                LBLSTUDENTPREV.Text = BaseMaintenance.PPrev
            Else
                DGSTUDENT.DataSource = BaseMaintenance.Fetch(QueryTableType.STUDENT_QUERY_TABLE)
                LBLSTUDENTNEXT.Text = BaseMaintenance.PMAX
                LBLSTUDENTPREV.Text = BaseMaintenance.PPrev
            End If
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
    End Sub

    Private Sub BTNFACULTYPREV_Click(sender As Object, e As EventArgs) Handles BTNFACULTYPREV.Click
        If BaseMaintenance.PPrev > 1 Then
            BaseMaintenance.PPrev -= 1
            LBLFACULTYPREV.Text = BaseMaintenance.PPrev
            DGFACULTY.DataSource = BaseMaintenance.Fetch(QueryTableType.FACULTY_QUERY_TABLE)
        End If
    End Sub

    Private Sub DGFACULTY_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGFACULTY.CellMouseClick
        If e.ColumnIndex <> 0 Then
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
            If Not String.IsNullOrEmpty(TXTFACULTYSEARCH.Text) Then
                DGFACULTY.DataSource = BaseMaintenance.Search(QueryTableType.FACULTY_QUERY_TABLE, TXTFACULTYSEARCH.Text)
                LBLFACULTYNEXT.Text = BaseMaintenance.PMAX
                LBLFACULTYPREV.Text = BaseMaintenance.PPrev
            Else
                DGFACULTY.DataSource = BaseMaintenance.Fetch(QueryTableType.FACULTY_QUERY_TABLE)
                LBLFACULTYNEXT.Text = BaseMaintenance.PMAX
                LBLFACULTYPREV.Text = BaseMaintenance.PPrev
            End If
        End If
    End Sub
#End Region

#Region "Select All Datagrid"
    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        If MainFormPanels.SelectedTab.Equals(MaintenanceTab) Then
            Select Case True
                Case MaintenancePanels.SelectedTab.Equals(GenresTab)
                    For Each item As DataGridViewRow In DGGENRE.Rows
                        item.Cells("chckBoxGenre").Value = True
                    Next
                    DGGENRE.EndEdit()
                Case MaintenancePanels.SelectedTab.Equals(AuthorTab)
                    For Each item As DataGridViewRow In DGAUTHORS.Rows
                        item.Cells("chckBoxAuthor").Value = True
                    Next
                    DGAUTHORS.EndEdit()
                Case MaintenancePanels.SelectedTab.Equals(PublishhersTab)
                    For Each item As DataGridViewRow In DGPUBLISHER.Rows
                        item.Cells("chckBoxPublisher").Value = True
                    Next
                    DGPUBLISHER.EndEdit()
                Case MaintenancePanels.SelectedTab.Equals(DonatorsTab)
                    For Each item As DataGridViewRow In DGDONATOR.Rows
                        item.Cells("chckBoxDonator").Value = True
                    Next
                    DGDONATOR.EndEdit()
                Case MaintenancePanels.SelectedTab.Equals(SuppliersTab)
                    For Each item As DataGridViewRow In DGSUPPLIER.Rows
                        item.Cells("chckBoxSupplier").Value = True
                    Next
                    DGSUPPLIER.EndEdit()
                Case MaintenancePanels.SelectedTab.Equals(ClassificationTab)
                    For Each item As DataGridViewRow In DGCLASSIFICATIONS.Rows
                        item.Cells("chckBoxClassification").Value = True
                    Next
                    DGCLASSIFICATIONS.EndEdit()
                Case MaintenancePanels.SelectedTab.Equals(LanguagesTab)
                    For Each item As DataGridViewRow In DGLANGUAGE.Rows
                        item.Cells("chckBoxLanguage").Value = True
                    Next
                    DGLANGUAGE.EndEdit()
                Case MaintenancePanels.SelectedTab.Equals(DonatorsTab)
                    For Each item As DataGridViewRow In DGDONATOR.Rows
                        item.Cells("chckBoxDonator").Value = True
                    Next
                    DGDONATOR.EndEdit()
                Case MaintenancePanels.SelectedTab.Equals(SuppliersTab)
                    For Each item As DataGridViewRow In DGSUPPLIER.Rows
                        item.Cells("chckBoxSupplier").Value = True
                    Next
                    DGSUPPLIER.EndEdit()
            End Select
        Else
            Select Case True
                Case AccountsPanel.SelectedTab.Equals(DepartmentTab)
                    For Each item As DataGridViewRow In DGDEPARTMENT.Rows
                        item.Cells("chckBoxDepartment").Value = True
                    Next
                    DGDEPARTMENT.EndEdit()
            End Select
        End If
    End Sub
#End Region

#Region "Unselect All"
    Private Sub UnselectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnselectAllToolStripMenuItem.Click
        If MainFormPanels.SelectedTab.Equals(MaintenanceTab) Then
            Select Case True
            ' Maintenance Panel Selection
                Case MaintenancePanels.SelectedTab.Equals(GenresTab)
                    For Each item As DataGridViewRow In DGGENRE.Rows
                        item.Cells("chckBoxGenre").Value = False
                    Next
                    DGGENRE.EndEdit()
                Case MaintenancePanels.SelectedTab.Equals(AuthorTab)
                    For Each item As DataGridViewRow In DGAUTHORS.Rows
                        item.Cells("chckBoxAuthor").Value = False
                    Next
                    DGAUTHORS.EndEdit()
                Case MaintenancePanels.SelectedTab.Equals(PublishhersTab)
                    For Each item As DataGridViewRow In DGPUBLISHER.Rows
                        item.Cells("chckBoxPublisher").Value = False
                    Next
                    DGPUBLISHER.EndEdit()
                Case MaintenancePanels.SelectedTab.Equals(DonatorsTab)
                    For Each item As DataGridViewRow In DGDONATOR.Rows
                        item.Cells("chckBoxDonator").Value = False
                    Next
                    DGDONATOR.EndEdit()
                Case MaintenancePanels.SelectedTab.Equals(SuppliersTab)
                    For Each item As DataGridViewRow In DGSUPPLIER.Rows
                        item.Cells("chckBoxSupplier").Value = False
                    Next
                    DGSUPPLIER.EndEdit()
                Case MaintenancePanels.SelectedTab.Equals(ClassificationTab)
                    For Each item As DataGridViewRow In DGCLASSIFICATIONS.Rows
                        item.Cells("chckBoxClassification").Value = False
                    Next
                    DGCLASSIFICATIONS.EndEdit()
                Case MaintenancePanels.SelectedTab.Equals(LanguagesTab)
                    For Each item As DataGridViewRow In DGLANGUAGE.Rows
                        item.Cells("chckBoxLanguage").Value = False
                    Next
                    DGLANGUAGE.EndEdit()
                Case MaintenancePanels.SelectedTab.Equals(DonatorsTab)
                    For Each item As DataGridViewRow In DGDONATOR.Rows
                        item.Cells("chckBoxDonator").Value = False
                    Next
                    DGDONATOR.EndEdit()
                Case MaintenancePanels.SelectedTab.Equals(SuppliersTab)
                    For Each item As DataGridViewRow In DGSUPPLIER.Rows
                        item.Cells("chckBoxSupplier").Value = False
                    Next
                    DGSUPPLIER.EndEdit()
            End Select
        Else
            Select Case True
                ' Accounts Panel Selection
                Case AccountsPanel.SelectedTab.Equals(DepartmentTab)
                    For Each item As DataGridViewRow In DGDEPARTMENT.Rows
                        item.Cells("chckBoxDepartment").Value = False
                    Next
                    DGDEPARTMENT.EndEdit()
            End Select
        End If
    End Sub
#End Region

#Region "Remove Selected"
    Private Sub RemoveSelectedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        ' TODO PERFORM A CHECK BEFORE DELETING THE DATA
        Select Case True
            Case MaintenancePanels.SelectedTab.Equals(GenresTab)
                DeleteHelper(DGGENRE, QueryTableType.GENRE_QUERY_TABLE, "chckBoxGenre", "ColumnGenreID")

            Case MaintenancePanels.SelectedTab.Equals(AuthorTab)
                DeleteHelper(DGAUTHORS, QueryTableType.AUTHOR_QUERY_TABLE, "chckBoxAuthor", "ColumnAuthorID")

            Case MaintenancePanels.SelectedTab.Equals(PublishhersTab)
                DeleteHelper(DGPUBLISHER, QueryTableType.PUBLISHER_QUERY_TABLE, "chckBoxPublisher", "ColumnPublisherID")

            Case MaintenancePanels.SelectedTab.Equals(ClassificationTab)
                DeleteHelper(DGCLASSIFICATIONS, QueryTableType.CLASSIFICATION_QUERY_TABLE, "chckBoxClassification", "ColumnClassificationID")

            Case MaintenancePanels.SelectedTab.Equals(LanguagesTab)
                DeleteHelper(DGLANGUAGE, QueryTableType.LANGUAGES_QUERY_TABLE, "chckBoxLanguage", "ColumnLanguageID")

            Case MaintenancePanels.SelectedTab.Equals(DonatorsTab)
                DeleteHelper(DGDONATOR, QueryTableType.DONATOR_QUERY_TABLE, "chckBoxDonator", "ColumnDonatorID")

            Case MaintenancePanels.SelectedTab.Equals(SuppliersTab)
                DeleteHelper(DGSUPPLIER, QueryTableType.SUPPLIER_QUERY_TABLE, "chckBoxSupplier", "ColumnSupplierID")
        End Select
    End Sub
#End Region

#Region "Maintenance Tab"
    Private Sub MaintenancePanels_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MaintenancePanels.SelectedIndexChanged
        Select Case True
            Case MaintenancePanels.SelectedTab.Equals(GenresTab)
                DGGENRE.DataSource = BaseMaintenance.Fetch(QueryTableType.GENRE_QUERY_TABLE)
                LBLGENREPREV.Text = BaseMaintenance.PPrev
                LBLGENRENEXT.Text = BaseMaintenance.PMAX

            Case MaintenancePanels.SelectedTab.Equals(AuthorTab)
                DGAUTHORS.DataSource = BaseMaintenance.Fetch(QueryTableType.AUTHOR_QUERY_TABLE)
                LBLAUTHORPREV.Text = BaseMaintenance.PPrev
                LBLAUTHORNEXT.Text = BaseMaintenance.PMAX

            Case MaintenancePanels.SelectedTab.Equals(PublishhersTab)
                DGPUBLISHER.DataSource = BaseMaintenance.Fetch(QueryTableType.PUBLISHER_QUERY_TABLE)
                LBLPUBLISHERPREV.Text = BaseMaintenance.PPrev
                LBLPUBLISHERNEXT.Text = BaseMaintenance.PMAX

            Case MaintenancePanels.SelectedTab.Equals(ClassificationTab)
                DGCLASSIFICATIONS.DataSource = BaseMaintenance.Fetch(QueryTableType.CLASSIFICATION_QUERY_TABLE)
                LBLCLASSIFICATIONNEXT.Text = BaseMaintenance.PMAX
                LBLCLASSIFICATIONPREV.Text = BaseMaintenance.PPrev

            Case MaintenancePanels.SelectedTab.Equals(DonatorsTab)
                DGDONATOR.DataSource = BaseMaintenance.Fetch(QueryTableType.DONATOR_QUERY_TABLE)
                LBLDONATORNEXT.Text = BaseMaintenance.PMAX
                LBLDONATORRPREV.Text = BaseMaintenance.PPrev

            Case MaintenancePanels.SelectedTab.Equals(SuppliersTab)
                DGSUPPLIER.DataSource = BaseMaintenance.Fetch(QueryTableType.SUPPLIER_QUERY_TABLE)
                LBLSUPPLIERNEXT.Text = BaseMaintenance.PMAX
                LBLSUPPLIERPREV.Text = BaseMaintenance.PPrev

            Case MaintenancePanels.SelectedTab.Equals(LanguagesTab)
                DGLANGUAGE.DataSource = BaseMaintenance.Fetch(QueryTableType.LANGUAGES_QUERY_TABLE)
                LBLLANGUAGENEXT.Text = BaseMaintenance.PMAX
                LBLLANGUAGEPREV.Text = BaseMaintenance.PPrev

            Case MaintenancePanels.SelectedTab.Equals(BooksTab)
                SELECTED_BOOKS = New SystemDataSets.DTBookDataTable
                DGBOOKS.DataSource = BaseMaintenance.Fetch(QueryTableType.BOOK_QUERY_TABLE)
                LBLBOOKNEXT.Text = BaseMaintenance.PMAX
                LBLBOOKPREV.Text = BaseMaintenance.PPrev
        End Select
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
        NextPageHelper(LBLADMINPREV, DGADMINISTRATOR, QueryTableType.ADMIN_QUERY_TABLE)
    End Sub

    Private Sub BTNADMINPPREV_Click(sender As Object, e As EventArgs) Handles BTNADMINPREV.Click
        PrevPageHelper(LBLADMINPREV, DGADMINISTRATOR, QueryTableType.ADMIN_QUERY_TABLE)
    End Sub

    Private Sub TXTADMINISTRATORSEARCH_TextChanged(sender As Object, e As EventArgs) Handles TXTADMINSEARCH.TextChanged
        SearchHelper(AccountsPanel, AdminTab, DGADMINISTRATOR, LBLADMINNEXT, LBLADMINPREV, QueryTableType.ADMIN_QUERY_TABLE, TXTADMINSEARCH)
    End Sub
#End Region

    Private Sub AccountsPanel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AccountsPanel.SelectedIndexChanged
        Select Case True
            Case AccountsPanel.SelectedTab.Equals(DepartmentTab)
                LoadTabData(DGDEPARTMENT, LBLDEPARTMENTPREV, LBLDEPARTMENTNEXT, QueryTableType.DEPARTMENT_QUERY_TABLE)

            Case AccountsPanel.SelectedTab.Equals(YearLevelTab)
                LoadTabData(DGYEARLEVEL, LBLYEARLEVELPREV, LBLYEARLEVELNEXT, QueryTableType.YEARLEVEL_QUERY_TABLE)

            Case AccountsPanel.SelectedTab.Equals(SectionTab)
                LoadTabData(DGSECTIONS, LBLSECTIONPREV, LBLSECTIONNEXT, QueryTableType.SECTION_QUERY_TABLE)

            Case AccountsPanel.SelectedTab.Equals(StudentsTab)
                LoadTabData(DGSTUDENT, LBLSTUDENTPREV, LBLSTUDENTNEXT, QueryTableType.STUDENT_QUERY_TABLE)

            Case AccountsPanel.SelectedTab.Equals(FacultyTab)
                LoadTabData(DGFACULTY, LBLFACULTYPREV, LBLFACULTYNEXT, QueryTableType.FACULTY_QUERY_TABLE)

            Case AccountsPanel.SelectedTab.Equals(AdminTab)
                LoadTabData(DGADMINISTRATOR, LBLADMINPREV, LBLADMINNEXT, QueryTableType.ADMIN_QUERY_TABLE)

        End Select
    End Sub

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
            DGBOOKCOPIES.DataSource = BaseMaintenance.Fetch(QueryTableType.BOOKCOPIES_QUERY_TABLE)
        End If
    End Sub

    Private Sub BTNCOPIESNEXT_Click(sender As Object, e As EventArgs) Handles BTNCOPIESNEXT.Click
        If BaseMaintenance.PPrev < BaseMaintenance.PMAX Then
            BaseMaintenance.PPrev += 1
            LBLCOPIESPREV.Text = BaseMaintenance.PPrev
            DGBOOKCOPIES.DataSource = BaseMaintenance.Fetch(QueryTableType.BOOKCOPIES_QUERY_TABLE)
        End If
    End Sub

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

#Region "Student Menu Strip"
    Private Sub PromoteAsAssistLibrarianToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PromoteAsAssistLibrarianToolStripMenuItem.Click

    End Sub
#End Region

#Region "Book Copies Module"
    Private Sub ArchiveSelectedToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ArchiveSelectedToolStripMenuItem2.Click
        ' TODO FIX THE ARCHIVING
        For Each item As DataGridViewRow In DGBOOKS.Rows
            DeleteHelper(DGBOOKCOPIES, QueryTableType.BOOKCOPIES_QUERY_TABLE, NameOf(chckBoxBooks), NameOf(ColumnBookID))
        Next
        DGBOOKS.EndEdit()
    End Sub

    Private Sub UnarchiveSelectedToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles UnarchiveSelectedToolStripMenuItem2.Click
        For Each item As DataGridViewRow In DGBOOKS.Rows
            item.Cells(NameOf(chckBoxBooks)).Value = True
        Next
        DGBOOKS.EndEdit()
    End Sub

    Private Sub SelectAllToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem1.Click
        For Each item As DataGridViewRow In DGBOOKS.Rows
            item.Cells(NameOf(chckBoxBooks)).Value = True
        Next
        DGBOOKS.EndEdit()
    End Sub

    Private Sub UnselectAllToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles UnselectAllToolStripMenuItem1.Click
        For Each item As DataGridViewRow In DGBOOKS.Rows
            item.Cells(NameOf(chckBoxBooks)).Value = False
        Next
        SELECTED_BOOKS = New SystemDataSets.DTBookDataTable
        DGBOOKS.EndEdit()
    End Sub

    Private Sub BTNADDCOPIES_Click(sender As Object, e As EventArgs) Handles BTNADDCOPIES.Click
        ' TODO ADD SANITIZE THIS
        AddCopies(CInt(TXTQUANTITY.Text), TXTISBNCOPIES.Text, CInt(TXTPRICECOPIES.Text), CMBDONATORCOPIES.SelectedValue, CMBSUPPLIERCOPIES.SelectedValue)
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
            MyApplication.DialogInstances.Item(NameOf(BorrowDialog)).ShowDialog()
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
            MessageBox.Show("Cannot delete the selected items. Some items are being used to other resources. Please remove the them before deleting.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        dg.DataSource = BaseMaintenance.Fetch(qtype)
    End Sub

    Private Sub LoadTabData(dg As Object, lblPrev As Object, lblNext As Object, qtype As QueryTableType)
        dg.DataSource = BaseMaintenance.Fetch(qtype)
        lblPrev.Text = BaseMaintenance.PPrev
        lblNext.Text = BaseMaintenance.PMAX
    End Sub

    Private Sub NextPageHelper(prevButton As Object, dg As Object, qtype As QueryTableType)
        If BaseMaintenance.PPrev < BaseMaintenance.PMAX Then
            BaseMaintenance.PPrev += 1
            prevButton.Text = BaseMaintenance.PPrev
            dg.DataSource = BaseMaintenance.Fetch(qtype)
        End If
    End Sub

    Private Sub PrevPageHelper(prevButton As Object, dg As Object, qtype As QueryTableType)
        If BaseMaintenance.PPrev > 1 Then
            BaseMaintenance.PPrev -= 1
            prevButton.Text = BaseMaintenance.PPrev
            dg.DataSource = BaseMaintenance.Fetch(qtype)
        End If
    End Sub

    Private Sub SearchHelper(panel As Object, tab As Object, dg As Object, lblNext As Object, lblPrev As Object, qtype As QueryTableType, txtSearch As Object)
        If panel.SelectedTab.Equals(tab) Then
            If Not String.IsNullOrEmpty(txtSearch.Text) Then
                dg.DataSource = BaseMaintenance.Search(qtype, txtSearch.Text)
                lblNext.Text = BaseMaintenance.PMAX
                lblPrev.Text = BaseMaintenance.PPrev
            Else
                dg.DataSource = BaseMaintenance.Fetch(qtype)
                lblNext.Text = BaseMaintenance.PMAX
                lblPrev.Text = BaseMaintenance.PPrev
            End If
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
        MaintenancePanels_SelectedIndexChanged(MaintenancePanels, Nothing)
        BookInventoryPanels_SelectedIndexChanged(BookInventoryPanels, Nothing)
    End Sub
#End Region

End Class