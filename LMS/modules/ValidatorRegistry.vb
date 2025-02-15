Module ValidatorRegistry
    Public ReadOnly RegistryValidator As New Dictionary(Of VALIDATORTYPE, Func(Of String, Boolean)) From {
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
End Module
