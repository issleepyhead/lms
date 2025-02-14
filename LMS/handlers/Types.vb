''' <summary>
''' QueryType is an identifier for type of collection of query.
''' </summary>
Public Enum QueryType
    <SheetNameMapping("Genres")>
    <ColumnMapping("Name", 45, AddressOf Example)>
    <ColumnMapping("Description", 100)>
    GENRE

    <SheetNameMapping("Publishers")>
    <ColumnMapping("Name", 50)>
    PUBLISHER

    <SheetNameMapping("Authors")>
    <ColumnMapping("First Name", 50)>
    <ColumnMapping("Last Name", 50)>
    <ColumnMapping("Gender", 6)>
    AUTHOR

    <SheetNameMapping("Classifications")>
    <ColumnMapping("Classification", 50)>
    <ColumnMapping("Dewey Decimal", 12)>
    CLASSIFICATION

    <SheetNameMapping("Languages")>
    <ColumnMapping("Language", 50)>
    <ColumnMapping("Code", 50)>
    LANGUAGES

    <SheetNameMapping("Books")>
    <ColumnMapping("Title", 50)>
    <ColumnMapping("ISBN", 50)>
    <ColumnMapping("Genre", 50)>
    <ColumnMapping("Publisher", 50)>
    <ColumnMapping("Language", 50)>
    <ColumnMapping("Author", 50)>
    <ColumnMapping("Classification", 50)>
    <ColumnMapping("Cover", 50)>
    <ColumnMapping("Reserve", 50)>
    BOOK

    DONATOR
    SUPPLIER

    TRANSACTION

    YEARLEVEL
    SECTION
    STUDENT
    FACULTY
    DEPARTMENT
    ADMIN

    BOOKCOPIES
    BOOKINVENTORY
    BOOKLOSTDAMAGE

    BOOKREPORT
    EXPENDITUREREPORT
    FINESREPORT
    BORROWERREPORT
    CLSSIFICATIONREPORT

    SETTINGS
    EMAILSETTINGS

    LOGS
End Enum

Public Enum LOGTYPE
    ADD
    UPDATE
    DELETE
    ARCHIVE
    LOGGEDIN
    LOGGEDOUT
End Enum

''' <summary>
''' TRANSACTIONSTATE is for state of transactions in the system.
''' 0 for transactions that are already returned,
''' 1 for transactions that are still active,
''' 2 for transactions that are overdued
''' </summary>
Public Enum TRANSACTIONSTATE
    RETURNED = 0
    ACTIVE = 1
    OVERDUE = 2
End Enum

''' <summary>
''' STATUSTYPE is for library resources that can be archived.
''' 0 for active resources in the system
''' 1 for inactive or archived resources in the system
''' </summary>
Public Enum STATUSTYPE
    ACTIVE = 1
    INACTIVE = 0
End Enum

''' <summary>
''' BOOKSTATE determines if the copy of a book if available for borrowing or not.
''' BORROWED = 0
''' AVAILABLE = 1
''' </summary>
Public Enum BOOKSTATE
    BORROWED = 0
    AVAILABLE = 1
    ARCHIVED = 2
    LOST = 3
End Enum

''' <summary>
''' BOOKCONDITIONTYPE is an identifier of book's condition.
''' 0 is for good book condition, it means the book is not damaged.
''' 1 is for damaged books, books that lost its pages or anything
''' 2 is for lost books, gone forever :(
''' </summary>
Public Enum BOOKCONDITIONTYPE
    GOOD = 0
    DAMAGED = 1
    LOST = 2
End Enum

''' <summary>
''' Role Type
''' 0 for super admin account
''' 1 for assistant librarian accounts
''' </summary>
Public Enum ROLETYPE
    SUPERADMIN = 0
    ASSISTANT = 1
End Enum
