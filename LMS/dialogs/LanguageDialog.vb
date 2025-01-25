Imports LMS.QueryType
Public Class LanguageDialog
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
        Dim inputs As Object() = {TXTLANGUAGE, TXTLANGUAGECODE}
        For Each item In inputs
            errProvider.SetError(item, String.Empty)
        Next

        TXTLANGUAGE.Text = Validator.RemoveSpaces(TXTLANGUAGE.Text)
        TXTLANGUAGECODE.Text = Validator.RemoveSpaces(TXTLANGUAGECODE.Text)

        Dim data As New Dictionary(Of String, String) From {
                {"@language", TXTLANGUAGE.Text},
                {"@code", TXTLANGUAGECODE.Text},
                {"@id", If(IsNothing(_data), 0, _data.Item("id").ToString)}
        }

        If DBOperations.Exists(LANGUAGES, data) Then
            errProvider.SetError(TXTLANGUAGE, "This language already exits.")
            Exit Sub
        End If

        If IsNothing(_data) Then
            If DBOperations.Add(LANGUAGES, data) Then
                MessageBox.Show("Language has been added successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed adding the language.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Else
            If DBOperations.Update(LANGUAGES, data) Then
                MessageBox.Show("Language has been updated successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed updating the language.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If
        Close()
    End Sub

    Private Sub LanguageDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not IsNothing(_data) Then
            TXTLANGUAGE.Text = _data.Item("language")
            TXTLANGUAGECODE.Text = _data.Item("code")
        End If
    End Sub

    Private Sub TextBox_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TXTLANGUAGE.Validating, TXTLANGUAGECODE.Validating
        If String.IsNullOrWhiteSpace(sender.Text) Then
            errProvider.SetError(sender, "This field can't be empty.")
            e.Cancel = True
        End If
    End Sub

    Private Sub TextBox_Validated(sender As Object, e As EventArgs) Handles TXTLANGUAGECODE.Validated, TXTLANGUAGE.Validated
        errProvider.SetError(sender, String.Empty)
    End Sub

    Private Sub TXTLANGUAGECODE_TextChanged(sender As Object, e As EventArgs) Handles TXTLANGUAGECODE.TextChanged
        Validator.NotAllowed(sender, NUMBER_PATTERN)
    End Sub
End Class
