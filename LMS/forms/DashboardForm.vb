Imports LMS.My
Imports LMS.QueryType
Imports LMS.STATUSTYPE

Public Class DashboardForm

    ' Maintenancce selection collection
    Private SELECTED_BOOKS As New SystemDataSets.DTBookDataTable
    Private SELECTED_STUDENTS As New SystemDataSets.DTStudentDataTable
    Private SELECTED_FACULTY As New SystemDataSets.DTFacultyDataTable

    'Report selection collection
    Private SELECTED_BOOKSR As DataTable
    Private SELECTED_EXPENDITURE As DataTable
    Private SELECTED_FINES As DataTable
    Private SELECTED_BORROWER As DataTable
    Private SELECTED_BORROWED As DataTable

    Private ControlsMap As Dictionary(Of String, ControlMapping)
    Private IS_LOADED As Boolean = False
    Private CURRENT_TAG As String = String.Empty

    Sub New()
        InitializeComponent()
        ControlsMap = New Dictionary(Of String, ControlMapping) From {
            {NameOf(GENRE), New ControlMapping With {.DG = DGGENRE, .LBLNEXT = LBLGENRENEXT, .LBLPREV = LBLGENREPREV, .TXTSEARCH = TXTGENRESEARCH, .DIALOG_NAME = GenreDialog.GetType(), .QUERY_TYPE = GENRE}},
            {NameOf(AUTHOR), New ControlMapping With {.DG = DGAUTHORS, .LBLNEXT = LBLAUTHORNEXT, .LBLPREV = LBLAUTHORPREV, .TXTSEARCH = TXTSEARCHAUTHOR, .DIALOG_NAME = AuthorDialog.GetType(), .QUERY_TYPE = AUTHOR}},
            {NameOf(PUBLISHER), New ControlMapping With {.DG = DGPUBLISHER, .LBLNEXT = LBLPUBLISHERNEXT, .LBLPREV = LBLPUBLISHERPREV, .TXTSEARCH = TXTPUBLISHERSEARCH, .DIALOG_NAME = PublisherDialog.GetType(), .QUERY_TYPE = PUBLISHER}},
            {NameOf(CLASSIFICATION), New ControlMapping With {.DG = DGCLASSIFICATIONS, .LBLNEXT = LBLCLASSIFICATIONNEXT, .LBLPREV = LBLCLASSIFICATIONPREV, .TXTSEARCH = TXTCLASSIFICATIONSEARCH, .DIALOG_NAME = ClassificationDialog.GetType(), .QUERY_TYPE = CLASSIFICATION}},
            {NameOf(LANGUAGES), New ControlMapping With {.DG = DGLANGUAGE, .LBLNEXT = LBLLANGUAGENEXT, .LBLPREV = LBLLANGUAGEPREV, .TXTSEARCH = TXTLANGUAGESEARCH, .DIALOG_NAME = LanguageDialog.GetType(), .QUERY_TYPE = LANGUAGES}},
            {NameOf(DONATOR), New ControlMapping With {.DG = DGDONATOR, .LBLNEXT = LBLDONATORNEXT, .LBLPREV = LBLDONATORRPREV, .TXTSEARCH = TXTDONATORSEARCH, .DIALOG_NAME = DonatorDialog.GetType(), .QUERY_TYPE = DONATOR}},
            {NameOf(SUPPLIER), New ControlMapping With {.DG = DGSUPPLIER, .LBLNEXT = LBLSUPPLIERNEXT, .LBLPREV = LBLSUPPLIERPREV, .TXTSEARCH = TXTSUPPLIERSEARCH, .DIALOG_NAME = SupplierDialog.GetType(), .QUERY_TYPE = SUPPLIER}},
            {NameOf(BOOK), New ControlMapping With {.DG = DGBOOKS, .LBLNEXT = LBLBOOKNEXT, .LBLPREV = LBLBOOKPREV, .TXTSEARCH = TXTBOOKSEARCH, .DIALOG_NAME = BookDialog.GetType(), .QUERY_TYPE = BOOK}},
            {NameOf(SECTION), New ControlMapping With {.DG = DGSECTIONS, .LBLNEXT = LBLSECTIONNEXT, .LBLPREV = LBLSECTIONPREV, .TXTSEARCH = TXTSECTIONSEARCH, .DIALOG_NAME = SectionDialog.GetType(), .QUERY_TYPE = SECTION}},
            {NameOf(YEARLEVEL), New ControlMapping With {.DG = DGYEARLEVEL, .LBLNEXT = LBLYEARLEVELNEXT, .LBLPREV = LBLYEARLEVELPREV, .TXTSEARCH = TXTYEARLEVELSEARCH, .DIALOG_NAME = YearLevelDialog.GetType(), .QUERY_TYPE = YEARLEVEL}},
            {NameOf(DEPARTMENT), New ControlMapping With {.DG = DGDEPARTMENT, .LBLNEXT = LBLDEPARTMENTNEXT, .LBLPREV = LBLDEPARTMENTPREV, .TXTSEARCH = TXTDEPARTMENTSEARCH, .DIALOG_NAME = DepartmentDialog.GetType(), .QUERY_TYPE = DEPARTMENT}},
            {NameOf(STUDENT), New ControlMapping With {.DG = DGSTUDENT, .LBLNEXT = LBLSTUDENTNEXT, .LBLPREV = LBLSTUDENTPREV, .TXTSEARCH = TXTSTUDENTSEARCH, .DIALOG_NAME = StudentDialog.GetType(), .QUERY_TYPE = STUDENT}},
            {NameOf(FACULTY), New ControlMapping With {.DG = DGFACULTY, .LBLNEXT = LBLFACULTYNEXT, .LBLPREV = LBLFACULTYPREV, .TXTSEARCH = TXTFACULTYSEARCH, .DIALOG_NAME = FacultyDialog.GetType(), .QUERY_TYPE = FACULTY}},
            {NameOf(ADMIN), New ControlMapping With {.DG = DGADMINISTRATOR, .LBLNEXT = LBLADMINNEXT, .LBLPREV = LBLADMINPREV, .TXTSEARCH = TXTADMINSEARCH, .QUERY_TYPE = ADMIN}},
            {NameOf(BOOKCOPIES), New ControlMapping With {.DG = DGBOOKCOPIES, .LBLNEXT = LBLCOPIESNEXT, .LBLPREV = LBLCOPIESPREV, .TXTSEARCH = TXTCOPIESSEARCH, .QUERY_TYPE = BOOKCOPIES}},
            {NameOf(BOOKINVENTORY), New ControlMapping With {.DG = DGINVENTORY, .LBLNEXT = LBLINVENTORYNEXT, .LBLPREV = LBLINVENTORYPREV, .TXTSEARCH = TXTINVENTORYSEARCH, .QUERY_TYPE = BOOKINVENTORY}},
            {NameOf(BOOKLOSTDAMAGE), New ControlMapping With {.DG = DGLOSTDAMAGE, .LBLNEXT = LBLLOSTDAMAGENEXT, .LBLPREV = LBLLOSTDAMAGEPREV, .TXTSEARCH = TXTLOSTDAMAGESEARCH, .QUERY_TYPE = BOOKLOSTDAMAGE}},
            {NameOf(TRANSACTION), New ControlMapping With {.DG = DGTRANSACTION, .LBLNEXT = LBLTRANSACTIONNEXT, .LBLPREV = LBLTRANSACTIONPREV, .TXTSEARCH = TXTTRANSACTIONSEARCH, .QUERY_TYPE = TRANSACTION}},
            {NameOf(BOOKREPORT), New ControlMapping With {.DG = DGBOOKREPORT, .LBLNEXT = LBLBOOKREPORTNEXT, .LBLPREV = LBLBOOKREPORTPREV, .TXTSEARCH = TXTBOOKREPORTSEARCH, .QUERY_TYPE = BOOKREPORT}},
            {NameOf(QueryType.EXPENDITUREREPORT), New ControlMapping With {.DG = DGEXPENDITUREREPORT, .LBLNEXT = LBLEXPENDITUREREPORTNEXT, .LBLPREV = LBLEXPENDITUREREPORTPREV, .TXTSEARCH = TXTEXPENDITUREREPORTSEARCH, .QUERY_TYPE = QueryType.EXPENDITUREREPORT}},
            {NameOf(QueryType.FINESREPORT), New ControlMapping With {.DG = DGFINESREPORT, .LBLNEXT = LBLFINESREPORTNEXT, .LBLPREV = LBLFINESREPORTPREV, .TXTSEARCH = TXTFINESREPORTSSEARCH, .QUERY_TYPE = QueryType.FINESREPORT}},
            {NameOf(LOGS), New ControlMapping With {.DG = DGACTIVITY, .LBLNEXT = LBLACTIVITYNEXT, .LBLPREV = LBLACTIVITYPREV, .TXTSEARCH = TXTACTIVITYSEARCH, .QUERY_TYPE = LOGS}},
            {NameOf(BORROWERREPORT), New ControlMapping With {.DG = DGBORROWERERREPORT, .LBLNEXT = LBLBORROWERREPORTNEXT, .LBLPREV = LBLBORROWERREPORTPREV, .TXTSEARCH = TXTBORROWERREPORTSEARH, .QUERY_TYPE = BORROWERREPORT}},
            {NameOf(CLSSIFICATIONREPORT), New ControlMapping With {.DG = DGCLASSIFICATIONREPORT, .LBLNEXT = LBLCLASSIFICATIONREPORTNEXT, .LBLPREV = LBLCLASSIFICATIONREPORTPREV, .TXTSEARCH = TXTCLASSIFICATIONREPORTSSEARCH, .QUERY_TYPE = CLSSIFICATIONREPORT}}
        }
    End Sub

    Private Sub DashboardForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BookInventoryPanels_SelectedIndexChanged(BookInventoryPanels, Nothing)
        DGTRANSACTION.Columns(NameOf(ColumnOverdueDate)).DisplayIndex = DGTRANSACTION.Columns.Count - 1
        IS_LOADED = True
    End Sub

    Private Sub BTNLOGOUT_Click(sender As Object, e As EventArgs) Handles BTNLOGOUT.Click
        ' TODO LOG OUT LOGIC
        My.Settings.student_id = 0
        My.Settings.faculty_id = 0
        My.Settings.Save()
        Using Me
            LogInForm.Show()
        End Using
    End Sub

