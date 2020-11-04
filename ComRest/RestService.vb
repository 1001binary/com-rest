Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json

''' <summary>
''' Represents the common rest service for the specific HTTP Methods: GET, POST, PUT and DELETE.
''' </summary>
Public Class RestService

    ''' <summary>
    ''' Gets data from a specific request URI asynchronously.
    ''' </summary>
    ''' <typeparam name="TReturn">object</typeparam>
    ''' <param name="RequestUri">URI string</param>
    ''' <returns>Returns a specific <typeparamref name="TReturn"/>.</returns>
    Public Shared Async Function GetAsync(Of TReturn)(RequestUri As String) As Task(Of TReturn)
        Using HttpClient As New HttpClient
            Try
                Dim JsonResult As String = Await HttpClient.GetStringAsync(RequestUri)

                Return JsonConvert.DeserializeObject(Of TReturn)(JsonResult)
            Catch ex As Exception
                Return Nothing
            End Try
        End Using
    End Function

    ''' <summary>
    ''' Posts a specific content object to a specific request asynchronously.
    ''' </summary>
    ''' <typeparam name="TReturn">object</typeparam>
    ''' <param name="RequestUri">URI string</param>
    ''' <param name="Content">Content string</param>
    ''' <returns>Returns a specific <typeparamref name="TReturn"/>.</returns>
    Public Shared Async Function PostAsync(Of TReturn)(RequestUri As String, Content As Object) As Task(Of TReturn)
        Using HttpClient As New HttpClient
            Try
                Dim SerializedObject As String = JsonConvert.SerializeObject(Content)

                Dim HttpContent As New StringContent(SerializedObject, Encoding.UTF8, "application/json")

                Return Await PostAsync(Of TReturn)(RequestUri, HttpContent)
            Catch ex As Exception
                Return Nothing
            End Try
        End Using
    End Function

    ''' <summary>
    ''' Posts a specific HTTP Content to a specific request asynchronously.
    ''' </summary>
    ''' <typeparam name="TReturn">object</typeparam>
    ''' <param name="RequestUri">URI string</param>
    ''' <param name="Content">HTTP Content</param>
    ''' <returns>Returns a specific <typeparamref name="TReturn"/>.</returns>
    Public Shared Async Function PostAsync(Of TReturn)(RequestUri As String, Content As HttpContent) As Task(Of TReturn)
        Using HttpClient As New HttpClient
            Try
                Dim Response As HttpResponseMessage = Await HttpClient.PostAsync(RequestUri, Content)
                Dim JsonResult As String = Await Response.Content.ReadAsStringAsync()

                Return JsonConvert.DeserializeObject(Of TReturn)(JsonResult)
            Catch ex As Exception
                Return Nothing
            End Try
        End Using
    End Function

    ''' <summary>
    ''' Puts a specific content object to a specific request asynchronously. 
    ''' </summary>
    ''' <typeparam name="TReturn">object</typeparam>
    ''' <param name="RequestUri">URI string</param>
    ''' <param name="Content">Content string</param>
    ''' <returns>Returns a specific <typeparamref name="TReturn"/>.</returns>
    Public Shared Async Function PutAsync(Of TReturn)(RequestUri As String, Content As Object) As Task(Of TReturn)
        Using HttpClient As New HttpClient
            Try
                Dim SerializedObject As String = JsonConvert.SerializeObject(Content)

                Dim HttpContent As New StringContent(SerializedObject, Encoding.UTF8, "application/json")

                Return Await PutAsync(Of TReturn)(RequestUri, HttpContent)
            Catch ex As Exception
                Return Nothing
            End Try
        End Using
    End Function

    ''' <summary>
    ''' Puts a specific HTTP content to a specific request asynchronously.
    ''' </summary>
    ''' <typeparam name="TReturn">object</typeparam>
    ''' <param name="RequestUri">URI string</param>
    ''' <param name="Content">Http content</param>
    ''' <returns>Returns a specific <typeparamref name="TReturn"/>.</returns>
    Public Shared Async Function PutAsync(Of TReturn)(RequestUri As String, Content As HttpContent) As Task(Of TReturn)
        Using HttpClient As New HttpClient
            Try
                Dim Response As HttpResponseMessage = Await HttpClient.PutAsync(RequestUri, Content)
                Dim JsonResult As String = Await Response.Content.ReadAsStringAsync()

                Return JsonConvert.DeserializeObject(Of TReturn)(JsonResult)
            Catch ex As Exception
                Return Nothing
            End Try
        End Using
    End Function

    ''' <summary>
    ''' Deletes data from a specific request URI.
    ''' </summary>
    ''' <typeparam name="TReturn">object</typeparam>
    ''' <param name="RequestUri">URI string</param>
    ''' <returns>Returns a specific <typeparamref name="TReturn"/>.</returns>
    Public Shared Async Function DeleteAsync(Of TReturn)(RequestUri As String) As Task(Of TReturn)
        Using HttpClient As New HttpClient
            Try
                Dim Response As HttpResponseMessage = Await HttpClient.DeleteAsync(RequestUri)
                Dim JsonResult As String = Await Response.Content.ReadAsStringAsync()

                Return JsonConvert.DeserializeObject(Of TReturn)(JsonResult)
            Catch ex As Exception
                Return Nothing
            End Try
        End Using
    End Function

    ''' <summary>
    ''' Gets data from a specific request URI asynchronously.
    ''' </summary>
    ''' <typeparam name="TReturn">object</typeparam>
    ''' <param name="RequestUri">URI string</param>
    ''' <returns>Returns a specific api response.</returns>
    Public Shared Async Function GetApiResponseAsync(Of TReturn)(RequestUri As String) As Task(Of ApiResponse(Of TReturn))
        Return Await GetAsync(Of ApiResponse(Of TReturn))(RequestUri)
    End Function

    ''' <summary>
    ''' Posts a specific content object to a specific request asynchronously.
    ''' </summary>
    ''' <typeparam name="TReturn">object</typeparam>
    ''' <param name="RequestUri">URI string</param>
    ''' <param name="Content">Content string</param>
    ''' <returns>Returns a specific api response.</returns>
    Public Shared Async Function PostApiResponseAsync(Of TReturn)(RequestUri As String, Content As Object) As Task(Of ApiResponse(Of TReturn))
        Return Await PostAsync(Of ApiResponse(Of TReturn))(RequestUri, Content)
    End Function

    ''' <summary>
    ''' Posts a specific HTTP Content to a specific request asynchronously.
    ''' </summary>
    ''' <typeparam name="TReturn">object</typeparam>
    ''' <param name="RequestUri">URI string</param>
    ''' <param name="Content">HTTP Content</param>
    ''' <returns>Returns a specific api response.</returns>
    Public Shared Async Function PostApiResponseAsync(Of TReturn)(RequestUri As String, Content As HttpContent) As Task(Of ApiResponse(Of TReturn))
        Return Await PostAsync(Of ApiResponse(Of TReturn))(RequestUri, Content)
    End Function

    ''' <summary>
    ''' Puts a specific content object to a specific request asynchronously. 
    ''' </summary>
    ''' <typeparam name="TReturn">object</typeparam>
    ''' <param name="RequestUri">URI string</param>
    ''' <param name="Content">Content string</param>
    ''' <returns>Returns a specific api response.</returns>
    Public Shared Async Function PutApiResponseAsync(Of TReturn)(RequestUri As String, Content As Object) As Task(Of ApiResponse(Of TReturn))
        Return Await PutAsync(Of ApiResponse(Of TReturn))(RequestUri, Content)
    End Function

    ''' <summary>
    ''' Puts a specific HTTP content to a specific request asynchronously.
    ''' </summary>
    ''' <typeparam name="TReturn">object</typeparam>
    ''' <param name="RequestUri">URI string</param>
    ''' <param name="Content">Http content</param>
    ''' <returns>Returns a specific api response.</returns>
    Public Shared Async Function PutApiResponseAsync(Of TReturn)(RequestUri As String, Content As HttpContent) As Task(Of ApiResponse(Of TReturn))
        Return Await PutAsync(Of ApiResponse(Of TReturn))(RequestUri, Content)
    End Function

    ''' <summary>
    ''' Deletes data from a specific request URI.
    ''' </summary>
    ''' <typeparam name="TReturn">object</typeparam>
    ''' <param name="RequestUri">URI string</param>
    ''' <returns>Returns a specific api response.</returns>
    Public Shared Async Function DeleteApiResponseAsync(Of TReturn)(RequestUri As String) As Task(Of ApiResponse(Of TReturn))
        Return Await DeleteAsync(Of ApiResponse(Of TReturn))(RequestUri)
    End Function

End Class

