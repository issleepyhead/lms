﻿Imports LMS.QueryType

Module RegistryCollectionModule
    Private ReadOnly RegistryValidator As New Dictionary(Of VALIDATORTYPE, Func(Of String, Boolean)) From {
        {VALIDATORTYPE.EMAIL, AddressOf EmailValidator},
        {VALIDATORTYPE.NAME, AddressOf NameValidator},
        {VALIDATORTYPE.PHONE, AddressOf PhoneValidator},
        {VALIDATORTYPE.ALL, AddressOf AllValidator},
        {VALIDATORTYPE.OTHERNAME, AddressOf OtherNameValidator},
        {VALIDATORTYPE.GENDER, AddressOf GenderValidator},
        {VALIDATORTYPE.DECIMALVALUE, AddressOf DecimalValidator},
        {VALIDATORTYPE.INTEGERVALUE, AddressOf IntegerValidator}
    }

    Public Function GetValidatorType(type As VALIDATORTYPE) As Func(Of String, Boolean)
        Return RegistryValidator.Item(type)
    End Function

    Private ReadOnly RegistryImportQuery As New Dictionary(Of QueryType, ImportQueryTable) From {
        {GENRE, New ImportQueryTable With {
            .EXISTS_QUERY = "SELECT COUNT(*) FROM tblgenres WHERE LOWER(name) = LOWER(@data)",
            .SELECT_ID_QUERY = "SELECT id FROM tblgenres WHERE LOWER(name) = LOWER(@data) LIMIT 1"}},
        {AUTHOR, New ImportQueryTable With {
            .EXISTS_QUERY = "SELECT COUNT(*) FROM tblauthors WHERE LOWER(CONCAT(first_name, ' ', last_name)) = LOWER(@data)",
            .SELECT_ID_QUERY = ""}},
        {PUBLISHER, New ImportQueryTable With {
            .EXISTS_QUERY = "SELECT COUNT(*) FROM tblpublishers WHERE LOWER(publisher_name) = LOWER(@data)",
            .SELECT_ID_QUERY = "SELECT id FROM tblpublishers WHERE LOWER(publisher_name) = LOWER(@data) LIMIT 1"}},
        {CLASSIFICATION, New ImportQueryTable With {
            .EXISTS_QUERY = "SELECT COUNT(*) FROM tblclassifications WHERE LOWER(classification) = LOWER(@data) OR LOWER(dewey_decimal) = LOWER(@data)",
            .SELECT_ID_QUERY = "SELECT id FROM tblclassifications WHERE LOWER(classification) = LOWER(@data) OR LOWER(dewey_decimal) = LOWER(@data) LIMIT 1"}},
        {LANGUAGES, New ImportQueryTable With {
            .EXISTS_QUERY = "SELECT COUNT(*) FROM tbllanguages WHERE LOWER(language) = LOWER(@data) OR LOWER(code) = LOWER(@data)",
            .SELECT_ID_QUERY = "SELECT id FROM tbllanguages WHERE LOWER(language) = LOWER(@data) OR LOWER(code) = LOWER(@data) LIMIT 1"}},
        {BOOK, New ImportQueryTable With {
            .EXISTS_QUERY = "SELECT COUNT(*) FROM tblbooks WHERE LOWER(isbn) = LOWER(@isbn)"}}
    }


    Public Function GetImportQueryType(type As QueryType) As ImportQueryTable
        Return RegistryImportQuery.Item(type)
    End Function
End Module