#Region "Shared Functions"
    Private Sub BTNADD_Click(sender As Object, e As EventArgs) Handles BTNADDGENRE.Click, BTNADDAUTHOR.Click, BTNADDPUBLISHER.Click, BTNADDCLASSIFICATION.Click,
            BTNADDLANGUAGE.Click, BTNADDDONATOR.Click, BTNADDSUPPLIER.Click, BTNADDBOOK.Click, BTNADDSECTION.Click, BTNADDYEARLEVEL.Click, BTNADDDEPARTMENT.Click,
            BTNADDSTUDENTS.Click, BTNADDFACULTY.Click
        ControlsMap.Item(sender.Tag).OpenDialog()
    End Sub

    Private Sub BTNNEXT_Click(sender As Object, e As EventArgs) Handles BTNGENRENEXT.Click, BTNAUTHORNEXT.Click, BTNPUBLISHERNEXT.Click,
            BTNCLASSIFICATIONNEXT.Click, BTNLANGUAGENEXT.Click, BTNDONATORNEXT.Click, BTNSUPPLIERNEXT.Click, BTNBOOKNEXT.Click, BTNSECTIONNEXT.Click, BTNYEARLEVELNEXT.Click, BTNDEPARTMENTNEXT.Click,
            BTNSTUDENTNEXT.Click, BTNFACULTYNEXT.Click, BTNADMINNEXT.Click, BTNCOPIESNEXT.Click, BTNINVENTORYNEXT.Click, BTNLOSTDAMAGENEXT.Click, BTNTRANSACTIONNEXT.Click, BTNCLASSIFICATIONREPORTNEXT.Click,
            BTNACTIVITYNEXT.Click
        If sender.Tag = NameOf(BOOK) Then
            ControlsMap.Item(sender.Tag).NextPage(If(CMBBOOKFILTER.SelectedText.ToLower = NameOf(ACTIVE).ToLower, ACTIVE, INACTIVE), AddressOf RetrieveBookSelection)
        ElseIf sender.Tag = NameOf(STUDENT) Then
            ControlsMap.Item(sender.Tag).NextPage(If(CMBSTUDENTFILTER.SelectedText.ToLower = NameOf(ACTIVE).ToLower, ACTIVE, INACTIVE), AddressOf RetrieveStudentSelection)
        ElseIf sender.Tag = NameOf(FACULTY) Then
            ControlsMap.Item(sender.Tag).NextPage(If(CMBFACULTYFILTER.SelectedText.ToLower = NameOf(ACTIVE).ToLower, ACTIVE, INACTIVE), AddressOf RetrieveFacultySelection)
        Else
            ControlsMap.Item(sender.Tag).NextPage()
        End If
    End Sub

    Private Sub BTNPREV_Click(sender As Object, e As EventArgs) Handles BTNGENREPREV.Click, BTNAUTHORPREV.Click, BTNPUBLISHERPREV.Click,
            BTNCLASSIFICATIONPREV.Click, BTNLANGUAGEPREV.Click, BTNDONATORRPREV.Click, BTNSUPPLIERPREV.Click, BTNBOOKPREV.Click, BTNSECTIONPREV.Click, BTNYEARLEVELPREV.Click, BTNDEPARTMENTPREV.Click,
            BTNSTUDENTPREV.Click, BTNFACULTYPREV.Click, BTNADMINPREV.Click, BTNCOPIESPREV.Click, BTNINVENTORYPREV.Click, BTNLOSTDAMAGEPREV.Click, BTNTRANSACTIONPREV.Click, BTNCLASSIFICATIONREPORTPREV.Click,
            BTNACTIVITYPREV.Click
        If sender.Tag = NameOf(BOOK) Then
            ControlsMap.Item(sender.Tag).PrevPage(If(CMBBOOKFILTER.SelectedText.ToLower = NameOf(ACTIVE).ToLower, ACTIVE, INACTIVE), AddressOf RetrieveBookSelection)
        ElseIf sender.Tag = NameOf(STUDENT) Then
            ControlsMap.Item(sender.Tag).PrevPage(If(CMBSTUDENTFILTER.SelectedText.ToLower = NameOf(ACTIVE).ToLower, ACTIVE, INACTIVE), AddressOf RetrieveStudentSelection)
        ElseIf sender.Tag = NameOf(FACULTY) Then
            ControlsMap.Item(sender.Tag).PrevPage(If(CMBFACULTYFILTER.SelectedText.ToLower = NameOf(ACTIVE).ToLower, ACTIVE, INACTIVE), AddressOf RetrieveFacultySelection)
        Else
            ControlsMap.Item(sender.Tag).PrevPage()
        End If
    End Sub

    Private Sub CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGGENRE.CellClick, DGAUTHORS.CellClick, DGPUBLISHER.CellClick, DGCLASSIFICATIONS.CellClick,
            DGLANGUAGE.CellClick, DGBOOKS.CellClick, DGDONATOR.CellClick, DGSUPPLIER.CellClick, DGSECTIONS.CellClick, DGYEARLEVEL.CellClick, DGDEPARTMENT.CellClick, DGSTUDENT.CellClick,
            DGFACULTY.CellClick
        ControlsMap.Item(sender.Tag).CellClick(e)
    End Sub

    Private Sub TextSearch(sender As Object, e As EventArgs) Handles TXTGENRESEARCH.TextChanged, TXTSEARCHAUTHOR.TextChanged, TXTPUBLISHERSEARCH.TextChanged, TXTCLASSIFICATIONSEARCH.TextChanged,
            TXTLANGUAGESEARCH.TextChanged, TXTBOOKSEARCH.TextChanged, TXTDONATORSEARCH.TextChanged, TXTSUPPLIERSEARCH.TextChanged, TXTFACULTYSEARCH.TextChanged, TXTSTUDENTSEARCH.TextChanged,
            TXTADMINSEARCH.TextChanged, TXTCOPIESSEARCH.TextChanged, TXTINVENTORYSEARCH.TextChanged, TXTDEPARTMENTSEARCH.TextChanged, TXTSECTIONSEARCH.TextChanged, TXTYEARLEVELSEARCH.TextChanged,
            TXTLOSTDAMAGESEARCH.TextChanged, TXTTRANSACTIONSEARCH.TextChanged, TXTCLASSIFICATIONREPORTSSEARCH.TextChanged, TXTACTIVITYSEARCH.TextChanged
        DBOperations.PREV_PAGE_NUMBER = 1
        If IS_LOADED Then
            ' TO-DO ADD LOGIC
            If MainFormPanels.SelectedTab.Equals(MaintenanceTab) Then
                TabSelected(MaintenancePanels, Nothing)
            ElseIf MainFormPanels.SelectedTab.Equals(AccountsMaintenanceTab) Then
                TabSelected(AccountsPanel, Nothing)
            ElseIf MainFormPanels.SelectedTab.Equals(BookInventoryTab) Then
                TabSelected(BookInventoryPanels, Nothing)
            ElseIf MainFormPanels.SelectedTab.Equals(ReportsTab) Then
                TabSelected(ReportsPanel, Nothing)
            Else
                FilterTransactionHelper()
            End If
        End If
    End Sub
