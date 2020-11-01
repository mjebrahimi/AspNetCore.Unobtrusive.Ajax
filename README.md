[![NuGet](https://img.shields.io/nuget/v/AspNetCore.Unobtrusive.Ajax.svg)](https://www.nuget.org/packages/AspNetCore.Unobtrusive.Ajax)
[![License: MIT](https://img.shields.io/badge/License-MIT-brightgreen.svg)](https://opensource.org/licenses/MIT)
[![Build Status](https://github.com/mjebrahimi/AspNetCore.Unobtrusive.Ajax/workflows/.NET%20Core/badge.svg)](https://github.com/mjebrahimi/AspNetCore.Unobtrusive.Ajax)


# AspNetCore.Unobtrusive.Ajax

Unobtrusive Ajax Helpers (like MVC5 **Ajax.BeignForm** and **Ajax.ActionLink**) for ASP.NET Core.

## Features

- Works with Upload file.
- Works with `[AntiForgeryTokenValidation]`.
- Has `[AjaxOnly]` attribute to limit actions.
- Has `httpRequest.IsAjaxRequest()` extension method to check request is ajax and decide return PartialView or JSON result.
- Additional overloads for ease of use.
- Adds necessary JS script automatically when you use a Ajax Helpers and remove JS script when you no longer use it (Optional - is by default).
- Uses CDN url instead of Embedded script (Optional - isn't by default).

## Method Usages 

| Method |  MVC 5
| ------------ |  -------
| `Html.AjaxBeginForm` | instead of `Ajax.BeginForm`
| `Html.AjaxBeginRouteForm` | instead of `Ajax.BeginRouteForm`
| `Html.AjaxActionLink` | instead of `Ajax.ActionLink`
| `Html.AjaxRouteLink` | instead of `Ajax.RouteLink`

## Get Started

### 1. Install package

```ini
PM> Install-Package AspNetCore.Unobtrusive.Ajax
```

### 2. Add Service and Middleware

```csharp
public void ConfigureServices(IServiceCollection services)
{
    //...
    services.AddUnobtrusiveAjax(); 
    //services.AddUnobtrusiveAjax(useCdn: true, injectScriptIfNeeded: false);
    //...
}

public void Configure(IApplicationBuilder app)
{
    //...
    app.UseStaticFiles();

    //It is required for serving 'jquery-unobtrusive-ajax.min.js' embedded script file.
    app.UseUnobtrusiveAjax(); //It is suggested to place it after UseStaticFiles()
    //...
}
```

### 3. Add Script Tag in Layout.cshtml

```html
    <!--Place it at the end of body and after jquery-->
    @Html.RenderUnobtrusiveAjaxScript()
    <!-- Or you can reference your local script file -->

    @RenderSection("Scripts", required: false)
</body>
</html>
```

### 4. Use it

```csharp
@using (Html.AjaxBeginForm(new AjaxOptions
{
    HttpMethod = "post",
    //Other options ...
}))
{
}
```


## Demo

Checkout [AspNetCore.Unobtrusive.Ajax.Demo](https://github.com/mjebrahimi/AspNetCore.Unobtrusive.Ajax/tree/master/demo/AspNetCore.Unobtrusive.Ajax.Demo) for more samples.

![Demo](Demo.jpg)


## Contributing

Create an [issue](https://github.com/mjebrahimi/AspNetCore.Unobtrusive.Ajax/issues/new) if you find a BUG or have a Suggestion or Question. If you want to develop this project :

1. Fork it!
2. Create your feature branch: `git checkout -b my-new-feature`
3. Commit your changes: `git commit -am 'Add some feature'`
4. Push to the branch: `git push origin my-new-feature`
5. Submit a pull request

## Give a Star! ⭐️

If you find this repository useful, please give it a star. Thanks!

## License

AspNetCore.Unobtrusive.Ajax is Copyright © 2020 [Mohammd Javad Ebrahimi](https://github.com/mjebrahimi) under the [MIT License](https://github.com/mjebrahimi/AspNetCore.Unobtrusive.Ajax/LICENSE).
