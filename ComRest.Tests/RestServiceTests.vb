
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Newtonsoft.Json

Namespace ComRest.Tests

    Friend Class HttpBinResult
        <JsonProperty("origin")>
        Property Origin As String
    End Class

    <TestClass>
    Public Class RestServiceTests
        <TestMethod>
        Async Function GetAsync_WhenCalled_ReturnsHttpBinResult() As Task
            ' Arrange
            Dim Url As String = "https://httpbin.org/get"

            ' Act
            Dim Result As HttpBinResult = Await RestService.GetAsync(Of HttpBinResult)(Url)

            ' Assert
            Assert.AreNotEqual(Nothing, Result.Origin)
        End Function

        <TestMethod>
        Async Function PostAsync_WhenCalled_ReturnsHttpBinResult() As Task
            ' Arrange
            Dim Url As String = "https://httpbin.org/post"

            ' Act
            Dim Result As HttpBinResult = Await RestService.PostAsync(Of HttpBinResult)(Url, Nothing)

            ' Assert
            Assert.AreNotEqual(Nothing, Result.Origin)
        End Function

        <TestMethod>
        Async Function PutAsync_WhenCalled_ReturnsHttpBinResult() As Task
            ' Arrange
            Dim Url As String = "https://httpbin.org/put"

            ' Act
            Dim Result As HttpBinResult = Await RestService.PutAsync(Of HttpBinResult)(Url, Nothing)

            ' Assert
            Assert.AreNotEqual(Nothing, Result.Origin)
        End Function

        <TestMethod>
        Async Function DeleteAsync_WhenCalled_ReturnsHttpBinResult() As Task
            ' Arrange
            Dim Url As String = "https://httpbin.org/delete"

            ' Act
            Dim Result As HttpBinResult = Await RestService.DeleteAsync(Of HttpBinResult)(Url)

            ' Assert
            Assert.AreNotEqual(Nothing, Result.Origin)
        End Function
    End Class
End Namespace