#End Region
    Private Sub FilterTransactionHelper()
        Dim type As TRANSACTIONSTATE
        If CMBTRANSACTIONFILTER.Text.ToLower() = NameOf(TRANSACTIONSTATE.ACTIVE).ToLower() Then
            type = TRANSACTIONSTATE.ACTIVE
        ElseIf CMBTRANSACTIONFILTER.Text.ToLower() = NameOf(TRANSACTIONSTATE.OVERDUE).ToLower() Then
            type = TRANSACTIONSTATE.OVERDUE
        Else
            type = TRANSACTIONSTATE.RETURNED
        End If
        ControlsMap.Item(BookTransactionTab.Tag).Update(type)
    End Sub

    ' TODO THE FETCH OF THE TABS
#Region "Tab Selection"
    Private Sub MainFormPanels_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MainFormPanels.SelectedIndexChanged
        Select Case True
            Case MainFormPanels.SelectedTab.Equals(BookTransactionTab)
                FilterTransactionHelper()
            Case MainFormPanels.SelectedTab.Equals(BookInventoryTab)
                ControlsMap.Item(CopiesTab.Tag).Update()

                Dim dtDonator As DataTable = DBOperations.FetchAll(DONATOR)
                Dim newRow As DataRow = dtDonator.NewRow()
                newRow("id") = 0
                newRow("name") = "None"
                dtDonator.Rows.InsertAt(newRow, 0)

                Dim dtSupplier As DataTable = DBOperations.FetchAll(SUPPLIER)
                newRow = dtSupplier.NewRow()
                newRow("id") = 0
                newRow("name") = "None"
                dtSupplier.Rows.InsertAt(newRow, 0)

                TXTACCESSION.Text = GenerateAccession()

                CMBDONATORCOPIES.DataSource = dtDonator
                CMBSUPPLIERCOPIES.DataSource = dtSupplier
            Case MainFormPanels.SelectedTab.Equals(ReportsTab)
                ControlsMap.Item(BooksReportTab.Tag).Update()
            Case MainFormPanels.SelectedTab.Equals(SettingsTab)
                SettingsPanels_SelectedIndexChanged(SettingsPanels, Nothing)
            Case MainFormPanels.SelectedTab.Equals(AuditTrailTab)
                ControlsMap.Item(AuditTrailTab.Tag).Update()
            Case Else
                If MainFormPanels.SelectedTab.Equals(MaintenanceTab) Then
                    TabSelected(MaintenancePanels, Nothing)
                ElseIf MainFormPanels.SelectedTab.Equals(AccountsMaintenanceTab) Then
                    TabSelected(AccountsPanel, Nothing)
                End If
        End Select
    End Sub

    Private Sub TabSelected(sender As Object, e As TabControlEventArgs) Handles MaintenancePanels.Selected, AccountsPanel.Selected, BookInventoryPanels.Selected, ReportsPanel.Selected, AuditTrailPanels.Selected
        If CURRENT_TAG <> sender.Tag Then
            ControlsMap.Item(sender.SelectedTab.Tag).TXTSEARCH.Text = String.Empty
            CURRENT_TAG = sender.Tag
        End If

        If sender.Tag = NameOf(BOOK) Then
            ControlsMap.Item(sender.SelectedTab.Tag).Update(If(CMBBOOKFILTER.SelectedText.ToLower = NameOf(ACTIVE).ToLower, ACTIVE, INACTIVE))
        ElseIf sender.Tag = NameOf(STUDENT) Then
            ControlsMap.Item(sender.SelectedTab.Tag).Update(If(CMBSTUDENTFILTER.SelectedText.ToLower = NameOf(ACTIVE).ToLower, ACTIVE, INACTIVE))
        ElseIf sender.Tag = NameOf(FACULTY) Then
            ControlsMap.Item(sender.SelectedTab.Tag).Update(If(CMBSTUDENTFILTER.SelectedText.ToLower = NameOf(ACTIVE).ToLower, ACTIVE, INACTIVE))
        Else
            ControlsMap.Item(sender.SelectedTab.Tag).Update()
        End If
    End Sub
#End Region

    ' TODO FIX THIS SAME ROUTINE
#Region "Retrieve Selection"
    Private Sub RetrieveBookSelection()
        For Each item As DataGridViewRow In DGBOOKS.Rows
            For Each drow As DataRow In SELECTED_BOOKS.Rows
                Dim boundItem As DataRowView = TryCast(item.DataBoundItem, DataRowView)
                If boundItem.Row.Item("id") = drow.Item("id") Then
                    item.Cells(NameOf(chckBoxBooks)).Value = True
                End If
            Next
        Next
        DGBOOKS.EndEdit()
    End Sub

    Private Sub RetrieveStudentSelection()
        For Each item As DataGridViewRow In DGSTUDENT.Rows
            For Each drow As DataRow In SELECTED_STUDENTS.Rows
                Dim boundItem As DataRowView = TryCast(item.DataBoundItem, DataRowView)
                If boundItem.Row.Item("id") = drow.Item("id") Then
                    item.Cells(NameOf(chckBoxStudent)).Value = True
                End If
            Next
        Next
    End Sub

    Public Sub RetrieveFacultySelection()
        For Each item As DataGridViewRow In DGFACULTY.Rows
            For Each drow As DataRow In SELECTED_FACULTY.Rows
                Dim boundItem As DataRowView = TryCast(item.DataBoundItem, DataRowView)
                If boundItem.Row.Item("id") = drow.Item("id") Then
                    item.Cells(NameOf(chckBoxFaculty)).Value = True
                End If
            Next
        Next
    End Sub
