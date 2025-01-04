Imports System.Windows.Forms

Public Class FacultyDialog
    Private _data As DataRowView

    Sub New()
        InitializeComponent()
    End Sub

    Sub New(data As DataRowView)
        InitializeComponent()
        _data = data
    End Sub

    Private Sub StudentDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CMBDEPARTMENT.DataSource = BaseMaintenance.FetchAll(QueryTableType.DEPARTMENT_QUERY_TABLE)
        If Not IsNothing(_data) Then
            TXTUSERNAME.Enabled = False
            TXTFULLNAME.Text = _data.Row("full_name")
            CMBGENDER.SelectedText = _data.Row("gender")
            TXTADDRESS.Text = If(IsDBNull(_data.Row("address")), Nothing, _data.Row("address"))
            TXTPHONE.Text = If(IsDBNull(_data.Row("phone")), Nothing, _data.Row("phone"))
            CMBDEPARTMENT.SelectedValue = _data.Item("department_id")
            TXTEMAIL.Text = _data.Item("email")
            TXTUSERNAME.Text = _data.Item("username")
        End If
    End Sub

    Private Sub BTNSAVE_Click(sender As Object, e As EventArgs) Handles BTNSAVE.Click
        Dim inputs As Object() = {TXTFULLNAME, TXTEMAIL}
        For Each item In inputs
            errProvider.SetError(item, String.Empty)
        Next

        Dim year As String = Date.Now.Year.ToString
        Dim firstLetterName As String = TXTFULLNAME.Text.ToUpper().Substring(0, 1)
        Dim namearray As String() = TXTFULLNAME.Text.Split(" "c)
        Dim lastName As String = namearray(namearray.Length - 1)

        Dim data As New Dictionary(Of String, String) From {
                {"@id", If(IsNothing(_data), 0, _data.Item("id").ToString)},
                {"@full_name", TXTFULLNAME.Text},
                {"@gender", CMBGENDER.Text},
                {"@address", TXTADDRESS.Text},
                {"@phone", TXTPHONE.Text},
                {"@email", TXTEMAIL.Text},
                {"@did", CMBDEPARTMENT.SelectedValue},
                {"@username", TXTUSERNAME.Text},
                {"@passwd", BCrypt.Net.BCrypt.HashPassword(firstLetterName & lastName & year)}
        }

        If BaseMaintenance.Exists(QueryTableType.FACULTY_QUERY_TABLE, data) Then
            errProvider.SetError(TXTEMAIL, "This email already exists.")
            Exit Sub
        End If

        If IsNothing(_data) Then
            If BaseMaintenance.Add(QueryTableType.FACULTY_QUERY_TABLE, data) Then
                MessageBox.Show("Faculty/Teacher has been added successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed adding the faculty/teacher.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Else
            If BaseMaintenance.Update(QueryTableType.FACULTY_QUERY_TABLE, data) Then
                MessageBox.Show("Faculty/Teacher has been updated successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed updating the faculty/teacher.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If
        Close()
    End Sub

End Class
