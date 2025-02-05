Public Class QueryTable
    Property ADD_QUERY As String
    Property DELETE_QUERY As String
    Property UPDATE_QUERY As String
    Property EXISTS_UPDATE_QUERY As String
    Property EXISTS_ADD_QUERY As String
    Property SEARCH_COUNT_QUERY As String
    Property SEARCH_RESULT_QUERY As String
    Property FETCH_ALL_QUERY As String
    Property ARCHIVE_SEARCH_COUNT_QUERY As String
    Property ARCHIVE_SEARCH_RESULT_QUERY As String
    Property ARCHIVE_QUERY As String
    Property UNARCHIVE_QUERY As String
    Property ADVANCE_SEARCH_COUNT_QUERY As String
    Property ADVANCE_SEARCH_RESULT_QUERY As String
    Property LOG_QUERY As String = "INSERT INTO tbllogs (name, action, `type`) VALUES (@name, @action, @type);"
End Class
