# Com-Rest
The .NET library for common RESTful APIs.

<p align="center">
  <img height="200" src='https://cdn.lowgif.com/full/88e2332e965be77b-.gif'/>
</p>
<p align="center">
  Source: image from lowgif.com
</p>

### Installation

You can install ComRest via nuget.
```
Install-Package ComRest 
````

### Usage

- RestService.GetAsync(requestUri): get data from service API. Returns TData.
- RestService.PostAsync(requestUri, content): post object content or HTTP content to service API. Returns TData.
- RestService.DeleteAsync(requestUri): delete resources from service API. Returns TData.
- RestService.PutAsync(requestUri, content): change or save object content or HTTP content in service API. Returns TData.
- RestService.GetApiResponseAsync(requestUri): get data from service API. Returns ApiResponse<TData>.
- RestService.PostApiResponseAsync(requestUri, content): post object content or HTTP content to service API. Returns ApiResponse<TData>.
- RestService.DeleteApiResponseAsync(requestUri): delete resources from service API. Returns ApiResponse<TData>.
- RestService.PutApiResponseAsync(requestUri, content): change or save object content or HTTP content in service API. Returns ApiResponse<TData>.
  
For example:

- HTTP_GET: get list of users from service.
```csharp
IEnumerable<UserAccount> result =
    Await RestService.GetAsync<IEnumerable<UserAccount>>("[YOUR_BASE_API]/api/user/list").ConfigureAwait(true);
// NOTE: make sure your service returns ApiResponse<TData>
ApiResponse<IEnumerable<UserAccount>> result = 
  Await RestService.GetApiResponseAsync<IEnumerable<UserAccount>>("[YOUR_BASE_API]/api/user/list")
    .ConfigureAwait(true);
````

- HTTP_POST: post User object content to service.
```csharp
var user = new User()
{
    FirstName = "Jimmy",
    LastName = "Lee",
    PwdHashed = "fdsafdafdfdsadfafdsfads",
    PwdSalt = "fdsafddfassfdfdssfddfsf"
};
string result = Await RestService.PostAsync<string>("[YOUR_BASE_API]/api/user/register", user)
// NOTE: make sure your service returns ApiResponse<TData>
ApiResponse<string> result =
    Await RestService.PostApiResponseAsync<string>("[YOUR_BASE_API]/api/user/register", user)
      .ConfigureAwait(true);
````

- HTTP_PUT: save User object content to service.
```csharp
user.FirstName = "Thomas";
bool result = Await RestService.PutAsync<bool>("[YOUR_BASE_API]/api/user/save", user)
// NOTE: make sure your service returns ApiResponse<TData>
ApiResponse<bool> result =
    Await RestService.PutApiResponseAsync<bool>("[YOUR_BASE_API]/api/user/save", user)
      .ConfigureAwait(true);
````

- HTTP_DELETE: delete User object content from service.
```csharp
var userId = 1;
bool result = Await RestService.DeleteAsync<bool>($"[YOUR_BASE_API]/api/user/delete/{userId}")
// NOTE: make sure your service returns ApiResponse<TData>
ApiResponse<bool> result =
    Await RestService.DeleteApiResponseAsync<bool>($"[YOUR_BASE_API]/api/user/delete/{userId}")
      .ConfigureAwait(true);
````

### Copyright and License
&copy; Copyright 2020 by 1001binary.

MIT License
