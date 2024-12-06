Public Class DashboardForm
    Private Sub BTNLOGOUT_Click(sender As Object, e As EventArgs) Handles BTNLOGOUT.Click
        My.Settings.user_id = 0
        My.Settings.Save()
        Using Me
            LogInForm.Show()
        End Using
    End Sub
    Private Sub DashboardForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DGGENRE.DataSource = GenreMaintenance.Fetch()
        LBLGENREPREV.Text = GenreMaintenance.PPrev
        LBLGENRENEXT.Text = GenreMaintenance.PMAX

        DGAUTHORS.DataSource = AuthorMaintenance.Fetch()
        LBLAUTHORPREV.Text = AuthorMaintenance.PPrev
        LBLAUTHORNEXT.Text = AuthorMaintenance.PMAX

        DGPUBLISHER.DataSource = BaseMaintenance.Fetch(QueryTableType.PUBLISHER_QUERY_TABLE)
        LBLPUBLISHERPREV.Text = BaseMaintenance.PPrev
        LBLPUBLISHERNEXT.Text = BaseMaintenance.PMAX

        DGCLASSIFICATIONS.DataSource = BaseMaintenance.Fetch(QueryTableType.CLASSIFICATION_QUERY_TABLE)
        LBLCLASSIFICATIONNEXT.Text = BaseMaintenance.PMAX
        LBLCLASSIFICATIONPREV.Text = BaseMaintenance.PPrev

        DGDONATOR.DataSource = BaseMaintenance.Fetch(QueryTableType.DONATOR_QUERY_TABLE)
        LBLDONATORNEXT.Text = BaseMaintenance.PMAX
        LBLDONATORRPREV.Text = BaseMaintenance.PPrev

        DGSUPPLIER.DataSource = BaseMaintenance.Fetch(QueryTableType.SUPPLIER_QUERY_TABLE)
        LBLSUPPLIERNEXT.Text = BaseMaintenance.PMAX
        LBLSUPPLIERPREV.Text = BaseMaintenance.PPrev
    End Sub

#Region "Genre Module"
    Private Sub BTNADDGENRE_Click(sender As Object, e As EventArgs) Handles BTNADDGENRE.Click
        Using dialog = GenreDialog
            dialog.ShowDialog()
        End Using
        DGGENRE.DataSource = GenreMaintenance.Fetch
        LBLGENRENEXT.Text = GenreMaintenance.PMAX
        LBLGENREPREV.Text = GenreMaintenance.PPrev
    End Sub

    Private Sub BTNGENREPNEXT_Click(sender As Object, e As EventArgs) Handles BTNGENREPNEXT.Click
        If GenreMaintenance.PPrev < GenreMaintenance.PMAX Then
            GenreMaintenance.PPrev += 1
            LBLGENREPREV.Text = GenreMaintenance.PPrev
            DGGENRE.DataSource = GenreMaintenance.Fetch()
        End If
    End Sub

    Private Sub BTNGENREPPREV_Click(sender As Object, e As EventArgs) Handles BTNGENREPPREV.Click
        If GenreMaintenance.PPrev > 1 Then
            GenreMaintenance.PPrev -= 1
            LBLGENREPREV.Text = GenreMaintenance.PPrev
            DGGENRE.DataSource = GenreMaintenance.Fetch()
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
            DGGENRE.DataSource = GenreMaintenance.Fetch
            LBLGENRENEXT.Text = GenreMaintenance.PMAX
            LBLGENREPREV.Text = GenreMaintenance.PPrev
        End If
    End Sub

    Private Sub TXTGENRESEARCH_TextChanged(sender As Object, e As EventArgs) Handles TXTGENRESEARCH.TextChanged
        If Not String.IsNullOrEmpty(TXTGENRESEARCH.Text) Then
            DGGENRE.DataSource = GenreMaintenance.Search(TXTGENRESEARCH.Text)
            LBLGENRENEXT.Text = GenreMaintenance.PMAX
            LBLGENREPREV.Text = GenreMaintenance.PPrev
        Else
            DGGENRE.DataSource = GenreMaintenance.Fetch
            LBLGENRENEXT.Text = GenreMaintenance.PMAX
            LBLGENREPREV.Text = GenreMaintenance.PPrev
        End If
    End Sub
#End Region

#Region "Author Module"
    Private Sub BTNADDAUTHOR_Click(sender As Object, e As EventArgs) Handles BTNADDAUTHOR.Click
        Using dialog = AuthorDialog
            dialog.ShowDialog()
        End Using
        LBLGENRENEXT.Text = AuthorMaintenance.PMAX
        LBLGENREPREV.Text = AuthorMaintenance.PPrev
        DGAUTHORS.DataSource = AuthorMaintenance.Fetch()
    End Sub

    Private Sub BTNAUTHORPNEXT_Click(sender As Object, e As EventArgs) Handles BTNAUTHORNEXT.Click
        If AuthorMaintenance.PPrev < AuthorMaintenance.PMAX Then
            AuthorMaintenance.PPrev += 1
            LBLGENREPREV.Text = AuthorMaintenance.PPrev
            DGAUTHORS.DataSource = AuthorMaintenance.Fetch()
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
            DGAUTHORS.DataSource = AuthorMaintenance.Fetch
            LBLAUTHORNEXT.Text = AuthorMaintenance.PMAX
            LBLAUTHORPREV.Text = AuthorMaintenance.PPrev
        End If
    End Sub

    Private Sub TXTAUTHORSEARCH_TextChanged(sender As Object, e As EventArgs) Handles TXTSEARCHAUTHOR.TextChanged
        If Not String.IsNullOrEmpty(TXTGENRESEARCH.Text) Then
            DGAUTHORS.DataSource = AuthorMaintenance.Search(TXTSEARCHAUTHOR.Text)
            LBLAUTHORNEXT.Text = AuthorMaintenance.PMAX
            LBLAUTHORPREV.Text = AuthorMaintenance.PPrev
        Else
            DGAUTHORS.DataSource = AuthorMaintenance.Fetch
            LBLAUTHORNEXT.Text = AuthorMaintenance.PMAX
            LBLAUTHORPREV.Text = AuthorMaintenance.PPrev
        End If
    End Sub

    Private Sub BTNAUTHORPREV_Click(sender As Object, e As EventArgs) Handles BTNAUTHORPREV.Click
        If AuthorMaintenance.PPrev > 1 Then
            AuthorMaintenance.PPrev -= 1
            LBLAUTHORPREV.Text = AuthorMaintenance.PPrev
            DGAUTHORS.DataSource = AuthorMaintenance.Fetch()
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
#End Region

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
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
    End Sub

    Private Sub UnselectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnselectAllToolStripMenuItem.Click
        Select Case True
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

    Private Sub RemoveAllMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveAllMenuItem.Click
        Select Case True
            Case MaintenancePanels.SelectedTab.Equals(GenresTab)

            Case MaintenancePanels.SelectedTab.Equals(AuthorTab)

        End Select
    End Sub


End Class