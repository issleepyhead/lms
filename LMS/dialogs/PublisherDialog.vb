Imports LMS.QueryType

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
        Dim inputs As Object() = {TXTPUBLISHERNAME}
        For Each item In inputs
            errProvider.SetError(item, String.Empty)
        Next

        TXTPUBLISHERNAME.Text = Validator.RemoveSpaces(TXTPUBLISHERNAME.Text)

        Dim data As New Dictionary(Of String, String) From {
                {"@name", TXTPUBLISHERNAME.Text},
                {"@id", If(IsNothing(_data), 0, _data.Item("id").ToString)}
        }

        If DBOperations.Exists(PUBLISHER, data) Then
            errProvider.SetError(TXTPUBLISHERNAME, "This publisher already exits.")
            Exit Sub
        End If

        If IsNothing(_data) Then
            If DBOperations.Add(PUBLISHER, data) Then
                MessageBox.Show("Publisher has been added successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed adding the Publisher.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Else
            If DBOperations.Update(PUBLISHER, data) Then
                MessageBox.Show("Publisher has been updated successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed updating the publisher.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If
        Close()
    End Sub

    Private Sub PublisherDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not IsNothing(_data) Then
            TXTPUBLISHERNAME.Text = _data.Item("publisher_name")
        End If
    End Sub

    Private Sub TXTPUBLISHERNAME_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TXTPUBLISHERNAME.Validating
        If String.IsNullOrWhiteSpace(sender.Text) Then
            errProvider.SetError(sender, "This field can't be empty.")
            e.Cancel = True
        End If
    End Sub

    Private Sub TXTPUBLISHERNAME_Validated(sender As Object, e As EventArgs) Handles TXTPUBLISHERNAME.Validated
        errProvider.SetError(sender, String.Empty)
    End Sub

    Private Sub TXTPUBLISHERNAME_TextChanged(sender As Object, e As EventArgs) Handles TXTPUBLISHERNAME.TextChanged
        Validator.NotAllowed(sender, ALL_CHARACTERS_PATTERN)
    End Sub
End Class
