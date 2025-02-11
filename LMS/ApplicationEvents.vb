Imports Microsoft.VisualBasic.ApplicationServices
Imports MySql.Data.MySqlClient

Namespace My
    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.

    Partial Friend Class MyApplication

        ' Keeps all the dialogs of the application
        Public Shared DialogInstances As New Dictionary(Of String, Form)
        Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
            My.Settings.last_run = Date.Now

            ' Detect if we are already connected to the server
            Try
                If IsNothing(GetConnectionInstance()) Then
                    Throw New Exception("Can't connect to the server.")
                End If

                If ExecScalar("SELECT COUNT(*) FROM tblappsettings") = 0 Then
                    ExecNonQuery("INSERT INTO tblappsettings (enable_notification, gpenalty, spenalty, fpenalty, sdays, fdays, e_pass, s_count, f_count, return_message, overdue_message, borrow_message, app_email, boverdue_message) VALUES
                                    (@en, @gp, @sp, @fp, @sd, @fd, @ep, @sc, @fc, @rm, @om, @bm, @ae, @bom)", New Dictionary(Of String, String) From {
                        {"@en", My.Settings.enable_notif},
                        {"@gp", My.Settings.gpenalty},
                        {"@sp", My.Settings.spenalty},
                        {"@fp", My.Settings.fpenalty},
                        {"@sd", My.Settings.sdays},
                        {"@fd", My.Settings.fdays},
                        {"@ep", My.Settings.email_pass},
                        {"@sc", My.Settings.scount},
                        {"@fc", My.Settings.fcount},
                        {"@rm", My.Settings.return_message},
                        {"@om", My.Settings.overdue_message},
                        {"@bm", My.Settings.borrow_message},
                        {"@ae", My.Settings.email},
                        {"@bom", My.Settings.before_overdue_message}
                    })
                End If

                Dim dt As DataTable = ExecFetch("SELECT * FROM tblappsettings")
                With dt.Rows.Item(0)
                    My.Settings.enable_notif = .Item("enable_notification")
                    My.Settings.gpenalty = .Item("gpenalty")
                    My.Settings.spenalty = .Item("spenalty")
                    My.Settings.fpenalty = .Item("fpenalty")
                    My.Settings.sdays = .Item("sdays")
                    My.Settings.fdays = .Item("fdays")
                    My.Settings.email_pass = .Item("e_pass")
                    My.Settings.scount = .Item("s_count")
                    My.Settings.fcount = .Item("f_count")
                    My.Settings.return_message = .Item("return_message")
                    My.Settings.overdue_message = .Item("overdue_message")
                    My.Settings.borrow_message = .Item("borrow_message")
                    My.Settings.email = .Item("app_email")
                    My.Settings.before_overdue_message = .Item("boverdue_message")
                End With

                ' TODO FIX THIS THE ADMIN ACC DOES NOT CONTAIN THE INFO
                If ExecScalar("SELECT COUNT(*) FROM tbladmins WHERE role = 0") = 0 Then
                    Dim params As New Dictionary(Of String, String) From {
                        {"@full_name", "Juan Dela Cruz"},
                        {"@gender", "Male"},
                        {"@address", String.Empty},
                        {"@phone", String.Empty},
                        {"@email", "example@email.com"},
                        {"@did", String.Empty},
                        {"@username", "sa"},
                        {"@passwd", BCrypt.Net.BCrypt.HashPassword("sa")}
                    }
                    ExecNonQuery(Registry.Item(QueryType.FACULTY).ADD_QUERY, params)
                    ExecNonQuery("INSERT INTO tbladmins (faculty_id, role) SELECT id, 0 FROM tblfaculties WHERE email = 'example@email.com' AND username = 'sa'")
                End If

                If My.Settings.student_id <> 0 AndAlso My.Settings.session_login > Date.Now Then
                    ' This will go the userdashboard without authentication
                    MainForm = DashboardForm
                Else
                    MainForm = LogInForm
                End If
            Catch ex As Exception
                Logger.Logger(ex)
                MainForm = ServerForm
            End Try
        End Sub
    End Class
End Namespace
