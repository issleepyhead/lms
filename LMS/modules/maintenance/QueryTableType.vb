Public Enum QueryTableType

    <SheetNameMapping("Genres")>
    <ColumnMapping({"Names", "Description"}, {"@name", "@desc"})>
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