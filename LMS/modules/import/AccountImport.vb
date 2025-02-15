

Public Class AccountImport
    'Inherits ExcelDataLoader

    'Public Overrides Function DataFactory(type As QueryTableType, drow As DataRow) As Dictionary(Of String, String)
    '    Dim typeField = GetType(QueryTableType).GetField(type.ToString())
    '    Dim sheetAttrib As SheetNameMapping = CType(Attribute.GetCustomAttribute(typeField, GetType(SheetNameMapping)), SheetNameMapping)
    '    Dim colAttrib As ColumnMapping = CType(Attribute.GetCustomAttribute(typeField, GetType(ColumnMapping)), ColumnMapping)
    '    Dim tempt As New Dictionary(Of String, String)

    '    Try
    '        Select Case type
    '            Case DEPARTMENT_QUERY_TABLE, SECTION_QUERY_TABLE
    '                For i As Integer = 0 To colAttrib.Columns.Length - 1
    '                    tempt.Add(colAttrib.Names(i), drow.Item(colAttrib.Columns(i)))
    '                Next
    '                Return tempt
    '            Case YEARLEVEL_QUERY_TABLE
    '                For i As Integer = 0 To colAttrib.Columns.Length - 1
    '                    tempt.Add(colAttrib.Names(i), drow.Item(colAttrib.Columns(i)))
    '                Next
    '                Dim yid As Integer = ExecScalar("SELECT id FROM tbldepartments WHERE department_name = @name", New Dictionary(Of String, String) From {{"@name", drow.Item("Department")}})
    '                tempt.Item("@did") = yid
    '                Return tempt
    '            Case SECTION_QUERY_TABLE
    '                For i As Integer = 0 To colAttrib.Columns.Length - 1
    '                    tempt.Add(colAttrib.Names(i), drow.Item(colAttrib.Columns(i)))
    '                Next
    '                Dim yid As Integer = ExecScalar("SELECT id FROM tblyearlevels WHERE year_level = @name", New Dictionary(Of String, String) From {{"@name", drow.Item("Year Level")}})
    '                tempt.Item("@yid") = yid
    '                Return tempt
    '            Case STUDENT_QUERY_TABLE
    '                For i As Integer = 0 To colAttrib.Columns.Length - 1
    '                    tempt.Add(colAttrib.Names(i), drow.Item(colAttrib.Columns(i)))
    '                Next

    '                Dim sid As Integer = ExecScalar("SELECT id FROM tblsections WHERE name = @name", New Dictionary(Of String, String) From {{"@name", drow.Item("Section")}})

    '                Dim year As String = Date.Now.Year.ToString
    '                Dim firstLetterName As String = tempt.Item("@full_name").ToLower().Substring(0, 1)
    '                Dim namearray As String() = tempt.Item("@full_name").Split(" "c)
    '                Dim lastName As String = namearray(namearray.Length - 1).ToLower()

    '                tempt.Item("@sid") = sid

    '                If drow.Table.Columns.Contains("Phone") Then
    '                    tempt.Add("@phone", drow.Item("Phone"))
    '                Else
    '                    tempt.Item("@phone") = String.Empty
    '                End If

    '                If drow.Table.Columns.Contains("Address") Then
    '                    tempt.Add("@address", drow.Item("Address"))
    '                Else
    '                    tempt.Item("@phone") = String.Empty
    '                End If

    '                tempt.Item("@passwd") = BCrypt.Net.BCrypt.HashPassword(firstLetterName & lastName & year)
    '            Case FACULTY_QUERY_TABLE
    '                For i As Integer = 0 To colAttrib.Columns.Length - 1
    '                    tempt.Add(colAttrib.Names(i), drow.Item(colAttrib.Columns(i)))
    '                Next
    '                Dim did As Integer = ExecScalar("SELECT id FROM tbldepartments WHERE department_name = @name", New Dictionary(Of String, String) From {{"@name", drow.Item("Department")}})

    '                Dim year As String = Date.Now.Year.ToString
    '                Dim firstLetterName As String = tempt.Item("@full_name").ToLower().Substring(0, 1)
    '                Dim namearray As String() = tempt.Item("@full_name").Split(" "c)
    '                Dim lastName As String = namearray(namearray.Length - 1).ToLower()

    '                If drow.Table.Columns.Contains("Phone") Then
    '                    tempt.Add("@phone", drow.Item("Phone"))
    '                Else
    '                    tempt.Item("@phone") = Nothing
    '                End If

    '                If drow.Table.Columns.Contains("Address") Then
    '                    tempt.Add("@address", drow.Item("Address"))
    '                Else
    '                    tempt.Item("@address") = Nothing
    '                End If

    '                If drow.Table.Columns.Contains("Email") Then
    '                    tempt.Add("@email", drow.Item("Email"))
    '                Else
    '                    tempt.Item("@email") = Nothing
    '                End If


    '                tempt.Item("@did") = did
    '                tempt.Item("@username") = firstLetterName & lastName
    '                tempt.Item("@passwd") = BCrypt.Net.BCrypt.HashPassword(firstLetterName & lastName & year)
    '        End Select
    '    Catch ex As Exception
    '        Logger.Logger(ex)
    '    End Try

    '    Return tempt
    'End Function
End Class
