Imports LMS.QueryType
Imports LMS.LOGTYPE

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

        DBOperations.ACTION_PARAMS = New Dictionary(Of String, String) From {
            {"@sid", If(My.Settings.student_id > 0, My.Settings.student_id, String.Empty)},
            {"@fid", If(My.Settings.faculty_id > 0, My.Settings.faculty_id, String.Empty)}
        }

        If IsNothing(_data) Then
            DBOperations.ACTION_PARAMS.Add("@action", "Added a new genre " & TXTNAME.Text)
            DBOperations.ACTION_PARAMS.Add("@type", LOGTYPE.ADD)
        Else
            DBOperations.ACTION_PARAMS.Add("@action", "Updated a genre " & TXTNAME.Text)
            DBOperations.ACTION_PARAMS.Add("@type", LOGTYPE.UPDATE)
        End If

        If DBOperations.Exists(GENRE, data) Then
            errProvider.SetError(TXTNAME, "This genre already exits.")
            Exit Sub
        End If

        If IsNothing(_data) Then
            If DBOperations.Add(GENRE, data) Then
                MessageBox.Show("Genre has been added successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed adding the genre.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Else
            If DBOperations.Update(GENRE, data) Then
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
