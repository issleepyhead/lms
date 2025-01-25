Imports LMS.QueryType

Public Class ClassificationDialog
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
        Dim inputs As Object() = {TXTDEWEYNAME, TXTDEWEYNUMBER}
        For Each item In inputs
            errProvider.SetError(item, String.Empty)
        Next

        If Not Validator.MatchPattern(TXTDEWEYNUMBER.Text, DECI_NUMBER_PATTERN) Then
            errProvider.SetError(TXTDEWEYNUMBER, "Invalid dewey format.")
            Exit Sub
        End If

        TXTDEWEYNAME.Text = Validator.RemoveSpaces(TXTDEWEYNAME.Text)
        TXTDEWEYNUMBER.Text = Validator.RemoveSpaces(TXTDEWEYNUMBER.Text)

        If Double.Parse(TXTDEWEYNUMBER.Text) > 99 Then
            errProvider.SetError(TXTDEWEYNUMBER, "Dewey number must be from 0 to 99.")
            Exit Sub
        End If

        Dim padded As String = TXTDEWEYNUMBER.Text
        If Double.Parse(padded) < 10 Then
            padded = padded.PadLeft(padded.Length + 2, "0")
        Else
            padded = padded.PadLeft(padded.Length + 1, "0")
        End If


        Dim data As New Dictionary(Of String, String) From {
                {"@classification", TXTDEWEYNAME.Text},
                {"@dewey_no", padded},
                {"@id", If(IsNothing(_data), 0, _data.Item("id").ToString)}
        }

        If DBOperations.Exists(CLASSIFICATION, data) Then
            errProvider.SetError(TXTDEWEYNUMBER, "This dewey decimal already exits.")
            errProvider.SetError(TXTDEWEYNAME, "This dewey name already exits.")
            Exit Sub
        End If

        If IsNothing(_data) Then
            If DBOperations.Add(CLASSIFICATION, data) Then
                MessageBox.Show("Dewey Classification has been added successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed adding the dewey classification.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Else
            If DBOperations.Update(CLASSIFICATION, data) Then
                MessageBox.Show("Dewey classification has been updated successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed updating the Dewey classification.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If
        Close()
    End Sub

    Private Sub GenreDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActiveControl = TXTDEWEYNUMBER
        If Not IsNothing(_data) Then
            TXTDEWEYNUMBER.Text = _data.Item("dewey_decimal")
            TXTDEWEYNAME.Text = If(IsDBNull(_data.Item("classification")), Nothing, _data.Item("classification"))
        End If
    End Sub

    Private Sub TextBox_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TXTDEWEYNUMBER.Validating, TXTDEWEYNAME.Validating
        If String.IsNullOrWhiteSpace(sender.Text) Then
            errProvider.SetError(sender, "This field can't be empty.")
            e.Cancel = True
        End If
    End Sub

    Private Sub TextBox_Validated(sender As Object, e As EventArgs) Handles TXTDEWEYNUMBER.Validated, TXTDEWEYNAME.Validated
        errProvider.SetError(sender, String.Empty)
    End Sub

    Private Sub TXTDEWEYNUMBER_TextChanged(sender As Object, e As EventArgs) Handles TXTDEWEYNUMBER.TextChanged
        Validator.NotAllowed(sender, DECI_NUMBER_PATTERN)
    End Sub

    Private Sub TXTDEWEYNAME_TextChanged(sender As Object, e As EventArgs) Handles TXTDEWEYNAME.TextChanged
        Validator.NotAllowed(sender, ALL_CHARACTERS_PATTERN)
    End Sub
End Class
