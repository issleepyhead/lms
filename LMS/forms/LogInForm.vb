Public Class LogInForm

    Private _isShowing As Boolean = False
    Private Sub BTNLOGIN_Click(sender As Object, e As EventArgs) Handles BTNLOGIN.Click
        Dim params As New Dictionary(Of String, String) From {
            {"@username", TXTUSERNAME.Text}
        }
        Dim data As DataTable = ExecFetch("SELECT id, password FROM tblfaculties WHERE username = @username OR email = @username UNION SELECT id, password FROM tblstudents WHERE lrn = @username OR student_no = @username", params)
        If data.Rows.Count > 0 Then
            If BCrypt.Net.BCrypt.Verify(TXTPASSWORD.Text, data.Rows.Item(0).Item("password")) Then
                My.Settings.user_id = data.Rows.Item(0).Item("id")
                If CHKREMEMBER.Checked Then
                    My.Settings.remember_user = True
                    My.Settings.user_username = TXTUSERNAME.Text
                    My.Settings.session_login = Date.Now.AddDays(1)
                End If
                My.Settings.Save()
                MessageBox.Show("You have been logged in.", "Login Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Using Me
                    DashboardForm.Show()
                End Using
            Else
                MessageBox.Show("Invalid username or password.", "Login Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("This username doesn't exist in the database.", "Invalid Username!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub TXTUSERNAME_TextChanged(sender As Object, e As EventArgs) Handles TXTUSERNAME.TextChanged
        NotAllowed(sender, "^[a-z0-9\.@]*$")
    End Sub

    Private Sub TXTPASSWORD_TextChanged(sender As Object, e As EventArgs) Handles TXTPASSWORD.TextChanged
        NotAllowed(sender, "^[a-zA-Z0-9\p{P}]*$")
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

    Private Sub LogInForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.remember_user Then
            CHKREMEMBER.Checked = My.Settings.remember_user
            TXTUSERNAME.Text = My.Settings.user_username
        End If
    End Sub
End Class