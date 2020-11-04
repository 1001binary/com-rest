Public Class ApiResponse

    Sub New() ' To deserialize.

    End Sub

    Sub New(IsSuccess As Boolean, Exception As Exception)
        Me.IsSuccess = IsSuccess
        Me.Exception = Exception
    End Sub

    Property IsSuccess As Boolean
    Property Exception As Exception
End Class

Public Class ApiResponse(Of T)
    Inherits ApiResponse

    Sub New() ' To deserialize.

    End Sub

    Sub New(IsSuccess As Boolean, Result As T, Exception As Exception)
        MyBase.New(IsSuccess, Exception)
        Me.Result = Result
    End Sub

    Property Result As T
End Class
