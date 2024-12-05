Imports System.Windows.Forms

Public Class PublisherDialog
    Private _data As DataRowView
    Private _id As Integer

    Sub New()
        InitializeComponent()
    End Sub

    Sub New(data As DataRowView)
        InitializeComponent()
        _data = data
        BTNSAVE.Text = "Update"
    End Sub

    Private Sub BTNSAVE_Click(sender As Object, e As EventArgs) Handles BTNSAVE.Click
        Dim inputs As Object() = {TXTPUBLISHERNAME, TXTPUBLISHERADDRESS}
        For Each item In inputs
            errProvider.SetError(item, String.Empty)
        Next

        Dim data As New Dictionary(Of String, String) From {
                {"@name", TXTPUBLISHERNAME.Text},
                {"@address", TXTPUBLISHERADDRESS.Text},
                {"@id", If(IsNothing(_data), 0, _data.Item("id").ToString)}
        }

        If BaseMaintenance.Exists(QueryTableType.GENRE_QUERY_TABLE, data) Then
            errProvider.SetError(TXTPUBLISHERNAME, "This publisher already exits.")
            Exit Sub
        End If

        If IsNothing(_data) Then
            If BaseMaintenance.Add(QueryTableType.PUBLISHER_QUERY_TABLE, data) Then
                MessageBox.Show("Publisher has been added successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed adding the Publisher.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Else
            If BaseMaintenance.Update(QueryTableType.PUBLISHER_QUERY_TABLE, data) Then
                MessageBox.Show("Publisher has been updated successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed updating the publisher.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If
        Close()
    End Sub

    Private Sub GenreDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not IsNothing(_data) Then
            TXTPUBLISHERNAME.Text = _data.Item("name")
            TXTPUBLISHERADDRESS.Text = If(IsDBNull(_data.Item("address")), Nothing, _data.Item("address"))
        End If
    End Sub
End Class
