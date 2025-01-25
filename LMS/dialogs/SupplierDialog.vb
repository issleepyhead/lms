Imports LMS.QueryType

Public Class SupplierDialog
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
        Dim inputs As Object() = {TXTADDRESS, TXTNAME}
        For Each item In inputs
            errProvider.SetError(item, String.Empty)
        Next

        Dim data As New Dictionary(Of String, String) From {
                {"@name", TXTNAME.Text},
                {"@address", TXTADDRESS.Text},
                {"@id", If(IsNothing(_data), 0, _data.Item("id").ToString)}
        }

        If DBOperations.Exists(SUPPLIER, data) Then
            errProvider.SetError(TXTNAME, "This supplier already exists.")
            Exit Sub
        End If

        If IsNothing(_data) Then
            If DBOperations.Add(SUPPLIER, data) Then
                MessageBox.Show("Supplier has been added successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed adding the supplier.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Else
            If DBOperations.Update(SUPPLIER, data) Then
                MessageBox.Show("Supplier has been updated successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed updating the supplier.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If
        Close()
    End Sub

    Private Sub SupplierDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not IsNothing(_data) Then
            TXTNAME.Text = _data.Item("name")
            TXTADDRESS.Text = If(IsDBNull(_data.Item("address")), Nothing, _data.Item("address"))
        End If
    End Sub
End Class
