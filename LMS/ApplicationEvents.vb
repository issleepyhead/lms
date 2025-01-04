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
                    ExecNonQuery(QueryTableFactory.QueryTableFactory(QueryTableType.FACULTY_QUERY_TABLE).ADD_QUERY, params)
                    ExecNonQuery("INSERT INTO tbladmins (faculty_id, role) SELECT id, 0 FROM tblfaculties WHERE email = 'example@email.com' AND username = 'sa'")
                End If

                If My.Settings.user_id <> 0 AndAlso My.Settings.session_login > Date.Now Then
                    ' This will go the userdashboard without authentication
                    MainForm = DashboardForm
                Else
                    MainForm = LogInForm
                End If
            Catch ex As Exception
                MainForm = ServerForm
            End Try
        End Sub
    End Class
End Namespace
