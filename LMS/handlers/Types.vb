''' <summary>
''' QueryType is an identifier for type of collection of query.
''' </summary>
Public Enum QueryType
    <SheetNameMapping("Genres")>
    <ColumnMapping("Name", 45, VALIDATORTYPE.NAME)>
    <ColumnMapping("Description", 100, VALIDATORTYPE.ALL)>
    GENRE

    <SheetNameMapping("Publishers")>
    <ColumnMapping("Name", 50, VALIDATORTYPE.OTHERNAME)>
    PUBLISHER

    <SheetNameMapping("Authors")>
    <ColumnMapping("First Name", 50, VALIDATORTYPE.NAME)>
    <ColumnMapping("Last Name", 50, VALIDATORTYPE.NAME)>
    <ColumnMapping("Gender", 6, VALIDATORTYPE.GENDER)>
    AUTHOR

    <SheetNameMapping("Classifications")>
    <ColumnMapping("Classification", 50, VALIDATORTYPE.ALL)>
    <ColumnMapping("Dewey Decimal", 12, VALIDATORTYPE.DECIMALVALUE)>
    CLASSIFICATION

    <SheetNameMapping("Languages")>
    <ColumnMapping("Language", 50, VALIDATORTYPE.ALL)>
    <ColumnMapping("Code", 50, VALIDATORTYPE.INTEGERVALUE)>
    LANGUAGES

    <SheetNameMapping("Books")>
    <ColumnMapping("Title", 50, VALIDATORTYPE.OTHERNAME)>
    <ColumnMapping("ISBN", 50, VALIDATORTYPE.INTEGERVALUE)>
    <ColumnMapping("Genre", 50, VALIDATORTYPE.OTHERNAME)>
    <ColumnMapping("Publisher", 50, VALIDATORTYPE.OTHERNAME)>
    <ColumnMapping("Language", 50, VALIDATORTYPE.OTHERNAME)>
    <ColumnMapping("Author", 50, VALIDATORTYPE.NAME)>
    <ColumnMapping("Classification", 50, VALIDATORTYPE.OTHERNAME)>
    <ColumnMapping("Cover", 50, VALIDATORTYPE.NAME)>
    <ColumnMapping("Reserve Copy", 50, VALIDATORTYPE.INTEGERVALUE)>
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

Public Enum VALIDATORTYPE
    EMAIL
    PHONE
    NAME
    ALL
    OTHERNAME
    GENDER
    DECIMALVALUE
    INTEGERVALUE
End Enum
