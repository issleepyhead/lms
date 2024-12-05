Imports System.Windows.Forms

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

        Dim data As New Dictionary(Of String, String) From {
                {"@classification", TXTDEWEYNAME.Text},
                {"@dewey_no", TXTDEWEYNUMBER.Text},
                {"@id", If(IsNothing(_data), 0, _data.Item("id").ToString)}
        }

        If BaseMaintenance.Exists(QueryTableType.CLASSIFICATION_QUERY_TABLE, data) Then
            errProvider.SetError(TXTDEWEYNUMBER, "This dewey decimal already exits.")
            errProvider.SetError(TXTDEWEYNAME, "This dewey name already exits.")
            Exit Sub
        End If

        If IsNothing(_data) Then
            If BaseMaintenance.Add(QueryTableType.CLASSIFICATION_QUERY_TABLE, data) Then
                MessageBox.Show("Dewey Classification has been added successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed adding the dewey classification.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Else
            If BaseMaintenance.Update(QueryTableType.CLASSIFICATION_QUERY_TABLE, data) Then
                MessageBox.Show("Dewey classification has been updated successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed updating the Dewey classification.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If
        Close()
    End Sub

    Private Sub GenreDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not IsNothing(_data) Then
            TXTDEWEYNUMBER.Text = _data.Item("dewey_decimal")
            TXTDEWEYNAME.Text = If(IsDBNull(_data.Item("classification")), Nothing, _data.Item("classification"))
        End If
    End Sub
End Class
