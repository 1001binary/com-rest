# com-rest
The .NET library for common RESTful APIs.

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

For example: get list of users from service.
```
ApiResponse<IEnumerable<UserAccount>> result = Await RestService.GetAsync("[YOUR_BASE_API]/api/user/list")
  .ConfigureAwait(true);
````

### Copyright and License
&copy; Copyright 2020 by 1001binary.

MIT License
