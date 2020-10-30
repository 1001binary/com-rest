Public MustInherit Class ApiResponse

    Sub New()

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

    Sub New()

    End Sub

    Sub New(IsSuccess As Boolean, Result As T, Exception As Exception)
        Me.IsSuccess = IsSuccess
        Me.Result = Result
        Me.Exception = Exception
    End Sub

    Property Result As T
End Class
