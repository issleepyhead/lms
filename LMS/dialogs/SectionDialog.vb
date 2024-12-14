Imports System.Windows.Forms

Public Class SectionDialog
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
        Dim inputs As Object() = {TXTSECTIONNAME, CMBDEPARTMENT, CMBYEARLEVEL}
        For Each item In inputs
            errProvider.SetError(item, String.Empty)
        Next

        Dim data As New Dictionary(Of String, String) From {
                {"@name", TXTSECTIONNAME.Text},
                {"@id", If(IsNothing(_data), 0, _data.Item("id").ToString)}
        }

        If BaseMaintenance.Exists(QueryTableType.DEPARTMENT_QUERY_TABLE, data) Then
            errProvider.SetError(TXTSECTIONNAME, "This section already exists.")
            Exit Sub
        End If

        If IsNothing(_data) Then
            If BaseMaintenance.Add(QueryTableType.DEPARTMENT_QUERY_TABLE, data) Then
                MessageBox.Show("Section has been added successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed adding the section.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Else
            If BaseMaintenance.Update(QueryTableType.DEPARTMENT_QUERY_TABLE, data) Then
                MessageBox.Show("Section has been updated successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed updating the section.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If
        Close()
    End Sub

    Private Sub SectionDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CMBDEPARTMENT.DataSource = BaseMaintenance.FetchAll(QueryTableType.DEPARTMENT_QUERY_TABLE)
        CMBYEARLEVEL.DataSource = BaseMaintenance.FetchAll(QueryTableType.YEARLEVEL_QUERY_TABLE, New Dictionary(Of String, String) From {{"@did", CMBDEPARTMENT.SelectedValue}})
        If Not IsNothing(_data) Then
            TXTSECTIONNAME.Text = _data.Item("name")
            CMBYEARLEVEL.SelectedValue = _data.Item("year_id")
        End If
    End Sub

    Private Sub CMBDEPARTMENT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMBDEPARTMENT.SelectedIndexChanged
        CMBYEARLEVEL.DataSource = BaseMaintenance.FetchAll(QueryTableType.YEARLEVEL_QUERY_TABLE, New Dictionary(Of String, String) From {{"@did", CMBDEPARTMENT.SelectedValue}})
    End Sub
End Class
