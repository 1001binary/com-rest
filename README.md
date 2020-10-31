# Com-Rest
The .NET library for common RESTful APIs.

<p align="center">
  <img src="https://s3.amazonaws.com/media-p.slid.es/uploads/527096/images/5526835/gears.gif">
</p>
<p align="center">
  Source: image from Slides.com
</p>

### Installation

You can install ComRest via nuget.
```
Install-Package ComRest 
````

### Usage

- RestService.GetAsync(requestUri): get data from service API. Returns ApiResponse<TData>.
- RestService.PostAsync(requestUri, content): post object content or HTTP content to service API. Returns ApiResponse<TData>.
- RestService.DeleteAsync(requestUri): delete resources from service API. Returns ApiResponse<TData>.
- RestService.PutAsync(requestUri, content): change or save object content or HTTP content in service API. Returns ApiResponse<TData>.

For example:

- HTTP_GET: get list of users from service.
```
// NOTE: make sure your service returns ApiResponse<TData>
ApiResponse<IEnumerable<UserAccount>> result = Await RestService.GetAsync("[YOUR_BASE_API]/api/user/list")
  .ConfigureAwait(true);
````

- HTTP_POST: post User object content to service.
```
var user = new User()
{
    FirstName = "Jimmy",
    LastName = "Lee",
    PwdHashed = "fdsafdafdfdsadfafdsfads",
    PwdSalt = "fdsafddfassfdfdssfddfsf"
};
// NOTE: make sure your service returns ApiResponse<TData>
ApiResponse<bool> result = Await RestService.PostAsync("[YOUR_BASE_API]/api/user/register", user)
  .ConfigureAwait(true);
````

- HTTP_PUT: save User object content to service.
```
user.FirstName = "Thomas";
// NOTE: make sure your service returns ApiResponse<TData>
ApiResponse<bool> result = Await RestService.PutAsync("[YOUR_BASE_API]/api/user/save", user)
  .ConfigureAwait(true);
````

- HTTP_DELETE: delete User object content from service.
```
var userId = 1;
// NOTE: make sure your service returns ApiResponse<TData>
ApiResponse<bool> result = Await RestService.DeleteAsync($"[YOUR_BASE_API]/api/user/delete/{userId}")
  .ConfigureAwait(true);
````

### Copyright and License
&copy; Copyright 2020 by 1001binary.

MIT License
