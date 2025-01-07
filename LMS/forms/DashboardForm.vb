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
                Dim dialog As New ImportDataDialog(New BookImport, "importbook")
                If Not MyApplication.DialogInstances.ContainsKey("importbook") Then
                    MyApplication.DialogInstances.Add("importbook", dialog)
                    dialog.Show()
                Else
                    MyApplication.DialogInstances.Item("importbook").Show()
                End If
            Case sender.Equals(BTNIMPORTFACULTY)
                Dim dialog As New ImportDataDialog(New AccountImport(QueryTableType.FACULTY_QUERY_TABLE), "importfaculty")
                If Not MyApplication.DialogInstances.ContainsKey("importfaculty") Then
                    MyApplication.DialogInstances.Add("importfaculty", dialog)
                    dialog.Show()
                Else
                    MyApplication.DialogInstances.Item("importfaculty").Show()
                End If
            Case sender.Equals(BTNIMPORTSTUDENTS)
                Dim dialog As New ImportDataDialog(New AccountImport(QueryTableType.STUDENT_QUERY_TABLE), "importstudent")
                If Not MyApplication.DialogInstances.ContainsKey("importstudent") Then
                    MyApplication.DialogInstances.Add("importstudent", dialog)
                    dialog.Show()
                Else
                    MyApplication.DialogInstances.Item("importstudent").Show()
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