#End Region

#Region "Combobox Filter"
    Private Sub CMBFILTER(sender As Object, e As EventArgs) Handles CMBBOOKFILTER.SelectedIndexChanged, CMBSTUDENTFILTER.SelectedIndexChanged, CMBFACULTYFILTER.SelectedIndexChanged
        If IS_LOADED Then
            If sender.SelectedIndex = 0 Then
                ControlsMap.Item(sender.Tag).Update(STATUSTYPE.ACTIVE)
            ElseIf sender.SelectedIndex = 1 Then
                ControlsMap.Item(sender.Tag).Update(STATUSTYPE.INACTIVE)
            End If
        End If
    End Sub

    Private Sub CMBTRANSACTIONFILTER_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMBTRANSACTIONFILTER.SelectedIndexChanged
        If IS_LOADED Then
            Dim type As TRANSACTIONSTATE
            If CMBTRANSACTIONFILTER.Text.ToLower() = NameOf(TRANSACTIONSTATE.ACTIVE).ToLower() Then
                type = TRANSACTIONSTATE.ACTIVE
            ElseIf CMBTRANSACTIONFILTER.Text.ToLower() = NameOf(TRANSACTIONSTATE.OVERDUE).ToLower() Then
                type = TRANSACTIONSTATE.OVERDUE
            Else
                type = TRANSACTIONSTATE.RETURNED
            End If
            ControlsMap.Item(BookTransactionTab.Tag).Update(type)
        End If
    End Sub
#End Region

#Region "Student Module"
    Private Sub DGSTUDENT_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGSTUDENT.CellContentClick
        If e.ColumnIndex = chckBoxStudent.Index Then
            DGSTUDENT.EndEdit()
            Dim boundItem As DataRowView = TryCast(DGSTUDENT.Rows(e.RowIndex).DataBoundItem, DataRowView)
            If CBool(DGSTUDENT.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) AndAlso Not SELECTED_STUDENTS.Rows.Contains(boundItem.Row.Item("id")) Then
                SELECTED_STUDENTS.Rows.Add(boundItem.Row.Item("id"))
            Else
                If SELECTED_STUDENTS.Rows.Contains(boundItem.Row.Item("id")) Then
                    Dim row As DataRow = Nothing
                    For Each item As DataRow In SELECTED_STUDENTS.Rows
                        If item.Item("id") = boundItem.Row.Item("id") Then
                            row = item
                            Exit For
                        End If
                    Next
                    SELECTED_STUDENTS.Rows.Remove(row)
                End If
            End If
        End If
    End Sub
#End Region

#Region "Faculty/Teacher Module"
    Private Sub DGBOOKS_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGBOOKS.CellContentClick
        If e.ColumnIndex = chckBoxBooks.Index Then
            DGBOOKS.EndEdit()
            Dim boundItem As DataRowView = TryCast(DGBOOKS.Rows(e.RowIndex).DataBoundItem, DataRowView)
            If CBool(DGBOOKS.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) AndAlso Not SELECTED_BOOKS.Rows.Contains(boundItem.Row.Item("id")) Then
                SELECTED_BOOKS.Rows.Add(boundItem.Row.ItemArray)
            Else
                If SELECTED_BOOKS.Rows.Contains(boundItem.Row.Item("id")) Then
                    Dim row As DataRow = Nothing
                    For Each item As DataRow In SELECTED_BOOKS.Rows
                        If item.Item("id") = boundItem.Row.Item("id") Then
                            row = item
                            Exit For
                        End If
                    Next
                    SELECTED_BOOKS.Rows.Remove(row)
                End If
            End If
        End If
    End Sub
    Private Sub DGFACULTY_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGFACULTY.CellContentClick
        If e.ColumnIndex = chckBoxFaculty.Index Then
            DGFACULTY.EndEdit()
            Dim boundItem As DataRowView = TryCast(DGFACULTY.Rows(e.RowIndex).DataBoundItem, DataRowView)
            If CBool(DGFACULTY.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) AndAlso Not SELECTED_FACULTY.Rows.Contains(boundItem.Row.Item("id")) Then
                SELECTED_FACULTY.Rows.Add(boundItem.Row.Item("id"))
            Else
                If SELECTED_FACULTY.Rows.Contains(boundItem.Row.Item("id")) Then
                    Dim row As DataRow = Nothing
                    For Each item As DataRow In SELECTED_FACULTY.Rows
                        If item.Item("id") = boundItem.Row.Item("id") Then
                            row = item
                            Exit For
                        End If
                    Next
                    SELECTED_FACULTY.Rows.Remove(row)
                End If
            End If
        End If
    End Sub
#End Region

    ' ALL FIXED
#Region "Select All Datagrid"
    Public Sub SelectionHelper(dg As Object, chckName As String)
        For Each item As DataGridViewRow In dg.Rows
            item.Cells(chckName).Value = True
        Next
        dg.EndEdit()
    End Sub
    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        If MainFormPanels.SelectedTab.Equals(MaintenanceTab) Then
            Dim tabs As TabPage() = {GenresTab, AuthorTab, PublishhersTab, DonatorsTab, SuppliersTab, ClassificationTab, LanguagesTab}
            Dim dgs As Object() = {DGGENRE, DGAUTHORS, DGPUBLISHER, DGDONATOR, DGSUPPLIER, DGCLASSIFICATIONS, DGLANGUAGE}
            Dim checkBoxes As String() = {NameOf(chckBoxGenre), NameOf(chckBoxAuthor), NameOf(chckBoxPublisher), NameOf(chckBoxDonator), NameOf(chckBoxSupplier), NameOf(chckBoxClassification), NameOf(chckBoxLanguage)}
            For i As Integer = 0 To tabs.Length - 1
                If MainFormPanels.SelectedTab.Equals(tabs(i)) Then
                    SelectionHelper(dgs(i), checkBoxes(i))
                End If
            Next
        Else
            Dim tabs As TabPage() = {DepartmentTab, YearLevelTab, SectionTab}
            Dim dgs As Object() = {DGDEPARTMENT, DGYEARLEVEL, DGSECTIONS}
            Dim checkBoxes As String() = {NameOf(chckBoxDepartment), NameOf(chckBoxYearLevel), NameOf(chckBoxSection)}
            For i As Integer = 0 To tabs.Length - 1
                If AccountsPanel.SelectedTab.Equals(tabs(i)) Then
                    SelectionHelper(dgs(i), checkBoxes(i))
                End If
            Next
        End If
    End Sub
#End Region

    ' ALL FIXED
