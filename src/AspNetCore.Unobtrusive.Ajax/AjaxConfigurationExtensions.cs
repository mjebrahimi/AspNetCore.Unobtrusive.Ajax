using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace AspNetCore.Unobtrusive.Ajax
{
    /// <summary>
    /// Extension methods for UnobtrusiveAjax configuration
    /// </summary>
    public static class AjaxConfigurationExtensions
    {
        internal static bool UseCdn { get; private set; } = false;
        internal static bool InjectScriptIfNeeded { get; private set; } = true;
        internal static bool UnobtrusiveJavaScriptEnabled { get; private set; } = false;

        /// <summary>
        /// Config UnobtrusiveAjax options
        /// </summary>
        /// <param name="services">services</param>
        /// <param name="useCdn">If true, 'cdnjs' url will be used for 'jquery.unobtrusive-ajax.min.js' script. otherwise, embedded file will be used (in this case ensure to call app.UseUnobtrusiveAjax())</param>
        /// <param name="injectScriptIfNeeded">If true, the script file will be injected only if needed (if at least once Html.AjaxBeginForm or etc be called). otherwise, the script file will be injected always.</param>
        /// <returns>services</returns>
        public static IServiceCollection AddUnobtrusiveAjax(this IServiceCollection services, bool useCdn = false, bool injectScriptIfNeeded = true)
        {
            UseCdn = useCdn;
            InjectScriptIfNeeded = injectScriptIfNeeded;
            UnobtrusiveJavaScriptEnabled = true;

            return services;
        }

        /// <summary>
        /// Adds a static files middleware to serving embedded script file.
        /// </summary>
        public static IApplicationBuilder UseUnobtrusiveAjax(this IApplicationBuilder app)
        {
            var fileProvider = new ManifestEmbeddedFileProvider(typeof(AjaxConfigurationExtensions).Assembly);
            return app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = fileProvider,
                RequestPath = new PathString("/scripts")
            });

            #region Other Approaches
            //Old way and replaced by ManifestEmbeddedFileProvider
            //var fileProvider = new EmbeddedFileProvider(typeof(AjaxConfigurationExtensions).Assembly);
            //var scriptFile = fileProvider.GetFileInfo("jquery.unobtrusive-ajax.min.js");

            //Config required in csproj <GenerateEmbeddedFilesManifest>true</GenerateEmbeddedFilesManifest>
            //var fileProvider = new ManifestEmbeddedFileProvider(typeof(AjaxConfigurationExtensions).Assembly);
            //var scriptFile = fileProvider.GetFileInfo("jquery.unobtrusive-ajax.min.js");

            #region UseStaticFiles
            //GET only and Case-Sensitive
            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileProvider = fileProvider,
            //    RequestPath = new PathString(""), //new PathString("/scripts"),
            //});
            #endregion

            #region UseRouter/MapGet
            //GET only and Case-InSensitive
            //app.UseRouter(router =>
            //{
            //    router.MapGet("/jquery.unobtrusive-ajax.min.js", context =>
            //    {
            //        context.Response.ContentType = "text/javascript";
            //        return context.Response.SendFileAsync(scriptFile, context.RequestAborted);
            //    });
            //});
            #endregion

            #region MapWhen
            //GET (optional) only and Case-Sensitive (optional)
            //app.MapWhen(httpContext =>
            //{
            //    return
            //        httpContext.Request.Method.Equals("get", StringComparison.OrdinalIgnoreCase) &&
            //        httpContext.Request.Path.StartsWithSegments(new PathString("/jquery.unobtrusive-ajax.min.js"), StringComparison.Ordinal);
            //}, app =>
            //{
            //    app.Run(async context =>
            //    {
            //        await context.Response.SendFileAsync(scriptFile, context.RequestAborted);
            //        //using var stream = typeof(AjaxConfigurationExtensions).Assembly.GetManifestResourceStream("AspNetCore.Unobtrusive.Ajax.jquery.unobtrusive-ajax.min.js");
            //        //context.Response.ContentLength = stream.Length;
            //        //context.Response.ContentType = "text/javascript";
            //        //await stream.CopyToAsync(context.Response.Body, context.RequestAborted);
            //    });
            //});
            #endregion
            #endregion
        }
    }
}
