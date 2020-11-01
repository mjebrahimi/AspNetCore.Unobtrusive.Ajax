using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCore.Unobtrusive.Ajax
{
    internal static class Utilities
    {
        #region Merge Attributes
        /// <summary>
        /// Merge secondary attributes to primary attributes.
        /// </summary>
        /// <param name="primaryAttributes">Primary attributes</param>
        /// <param name="secondaryAttributes"></param>
        /// <param name="replaceExisting">Whether to replace existing attributes. Default is: false</param>
        /// <returns>Attributes dictionary</returns>
        internal static IDictionary<string, object> MergeAttributes(object primaryAttributes, object secondaryAttributes, bool replaceExisting = false)
        {
            if (secondaryAttributes is not IDictionary<string, object> secondary)
                secondary = HtmlHelper.AnonymousObjectToHtmlAttributes(secondaryAttributes);

            if (primaryAttributes is not IDictionary<string, object> primary)
                primary = HtmlHelper.AnonymousObjectToHtmlAttributes(primaryAttributes);

            return MergeAttributes(primary, secondary, replaceExisting);
        }

        /// <summary>
        /// Merge secondary attributes to primary attributes.
        /// </summary>
        /// <param name="primaryAttributes">Primary attributes</param>
        /// <param name="secondaryAttributes"></param>
        /// <param name="replaceExisting">Whether to replace existing attributes. Default is: false</param>
        /// <returns>Attributes dictionary</returns>
        internal static IDictionary<string, object> MergeAttributes(this IDictionary<string, object> primaryAttributes, object secondaryAttributes, bool replaceExisting = false)
        {
            if (secondaryAttributes is not IDictionary<string, object> secondary)
                secondary = HtmlHelper.AnonymousObjectToHtmlAttributes(secondaryAttributes);

            return MergeAttributes(primaryAttributes, secondary, replaceExisting);
        }

        /// <summary>
        /// Merge secondary attributes to primary attributes.
        /// </summary>
        /// <param name="primaryAttributes">Primary attributes</param>
        /// <param name="secondaryAttributes"></param>
        /// <param name="replaceExisting">Whether to replace existing attributes. Default is: false</param>
        /// <returns>Attributes dictionary</returns>
        internal static IDictionary<string, object> MergeAttributes(object primaryAttributes, IDictionary<string, object> secondaryAttributes, bool replaceExisting = false)
        {
            if (primaryAttributes is not IDictionary<string, object> primary)
                primary = HtmlHelper.AnonymousObjectToHtmlAttributes(primaryAttributes);

            return MergeAttributes(primary, secondaryAttributes, replaceExisting);
        }

        /// <summary>
        /// Merge secondary attributes to primary attributes.
        /// </summary>
        /// <param name="primaryAttributes">Primary attributes</param>
        /// <param name="secondaryAttributes"></param>
        /// <param name="replaceExisting">Whether to replace existing attributes. Default is: false</param>
        /// <returns>Attributes dictionary</returns>
        internal static IDictionary<string, object> MergeAttributes(this IDictionary<string, object> primaryAttributes, IDictionary<string, object> secondaryAttributes, bool replaceExisting = false)
        {
            var input = new TagBuilder("input");
            input.MergeAttributes(primaryAttributes, replaceExisting);
            input.MergeAttributes(secondaryAttributes, replaceExisting);
            return input.Attributes.ToDictionary(p => p.Key, p => (object)p.Value);
        }
        #endregion

        #region Unused
        //internal static T NotNull<T>(this T obj, string name, string message = null)
        //{
        //    if (obj is null)
        //        throw new ArgumentNullException($"{name} : {typeof(T)}", message);
        //    return obj;
        //}

        //internal static string ToHtmlString(this IHtmlContent tag, HtmlEncoder htmlEncoder = null)
        //{
        //    using var writer = new StringWriter();
        //    tag.WriteTo(writer, htmlEncoder ?? HtmlEncoder.Default);
        //    return writer.ToString();
        //}

        //internal static IUrlHelper GetUrlHelper(this IHtmlHelper htmlHelper)
        //{
        //    var urlFactory = htmlHelper.ViewContext.HttpContext.RequestServices.GetRequiredService<IUrlHelperFactory>();
        //    var actionAccessor = htmlHelper.ViewContext.HttpContext.RequestServices.GetRequiredService<IActionContextAccessor>();
        //    return urlFactory.GetUrlHelper(actionAccessor.ActionContext);
        //}

        ///// <summary>
        ///// Get the raw path and full query of request
        ///// </summary>
        ///// <param name="htmlHelper">Http request</param>
        ///// <returns>Raw Url</returns>
        //internal static string GetRawUrl(this HttpRequest httpRequest)
        //{
        //    //https://stackoverflow.com/questions/28120222/get-raw-url-from-microsoft-aspnet-http-httprequest
        //    //return httpRequest.GetEncodedUrl();
        //    //return UriHelper.GetEncodedUrl(httpRequest);
        //    //return httpRequest.GetDisplayUrl();
        //    //return UriHelper.GetDisplayUrl(httpRequest);

        //    //first try to get the raw target from request feature
        //    //note: value has not been UrlDecoded
        //    var rawUrl = httpRequest.HttpContext.Features.Get<IHttpRequestFeature>()?.RawTarget;

        //    //or compose raw URL manually
        //    if (string.IsNullOrEmpty(rawUrl))
        //        rawUrl = $"{httpRequest.PathBase}{httpRequest.Path}{httpRequest.QueryString}";

        //    return rawUrl;
        //}
        #endregion
    }
}
