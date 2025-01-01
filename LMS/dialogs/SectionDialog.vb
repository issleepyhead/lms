Imports System.Windows.Forms

Public Class SectionDialog
    Private _data As DataRowView

    Sub New()
        InitializeComponent()
    End Sub

    Sub New(data As DataRowView)
        InitializeComponent()
        _data = data
        BTNSAVE.Text = "Update"
    End Sub

    Private Sub BTNSAVE_Click(sender As Object, e As EventArgs) Handles BTNSAVE.Click
        Dim inputs As Object() = {TXTSECTIONNAME, CMBYEARLEVEL}
        For Each item In inputs
            errProvider.SetError(item, String.Empty)
        Next

        Dim data As New Dictionary(Of String, String) From {
                {"@name", TXTSECTIONNAME.Text},
                {"@yid", CMBYEARLEVEL.SelectedValue},
                {"@id", If(IsNothing(_data), 0, _data.Item("id").ToString)}
        }

        If BaseMaintenance.Exists(QueryTableType.SECTION_QUERY_TABLE, data) Then
            errProvider.SetError(TXTSECTIONNAME, "This section already exists.")
            Exit Sub
        End If

        If IsNothing(_data) Then
            If BaseMaintenance.Add(QueryTableType.SECTION_QUERY_TABLE, data) Then
                MessageBox.Show("Section has been added successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed adding the section.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Else
            If BaseMaintenance.Update(QueryTableType.SECTION_QUERY_TABLE, data) Then
                MessageBox.Show("Section has been updated successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed updating the section.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If
        Close()
    End Sub

    Private Sub SectionDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CMBYEARLEVEL.DataSource = BaseMaintenance.FetchAll(QueryTableType.YEARLEVEL_QUERY_TABLE)
        If Not IsNothing(_data) Then
            TXTSECTIONNAME.Text = _data.Item("name")
            CMBYEARLEVEL.SelectedValue = _data.Item("year_id")
        End If
    End Sub
End Class
