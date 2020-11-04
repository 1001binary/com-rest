Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Newtonsoft.Json

Namespace ComRest.Tests
    <TestClass>
    Public Class ApiResponseTests
        <TestMethod>
        Sub Deserialize_WhenCalled_ReturnsApiResponseObject()
            ' Arrange
            Dim ApiResponse As New ApiResponse(True, Nothing)

            ' Act
            Dim JsonString As String = JsonConvert.SerializeObject(ApiResponse)
            Dim Result As ApiResponse = JsonConvert.DeserializeObject(Of ApiResponse)(JsonString)

            ' Assert
            Assert.AreEqual(True, Result.IsSuccess)
            Assert.AreEqual(Nothing, Result.Exception)
        End Sub
    End Class
End Namespace