#Region "Unselect All"
    Public Sub UnselectHelper(dg As Object, chckName As String)
        For Each item As DataGridViewRow In dg.Rows
            item.Cells(chckName).Value = False
        Next
        dg.EndEdit()
    End Sub
    Private Sub UnselectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnselectAllToolStripMenuItem.Click
        If MainFormPanels.SelectedTab.Equals(MaintenanceTab) Then
            Dim tabs As TabPage() = {GenresTab, AuthorTab, PublishhersTab, DonatorsTab, SuppliersTab, ClassificationTab, LanguagesTab}
            Dim dgs As Object() = {DGGENRE, DGAUTHORS, DGPUBLISHER, DGDONATOR, DGSUPPLIER, DGCLASSIFICATIONS, DGLANGUAGE}
            Dim checkBoxes As String() = {NameOf(chckBoxGenre), NameOf(chckBoxAuthor), NameOf(chckBoxPublisher), NameOf(chckBoxDonator), NameOf(chckBoxSupplier), NameOf(chckBoxClassification), NameOf(chckBoxLanguage)}
            For i As Integer = 0 To tabs.Length - 1
                If MainFormPanels.SelectedTab.Equals(tabs(i)) Then
                    UnselectHelper(dgs(i), checkBoxes(i))
                End If
            Next
        Else
            Dim tabs As TabPage() = {DepartmentTab, YearLevelTab, SectionTab}
            Dim dgs As Object() = {DGDEPARTMENT, DGYEARLEVEL, DGSECTIONS}
            Dim checkBoxes As String() = {NameOf(chckBoxDepartment), NameOf(chckBoxYearLevel), NameOf(chckBoxSection)}
            For i As Integer = 0 To tabs.Length - 1
                If AccountsPanel.SelectedTab.Equals(tabs(i)) Then
                    UnselectHelper(dgs(i), checkBoxes(i))
                End If
            Next
        End If
    End Sub
#End Region

    ' ALL FIXED
#Region "Remove Selected"
    Private Sub RemoveSelectedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        ' TODO PERFORM A CHECK BEFORE DELETING THE DATA
        If MainFormPanels.SelectedTab.Equals(MaintenanceTab) Then
            ControlsMap.Item(MaintenancePanels.SelectedTab.Tag).Delete(AddressOf DeleteHelper)
        Else
            ControlsMap.Item(AccountsPanel.SelectedTab.Tag).Delete(AddressOf DeleteHelper)
        End If
    End Sub
#End Region

    ' ALL FIXED
#Region "Import Module"
    Private Sub BTNIMPORTS_Click(sender As Object, e As EventArgs) Handles BTNIMPORTBOOKS.Click, BTNIMPORTFACULTY.Click, BTNIMPORTSTUDENTS.Click
        Select Case True
            Case sender.Equals(BTNIMPORTBOOKS)
                Dim dialog As New ImportDataDialog(New BookImport, NameOf(BookDialog))
                If Not MyApplication.DialogInstances.ContainsKey(NameOf(BookDialog)) Then
                    MyApplication.DialogInstances.Add(NameOf(BookDialog), dialog)
                    dialog.Show()
                Else
                    MyApplication.DialogInstances.Item(NameOf(BookDialog)).Show()
                End If
            Case sender.Equals(BTNIMPORTFACULTY)
                Dim dialog As New ImportDataDialog(New AccountImport(QueryTableType.FACULTY_QUERY_TABLE), NameOf(FacultyDialog))
                If Not MyApplication.DialogInstances.ContainsKey(NameOf(FacultyDialog)) Then
                    MyApplication.DialogInstances.Add(NameOf(FacultyDialog), dialog)
                    dialog.Show()
                Else
                    MyApplication.DialogInstances.Item(NameOf(FacultyDialog)).Show()
                End If
            Case sender.Equals(BTNIMPORTSTUDENTS)
                Dim dialog As New ImportDataDialog(New AccountImport(QueryTableType.STUDENT_QUERY_TABLE), NameOf(StudentDialog))
                If Not MyApplication.DialogInstances.ContainsKey(NameOf(StudentDialog)) Then
                    MyApplication.DialogInstances.Add(NameOf(StudentDialog), dialog)
                    dialog.Show()
                Else
                    MyApplication.DialogInstances.Item(NameOf(StudentDialog)).Show()
                End If
        End Select
    End Sub
#End Region

#Region "BookInventory Panels"
    ' Change this logic
    Private Sub BookInventoryPanels_SelectedIndexChanged(sender As Object, e As EventArgs) Handles BookInventoryPanels.SelectedIndexChanged
        Select Case True
            Case BookInventoryPanels.SelectedTab.Equals(CopiesTab)
                ControlsMap.Item(CopiesTab.Tag).Update()

                Dim dtDonator As DataTable = DBOperations.FetchAll(DONATOR)
                Dim newRow As DataRow = dtDonator.NewRow()
                newRow("id") = 0
                newRow("name") = "None"
                dtDonator.Rows.InsertAt(newRow, 0)

                Dim dtSupplier As DataTable = DBOperations.FetchAll(SUPPLIER)
                newRow = dtSupplier.NewRow()
                newRow("id") = 0
                newRow("name") = "None"
                dtSupplier.Rows.InsertAt(newRow, 0)

                TXTACCESSION.Text = GenerateAccession()

                CMBDONATORCOPIES.DataSource = dtDonator
                CMBSUPPLIERCOPIES.DataSource = dtSupplier
            Case BookInventoryPanels.SelectedTab.Equals(InventoryTab)
                ControlsMap.Item(InventoryTab.Tag).Update()
        End Select
    End Sub
#End Region

