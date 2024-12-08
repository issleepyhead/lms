Public Class DashboardForm
    Private Sub BTNLOGOUT_Click(sender As Object, e As EventArgs) Handles BTNLOGOUT.Click
        ' TODO FIX THIS
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
        LBLGENRENEXT.Text = GenreMaintenance.PMAX
        LBLGENREPREV.Text = GenreMaintenance.PPrev
    End Sub

    Private Sub BTNGENREPNEXT_Click(sender As Object, e As EventArgs) Handles BTNGENREPNEXT.Click
        If BaseMaintenance.PPrev < BaseMaintenance.PMAX Then
            GenreMaintenance.PPrev += 1
            LBLGENREPREV.Text = BaseMaintenance.PPrev
            DGGENRE.DataSource = BaseMaintenance.Fetch(QueryTableType.GENRE_QUERY_TABLE)
        End If
    End Sub

    Private Sub BTNGENREPPREV_Click(sender As Object, e As EventArgs) Handles BTNGENREPPREV.Click
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
        Using dialog = AuthorDialog
            dialog.ShowDialog()
        End Using
        LBLGENRENEXT.Text = BaseMaintenance.PMAX
        LBLGENREPREV.Text = BaseMaintenance.PPrev
        DGAUTHORS.DataSource = BaseMaintenance.Fetch(QueryTableType.AUTHOR_QUERY_TABLE)
    End Sub

    Private Sub BTNAUTHORPNEXT_Click(sender As Object, e As EventArgs) Handles BTNAUTHORNEXT.Click
        If BaseMaintenance.PPrev < BaseMaintenance.PMAX Then
            BaseMaintenance.PPrev += 1
            LBLGENREPREV.Text = BaseMaintenance.PPrev
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

#Region "Publisher Maintenance"
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

#Region "Classification Maintenance"
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

#Region "Donator Maintenance"
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

#Region "Supplier Maintenance"
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

#Region "Department Maintenance"
    Private Sub BTNADDDEPARTMENT_Click(sender As Object, e As EventArgs) Handles BTNADDDEPARTMENT.Click
        Using dialog = DepartmentDialog
            dialog.ShowDialog()
        End Using
        DGDEPARTMENT.DataSource = BaseMaintenance.Fetch(QueryTableType.DEPARTMENT_QUERY_TABLE)
        LBLDEPARTMENTNEXT.Text = BaseMaintenance.PMAX
        LBLDEPARTMENTPREV.Text = BaseMaintenance.PPrev
    End Sub
#End Region

#Region "Year Level Maintenance"
    Private Sub BTNADDYEARLEVEL_Click(sender As Object, e As EventArgs) Handles BTNADDYEARLEVEL.Click
        Using dialog = YearLevelDialog
            dialog.ShowDialog()
        End Using
        DGYEARLEVEL.DataSource = BaseMaintenance.Fetch(QueryTableType.YEARLEVEL_QUERY_TABLE)
        LBLYEARLEVELNEXT.Text = BaseMaintenance.PMAX
        LBLYEARLEVELPREV.Text = BaseMaintenance.PPrev
    End Sub
#End Region

#Region "Language Maintenance"
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
            If Not String.IsNullOrEmpty(TXTPUBLISHERSEARCH.Text) Then
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

    Private Sub RemoveSelectedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        ' TODO PERFORM A CHECK BEFORE DELETING THE DATA
        If MessageBox.Show("Are you sure you want to delete the selected item(s)?", "Delete Selected Items?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        Select Case True
            Case MaintenancePanels.SelectedTab.Equals(GenresTab)
                DGGENRE.EndEdit()
                Dim params As New List(Of Dictionary(Of String, String))
                For Each data As DataGridViewRow In DGGENRE.Rows
                    If data.Cells("chckBoxGenre").Value Then
                        Dim temp As New Dictionary(Of String, String) From {
                            {"@id", data.Cells("ColumnGenreID").Value.ToString}
                        }
                        params.Add(temp)
                    End If
                Next

                If GenreMaintenance.Delete(params) Then
                    MessageBox.Show("Deleted Successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Cannot delete the selected genre(s). Some genres are currently assigned to one or more books. Please remove the genre from the books before deleting.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                DGGENRE.DataSource = GenreMaintenance.Fetch()



            Case MaintenancePanels.SelectedTab.Equals(AuthorTab)
                DGAUTHORS.EndEdit()
                Dim params As New List(Of Dictionary(Of String, String))
                For Each data As DataGridViewRow In DGAUTHORS.Rows
                    If data.Cells("chckBoxAuthor").Value Then
                        Dim temp As New Dictionary(Of String, String) From {
                            {"@id", data.Cells("ColumnAuthorID").Value.ToString}
                        }
                        params.Add(temp)
                    End If
                Next

                If AuthorMaintenance.Delete(params) Then
                    MessageBox.Show("Deleted Successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Cannot delete the selected author(s). Some authors are currently assigned to one or more books. Please remove the author from the books before deleting.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                DGAUTHORS.DataSource = AuthorMaintenance.Fetch()
        End Select
    End Sub

    Private Sub MaintenancePanels_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MaintenancePanels.SelectedIndexChanged
        Select Case True
            Case MaintenancePanels.SelectedTab.Equals(GenresTab)
                ' TO DO FIX THIS SHITS!
                DGGENRE.DataSource = GenreMaintenance.Fetch()
                LBLGENREPREV.Text = GenreMaintenance.PPrev
                LBLGENRENEXT.Text = GenreMaintenance.PMAX

            Case MaintenancePanels.SelectedTab.Equals(AuthorTab)
                DGAUTHORS.DataSource = AuthorMaintenance.Fetch()
                LBLAUTHORPREV.Text = AuthorMaintenance.PPrev
                LBLAUTHORNEXT.Text = AuthorMaintenance.PMAX

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
        End Select
    End Sub
End Class