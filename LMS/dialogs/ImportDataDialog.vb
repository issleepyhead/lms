Imports System.ComponentModel
Imports System.Windows.Forms
Imports LMS.My

Public Class ImportDataDialog
    Private path As String
    Private data As Dictionary(Of String, DataTable)
    Private _isHiding = False
    Private _importHandler As ExcelDataLoader
    Private _keyDialog As String

    Sub New(excelLoader As ExcelDataLoader, keyDialog As String)
        InitializeComponent()
        _importHandler = excelLoader
        _keyDialog = keyDialog

        If keyDialog = NameOf(BookDialog) Then
            _importHandler = New BookImport
            Text &= " - Books"
        ElseIf keyDialog = NameOf(StudentDialog) Then
            _importHandler = New AccountImport(QueryTableType.STUDENT_QUERY_TABLE)
            Text &= " - Students"
        Else
            _importHandler = New AccountImport(QueryTableType.FACULTY_QUERY_TABLE)
            Text &= " - Teachers/Faculties"
        End If
    End Sub

    Private Sub BTNSELECTFILE_Click(sender As Object, e As EventArgs) Handles BTNSELECTFILE.Click
        Using dialog As New OpenFileDialog
            If dialog.ShowDialog = DialogResult.OK Then
                If Not _importHandler.IsValid(dialog.FileName) Then
                    MessageBox.Show("Invalid excel file, this file doesn't contain the required sheets or columns.", "Invalid Excel File", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                BTNPREVIEW.Enabled = True
                path = dialog.FileName
                TXTPATH.Text = path
            End If
        End Using
    End Sub

    Private Async Sub BTNPREVIEW_Click(sender As Object, e As EventArgs) Handles BTNPREVIEW.Click
        ' Loads all the data from excel file.
        data = Await ExcelDataLoader.ReadData(path)

        If data.ContainsKey("Books") Then
            DGDATA.DataSource = data.Item("Books")
        ElseIf data.ContainsKey("Faculties") Then
            DGDATA.DataSource = data.Item("Faculties")
        Else
            DGDATA.DataSource = data.Item("Students")
        End If
    End Sub

    Private Sub ImportBookDialog_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not _isHiding Then
            If Not String.IsNullOrEmpty(path) OrElse Not IsNothing(DGDATA.DataSource) Then
                If MessageBox.Show("Are you sure you want to discard changes?", "Discard Changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    If Not ImportBackground.CancellationPending Then
                        ImportBackground.CancelAsync()
                        _importHandler.DBHANDLER.RollbackTransaction()
                    End If
                    MyApplication.DialogInstances.Remove(_keyDialog)
                Else
                    e.Cancel = True
                End If
            Else
                MyApplication.DialogInstances.Remove(_keyDialog)
            End If
        Else
            MyApplication.DialogInstances.Remove(_keyDialog)
        End If
        _isHiding = False
    End Sub

    Private Sub DGBOOK_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGDATA.CellFormatting
        ' Check if the value in the current cell is greater than 25
        If e.ColumnIndex = DGDATA.Columns.Count - 1 Then

            e.CellStyle.ForeColor = Color.White
            e.CellStyle.SelectionForeColor = Color.White
            If e.Value = "Ready" Then
                e.CellStyle.BackColor = Color.DodgerBlue
                e.CellStyle.SelectionBackColor = Color.DodgerBlue
            ElseIf e.Value = "Success" Then
                e.CellStyle.BackColor = Color.Green
                e.CellStyle.SelectionBackColor = Color.Green
            ElseIf e.Value = "Duplicate" Then
                e.CellStyle.ForeColor = Color.Black
                e.CellStyle.SelectionForeColor = Color.Black
                e.CellStyle.BackColor = Color.Yellow
                e.CellStyle.SelectionBackColor = Color.Yellow
            Else
                e.CellStyle.BackColor = Color.Red
                e.CellStyle.SelectionBackColor = Color.Red
            End If
        End If
    End Sub

    Private Sub BTNCANCEL_Click(sender As Object, e As EventArgs) Handles BTNCANCEL.Click
        If Not IsNothing(_importHandler) Then
            ImportBackground.CancelAsync()
            _importHandler.DBHANDLER.RollbackTransaction()
        End If
    End Sub

    Private Sub BTNHIDE_Click(sender As Object, e As EventArgs) Handles BTNHIDE.Click
        _isHiding = True
        Hide()
    End Sub

    Private Sub BTNIMPORT_Click(sender As Object, e As EventArgs) Handles BTNIMPORT.Click
        If IsNothing(data) Then
            MessageBox.Show("Please select an excel data to be imported.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If Not ImportBackground.IsBusy Then
            ImportBackground.RunWorkerAsync()
        Else
            MessageBox.Show("Another data import is already in progress. Please wait until the current import is complete before starting a new one.", "Data Import in Progress", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ImportBackground_DoWork(sender As Object, e As DoWorkEventArgs) Handles ImportBackground.DoWork
        ' TODO Fix these some sheets and columns are optional.
        If Not IsNothing(data) Then
            Me.Invoke(Sub()
                          BTNIMPORT.Enabled = False
                      End Sub)
            Dim orderImport As String() = Nothing
            Dim orderQuery As QueryTableType() = Nothing

            If data.ContainsKey("Books") Then
                orderImport = {"Genres", "Authors", "Publishers", "Classifications", "Languages", "Books"}
                orderQuery = {QueryTableType.GENRE_QUERY_TABLE, QueryTableType.AUTHOR_QUERY_TABLE, QueryTableType.PUBLISHER_QUERY_TABLE, QueryTableType.CLASSIFICATION_QUERY_TABLE,
                                    QueryTableType.LANGUAGES_QUERY_TABLE, QueryTableType.BOOK_QUERY_TABLE}

            ElseIf data.ContainsKey("Students") Then
                orderImport = {"Departments", "Year Levels", "Sections", "Students"}
                orderQuery = {QueryTableType.DEPARTMENT_QUERY_TABLE, QueryTableType.YEARLEVEL_QUERY_TABLE, QueryTableType.SECTION_QUERY_TABLE, QueryTableType.STUDENT_QUERY_TABLE}
            Else
                orderImport = {"Departments", "Faculties"}
                orderQuery = {QueryTableType.DEPARTMENT_QUERY_TABLE, QueryTableType.FACULTY_QUERY_TABLE}
            End If

            For index As Integer = 0 To orderImport.Length - 1
                If data.ContainsKey(orderImport(index)) Then
                    Dim dt As DataTable = data.Item(orderImport(index))


                    For Each drow As DataRow In dt.Rows
                        Dim rdata As Dictionary(Of String, String) = _importHandler.DataFactory(orderQuery(index), drow)
                        Dim query As QueryTable = Registry.Item(orderQuery(index))
                        If _importHandler.DBHANDLER.ExistsData(query, rdata) Then
                            drow.Item("Status") = "Duplicate"
                        Else
                            If _importHandler.DBHANDLER.AddData(query, rdata) Then
                                drow.Item("Status") = "Success"
                            Else
                                drow.Item("Status") = "Failed"
                            End If
                        End If
                        ImportBackground.ReportProgress(index)
                    Next
                End If
            Next
        End If
    End Sub

    Private Sub ImportBackground_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles ImportBackground.ProgressChanged
        If data.ContainsKey("Books") Then
            DGDATA.DataSource = data.Item("Books")
        ElseIf data.ContainsKey("Students") Then
            DGDATA.DataSource = data.Item("Students")
        Else
            DGDATA.DataSource = data.Item("Faculties")
        End If
    End Sub

    Private Sub ImportBackground_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles ImportBackground.RunWorkerCompleted
        _importHandler.DBHANDLER.CommitTransaction()
        If data.ContainsKey("Books") Then
            DGDATA.DataSource = data.Item("Books")
        ElseIf data.ContainsKey("Students") Then
            DGDATA.DataSource = data.Item("Students")
        Else
            DGDATA.DataSource = data.Item("Faculties")
        End If
        BTNIMPORT.Enabled = True
    End Sub
End Class