#Region "Student Menu Strip"
    Private Sub PromoteAsAssistLibrarianToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PromoteAsAssistLibrarianToolStripMenuItem.Click
        If SELECTED_STUDENTS.Rows.Count = 0 Then
            MessageBox.Show("Please select an item to continue.", "No Item Selected!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            If MessageBox.Show("Are you sure you want to add the selected item(s) as assistant librarian?", "Archive Selected?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) <> DialogResult.Yes Then
                Exit Sub
            End If

            Dim collection As New List(Of Dictionary(Of String, String))
            For Each item As DataRow In SELECTED_STUDENTS.Rows
                collection.Add(New Dictionary(Of String, String) From {{"@sid", item.Item("id")}, {"@fid", ""}})
            Next
            If AddAssistantLibrarian(collection) Then
                MessageBox.Show("Added Successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Action failed.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
        DGSTUDENT.EndEdit()
        SELECTED_STUDENTS = New SystemDataSets.DTStudentDataTable
    End Sub

    Private Sub SelectAllToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem2.Click
        For Each item As DataGridViewRow In DGSTUDENT.Rows
            item.Cells(NameOf(chckBoxStudent)).Value = True
            Dim boundItem As DataRowView = TryCast(item.DataBoundItem, DataRowView)
            If Not SELECTED_STUDENTS.Rows.Contains(boundItem.Row.Item("id")) Then
                SELECTED_STUDENTS.Rows.Add(boundItem.Row.Item("id"))
            End If
        Next
        DGBOOKS.EndEdit()
    End Sub

    Private Sub UnselectAllToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles UnselectAllToolStripMenuItem2.Click
        For Each item As DataGridViewRow In DGSTUDENT.Rows
            item.Cells(NameOf(chckBoxStudent)).Value = False
        Next
        SELECTED_STUDENTS = New SystemDataSets.DTStudentDataTable
        DGSTUDENT.EndEdit()
    End Sub

    Private Sub ArchiveSelectedToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ArchiveSelectedToolStripMenuItem1.Click
        If SELECTED_STUDENTS.Rows.Count = 0 Then
            MessageBox.Show("Please select an item to continue.", "No Item Selected!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            If MessageBox.Show("Are you sure you want to archive the selected item(s)?", "Archive Selected?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) <> DialogResult.Yes Then
                Exit Sub
            End If

            Dim collection As New List(Of Dictionary(Of String, String))
            For Each item As DataRow In SELECTED_STUDENTS.Rows
                collection.Add(New Dictionary(Of String, String) From {{"@id", item.Item("id")}})
            Next
            'If ExecTransactionNonQuery(ARCHIVE_STUDENT_QUERY, collection) Then
            '    MessageBox.Show("Archived Successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Else
            '    MessageBox.Show("Archiving failed.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'End If
        End If
        DGSTUDENT.EndEdit()
        SELECTED_STUDENTS = New SystemDataSets.DTStudentDataTable
    End Sub

    Private Sub UnarchiveSelectedToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles UnarchiveSelectedToolStripMenuItem1.Click
        If SELECTED_STUDENTS.Rows.Count = 0 Then
            MessageBox.Show("Please select an item to continue.", "No Item Selected!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else

            Dim collection As New List(Of Dictionary(Of String, String))
            For Each item As DataRow In SELECTED_STUDENTS.Rows
                collection.Add(New Dictionary(Of String, String) From {{"@id", item.Item("id")}})
            Next
            'If ExecTransactionNonQuery(UNARCHIVE_STUDENT_QUERY, collection) Then
            '    MessageBox.Show("Unarchived Successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Else
            '    MessageBox.Show("Unarchive failed.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'End If
        End If
        'CMBSTUDENTFILTER_SelectedIndexChanged(CMBSTUDENTFILTER, Nothing)
        SELECTED_STUDENTS = New SystemDataSets.DTStudentDataTable
    End Sub

    Private Sub DeleteSelectedToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DeleteSelectedToolStripMenuItem1.Click
        If SELECTED_STUDENTS.Rows.Count = 0 Then
            MessageBox.Show("Please select an item to continue.", "No Item Selected!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If MessageBox.Show("Deleting these items will also delete the existing book copies." & vbLf & "Are you sure you want to delete the selected item(s)?", "Delete Selected?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        Dim collection As New List(Of Dictionary(Of String, String))

        For Each item As DataRow In SELECTED_STUDENTS.Rows
            collection.Add(New Dictionary(Of String, String) From {{"@id", item.Item("id")}})
        Next

        'If BaseMaintenance.Delete(QueryTableType.STUDENT_QUERY_TABLE, collection) Then
        '    MessageBox.Show("Deleted Successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Else
        '    MessageBox.Show("Cannot delete the selected items. Some items are being used to other resources. Please remove the them before deleting.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If
        'CMBSTUDENTFILTER_SelectedIndexChanged(CMBSTUDENTFILTER, Nothing)
        SELECTED_STUDENTS = New SystemDataSets.DTStudentDataTable
    End Sub
#End Region

#Region "Faculty Menu Strip"

    Private Sub SelectAllToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem3.Click
        For Each item As DataGridViewRow In DGFACULTY.Rows
            item.Cells(NameOf(chckBoxFaculty)).Value = True
            Dim boundItem As DataRowView = TryCast(item.DataBoundItem, DataRowView)
            If Not SELECTED_FACULTY.Rows.Contains(boundItem.Row.Item("id")) Then
                SELECTED_FACULTY.Rows.Add(boundItem.Row.Item("id"))
            End If
        Next
        DGBOOKS.EndEdit()
    End Sub

    Private Sub UnselectAllToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles UnselectAllToolStripMenuItem3.Click
        For Each item As DataGridViewRow In DGFACULTY.Rows
            item.Cells(NameOf(chckBoxFaculty)).Value = False
        Next
        SELECTED_FACULTY = New SystemDataSets.DTFacultyDataTable
        DGFACULTY.EndEdit()
    End Sub

    Private Sub DeleteSelectedToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles DeleteSelectedToolStripMenuItem2.Click
        If SELECTED_FACULTY.Rows.Count = 0 Then
            MessageBox.Show("Please select an item to continue.", "No Item Selected!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If MessageBox.Show("Deleting these items will also delete the existing book copies." & vbLf & "Are you sure you want to delete the selected item(s)?", "Delete Selected?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        Dim collection As New List(Of Dictionary(Of String, String))

        For Each item As DataRow In SELECTED_FACULTY.Rows
            collection.Add(New Dictionary(Of String, String) From {{"@id", item.Item("id")}})
        Next

        'If BaseMaintenance.Delete(QueryTableType.FACULTY_QUERY_TABLE, collection) Then
        '    MessageBox.Show("Deleted Successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Else
        '    MessageBox.Show("Cannot delete the selected items. Some items are being used to other resources. Please remove the them before deleting.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If
        SELECTED_FACULTY = New SystemDataSets.DTFacultyDataTable
    End Sub

    Private Sub ArchiveSelectedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArchiveSelectedToolStripMenuItem.Click
        If SELECTED_FACULTY.Rows.Count = 0 Then
            MessageBox.Show("Please select an item to continue.", "No Item Selected!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            If MessageBox.Show("Are you sure you want to archive the selected item(s)?", "Archive Selected?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) <> DialogResult.Yes Then
                Exit Sub
            End If

            Dim collection As New List(Of Dictionary(Of String, String))
            For Each item As DataRow In SELECTED_FACULTY.Rows
                collection.Add(New Dictionary(Of String, String) From {{"@id", item.Item("id")}})
            Next
            'If ExecTransactionNonQuery(ARCHIVE_FACULTY_QUERY, collection) Then
            '    MessageBox.Show("Archived Successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Else
            '    MessageBox.Show("Archiving failed.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'End If
        End If
        DGFACULTY.EndEdit()
        SELECTED_FACULTY = New SystemDataSets.DTFacultyDataTable
    End Sub

    Private Sub UnarchiveSelectedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnarchiveSelectedToolStripMenuItem.Click
        If SELECTED_FACULTY.Rows.Count = 0 Then
            MessageBox.Show("Please select an item to continue.", "No Item Selected!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else

            Dim collection As New List(Of Dictionary(Of String, String))
            For Each item As DataRow In SELECTED_FACULTY.Rows
                collection.Add(New Dictionary(Of String, String) From {{"@id", item.Item("id")}})
            Next
            'If ExecTransactionNonQuery(UNARCHIVE_FACULTY_QUERY, collection) Then
            '    MessageBox.Show("Unarchived Successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Else
            '    MessageBox.Show("Unarchive failed.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'End If
        End If
        SELECTED_FACULTY = New SystemDataSets.DTFacultyDataTable
    End Sub

    Private Sub AssistLibrarianToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AssistLibrarianToolStripMenuItem.Click
        If SELECTED_FACULTY.Rows.Count = 0 Then
            MessageBox.Show("Please select an item to continue.", "No Item Selected!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            If MessageBox.Show("Are you sure you want to add the selected item(s) as assistant librarian?", "Archive Selected?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) <> DialogResult.Yes Then
                Exit Sub
            End If

            Dim collection As New List(Of Dictionary(Of String, String))
            For Each item As DataRow In SELECTED_FACULTY.Rows
                collection.Add(New Dictionary(Of String, String) From {{"@sid", ""}, {"@fid", item.Item("id")}})
            Next
            If AddAssistantLibrarian(collection) Then
                MessageBox.Show("Added Successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Action failed.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
        DGFACULTY.EndEdit()
        SELECTED_FACULTY = New SystemDataSets.DTFacultyDataTable
    End Sub
#End Region

#Region "Book Copies Module"
    'Private Sub ArchiveSelectedToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ArchiveSelectedToolStripMenuItem2.Click
    '    If SELECTED_BOOKS.Rows.Count = 0 Then
    '        MessageBox.Show("Please select an item to continue.", "No Item Selected!", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        Exit Sub
    '    Else
    '        If MessageBox.Show("Archiving the selected item(s) will make the copies unavailable to inventory." & vbLf & "Are you sure you want to archive the selected item(s)?", "Archive Selected?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) <> DialogResult.Yes Then
    '            Exit Sub
    '        End If

    '        Dim collection As New List(Of Dictionary(Of String, String))
    '        For Each item As DataRow In SELECTED_BOOKS.Rows
    '            collection.Add(New Dictionary(Of String, String) From {{"@id", item.Item("id")}})
    '        Next
    '        If ExecTransactionNonQuery(ARCHIVE_BOOKS_QUERY, collection) Then
    '            MessageBox.Show("Archived Successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        Else
    '            MessageBox.Show("Archiving failed.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        End If
    '    End If
    '    DGBOOKS.EndEdit()
    '    'CMBBOOKFILTER_SelectedIndexChanged(CMBBOOKFILTER, Nothing)
    '    SELECTED_BOOKS = New SystemDataSets.DTBookDataTable
    'End Sub

    Private Sub UnarchiveSelectedToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles UnarchiveSelectedToolStripMenuItem2.Click
        If SELECTED_BOOKS.Rows.Count = 0 Then
            MessageBox.Show("Please select an item to continue.", "No Item Selected!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else

            Dim collection As New List(Of Dictionary(Of String, String))
            For Each item As DataRow In SELECTED_BOOKS.Rows
                collection.Add(New Dictionary(Of String, String) From {{"@id", item.Item("id")}})
            Next
            'If ExecTransactionNonQuery(UNARCHIVE_BOOKS_QUERY, collection) Then
            '    MessageBox.Show("Unarchived Successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Else
            '    MessageBox.Show("Unarchive failed.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'End If
        End If
        DGBOOKS.EndEdit()
        SELECTED_BOOKS = New SystemDataSets.DTBookDataTable
    End Sub

    Private Sub DeleteSelectedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteSelectedToolStripMenuItem.Click

        If SELECTED_BOOKS.Rows.Count = 0 Then
            MessageBox.Show("Please select an item to continue.", "No Item Selected!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If MessageBox.Show("Deleting these items will also delete the existing book copies." & vbLf & "Are you sure you want to delete the selected item(s)?", "Delete Selected?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        Dim collection As New List(Of Dictionary(Of String, String))

        For Each item As DataRow In SELECTED_BOOKS.Rows
            collection.Add(New Dictionary(Of String, String) From {{"@id", item.Item("id")}})
        Next

        If DBOperations.Delete(BOOK, collection) Then
            MessageBox.Show("Deleted Successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Cannot delete the selected items. Some items are being used to other resources. Please remove the them before deleting.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        SELECTED_BOOKS = New SystemDataSets.DTBookDataTable
    End Sub



    Private Sub SelectAllToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem1.Click
        For Each item As DataGridViewRow In DGBOOKS.Rows
            item.Cells(NameOf(chckBoxBooks)).Value = True
            Dim boundItem As DataRowView = TryCast(item.DataBoundItem, DataRowView)
            If Not SELECTED_BOOKS.Rows.Contains(boundItem.Row.Item("id")) Then
                SELECTED_BOOKS.Rows.Add(boundItem.Row.ItemArray)
            End If
        Next
        DGBOOKS.EndEdit()
    End Sub

    Private Sub UnselectAllToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles UnselectAllToolStripMenuItem1.Click
        For Each item As DataGridViewRow In DGGENRE.Rows
            item.Cells(NameOf(chckBoxGenre)).Value = False
        Next
        SELECTED_BOOKS = New SystemDataSets.DTBookDataTable
        DGBOOKS.EndEdit()
    End Sub

    Private Sub BTNADDCOPIES_Click(sender As Object, e As EventArgs) Handles BTNADDCOPIES.Click
        ' TODO ADD SANITIZE THIS
        Dim price_copy As String = If(String.IsNullOrEmpty(TXTPRICECOPIES.Text), "0", TXTPRICECOPIES.Text)
        Dim hasErrors As Boolean = False
        If Not Validator.MatchPattern(TXTQUANTITY.Text, "^\d+$") Then
            errProvider.SetError(TXTQUANTITY, "Invalid number format.")
            hasErrors = True
        End If

        If Not Validator.MatchPattern(price_copy, "^\d+\.?\d*$") Then
            errProvider.SetError(TXTPRICECOPIES, "Invalid number format.")
            hasErrors = True
        End If

        If Not hasErrors AndAlso CInt(TXTQUANTITY.Text) < 1 Then
            errProvider.SetError(TXTQUANTITY, "Quantity should be greater than 0.")
            hasErrors = True
        End If

        If hasErrors Then
            Exit Sub
        End If


        If MessageBox.Show($"Are you sure you want to add {CInt(TXTQUANTITY.Text)} copies of {TXTISBNCOPIES.Text}?", "Add Copies?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
            AddCopies(CInt(TXTQUANTITY.Text), TXTISBNCOPIES.Text, If(String.IsNullOrEmpty(TXTPRICECOPIES.Text), 0, CInt(price_copy)), CMBDONATORCOPIES.SelectedValue, CMBSUPPLIERCOPIES.SelectedValue)
        End If
        TXTQUANTITY.Text = String.Empty
        TXTISBNCOPIES.Text = String.Empty
        'CMBDONATORCOPIES.Text = "None"
        'CMBSUPPLIERCOPIES.Text = "None"
    End Sub

    Private Sub CHCKBOXDONATED_CheckedChanged(sender As Object, e As EventArgs) Handles CHCKBOXDONATED.CheckedChanged
        If CHCKBOXDONATED.Checked Then
            CMBSUPPLIERCOPIES.Enabled = False
            CMBDONATORCOPIES.Enabled = True
        Else
            CMBDONATORCOPIES.Enabled = False
            CMBSUPPLIERCOPIES.Enabled = True
        End If
    End Sub

    Private Sub BTNADDTRANSACTION_Click(sender As Object, e As EventArgs) Handles BTNADDTRANSACTION.Click
        Dim dialog As New BorrowDialog()
        If Not MyApplication.DialogInstances.ContainsKey(NameOf(BorrowDialog)) Then
            MyApplication.DialogInstances.Add(NameOf(BorrowDialog), dialog)
            dialog.Show()
        Else
            MyApplication.DialogInstances.Item(NameOf(BorrowDialog)).Show()
        End If
    End Sub
#End Region

#Region "Helper Functions"
    Private Sub DeleteHelper(params As List(Of Dictionary(Of String, String)), qtype As QueryType)
        If MessageBox.Show("Are you sure you want to delete the selected item(s)?", "Delete Selected Items?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        If DBOperations.Delete(qtype, params) Then
            MessageBox.Show("Deleted Successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Cannot delete the selected items. Some items are being used to other resources. Please remove the them before deleting.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
#End Region

    '#Region "Refresh Buttons"
    '    Private Sub BTNREFRESH_Click(sender As Object, e As EventArgs) Handles BTNGENREREFRESH.Click, BTNADMINREFRESH.Click, BTNAUTHORREFRESH.Click, BTNBOOKREFRESH.Click,
    '            BTNBOOKREPORTREFRESH.Click, BTNBORROWEDREPORTREFRESH.Click, BTNBORROWERREPORTREFRESH.Click, BTNCLASSIFICATIONREFRESH.Click, BTNDEPARTMENTREFRESH.Click,
    '            BTNDONATORREFRESH.Click, BTNEXPENDITUREREPORTREFRESH.Click, BTNFACULTYREFRESH.Click, BTNFINESREPORTREFRESH.Click, BTNLANGUAGEREFRESH.Click, BTNPUBLISHERREFRESH.Click,
    '            BTNSECTIONREFRESH.Click, BTNSTUDENTREFRESH.Click, BTNSUPPLIERREFRESH.Click, BTNTRANSACTIONREFRESH.Click, BTNYEARLEVELREFRESH.Click
    '        ' TODO ADD ALL THE NECESSARY REFRESH
    '        AccountsPanel_SelectedIndexChanged(AccountsPanel, Nothing)
    '        'MaintenancePanels_SelectedIndexChanged(MaintenancePanels, Nothing)
    '        BookInventoryPanels_SelectedIndexChanged(BookInventoryPanels, Nothing)
    '    End Sub
    '#End Region

#Region "Settings Panel"
    Private Sub BTNSAVEGENSET_Click(sender As Object, e As EventArgs) Handles BTNSAVEGENSET.Click
        Dim params As New Dictionary(Of String, String) From {
            {"@gp", If(CHCKSETGLOBALP.Checked, 1, 0)},
            {"@en", If(CHCKSETNOTIF.Checked, 1, 0)},
            {"@sp", TXTSETFPENALTY.Text},
            {"@fp", TXTSETFPENALTY.Text},
            {"@sd", TXTSETSDAYS.Text},
            {"@fd", TXTSETFDAYS.Text},
            {"@sc", TXTSETSCOUNT.Text},
            {"@fc", TXTSETFCOUNT.Text}
        }
        If DBOperations.Update(SETTINGS, params) > 0 Then
            MessageBox.Show("General settings has been updated.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Failed to update General settings.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub BTNEMAILSET_Click(sender As Object, e As EventArgs) Handles BTNEMAILSET.Click
        Dim params As New Dictionary(Of String, String) From {
            {"@email", TXTEMAILSETTINGS.Text},
            {"@pass", TXTEMAILPASSWORDSETTINGS.Text},
            {"@overdue", TXTSETOVERDUE.Text},
            {"@borrow", TXTSETBORROW.Text},
            {"@before", TXTSETBEFORE.Text},
            {"@return", TXTSETRETURN.Text}
        }

        If DBOperations.Update(EMAILSETTINGS, params) > 0 Then
            MessageBox.Show("Email settings has been updated.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Failed to update Email settings.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub BTNSAVEPATH_Click(sender As Object, e As EventArgs) Handles BTNSAVEPATH.Click
        Using dialog As New FolderBrowserDialog()
            If dialog.ShowDialog() = DialogResult.OK Then
                My.Settings.backup_folder = dialog.SelectedPath
                TXTSETPATH.Text = dialog.SelectedPath
            End If
        End Using
    End Sub

    Private Sub BTNSETSERVER_Click(sender As Object, e As EventArgs) Handles BTNSETSERVER.Click
        MsgBox(My.Settings.server_password)
        If TestConnection(TXTSETIP.Text, TXTSETUSERNAME.Text, TXTSETPORT.Text, TXTSETSERPASS.Text) Then
            My.Settings.server_name = TXTSETIP.Text
            My.Settings.server_username = TXTSETUSERNAME.Text
            My.Settings.server_password = TXTSETSERPASS.Text
            My.Settings.server_port = TXTSETPORT.Text
            My.Settings.Save()
            MessageBox.Show("Server Settings has been updated.", "Successs!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Faild to update server settings.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub SettingsPanels_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SettingsPanels.SelectedIndexChanged
        Dim dt As DataTable = DBOperations.FetchAll(SETTINGS)

        If dt.Rows.Count = 0 Then
            Return
        End If
        With dt.Rows.Item(0)
            Select Case True
                Case SettingsPanels.SelectedTab.Equals(GeneralSettingsTab)
                    CHCKSETNOTIF.Checked = If(.Item("enable_notification") > 0, True, False)
                    CHCKSETGLOBALP.Checked = If(.Item("gpenalty") > 0, True, False)
                    TXTSETSPENALTY.Text = .Item("spenalty")
                    TXTSETFPENALTY.Text = .Item("fpenalty")
                    TXTSETSDAYS.Text = .Item("sdays")
                    TXTSETFDAYS.Text = .Item("fdays")
                    TXTSETSCOUNT.Text = .Item("s_count")
                    TXTSETFCOUNT.Text = .Item("f_count")
                Case SettingsPanels.SelectedTab.Equals(EmailSettingsTab)
                    TXTEMAILPASSWORDSETTINGS.Text = .Item("e_pass")
                    TXTSETRETURN.Text = .Item("return_message")
                    TXTSETOVERDUE.Text = .Item("overdue_message")
                    TXTSETBORROW.Text = .Item("borrow_message")
                    TXTEMAILSETTINGS.Text = .Item("app_email")
                    TXTSETBEFORE.Text = .Item("boverdue_message")
                Case SettingsPanels.SelectedTab.Equals(ServerSettingsTab)
                    TXTSETIP.Text = My.Settings.server_name
                    TXTSETUSERNAME.Text = My.Settings.server_username
                    TXTSETSERPASS.Text = My.Settings.server_password
                    TXTSETPORT.Text = My.Settings.server_port

            End Select
        End With
    End Sub
#End Region

#Region "Transaction Module"
    Private Sub DGTRANSACTION_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGTRANSACTION.CellClick
        If DGTRANSACTION.SelectedRows.Count > 0 AndAlso e.RowIndex <> -1 Then
            Dim boundItem As DataRowView = TryCast(DGTRANSACTION.SelectedRows(0).DataBoundItem, DataRowView)
            Using dialog As New ReturnDialog(boundItem)
                dialog.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub BTNTRANSACTIONSEARCH_Click(sender As Object, e As EventArgs) Handles BTNTRANSACTIONSEARCH.Click
        Dim type As TRANSACTIONSTATE
        If CMBTRANSACTIONFILTER.Text.ToLower() = NameOf(TRANSACTIONSTATE.ACTIVE).ToLower() Then
            type = TRANSACTIONSTATE.ACTIVE
        ElseIf CMBTRANSACTIONFILTER.Text.ToLower() = NameOf(TRANSACTIONSTATE.OVERDUE).ToLower() Then
            type = TRANSACTIONSTATE.OVERDUE
        Else
            type = TRANSACTIONSTATE.RETURNED
        End If
        ControlsMap.Item(sender.Tag).Update(type, DTTRANSACTIONS.Value, DTTRANSACTIONE.Value)
    End Sub
#End Region

#Region "Book Inventory Module"
    Private Sub DGINVENTORY_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGINVENTORY.CellClick
        If e.ColumnIndex <> chckBoxInventory.Index AndAlso e.RowIndex <> -1 Then
            Dim boundItem As DataRowView = TryCast(DGINVENTORY.Rows(e.RowIndex).DataBoundItem, DataRowView)
            LBLINVACCESSION.Text = boundItem.Item("accession_no")
            LBLINVDONATOR.Text = If(IsDBNull(boundItem.Item("donator_name")), "None", boundItem.Item("donator_name"))
            LBLINVISBN.Text = boundItem.Item("isbn")
            LBLINVSUPPLIER.Text = If(IsDBNull(boundItem.Item("supplier_name")), "None", boundItem.Item("supplier_name"))
            TXTINVPRICE.Text = If(IsDBNull(boundItem.Item("price")), Nothing, boundItem.Item("price"))
        End If
    End Sub
#End Region
End Class