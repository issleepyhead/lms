Imports System.Windows.Forms

Public Class GenreDialog
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
        Dim inputs As Object() = {TXTNAME, TXTDESCRIPTION}
        For Each item In inputs
            errProvider.SetError(item, String.Empty)
        Next

        TXTNAME.Text = Validator.RemoveSpaces(TXTNAME.Text)
        TXTDESCRIPTION.Text = Validator.RemoveSpaces(TXTDESCRIPTION.Text)


        Dim data As New Dictionary(Of String, String) From {
                {"@name", TXTNAME.Text},
                {"@desc", TXTDESCRIPTION.Text},
                {"@id", If(IsNothing(_data), 0, _data.Item("id").ToString)}
        }

        If BaseMaintenance.Exists(QueryTableType.GENRE_QUERY_TABLE, data) Then
            errProvider.SetError(TXTNAME, "This genre already exits.")
            Exit Sub
        End If

        If IsNothing(_data) Then
            If BaseMaintenance.Add(QueryTableType.GENRE_QUERY_TABLE, data) Then
                MessageBox.Show("Genre has been added successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed adding the genre.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Else
            If BaseMaintenance.Update(QueryTableType.GENRE_QUERY_TABLE, data) Then
                MessageBox.Show("Genre has been updated successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed updating the genre.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If
        Close()
    End Sub

    Private Sub GenreDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActiveControl = TXTNAME
        If Not IsNothing(_data) Then
            TXTNAME.Text = _data.Item("name")
            TXTDESCRIPTION.Text = If(IsDBNull(_data.Item("description")), Nothing, _data.Item("description"))
        End If
    End Sub

    Private Sub TXTNAME_TextChanged(sender As Object, e As EventArgs) Handles TXTNAME.TextChanged, TXTDESCRIPTION.TextChanged
        Validator.NotAllowed(sender, Validator.ALL_CHARACTERS_PATTERN)
    End Sub

    Private Sub TXTNAME_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TXTNAME.Validating
        If String.IsNullOrWhiteSpace(sender.Text) Then
            errProvider.SetError(sender, "Please provide a genre name.")
            e.Cancel = True
        End If
    End Sub

    Private Sub TXTNAME_Validated(sender As Object, e As EventArgs) Handles TXTNAME.Validated
        errProvider.SetError(sender, String.Empty)
    End Sub
End Class
