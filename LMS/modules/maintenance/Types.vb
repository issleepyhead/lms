
''' <summary>
''' STATUS TYPE is for library resources that can be archived.
''' ACTIVE = 0
''' INACTIVE = 1
''' </summary>
Public Enum STATUSTYPE
    ACTIVE = 0
    INACTIVE = 1
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
End Enum

''' <summary>
''' Condition type of a book
''' GOOD = 0
''' DAMAGED = 1
''' LOST = 2
''' </summary>
Public Enum BOOKCONDITIONTYPE
    GOOD = 0
    DAMAGED = 1
    LOST = 2
End Enum

Public Enum ROLETYPE
    SUPERADMIN = 0
    ASSIST_LIB = 1
End Enum

Public Enum TRANSACTIONSTATE
    ACTIVE = 0
    OVERDUE = 1
    RETURNED = 2
End Enum
