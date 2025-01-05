Public Enum QueryTableType
#Region "Book Enums"
    <SheetNameMapping("Genres")>
    <ColumnMapping({"Name", "Description"}, {"@name", "@desc"})>
    GENRE_QUERY_TABLE

    <SheetNameMapping("Publishers")>
    <ColumnMapping({"Publisher Name"}, {"@name"})>
    PUBLISHER_QUERY_TABLE

    <SheetNameMapping("Authors")>
    <ColumnMapping({"First Name", "Last Name", "Gender"}, {"@first_name", "@last_name", "@gender"})>
    AUTHOR_QUERY_TABLE

    <SheetNameMapping("Classifications")>
    <ColumnMapping({"Dewey Decimal", "Classification"}, {"@dewey_no", "@classification"})>
    CLASSIFICATION_QUERY_TABLE

    <SheetNameMapping("Books")>
    <ColumnMapping(
        {"Title",
            "ISBN",
            "Genre",
            "Publisher",
            "Language",
            "Author",
            "Classification",
            "Book Cover",
            "Reserve Copy"},
        {"@title",
            "@isbn",
            "@gid",
            "@pid",
            "@lid",
            "@aid",
            "@cid",
            "@cover",
            "@rcopy"
        })>
    BOOK_QUERY_TABLE

    <SheetNameMapping("Languages")>
    <ColumnMapping({"Language", "Code"}, {"@language", "@code"})>
    LANGUAGES_QUERY_TABLE
#End Region

#Region "User Enums"
    <SheetNameMapping("Year Levels")>
    <ColumnMapping({"Year Level", "Department"}, {"@name", "@did"})>
    YEARLEVEL_QUERY_TABLE

    <SheetNameMapping("Sections")>
    <ColumnMapping({"Section Name", "Year Level"}, {"@name", "@yid"})>
    SECTION_QUERY_TABLE

    <SheetNameMapping("Students")>
    <ColumnMapping({"Student Number", "LRN", "Full Name", "Email", "Section"}, {"@name", "@desc"})>
    STUDENT_QUERY_TABLE

    <SheetNameMapping("Facultly")>
    <ColumnMapping({"Name", "Description"}, {"@name", "@desc"})>
    FACULTY_QUERY_TABLE

    <SheetNameMapping("Departments")>
    <ColumnMapping({"Department Name"}, {"@name"})>
    DEPARTMENT_QUERY_TABLE
#End Region

    DONATOR_QUERY_TABLE
    SUPPLIER_QUERY_TABLE
    BOOKCOPIES_QUERY_TABLE
    BOOKINVENTORY_QUERY_TABLE


    ADMIN_QUERY_TABLE

    ARCHIVEBOOKS_QUERY_TABLE
    ARCHIVECOPIES_QUERY_TABLE
    DEACTIVATESTUDENT_QUERY_TABLE
    DEACTIVATEFACULTY_QUERY_TABLE
End Enum