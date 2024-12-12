Public Class ServerForm
    Private _isShowing As Boolean = False
    Private Sub BtnConnect_Click(sender As Object, e As EventArgs) Handles BtnConnect.Click
        My.Settings.server_name = TXTSERVER.Text
        My.Settings.server_username = TXTUSERNAME.Text
        My.Settings.server_password = TXTPASSWORD.Text
        My.Settings.connection_string = TestConnectionString()
        My.Settings.Save()

        If Not IsNothing(GetConnectionInstance()) AndAlso GetConnectionInstance().State = ConnectionState.Open Then
            Using Me
                DashboardForm.Show()
            End Using
            MessageBox.Show("Connection has been established.", "Connected Successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Failed connecting to the server.", "Connection Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub TXTPASSWORD_IconRightClick(sender As Object, e As EventArgs) Handles TXTPASSWORD.IconRightClick
        If _isShowing Then
            TXTPASSWORD.IconRight = My.Resources.password_disable
            TXTPASSWORD.PasswordChar = "●"
            _isShowing = False
        Else
            TXTPASSWORD.IconRight = My.Resources.password_enable
            TXTPASSWORD.PasswordChar = ""
            _isShowing = True
        End If
    End Sub

    Private Sub ServerForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.remember_server Then
            TXTUSERNAME.Text = My.Settings.server_username
            TXTSERVER.Text = My.Settings.server_name
            CHKREMEMBER.Checked = My.Settings.remember_server
        End If
    End Sub

    Private Sub CHKREMEMBER_CheckedChanged(sender As Object, e As EventArgs) Handles CHKREMEMBER.CheckedChanged
        If CHKREMEMBER.Checked Then
            My.Settings.remember_server = True
        Else
            My.Settings.remember_server = False
        End If
        My.Settings.Save()
    End Sub

    Private Sub TXTSERVER_TextChanged(sender As Object, e As EventArgs) Handles TXTSERVER.TextChanged

    End Sub

    Private Sub TXTSERVER_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TXTSERVER.Validating
        NotAllowed(sender, "^[\d\.]*$")
    End Sub
End Class
