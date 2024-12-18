Public Enum QueryTableType

    <SheetNameMapping("Genres")>
    <ColumnMapping({"Name", "Description"})>
    GENRE_QUERY_TABLE

    <SheetNameMapping("Publishers")>
    <ColumnMapping({"Publisher Name"})>
    PUBLISHER_QUERY_TABLE

    <SheetNameMapping("Authors")>
    <ColumnMapping({"First Name", "Last Name", "Gender"})>
    AUTHOR_QUERY_TABLE

    <SheetNameMapping("Classifications")>
    <ColumnMapping({"Dewey Decimal", "Classification"})>
    CLASSIFICATION_QUERY_TABLE

    <SheetNameMapping("Books")>
    <ColumnMapping({"Title", "ISBN", "Genre", "Publisher", "Language", "Author", "Classification", "Book Cover", "Reserve Copy"})>
    BOOK_QUERY_TABLE

    <SheetNameMapping("Languages")>
    <ColumnMapping({"Language", "Code"})>
    LANGUAGES_QUERY_TABLE

    DONATOR_QUERY_TABLE
    SUPPLIER_QUERY_TABLE
    YEARLEVEL_QUERY_TABLE
    SECTION_QUERY_TABLE
    LANGUAGE_QUERY_TABLE
    STUDENT_QUERY_TABLE
    FACULTY_QUERY_TABLE
    ADMIN_QUERY_TABLE
    DEPARTMENT_QUERY_TABLE


End Enum