#Region "Book Menu Strip"
    Private Sub SelectAllToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem1.Click
        For Each item As DataGridViewRow In DGBOOKS.Rows
            item.Cells("chckBoxBooks").Value = True
        Next
        DGBOOKS.EndEdit()
    End Sub

    Private Sub UnselectAllToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles UnselectAllToolStripMenuItem1.Click
        For Each item As DataGridViewRow In DGBOOKS.Rows
            item.Cells("chckBoxBooks").Value = False
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
        If Not MyApplication.DialogInstances.ContainsKey("borrowdialog") Then
            MyApplication.DialogInstances.Add("borrowdialog", dialog)
            dialog.Show()
        Else
            MyApplication.DialogInstances.Item("borrowdialog").ShowDialog()
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

    Private Sub Guna2Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel2.Paint

    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub

    Private Sub MainFormPanels_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MainFormPanels.SelectedIndexChanged

    End Sub

    Private Sub DashboardTab_Click(sender As Object, e As EventArgs) Handles DashboardTab.Click

    End Sub

    Private Sub DGGENRE_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGGENRE.CellContentClick

    End Sub

    Private Sub Guna2Panel43_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel43.Paint

    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub TableLayoutPanel30_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel30.Paint

    End Sub

    Private Sub MaintenanceTab_Click(sender As Object, e As EventArgs) Handles MaintenanceTab.Click

    End Sub

    Private Sub GenresTab_Click(sender As Object, e As EventArgs) Handles GenresTab.Click

    End Sub

    Private Sub TableLayoutPanel2_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel2.Paint

    End Sub

    Private Sub Guna2Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel3.Paint

    End Sub

    Private Sub Guna2Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel4.Paint

    End Sub

    Private Sub LBLGENRENEXT_Click(sender As Object, e As EventArgs) Handles LBLGENRENEXT.Click

    End Sub

    Private Sub Guna2HtmlLabel7_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel7.Click

    End Sub

    Private Sub LBLGENREPREV_Click(sender As Object, e As EventArgs) Handles LBLGENREPREV.Click

    End Sub

    Private Sub Guna2Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel5.Paint

    End Sub

    Private Sub TableLayoutPanel29_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel29.Paint

    End Sub

    Private Sub DGMAINTENANCECONTEXTMENU_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DGMAINTENANCECONTEXTMENU.Opening

    End Sub

    Private Sub AuthorTab_Click(sender As Object, e As EventArgs) Handles AuthorTab.Click

    End Sub

    Private Sub TableLayoutPanel3_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel3.Paint

    End Sub

    Private Sub Guna2Panel7_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel7.Paint

    End Sub

    Private Sub Guna2Panel8_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel8.Paint

    End Sub

    Private Sub LBLAUTHORNEXT_Click(sender As Object, e As EventArgs) Handles LBLAUTHORNEXT.Click

    End Sub

    Private Sub Guna2HtmlLabel9_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel9.Click

    End Sub

    Private Sub LBLAUTHORPREV_Click(sender As Object, e As EventArgs) Handles LBLAUTHORPREV.Click

    End Sub

    Private Sub Guna2Panel9_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel9.Paint

    End Sub

    Private Sub DGAUTHORS_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGAUTHORS.CellContentClick

    End Sub

    Private Sub PublishhersTab_Click(sender As Object, e As EventArgs) Handles PublishhersTab.Click

    End Sub

    Private Sub TableLayoutPanel4_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel4.Paint

    End Sub

    Private Sub Guna2Panel10_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel10.Paint

    End Sub

    Private Sub Guna2Panel11_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel11.Paint

    End Sub

    Private Sub LBLPUBLISHERNEXT_Click(sender As Object, e As EventArgs) Handles LBLPUBLISHERNEXT.Click

    End Sub

    Private Sub Guna2HtmlLabel10_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel10.Click

    End Sub

    Private Sub LBLPUBLISHERPREV_Click(sender As Object, e As EventArgs) Handles LBLPUBLISHERPREV.Click

    End Sub

    Private Sub Guna2Panel12_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel12.Paint

    End Sub

    Private Sub DGPUBLISHER_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGPUBLISHER.CellContentClick

    End Sub

    Private Sub ClassificationTab_Click(sender As Object, e As EventArgs) Handles ClassificationTab.Click

    End Sub

    Private Sub TableLayoutPanel5_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel5.Paint

    End Sub

    Private Sub Guna2Panel13_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel13.Paint

    End Sub

    Private Sub Guna2Panel14_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel14.Paint

    End Sub

    Private Sub LBLCLASSIFICATIONNEXT_Click(sender As Object, e As EventArgs) Handles LBLCLASSIFICATIONNEXT.Click

    End Sub

    Private Sub Guna2HtmlLabel13_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel13.Click

    End Sub

    Private Sub LBLCLASSIFICATIONPREV_Click(sender As Object, e As EventArgs) Handles LBLCLASSIFICATIONPREV.Click

    End Sub

    Private Sub Guna2Panel15_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel15.Paint

    End Sub

    Private Sub DGCLASSIFICATIONS_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGCLASSIFICATIONS.CellContentClick

    End Sub

    Private Sub LanguagesTab_Click(sender As Object, e As EventArgs) Handles LanguagesTab.Click

    End Sub

    Private Sub TableLayoutPanel16_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel16.Paint

    End Sub

    Private Sub Guna2Panel45_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel45.Paint

    End Sub

    Private Sub Guna2Panel46_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel46.Paint

    End Sub

    Private Sub LBLLANGUAGENEXT_Click(sender As Object, e As EventArgs) Handles LBLLANGUAGENEXT.Click

    End Sub

    Private Sub Guna2HtmlLabel11_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel11.Click

    End Sub

    Private Sub LBLLANGUAGEPREV_Click(sender As Object, e As EventArgs) Handles LBLLANGUAGEPREV.Click

    End Sub

    Private Sub Guna2Panel47_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel47.Paint

    End Sub

    Private Sub DGLANGUAGE_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGLANGUAGE.CellContentClick

    End Sub

    Private Sub BooksTab_Click(sender As Object, e As EventArgs) Handles BooksTab.Click

    End Sub

    Private Sub TableLayoutPanel6_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel6.Paint

    End Sub

    Private Sub Guna2Panel16_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel16.Paint

    End Sub

    Private Sub Guna2ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMBBOOKFILTER.SelectedIndexChanged

    End Sub

    Private Sub Guna2Panel17_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel17.Paint

    End Sub

    Private Sub LBLBOOKNEXT_Click(sender As Object, e As EventArgs) Handles LBLBOOKNEXT.Click

    End Sub

    Private Sub Guna2HtmlLabel16_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel16.Click

    End Sub

    Private Sub LBLBOOKPREV_Click(sender As Object, e As EventArgs) Handles LBLBOOKPREV.Click

    End Sub

    Private Sub Guna2Panel18_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel18.Paint

    End Sub

    Private Sub DGBOOKS_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGBOOKS.CellContentClick

    End Sub

    Private Sub DGBOOKCONTEXTMENUSTRIP_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DGBOOKCONTEXTMENUSTRIP.Opening

    End Sub

    Private Sub ArchiveSelectedToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ArchiveSelectedToolStripMenuItem2.Click

    End Sub

    Private Sub UnarchiveSelectedToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles UnarchiveSelectedToolStripMenuItem2.Click

    End Sub

    Private Sub DeleteSelectedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteSelectedToolStripMenuItem.Click

    End Sub

    Private Sub ISBNToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ISBNToolStripMenuItem.Click

    End Sub

    Private Sub DonatorsTab_Click(sender As Object, e As EventArgs) Handles DonatorsTab.Click

    End Sub

    Private Sub TableLayoutPanel7_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel7.Paint

    End Sub

    Private Sub Guna2Panel19_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel19.Paint

    End Sub

    Private Sub Guna2Panel20_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel20.Paint

    End Sub

    Private Sub LBLDONATORNEXT_Click(sender As Object, e As EventArgs) Handles LBLDONATORNEXT.Click

    End Sub

    Private Sub Guna2HtmlLabel19_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel19.Click

    End Sub

    Private Sub LBLDONATORRPREV_Click(sender As Object, e As EventArgs) Handles LBLDONATORRPREV.Click

    End Sub

    Private Sub Guna2Panel21_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel21.Paint

    End Sub

    Private Sub DGDONATOR_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGDONATOR.CellContentClick

    End Sub

    Private Sub SuppliersTab_Click(sender As Object, e As EventArgs) Handles SuppliersTab.Click

    End Sub

    Private Sub TableLayoutPanel8_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel8.Paint

    End Sub

    Private Sub Guna2Panel22_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel22.Paint

    End Sub

    Private Sub Guna2Panel23_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel23.Paint

    End Sub

    Private Sub LBLSUPPLIERNEXT_Click(sender As Object, e As EventArgs) Handles LBLSUPPLIERNEXT.Click

    End Sub

    Private Sub Guna2HtmlLabel22_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel22.Click

    End Sub

    Private Sub LBLSUPPLIERPREV_Click(sender As Object, e As EventArgs) Handles LBLSUPPLIERPREV.Click

    End Sub

    Private Sub Guna2Panel24_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel24.Paint

    End Sub

    Private Sub DGSUPPLIER_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGSUPPLIER.CellContentClick

    End Sub

    Private Sub AccountsMaintenanceTab_Click(sender As Object, e As EventArgs) Handles AccountsMaintenanceTab.Click

    End Sub

    Private Sub DepartmentTab_Click(sender As Object, e As EventArgs) Handles DepartmentTab.Click

    End Sub

    Private Sub TableLayoutPanel14_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel14.Paint

    End Sub

    Private Sub Guna2Panel40_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel40.Paint

    End Sub

    Private Sub Guna2Panel41_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel41.Paint

    End Sub

    Private Sub LBLDEPARTMENTNEXT_Click(sender As Object, e As EventArgs) Handles LBLDEPARTMENTNEXT.Click

    End Sub

    Private Sub Guna2HtmlLabel40_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel40.Click

    End Sub

    Private Sub LBLDEPARTMENTPREV_Click(sender As Object, e As EventArgs) Handles LBLDEPARTMENTPREV.Click

    End Sub

    Private Sub Guna2Panel42_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel42.Paint

    End Sub

    Private Sub DGDEPARTMENT_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGDEPARTMENT.CellContentClick

    End Sub

    Private Sub YearLevelTab_Click(sender As Object, e As EventArgs) Handles YearLevelTab.Click

    End Sub

    Private Sub TableLayoutPanel9_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel9.Paint

    End Sub

    Private Sub Guna2Panel25_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel25.Paint

    End Sub

    Private Sub Guna2Panel26_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel26.Paint

    End Sub

    Private Sub LBLYEARLEVELNEXT_Click(sender As Object, e As EventArgs) Handles LBLYEARLEVELNEXT.Click

    End Sub

    Private Sub Guna2HtmlLabel25_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel25.Click

    End Sub

    Private Sub LBLYEARLEVELPREV_Click(sender As Object, e As EventArgs) Handles LBLYEARLEVELPREV.Click

    End Sub

    Private Sub Guna2Panel27_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel27.Paint

    End Sub

    Private Sub DGYEARLEVEL_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGYEARLEVEL.CellContentClick

    End Sub

    Private Sub SectionTab_Click(sender As Object, e As EventArgs) Handles SectionTab.Click

    End Sub

    Private Sub TableLayoutPanel10_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel10.Paint

    End Sub

    Private Sub Guna2Panel28_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel28.Paint

    End Sub

    Private Sub Guna2Panel29_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel29.Paint

    End Sub

    Private Sub LBLSECTIONNEXT_Click(sender As Object, e As EventArgs) Handles LBLSECTIONNEXT.Click

    End Sub

    Private Sub Guna2HtmlLabel28_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel28.Click

    End Sub

    Private Sub LBLSECTIONPREV_Click(sender As Object, e As EventArgs) Handles LBLSECTIONPREV.Click

    End Sub

    Private Sub Guna2Panel30_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel30.Paint

    End Sub

    Private Sub DGSECTIONS_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGSECTIONS.CellContentClick

    End Sub

    Private Sub StudentsTab_Click(sender As Object, e As EventArgs) Handles StudentsTab.Click

    End Sub

    Private Sub TableLayoutPanel11_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel11.Paint

    End Sub

    Private Sub Guna2Panel31_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel31.Paint

    End Sub

    Private Sub CMBYEARLEVEL_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMBYEARLEVEL.SelectedIndexChanged

    End Sub

    Private Sub Guna2Panel32_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel32.Paint

    End Sub

    Private Sub LBLSTUDENTNEXT_Click(sender As Object, e As EventArgs) Handles LBLSTUDENTNEXT.Click

    End Sub

    Private Sub Guna2HtmlLabel31_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel31.Click

    End Sub

    Private Sub LBLSTUDENTPREV_Click(sender As Object, e As EventArgs) Handles LBLSTUDENTPREV.Click

    End Sub

    Private Sub Guna2Panel33_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel33.Paint

    End Sub

    Private Sub DGSTUDENT_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGSTUDENT.CellContentClick

    End Sub

    Private Sub DGSTUDENTCONTEXTMENUSTRIP_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DGSTUDENTCONTEXTMENUSTRIP.Opening

    End Sub

    Private Sub SelectAllToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem2.Click

    End Sub

    Private Sub UnselectAllToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles UnselectAllToolStripMenuItem2.Click

    End Sub

    Private Sub ArchiveSelectedToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ArchiveSelectedToolStripMenuItem1.Click

    End Sub

    Private Sub UnarchiveSelectedToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles UnarchiveSelectedToolStripMenuItem1.Click

    End Sub

    Private Sub DeleteSelectedToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DeleteSelectedToolStripMenuItem1.Click

    End Sub

    Private Sub PrintLibraryCardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintLibraryCardToolStripMenuItem.Click

    End Sub

    Private Sub PromoteAsAssistLibrarianToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PromoteAsAssistLibrarianToolStripMenuItem.Click

    End Sub

    Private Sub FacultyTab_Click(sender As Object, e As EventArgs) Handles FacultyTab.Click

    End Sub

    Private Sub TableLayoutPanel12_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel12.Paint

    End Sub

    Private Sub Guna2Panel34_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel34.Paint

    End Sub

    Private Sub Guna2Panel35_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel35.Paint

    End Sub

    Private Sub LBLFACULTYNEXT_Click(sender As Object, e As EventArgs) Handles LBLFACULTYNEXT.Click

    End Sub

    Private Sub Guna2HtmlLabel34_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel34.Click

    End Sub

    Private Sub LBLFACULTYPREV_Click(sender As Object, e As EventArgs) Handles LBLFACULTYPREV.Click

    End Sub

    Private Sub Guna2Panel36_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel36.Paint

    End Sub

    Private Sub DGFACULTY_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGFACULTY.CellContentClick

    End Sub

    Private Sub DGFACULTYCONTEXTMENUSTRIP_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DGFACULTYCONTEXTMENUSTRIP.Opening

    End Sub

    Private Sub SelectAllToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem3.Click

    End Sub

    Private Sub UnselectAllToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles UnselectAllToolStripMenuItem3.Click

    End Sub

    Private Sub DeleteSelectedToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles DeleteSelectedToolStripMenuItem2.Click

    End Sub

    Private Sub ArchiveSelectedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArchiveSelectedToolStripMenuItem.Click

    End Sub

    Private Sub UnarchiveSelectedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnarchiveSelectedToolStripMenuItem.Click

    End Sub

    Private Sub PromoteAsSuperadminToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PromoteAsSuperadminToolStripMenuItem.Click

    End Sub

    Private Sub SuperAdminToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SuperAdminToolStripMenuItem.Click

    End Sub

    Private Sub AssistLibrarianToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AssistLibrarianToolStripMenuItem.Click

    End Sub

    Private Sub AdminTab_Click(sender As Object, e As EventArgs) Handles AdminTab.Click

    End Sub

    Private Sub TableLayoutPanel13_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel13.Paint

    End Sub

    Private Sub Guna2Panel37_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel37.Paint

    End Sub

    Private Sub TXTADMINSEARCH_TextChanged(sender As Object, e As EventArgs) Handles TXTADMINSEARCH.TextChanged

    End Sub

    Private Sub BTNADDADMIN_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub Guna2Panel38_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel38.Paint

    End Sub

    Private Sub LBLADMINNEXT_Click(sender As Object, e As EventArgs) Handles LBLADMINNEXT.Click

    End Sub

    Private Sub Guna2HtmlLabel37_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel37.Click

    End Sub

    Private Sub LBLADMINPREV_Click(sender As Object, e As EventArgs) Handles LBLADMINPREV.Click

    End Sub

    Private Sub BTNADMINPREV_Click(sender As Object, e As EventArgs) Handles BTNADMINPREV.Click

    End Sub

    Private Sub BTNADMINNEXT_Click(sender As Object, e As EventArgs) Handles BTNADMINNEXT.Click

    End Sub

    Private Sub Guna2Panel39_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel39.Paint

    End Sub

    Private Sub DGADMINISTRATOR_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGADMINISTRATOR.CellContentClick

    End Sub

    Private Sub BookInventoryTab_Click(sender As Object, e As EventArgs) Handles BookInventoryTab.Click

    End Sub

    Private Sub CopiesTab_Click(sender As Object, e As EventArgs) Handles CopiesTab.Click

    End Sub

    Private Sub TableLayoutPanel15_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel15.Paint

    End Sub

    Private Sub TableLayoutPanel20_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel20.Paint

    End Sub

    Private Sub Guna2Panel54_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel54.Paint

    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click

    End Sub

    Private Sub Guna2Panel55_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel55.Paint

    End Sub

    Private Sub LBLCOPIESNEXT_Click(sender As Object, e As EventArgs) Handles LBLCOPIESNEXT.Click

    End Sub

    Private Sub Guna2HtmlLabel42_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel42.Click

    End Sub

    Private Sub LBLCOPIESPREV_Click(sender As Object, e As EventArgs) Handles LBLCOPIESPREV.Click

    End Sub

    Private Sub Guna2Panel56_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel56.Paint

    End Sub

    Private Sub DGBOOKCOPIES_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGBOOKCOPIES.CellContentClick

    End Sub

    Private Sub Guna2Panel6_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel6.Paint

    End Sub

    Private Sub Guna2HtmlLabel68_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel68.Click

    End Sub

    Private Sub Guna2HtmlLabel67_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel67.Click

    End Sub

    Private Sub Guna2HtmlLabel43_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel43.Click

    End Sub

    Private Sub TXTQUANTITY_TextChanged(sender As Object, e As EventArgs) Handles TXTQUANTITY.TextChanged

    End Sub

    Private Sub Guna2HtmlLabel41_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel41.Click

    End Sub

    Private Sub TXTPRICECOPIES_TextChanged(sender As Object, e As EventArgs) Handles TXTPRICECOPIES.TextChanged

    End Sub

    Private Sub Guna2HtmlLabel45_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel45.Click

    End Sub

    Private Sub CMBDONATORCOPIES_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMBDONATORCOPIES.SelectedIndexChanged

    End Sub

    Private Sub Guna2HtmlLabel18_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel18.Click

    End Sub

    Private Sub CMBSUPPLIERCOPIES_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMBSUPPLIERCOPIES.SelectedIndexChanged

    End Sub

    Private Sub Guna2HtmlLabel15_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel15.Click

    End Sub

    Private Sub TXTISBNCOPIES_TextChanged(sender As Object, e As EventArgs) Handles TXTISBNCOPIES.TextChanged

    End Sub

    Private Sub Guna2HtmlLabel12_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel12.Click

    End Sub

    Private Sub TXTACCESSION_TextChanged(sender As Object, e As EventArgs) Handles TXTACCESSION.TextChanged

    End Sub

    Private Sub Guna2HtmlLabel2_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel2.Click

    End Sub

    Private Sub InventoryTab_Click(sender As Object, e As EventArgs) Handles InventoryTab.Click

    End Sub

    Private Sub TableLayoutPanel17_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel17.Paint

    End Sub

    Private Sub TableLayoutPanel19_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel19.Paint

    End Sub

    Private Sub Guna2Panel44_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel44.Paint

    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click

    End Sub

    Private Sub TXTINVENTORYSEARCH_TextChanged(sender As Object, e As EventArgs) Handles TXTINVENTORYSEARCH.TextChanged

    End Sub

    Private Sub Guna2Panel51_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel51.Paint

    End Sub

    Private Sub LBLINVENTORYNEXT_Click(sender As Object, e As EventArgs) Handles LBLINVENTORYNEXT.Click

    End Sub

    Private Sub Guna2HtmlLabel8_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel8.Click

    End Sub

    Private Sub LBLINVENTORYPREV_Click(sender As Object, e As EventArgs) Handles LBLINVENTORYPREV.Click

    End Sub

    Private Sub BTNINVENTORYPREV_Click(sender As Object, e As EventArgs) Handles BTNINVENTORYPREV.Click

    End Sub

    Private Sub BTNINVENTORYNEXT_Click(sender As Object, e As EventArgs) Handles BTNINVENTORYNEXT.Click

    End Sub

    Private Sub Guna2Panel52_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel52.Paint

    End Sub

    Private Sub DGINVENTORY_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGINVENTORY.CellContentClick

    End Sub

    Private Sub DGBOOKCOPIESCONTEXTMENUSTRIP_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DGBOOKCOPIESCONTEXTMENUSTRIP.Opening

    End Sub

    Private Sub SelectAllToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem4.Click

    End Sub

    Private Sub UnselectAllToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles UnselectAllToolStripMenuItem4.Click

    End Sub

    Private Sub ArchiveSelectedToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ArchiveSelectedToolStripMenuItem3.Click

    End Sub

    Private Sub UnarchiveSelectedToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles UnarchiveSelectedToolStripMenuItem3.Click

    End Sub

    Private Sub DeleteSelectedToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles DeleteSelectedToolStripMenuItem3.Click

    End Sub

    Private Sub PrintAccessionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintAccessionToolStripMenuItem.Click

    End Sub

    Private Sub Guna2Panel53_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel53.Paint

    End Sub

    Private Sub LBLINVDONATOR_Click(sender As Object, e As EventArgs) Handles LBLINVDONATOR.Click

    End Sub

    Private Sub LBLINVSUPPLIER_Click(sender As Object, e As EventArgs) Handles LBLINVSUPPLIER.Click

    End Sub

    Private Sub LBLINVISBN_Click(sender As Object, e As EventArgs) Handles LBLINVISBN.Click

    End Sub

    Private Sub LBLINVACCESSION_Click(sender As Object, e As EventArgs) Handles LBLINVACCESSION.Click

    End Sub

    Private Sub TXTINVPRICE_TextChanged(sender As Object, e As EventArgs) Handles TXTINVPRICE.TextChanged

    End Sub

    Private Sub Guna2HtmlLabel17_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel17.Click

    End Sub

    Private Sub BTNINVUPDATE_Click(sender As Object, e As EventArgs) Handles BTNINVUPDATE.Click

    End Sub

    Private Sub Guna2HtmlLabel20_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel20.Click

    End Sub

    Private Sub Guna2HtmlLabel21_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel21.Click

    End Sub

    Private Sub Guna2HtmlLabel23_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel23.Click

    End Sub

    Private Sub Guna2HtmlLabel24_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel24.Click

    End Sub

    Private Sub LostDamageTab_Click(sender As Object, e As EventArgs) Handles LostDamageTab.Click

    End Sub

    Private Sub TableLayoutPanel18_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel18.Paint

    End Sub

    Private Sub Guna2Panel48_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel48.Paint

    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click

    End Sub

    Private Sub CMBLOSTDAMAGEFILTER_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMBLOSTDAMAGEFILTER.SelectedIndexChanged

    End Sub

    Private Sub TXTLOSTDAMAGESEARCH_TextChanged(sender As Object, e As EventArgs) Handles TXTLOSTDAMAGESEARCH.TextChanged

    End Sub

    Private Sub Guna2Panel49_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel49.Paint

    End Sub

    Private Sub LBLLOSTDAMAGENEXT_Click(sender As Object, e As EventArgs) Handles LBLLOSTDAMAGENEXT.Click

    End Sub

    Private Sub Guna2HtmlLabel33_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel33.Click

    End Sub

    Private Sub LBLLOSTDAMAGEPREV_Click(sender As Object, e As EventArgs) Handles LBLLOSTDAMAGEPREV.Click

    End Sub

    Private Sub BTNLOSTDAMAGEPREV_Click(sender As Object, e As EventArgs) Handles BTNLOSTDAMAGEPREV.Click

    End Sub

    Private Sub BTNLOSTDAMAGENEXT_Click(sender As Object, e As EventArgs) Handles BTNLOSTDAMAGENEXT.Click

    End Sub

    Private Sub Guna2Panel50_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel50.Paint

    End Sub

    Private Sub Guna2DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Guna2DataGridView1.CellContentClick

    End Sub

    Private Sub BookTransactionTab_Click(sender As Object, e As EventArgs) Handles BookTransactionTab.Click

    End Sub

    Private Sub TableLayoutPanel21_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel21.Paint

    End Sub

    Private Sub Guna2Panel57_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel57.Paint

    End Sub

    Private Sub TXTTRANSACTIONSEARCH_TextChanged(sender As Object, e As EventArgs) Handles TXTTRANSACTIONSEARCH.TextChanged

    End Sub

    Private Sub Guna2Panel58_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel58.Paint

    End Sub

    Private Sub Guna2Button11_Click(sender As Object, e As EventArgs) Handles Guna2Button11.Click

    End Sub

    Private Sub Guna2HtmlLabel44_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel44.Click

    End Sub

    Private Sub Guna2DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles Guna2DateTimePicker1.ValueChanged

    End Sub

    Private Sub dtStart_ValueChanged(sender As Object, e As EventArgs) Handles dtStart.ValueChanged

    End Sub

    Private Sub LBLTRANSACTIONNEXT_Click(sender As Object, e As EventArgs) Handles LBLTRANSACTIONNEXT.Click

    End Sub

    Private Sub Guna2HtmlLabel38_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel38.Click

    End Sub

    Private Sub LBLTRANSACTIONPREV_Click(sender As Object, e As EventArgs) Handles LBLTRANSACTIONPREV.Click

    End Sub

    Private Sub BTNTRANSACTIONPREV_Click(sender As Object, e As EventArgs) Handles BTNTRANSACTIONPREV.Click

    End Sub

    Private Sub BTNTRANSACTIONNEXT_Click(sender As Object, e As EventArgs) Handles BTNTRANSACTIONNEXT.Click

    End Sub

    Private Sub Guna2Panel59_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel59.Paint

    End Sub

    Private Sub DGTRANSACTION_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGTRANSACTION.CellContentClick

    End Sub

    Private Sub ReportsTab_Click(sender As Object, e As EventArgs) Handles ReportsTab.Click

    End Sub

    Private Sub ReportsPanel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ReportsPanel.SelectedIndexChanged

    End Sub

    Private Sub BooksReportTab_Click(sender As Object, e As EventArgs) Handles BooksReportTab.Click

    End Sub

    Private Sub TableLayoutPanel22_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel22.Paint

    End Sub

    Private Sub Guna2Panel60_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel60.Paint

    End Sub

    Private Sub TXTBOOKREPORTSEARCH_TextChanged(sender As Object, e As EventArgs) Handles TXTBOOKREPORTSEARCH.TextChanged

    End Sub

    Private Sub Guna2Panel61_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel61.Paint

    End Sub

    Private Sub LBLBOOKREPORTNEXT_Click(sender As Object, e As EventArgs) Handles LBLBOOKREPORTNEXT.Click

    End Sub

    Private Sub Guna2HtmlLabel47_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel47.Click

    End Sub

    Private Sub LBLBOOKREPORTPREV_Click(sender As Object, e As EventArgs) Handles LBLBOOKREPORTPREV.Click

    End Sub

    Private Sub BTNBOOKREPORTRPEV_Click(sender As Object, e As EventArgs) Handles BTNBOOKREPORTRPEV.Click

    End Sub

    Private Sub BTNBOOKREPORTNEXT_Click(sender As Object, e As EventArgs) Handles BTNBOOKREPORTNEXT.Click

    End Sub

    Private Sub Guna2Panel62_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel62.Paint

    End Sub

    Private Sub DGBOOKREPORT_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGBOOKREPORT.CellContentClick

    End Sub

    Private Sub ExpenditureReportTab_Click(sender As Object, e As EventArgs) Handles ExpenditureReportTab.Click

    End Sub

    Private Sub TableLayoutPanel23_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel23.Paint

    End Sub

    Private Sub Guna2Panel63_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel63.Paint

    End Sub

    Private Sub TXTEXPENDITUREREPORTSEARCH_TextChanged(sender As Object, e As EventArgs) Handles TXTEXPENDITUREREPORTSEARCH.TextChanged

    End Sub

    Private Sub Guna2Panel64_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel64.Paint

    End Sub

    Private Sub LBLEXPENDITUREREPORTNEXT_Click(sender As Object, e As EventArgs) Handles LBLEXPENDITUREREPORTNEXT.Click

    End Sub

    Private Sub Guna2HtmlLabel50_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel50.Click

    End Sub

    Private Sub LBLEXPENDITUREREPORTPREV_Click(sender As Object, e As EventArgs) Handles LBLEXPENDITUREREPORTPREV.Click

    End Sub

    Private Sub BTNEXPENDITUREREPORTPREV_Click(sender As Object, e As EventArgs) Handles BTNEXPENDITUREREPORTPREV.Click

    End Sub

    Private Sub BTNEXPENDITUREREPORTNEXT_Click(sender As Object, e As EventArgs) Handles BTNEXPENDITUREREPORTNEXT.Click

    End Sub

    Private Sub Guna2Panel65_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel65.Paint

    End Sub

    Private Sub DGEXPENDITUREREPORT_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGEXPENDITUREREPORT.CellContentClick

    End Sub

    Private Sub FinesReportTab_Click(sender As Object, e As EventArgs) Handles FinesReportTab.Click

    End Sub

    Private Sub TableLayoutPanel24_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel24.Paint

    End Sub

    Private Sub Guna2Panel66_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel66.Paint

    End Sub

    Private Sub TXTFINESREPORTSSEARCH_TextChanged(sender As Object, e As EventArgs) Handles TXTFINESREPORTSSEARCH.TextChanged

    End Sub

    Private Sub Guna2Panel67_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel67.Paint

    End Sub

    Private Sub LBLFINESREPORTNEXT_Click(sender As Object, e As EventArgs) Handles LBLFINESREPORTNEXT.Click

    End Sub

    Private Sub Guna2HtmlLabel53_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel53.Click

    End Sub

    Private Sub LBLFINESREPORTPREV_Click(sender As Object, e As EventArgs) Handles LBLFINESREPORTPREV.Click

    End Sub

    Private Sub BTNFINESREPORTPREV_Click(sender As Object, e As EventArgs) Handles BTNFINESREPORTPREV.Click

    End Sub

    Private Sub BTNFINESREPORTNEXT_Click(sender As Object, e As EventArgs) Handles BTNFINESREPORTNEXT.Click

    End Sub

    Private Sub Guna2Panel68_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel68.Paint

    End Sub

    Private Sub DGFINESREPORT_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGFINESREPORT.CellContentClick

    End Sub

    Private Sub BorrowerReportTab_Click(sender As Object, e As EventArgs) Handles BorrowerReportTab.Click

    End Sub

    Private Sub TableLayoutPanel25_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel25.Paint

    End Sub

    Private Sub Guna2Panel69_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel69.Paint

    End Sub

    Private Sub TXTBORROWERREPORTSEARH_TextChanged(sender As Object, e As EventArgs) Handles TXTBORROWERREPORTSEARH.TextChanged

    End Sub

    Private Sub Guna2Panel70_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel70.Paint

    End Sub

    Private Sub LBLBORROWERREPORTNEXT_Click(sender As Object, e As EventArgs) Handles LBLBORROWERREPORTNEXT.Click

    End Sub

    Private Sub Guna2HtmlLabel56_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel56.Click

    End Sub

    Private Sub LBLBORROWERREPORTPREV_Click(sender As Object, e As EventArgs) Handles LBLBORROWERREPORTPREV.Click

    End Sub

    Private Sub BTNBORROWERREPORTPREV_Click(sender As Object, e As EventArgs) Handles BTNBORROWERREPORTPREV.Click

    End Sub

    Private Sub BTNBORROWERREPORTNEXT_Click(sender As Object, e As EventArgs) Handles BTNBORROWERREPORTNEXT.Click

    End Sub

    Private Sub Guna2Panel71_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel71.Paint

    End Sub

    Private Sub DGBORROWERERREPORT_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGBORROWERERREPORT.CellContentClick

    End Sub

    Private Sub BorrowedBookReport_Click(sender As Object, e As EventArgs) Handles BorrowedBookReport.Click

    End Sub

    Private Sub TableLayoutPanel26_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel26.Paint

    End Sub

    Private Sub Guna2Panel72_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel72.Paint

    End Sub

    Private Sub TXTBORROWEDREPORTSSEARCH_TextChanged(sender As Object, e As EventArgs) Handles TXTBORROWEDREPORTSSEARCH.TextChanged

    End Sub

    Private Sub Guna2Panel73_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel73.Paint

    End Sub

    Private Sub LBLBORROWEDREPORTNEXT_Click(sender As Object, e As EventArgs) Handles LBLBORROWEDREPORTNEXT.Click

    End Sub

    Private Sub Guna2HtmlLabel59_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel59.Click

    End Sub

    Private Sub LBLBORROWEDREPORTPREV_Click(sender As Object, e As EventArgs) Handles LBLBORROWEDREPORTPREV.Click

    End Sub

    Private Sub BTNBORROWEDREPORTPREV_Click(sender As Object, e As EventArgs) Handles BTNBORROWEDREPORTPREV.Click

    End Sub

    Private Sub BTNBORROWEDREPORTNEXT_Click(sender As Object, e As EventArgs) Handles BTNBORROWEDREPORTNEXT.Click

    End Sub

    Private Sub Guna2Panel74_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel74.Paint

    End Sub

    Private Sub DGBORROWEDREPORT_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGBORROWEDREPORT.CellContentClick

    End Sub

    Private Sub AccountTab_Click(sender As Object, e As EventArgs) Handles AccountTab.Click

    End Sub

    Private Sub SettingsTab_Click(sender As Object, e As EventArgs) Handles SettingsTab.Click

    End Sub

    Private Sub SettingsPanels_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SettingsPanels.SelectedIndexChanged

    End Sub

    Private Sub GeneralSettingsTab_Click(sender As Object, e As EventArgs) Handles GeneralSettingsTab.Click

    End Sub

    Private Sub Guna2CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles Guna2CheckBox1.CheckedChanged

    End Sub

    Private Sub chkEmail_CheckedChanged(sender As Object, e As EventArgs) Handles chkEmail.CheckedChanged

    End Sub

    Private Sub Guna2Button27_Click(sender As Object, e As EventArgs) Handles Guna2Button27.Click

    End Sub

    Private Sub Guna2HtmlLabel29_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel29.Click

    End Sub

    Private Sub Guna2TextBox4_TextChanged(sender As Object, e As EventArgs) Handles Guna2TextBox4.TextChanged

    End Sub

    Private Sub Guna2HtmlLabel27_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel27.Click

    End Sub

    Private Sub Guna2TextBox3_TextChanged(sender As Object, e As EventArgs) Handles Guna2TextBox3.TextChanged

    End Sub

    Private Sub Guna2HtmlLabel26_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel26.Click

    End Sub

    Private Sub Guna2TextBox2_TextChanged(sender As Object, e As EventArgs) Handles Guna2TextBox2.TextChanged

    End Sub

    Private Sub Guna2HtmlLabel14_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel14.Click

    End Sub

    Private Sub Guna2TextBox1_TextChanged(sender As Object, e As EventArgs) Handles Guna2TextBox1.TextChanged

    End Sub

    Private Sub Guna2HtmlLabel1_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel1.Click

    End Sub

    Private Sub txtSettingsPenalty_TextChanged(sender As Object, e As EventArgs) Handles txtSettingsPenalty.TextChanged

    End Sub

    Private Sub EmailSettingsTab_Click(sender As Object, e As EventArgs) Handles EmailSettingsTab.Click

    End Sub

    Private Sub AuditTrailTab_Click(sender As Object, e As EventArgs) Handles AuditTrailTab.Click

    End Sub

    Private Sub AuditTrailPanels_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AuditTrailPanels.SelectedIndexChanged

    End Sub

    Private Sub ActivityLogTab_Click(sender As Object, e As EventArgs) Handles ActivityLogTab.Click

    End Sub

    Private Sub TableLayoutPanel27_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel27.Paint

    End Sub

    Private Sub Guna2Panel75_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel75.Paint

    End Sub

    Private Sub Guna2Button10_Click(sender As Object, e As EventArgs) Handles Guna2Button10.Click

    End Sub

    Private Sub Guna2TextBox13_TextChanged(sender As Object, e As EventArgs) Handles Guna2TextBox13.TextChanged

    End Sub

    Private Sub Guna2Panel76_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel76.Paint

    End Sub

    Private Sub Guna2HtmlLabel61_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel61.Click

    End Sub

    Private Sub Guna2HtmlLabel62_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel62.Click

    End Sub

    Private Sub Guna2HtmlLabel63_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel63.Click

    End Sub

    Private Sub Guna2Button23_Click(sender As Object, e As EventArgs) Handles Guna2Button23.Click

    End Sub

    Private Sub Guna2Button24_Click(sender As Object, e As EventArgs) Handles Guna2Button24.Click

    End Sub

    Private Sub Guna2Panel77_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel77.Paint

    End Sub

    Private Sub Guna2DataGridView10_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Guna2DataGridView10.CellContentClick

    End Sub

    Private Sub ActiveLogs_Click(sender As Object, e As EventArgs) Handles ActiveLogs.Click

    End Sub

    Private Sub TableLayoutPanel28_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel28.Paint

    End Sub

    Private Sub Guna2Panel78_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel78.Paint

    End Sub

    Private Sub Guna2Button13_Click(sender As Object, e As EventArgs) Handles Guna2Button13.Click

    End Sub

    Private Sub Guna2TextBox14_TextChanged(sender As Object, e As EventArgs) Handles Guna2TextBox14.TextChanged

    End Sub

    Private Sub Guna2Panel79_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel79.Paint

    End Sub

    Private Sub Guna2HtmlLabel64_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel64.Click

    End Sub

    Private Sub Guna2HtmlLabel65_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel65.Click

    End Sub

    Private Sub Guna2HtmlLabel66_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel66.Click

    End Sub

    Private Sub Guna2Button25_Click(sender As Object, e As EventArgs) Handles Guna2Button25.Click

    End Sub

    Private Sub Guna2Button26_Click(sender As Object, e As EventArgs) Handles Guna2Button26.Click

    End Sub

    Private Sub Guna2Panel80_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel80.Paint

    End Sub

    Private Sub Guna2DataGridView11_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Guna2DataGridView11.CellContentClick

    End Sub

    Private Sub Guna2Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel1.Paint

    End Sub

    Private Sub Guna2HtmlLabel6_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel6.Click

    End Sub

    Private Sub Guna2HtmlLabel5_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel5.Click

    End Sub

    Private Sub Guna2HtmlLabel4_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel4.Click

    End Sub

    Private Sub Guna2HtmlLabel3_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel3.Click

    End Sub

    Private Sub LBLPROFILEROLE_Click(sender As Object, e As EventArgs) Handles LBLPROFILEROLE.Click

    End Sub

    Private Sub LBLPROFILENAME_Click(sender As Object, e As EventArgs) Handles LBLPROFILENAME.Click

    End Sub
#End Region

End Class