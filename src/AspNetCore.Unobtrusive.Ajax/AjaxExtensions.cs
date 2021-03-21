using AspNetCore.Unobtrusive.Ajax;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;
using System.Globalization;

namespace Microsoft.AspNetCore.Mvc.Rendering
{
    /// <summary>
    /// Represents support for AJAX within an ASP.NET Core application.
    /// </summary>
    public static class AjaxExtensions
    {
        private const string LinkOnClickFormat = "Sys.Mvc.AsyncHyperlink.handleClick(this, new Sys.UI.DomEvent(event), {0});";
        private const string FormOnClickValue = "Sys.Mvc.AsyncForm.handleClick(this, new Sys.UI.DomEvent(event));";
        private const string FormOnSubmitFormat = "Sys.Mvc.AsyncForm.handleSubmit(this, new Sys.UI.DomEvent(event), {0});";

        #region AjaxActionLink
        /// <summary>
        /// Returns an anchor element that contains the URL to the specified action method; when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="linkText">The inner text of the anchor element.</param>
        /// <param name="actionName">The name of the action method.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <returns>An anchor element.</returns>
        public static IHtmlContent AjaxActionLink(this IHtmlHelper htmlHelper, string linkText, string actionName, AjaxOptions ajaxOptions)
        {
            return htmlHelper.ActionLink(linkText, actionName, null, GetLinkHtmlAttributes(htmlHelper, ajaxOptions, null));
        }

        /// <summary>
        /// Returns an anchor element that contains the URL to the specified action method; when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="linkText">The inner text of the anchor element.</param>
        /// <param name="actionName">The name of the action method that will handle the request.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <returns>An anchor element.</returns>
        public static IHtmlContent AjaxActionLink(this IHtmlHelper htmlHelper, string linkText, string actionName, object routeValues, AjaxOptions ajaxOptions)
        {
            return htmlHelper.ActionLink(linkText, actionName, routeValues, GetLinkHtmlAttributes(htmlHelper, ajaxOptions, null));
        }

        /// <summary>
        /// Returns an anchor element that contains the URL to the specified action method; when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="linkText">The inner text of the anchor element.</param>
        /// <param name="actionName">The name of the action method that will handle the request.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An anchor element.</returns>
        public static IHtmlContent AjaxActionLink(this IHtmlHelper htmlHelper, string linkText, string actionName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            return htmlHelper.ActionLink(linkText, actionName, routeValues, GetLinkHtmlAttributes(htmlHelper, ajaxOptions, htmlAttributes));
        }

        /// <summary>
        /// Returns an anchor element that contains the URL to the specified action method; when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="linkText">The inner text of the anchor element.</param>
        /// <param name="actionName">The name of the action method that will handle the request.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <returns>An anchor element.</returns>
        public static IHtmlContent AjaxActionLink(this IHtmlHelper htmlHelper, string linkText, string actionName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions)
        {
            return htmlHelper.ActionLink(linkText, actionName, routeValues, GetLinkHtmlAttributes(htmlHelper, ajaxOptions, null));
        }

        /// <summary>
        /// Returns an anchor element that contains the URL to the specified action method; when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="linkText">The inner text of the anchor element.</param>
        /// <param name="actionName">The name of the action method that will handle the request.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An anchor element.</returns>
        public static IHtmlContent AjaxActionLink(this IHtmlHelper htmlHelper, string linkText, string actionName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.ActionLink(linkText, actionName, routeValues, GetLinkHtmlAttributes(htmlHelper, ajaxOptions, htmlAttributes));
        }

        /// <summary>
        /// Returns an anchor element that contains the URL to the specified action method; when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="linkText">The inner text of the anchor element.</param>
        /// <param name="actionName">The name of the action method that will handle the request.</param>
        /// <param name="controllerName">The name of the controller.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <returns>An anchor element.</returns>
        public static IHtmlContent AjaxActionLink(this IHtmlHelper htmlHelper, string linkText, string actionName, string controllerName, AjaxOptions ajaxOptions)
        {
            return htmlHelper.ActionLink(linkText, actionName, controllerName, GetLinkHtmlAttributes(htmlHelper, ajaxOptions, null));
        }

        /// <summary>
        /// Returns an anchor element that contains the URL to the specified action method; when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="linkText">The inner text of the anchor element.</param>
        /// <param name="actionName">The name of the action method that will handle the request.</param>
        /// <param name="controllerName">The name of the controller.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <returns>An anchor element.</returns>
        public static IHtmlContent AjaxActionLink(this IHtmlHelper htmlHelper, string linkText, string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions)
        {
            return htmlHelper.ActionLink(linkText, actionName, controllerName, routeValues, GetLinkHtmlAttributes(htmlHelper, ajaxOptions, null));
        }

        /// <summary>
        /// Returns an anchor element that contains the URL to the specified action method; when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="linkText">The inner text of the anchor element.</param>
        /// <param name="actionName">The name of the action method that will handle the request.</param>
        /// <param name="controllerName">The name of the controller.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An anchor element.</returns>
        public static IHtmlContent AjaxActionLink(this IHtmlHelper htmlHelper, string linkText, string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            return htmlHelper.ActionLink(linkText, actionName, controllerName, routeValues, GetLinkHtmlAttributes(htmlHelper, ajaxOptions, htmlAttributes));
        }

        /// <summary>
        /// Returns an anchor element that contains the URL to the specified action method; when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="linkText">The inner text of the anchor element.</param>
        /// <param name="actionName">The name of the action method that will handle the request.</param>
        /// <param name="controllerName">The name of the controller.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <returns>An anchor element.</returns>
        public static IHtmlContent AjaxActionLink(this IHtmlHelper htmlHelper, string linkText, string actionName, string controllerName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions)
        {
            return htmlHelper.ActionLink(linkText, actionName, controllerName, routeValues, GetLinkHtmlAttributes(htmlHelper, ajaxOptions, null));
        }

        /// <summary>
        /// Returns an anchor element that contains the URL to the specified action method; when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="linkText">The inner text of the anchor element.</param>
        /// <param name="actionName">The name of the action method that will handle the request.</param>
        /// <param name="controllerName">The name of the controller.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An anchor element.</returns>
        public static IHtmlContent AjaxActionLink(this IHtmlHelper htmlHelper, string linkText, string actionName, string controllerName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.ActionLink(linkText, actionName, controllerName, routeValues, GetLinkHtmlAttributes(htmlHelper, ajaxOptions, htmlAttributes));
        }

        /// <summary>
        /// Returns an anchor element that contains the URL to the specified action method; when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="linkText">The inner text of the anchor element.</param>
        /// <param name="actionName">The name of the action method that will handle the request.</param>
        /// <param name="controllerName">The name of the controller.</param>
        /// <param name="protocol">The protocol for the URL, such as "http" or "https".</param>
        /// <param name="hostName">The host name for the URL.</param>
        /// <param name="fragment">The URL fragment name (the anchor name).</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An anchor element.</returns>
        public static IHtmlContent AjaxActionLink(this IHtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string protocol, string hostName, string fragment, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            return htmlHelper.ActionLink(linkText, actionName, controllerName, protocol, hostName, fragment, routeValues, GetLinkHtmlAttributes(htmlHelper, ajaxOptions, htmlAttributes));
        }

        /// <summary>
        /// Returns an anchor element that contains the URL to the specified action method; when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="linkText">The inner text of the anchor element.</param>
        /// <param name="actionName">The name of the action method that will handle the request.</param>
        /// <param name="controllerName">The name of the controller.</param>
        /// <param name="protocol">The protocol for the URL, such as "http" or "https".</param>
        /// <param name="hostName">The host name for the URL.</param>
        /// <param name="fragment">The URL fragment name (the anchor name).</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An anchor element.</returns>
        public static IHtmlContent AjaxActionLink(this IHtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.ActionLink(linkText, actionName, controllerName, protocol, hostName, fragment, routeValues, GetLinkHtmlAttributes(htmlHelper, ajaxOptions, htmlAttributes));
        }
        #endregion

        #region AjaxRouteLink
        /// <summary>
        /// Returns an anchor element that contains the virtual path for the specified route values; when the link is clicked, a request is made to the virtual path asynchronously by using JavaScript.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="linkText">The inner text of the anchor element.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <returns>An anchor element.</returns>
        public static IHtmlContent AjaxRouteLink(this IHtmlHelper htmlHelper, string linkText, object routeValues, AjaxOptions ajaxOptions)
        {
            return htmlHelper.RouteLink(linkText, routeValues, GetLinkHtmlAttributes(htmlHelper, ajaxOptions, null));
        }

        /// <summary>
        /// Returns an anchor element that contains the virtual path for the specified route values; when the link is clicked, a request is made to the virtual path asynchronously by using JavaScript.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="linkText">The inner text of the anchor element.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An anchor element.</returns>
        public static IHtmlContent AjaxRouteLink(this IHtmlHelper htmlHelper, string linkText, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            return htmlHelper.RouteLink(linkText, routeValues, GetLinkHtmlAttributes(htmlHelper, ajaxOptions, htmlAttributes));
        }

        /// <summary>
        /// Returns an anchor element that contains the virtual path for the specified route values; when the link is clicked, a request is made to the virtual path asynchronously by using JavaScript.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="linkText">The inner text of the anchor element.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <returns>An anchor element.</returns>
        public static IHtmlContent AjaxRouteLink(this IHtmlHelper htmlHelper, string linkText, RouteValueDictionary routeValues, AjaxOptions ajaxOptions)
        {
            return htmlHelper.RouteLink(linkText, routeValues, GetLinkHtmlAttributes(htmlHelper, ajaxOptions, null));
        }

        /// <summary>
        /// Returns an anchor element that contains the virtual path for the specified route values; when the link is clicked, a request is made to the virtual path asynchronously by using JavaScript.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="linkText">The inner text of the anchor element.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An anchor element.</returns>
        public static IHtmlContent AjaxRouteLink(this IHtmlHelper htmlHelper, string linkText, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.RouteLink(linkText, routeValues, GetLinkHtmlAttributes(htmlHelper, ajaxOptions, htmlAttributes));
        }

        /// <summary>
        /// Returns an anchor element that contains the virtual path for the specified route values; when the link is clicked, a request is made to the virtual path asynchronously by using JavaScript.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="linkText">The inner text of the anchor element.</param>
        /// <param name="routeName">The name of the route to use to obtain the form post URL.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <returns>An anchor element.</returns>
        public static IHtmlContent AjaxRouteLink(this IHtmlHelper htmlHelper, string linkText, string routeName, AjaxOptions ajaxOptions)
        {
            return htmlHelper.RouteLink(linkText, routeName, GetLinkHtmlAttributes(htmlHelper, ajaxOptions, null));
        }

        /// <summary>
        /// Returns an anchor element that contains the virtual path for the specified route values; when the link is clicked, a request is made to the virtual path asynchronously by using JavaScript.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="linkText">The inner text of the anchor element.</param>
        /// <param name="routeName">The name of the route to use to obtain the form post URL.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An anchor element.</returns>
        public static IHtmlContent AjaxRouteLink(this IHtmlHelper htmlHelper, string linkText, string routeName, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            return htmlHelper.RouteLink(linkText, routeName, GetLinkHtmlAttributes(htmlHelper, ajaxOptions, htmlAttributes));
        }

        /// <summary>
        /// Returns an anchor element that contains the virtual path for the specified route values; when the link is clicked, a request is made to the virtual path asynchronously by using JavaScript.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="linkText">The inner text of the anchor element.</param>
        /// <param name="routeName">The name of the route to use to obtain the form post URL.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An anchor element.</returns>
        public static IHtmlContent AjaxRouteLink(this IHtmlHelper htmlHelper, string linkText, string routeName, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.RouteLink(linkText, routeName, GetLinkHtmlAttributes(htmlHelper, ajaxOptions, htmlAttributes));
        }

        /// <summary>
        /// Returns an anchor element that contains the virtual path for the specified route values; when the link is clicked, a request is made to the virtual path asynchronously by using JavaScript.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="linkText">The inner text of the anchor element.</param>
        /// <param name="routeName">The name of the route to use to obtain the form post URL.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <returns>An anchor element.</returns>
        public static IHtmlContent AjaxRouteLink(this IHtmlHelper htmlHelper, string linkText, string routeName, object routeValues, AjaxOptions ajaxOptions)
        {
            return htmlHelper.RouteLink(linkText, routeName, routeValues, GetLinkHtmlAttributes(htmlHelper, ajaxOptions, null));
        }

        /// <summary>
        /// Returns an anchor element that contains the virtual path for the specified route values; when the link is clicked, a request is made to the virtual path asynchronously by using JavaScript.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="linkText">The inner text of the anchor element.</param>
        /// <param name="routeName">The name of the route to use to obtain the form post URL.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An anchor element.</returns>
        public static IHtmlContent AjaxRouteLink(this IHtmlHelper htmlHelper, string linkText, string routeName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            return htmlHelper.RouteLink(linkText, routeName, routeValues, GetLinkHtmlAttributes(htmlHelper, ajaxOptions, htmlAttributes));
        }

        /// <summary>
        /// Returns an anchor element that contains the virtual path for the specified route values; when the link is clicked, a request is made to the virtual path asynchronously by using JavaScript.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="linkText">The inner text of the anchor element.</param>
        /// <param name="routeName">The name of the route to use to obtain the form post URL.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <returns>An anchor element.</returns>
        public static IHtmlContent AjaxRouteLink(this IHtmlHelper htmlHelper, string linkText, string routeName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions)
        {
            return htmlHelper.RouteLink(linkText, routeName, routeValues, GetLinkHtmlAttributes(htmlHelper, ajaxOptions, null));
        }

        /// <summary>
        /// Returns an anchor element that contains the virtual path for the specified route values; when the link is clicked, a request is made to the virtual path asynchronously by using JavaScript.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="linkText">The inner text of the anchor element.</param>
        /// <param name="routeName">The name of the route to use to obtain the form post URL.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An anchor element.</returns>
        public static IHtmlContent AjaxRouteLink(this IHtmlHelper htmlHelper, string linkText, string routeName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.RouteLink(linkText, routeName, routeValues, GetLinkHtmlAttributes(htmlHelper, ajaxOptions, htmlAttributes));
        }

        /// <summary>
        /// Returns an anchor element that contains the virtual path for the specified route values; when the link is clicked, a request is made to the virtual path asynchronously by using JavaScript.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="linkText">The inner text of the anchor element.</param>
        /// <param name="routeName">The name of the route to use to obtain the form post URL.</param>
        /// <param name="protocol">The protocol for the URL, such as "http" or "https".</param>
        /// <param name="hostName">The host name for the URL.</param>
        /// <param name="fragment">The URL fragment name (the anchor name).</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An anchor element.</returns>
        public static IHtmlContent AjaxRouteLink(this IHtmlHelper htmlHelper, string linkText, string routeName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.RouteLink(linkText, routeName, protocol, hostName, fragment, routeValues, GetLinkHtmlAttributes(htmlHelper, ajaxOptions, htmlAttributes));
        }
        #endregion

        #region AjaxBeginForm
        /// <summary>
        /// Writes an opening&lt;form&gt;tag to the response.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <returns>An opening&lt;form&gt;tag.</returns>
        public static MvcForm AjaxBeginForm(this IHtmlHelper htmlHelper, AjaxOptions ajaxOptions)
        {
            return htmlHelper.BeginForm(FormMethod.Post, GetFormHtmlAttributes(htmlHelper, ajaxOptions, null));
        }

        /// <summary>
        /// Writes an opening&lt;form&gt;tag to the response.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="actionName">The name of the action method that will handle the request.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <returns>An opening&lt;form&gt;tag.</returns>
        public static MvcForm AjaxBeginForm(this IHtmlHelper htmlHelper, string actionName, AjaxOptions ajaxOptions)
        {
            return htmlHelper.BeginForm(actionName, null, FormMethod.Post, GetFormHtmlAttributes(htmlHelper, ajaxOptions, null));
        }

        /// <summary>
        /// Writes an opening&lt;form&gt;tag to the response.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="actionName">The name of the action method that will handle the request.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An opening&lt;form&gt;tag.</returns>
        public static MvcForm AjaxBeginForm(this IHtmlHelper htmlHelper, string actionName, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            return htmlHelper.BeginForm(actionName, null, FormMethod.Post, GetFormHtmlAttributes(htmlHelper, ajaxOptions, htmlAttributes));
        }

        /// <summary>
        /// Writes an opening&lt;form&gt;tag to the response.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="actionName">The name of the action method that will handle the request.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <returns>An opening&lt;form&gt;tag.</returns>
        public static MvcForm AjaxBeginForm(this IHtmlHelper htmlHelper, string actionName, object routeValues, AjaxOptions ajaxOptions)
        {
            return htmlHelper.BeginForm(actionName, null, routeValues, FormMethod.Post, null, GetFormHtmlAttributes(htmlHelper, ajaxOptions, null));
        }

        /// <summary>
        /// Writes an opening&lt;form&gt;tag to the response.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="actionName">The name of the action method that will handle the request.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An opening&lt;form&gt;tag.</returns>
        public static MvcForm AjaxBeginForm(this IHtmlHelper htmlHelper, string actionName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            return htmlHelper.BeginForm(actionName, null, routeValues, FormMethod.Post, null, GetFormHtmlAttributes(htmlHelper, ajaxOptions, htmlAttributes));
        }

        /// <summary>
        /// Writes an opening&lt;form&gt;tag to the response.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="actionName">The name of the action method that will handle the request.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <returns>An opening&lt;form&gt;tag.</returns>
        public static MvcForm AjaxBeginForm(this IHtmlHelper htmlHelper, string actionName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions)
        {
            return htmlHelper.BeginForm(actionName, null, routeValues, FormMethod.Post, null, GetFormHtmlAttributes(htmlHelper, ajaxOptions, null));
        }

        /// <summary>
        /// Writes an opening&lt;form&gt;tag to the response.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="actionName">The name of the action method that will handle the request.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An opening&lt;form&gt;tag.</returns>
        public static MvcForm AjaxBeginForm(this IHtmlHelper htmlHelper, string actionName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.BeginForm(actionName, null, routeValues, FormMethod.Post, null, GetFormHtmlAttributes(htmlHelper, ajaxOptions, htmlAttributes));
        }

        /// <summary>
        /// Writes an opening&lt;form&gt;tag to the response.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="actionName">The name of the action method that will handle the request.</param>
        /// <param name="controllerName">The name of the controller.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <returns>An opening&lt;form&gt;tag.</returns>
        public static MvcForm AjaxBeginForm(this IHtmlHelper htmlHelper, string actionName, string controllerName, AjaxOptions ajaxOptions)
        {
            return htmlHelper.BeginForm(actionName, controllerName, FormMethod.Post, GetFormHtmlAttributes(htmlHelper, ajaxOptions, null));
        }

        /// <summary>
        /// Writes an opening&lt;form&gt;tag to the response.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="actionName">The name of the action method that will handle the request.</param>
        /// <param name="controllerName">The name of the controller.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <returns>An opening&lt;form&gt;tag.</returns>
        public static MvcForm AjaxBeginForm(this IHtmlHelper htmlHelper, string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions)
        {
            return htmlHelper.BeginForm(actionName, controllerName, routeValues, FormMethod.Post, null, GetFormHtmlAttributes(htmlHelper, ajaxOptions, null));
        }

        /// <summary>
        /// Writes an opening&lt;form&gt;tag to the response.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="actionName">The name of the action method that will handle the request.</param>
        /// <param name="controllerName">The name of the controller.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An opening&lt;form&gt;tag.</returns>
        public static MvcForm AjaxBeginForm(this IHtmlHelper htmlHelper, string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            return htmlHelper.BeginForm(actionName, controllerName, routeValues, FormMethod.Post, null, GetFormHtmlAttributes(htmlHelper, ajaxOptions, htmlAttributes));
        }

        /// <summary>
        /// Writes an opening&lt;form&gt;tag to the response.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="actionName">The name of the action method that will handle the request.</param>
        /// <param name="controllerName">The name of the controller.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <returns>An opening&lt;form&gt;tag.</returns>
        public static MvcForm AjaxBeginForm(this IHtmlHelper htmlHelper, string actionName, string controllerName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions)
        {
            return htmlHelper.BeginForm(actionName, controllerName, routeValues, FormMethod.Post, null, GetFormHtmlAttributes(htmlHelper, ajaxOptions, null));
        }

        /// <summary>
        /// Writes an opening&lt;form&gt;tag to the response.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="actionName">The name of the action method that will handle the request.</param>
        /// <param name="controllerName">The name of the controller.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An opening&lt;form&gt;tag.</returns>
        public static MvcForm AjaxBeginForm(this IHtmlHelper htmlHelper, string actionName, string controllerName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.BeginForm(actionName, controllerName, routeValues, FormMethod.Post, null, GetFormHtmlAttributes(htmlHelper, ajaxOptions, htmlAttributes));
        }

        #region Other overloads
        /// <summary>
        /// Writes an opening&lt;form&gt;tag to the response.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An opening&lt;form&gt;tag.</returns>
        public static MvcForm AjaxBeginForm(this IHtmlHelper htmlHelper, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            return htmlHelper.BeginForm(FormMethod.Post, GetFormHtmlAttributes(htmlHelper, ajaxOptions, htmlAttributes));
        }

        /// <summary>
        /// Writes an opening&lt;form&gt;tag to the response.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="antiforgery">If true,&lt;form&gt;elements will include an antiforgery token. If false, suppresses the generation an &lt;input&gt; of type "hidden" with an antiforgery token.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <returns>An opening&lt;form&gt;tag.</returns>
        public static MvcForm AjaxBeginForm(this IHtmlHelper htmlHelper, bool? antiforgery, AjaxOptions ajaxOptions)
        {
            return htmlHelper.BeginForm(FormMethod.Post, antiforgery, GetFormHtmlAttributes(htmlHelper, ajaxOptions, null));
        }

        /// <summary>
        /// Writes an opening&lt;form&gt;tag to the response.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="antiforgery">If true,&lt;form&gt;elements will include an antiforgery token. If false, suppresses the generation an &lt;input&gt; of type "hidden" with an antiforgery token.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An opening&lt;form&gt;tag.</returns>
        public static MvcForm AjaxBeginForm(this IHtmlHelper htmlHelper, bool? antiforgery, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            return htmlHelper.BeginForm(FormMethod.Post, antiforgery, GetFormHtmlAttributes(htmlHelper, ajaxOptions, htmlAttributes));
        }

        /// <summary>
        /// Writes an opening&lt;form&gt;tag to the response.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="actionName">The name of the action method that will handle the request.</param>
        /// <param name="controllerName">The name of the controller.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An opening&lt;form&gt;tag.</returns>
        public static MvcForm AjaxBeginForm(this IHtmlHelper htmlHelper, string actionName, string controllerName, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            return htmlHelper.BeginForm(actionName, controllerName, FormMethod.Post, GetFormHtmlAttributes(htmlHelper, ajaxOptions, htmlAttributes));
        }

        /// <summary>
        /// Writes an opening&lt;form&gt;tag to the response.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="actionName">The name of the action method that will handle the request.</param>
        /// <param name="controllerName">The name of the controller.</param>
        /// <param name="antiforgery">If true,&lt;form&gt;elements will include an antiforgery token. If false, suppresses the generation an &lt;input&gt; of type "hidden" with an antiforgery token.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <returns>An opening&lt;form&gt;tag.</returns>
        public static MvcForm AjaxBeginForm(this IHtmlHelper htmlHelper, string actionName, string controllerName, bool? antiforgery, AjaxOptions ajaxOptions)
        {
            return htmlHelper.BeginForm(actionName, controllerName, null, FormMethod.Post, antiforgery, GetFormHtmlAttributes(htmlHelper, ajaxOptions, null));
        }

        /// <summary>
        /// Writes an opening&lt;form&gt;tag to the response.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="actionName">The name of the action method that will handle the request.</param>
        /// <param name="controllerName">The name of the controller.</param>
        /// <param name="antiforgery">If true,&lt;form&gt;elements will include an antiforgery token. If false, suppresses the generation an &lt;input&gt; of type "hidden" with an antiforgery token.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An opening&lt;form&gt;tag.</returns>
        public static MvcForm AjaxBeginForm(this IHtmlHelper htmlHelper, string actionName, string controllerName, bool? antiforgery, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            return htmlHelper.BeginForm(actionName, controllerName, null, FormMethod.Post, antiforgery, GetFormHtmlAttributes(htmlHelper, ajaxOptions, htmlAttributes));
        }

        /// <summary>
        /// Writes an opening&lt;form&gt;tag to the response.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <returns>An opening&lt;form&gt;tag.</returns>
        public static MvcForm AjaxBeginForm(this IHtmlHelper htmlHelper, object routeValues, AjaxOptions ajaxOptions)
        {
            return htmlHelper.BeginForm(null, null, routeValues, FormMethod.Post, null, GetFormHtmlAttributes(htmlHelper, ajaxOptions, null));
        }

        /// <summary>
        /// Writes an opening&lt;form&gt;tag to the response.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An opening&lt;form&gt;tag.</returns>
        public static MvcForm AjaxBeginForm(this IHtmlHelper htmlHelper, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            return htmlHelper.BeginForm(null, null, routeValues, FormMethod.Post, null, GetFormHtmlAttributes(htmlHelper, ajaxOptions, htmlAttributes));
        }

        /// <summary>
        /// Writes an opening&lt;form&gt;tag to the response.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="antiforgery">If true,&lt;form&gt;elements will include an antiforgery token. If false, suppresses the generation an &lt;input&gt; of type "hidden" with an antiforgery token.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <returns>An opening&lt;form&gt;tag.</returns>
        public static MvcForm AjaxBeginForm(this IHtmlHelper htmlHelper, object routeValues, bool? antiforgery, AjaxOptions ajaxOptions)
        {
            return htmlHelper.BeginForm(null, null, routeValues, FormMethod.Post, antiforgery, GetFormHtmlAttributes(htmlHelper, ajaxOptions, null));
        }

        /// <summary>
        /// Writes an opening&lt;form&gt;tag to the response.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="antiforgery">If true,&lt;form&gt;elements will include an antiforgery token. If false, suppresses the generation an &lt;input&gt; of type "hidden" with an antiforgery token.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An opening&lt;form&gt;tag.</returns>
        public static MvcForm AjaxBeginForm(this IHtmlHelper htmlHelper, object routeValues, bool? antiforgery, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            return htmlHelper.BeginForm(null, null, routeValues, FormMethod.Post, antiforgery, GetFormHtmlAttributes(htmlHelper, ajaxOptions, htmlAttributes));
        }

        /// <summary>
        /// Writes an opening&lt;form&gt;tag to the response.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="actionName">The name of the action method that will handle the request.</param>
        /// <param name="controllerName">The name of the controller.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="antiforgery">If true,&lt;form&gt;elements will include an antiforgery token. If false, suppresses the generation an &lt;input&gt; of type "hidden" with an antiforgery token.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <returns>An opening&lt;form&gt;tag.</returns>
        public static MvcForm AjaxBeginForm(this IHtmlHelper htmlHelper, string actionName, string controllerName, object routeValues, bool? antiforgery, AjaxOptions ajaxOptions)
        {
            return htmlHelper.BeginForm(actionName, controllerName, routeValues, FormMethod.Post, antiforgery, GetFormHtmlAttributes(htmlHelper, ajaxOptions, null));
        }

        /// <summary>
        /// Writes an opening&lt;form&gt;tag to the response.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="actionName">The name of the action method that will handle the request.</param>
        /// <param name="controllerName">The name of the controller.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="antiforgery">If true,&lt;form&gt;elements will include an antiforgery token. If false, suppresses the generation an &lt;input&gt; of type "hidden" with an antiforgery token.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An opening&lt;form&gt;tag.</returns>
        public static MvcForm AjaxBeginForm(this IHtmlHelper htmlHelper, string actionName, string controllerName, object routeValues, bool? antiforgery, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            return htmlHelper.BeginForm(actionName, controllerName, routeValues, FormMethod.Post, antiforgery, GetFormHtmlAttributes(htmlHelper, ajaxOptions, htmlAttributes));
        }
        #endregion

        #endregion

        #region AjaxBeginRouteForm
        /// <summary>
        /// Writes an opening&lt;form&gt;tag to the response using the specified routing information.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="routeName">The name of the route to use to obtain the form post URL.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <returns>An opening&lt;form&gt;tag.</returns>
        public static MvcForm AjaxBeginRouteForm(this IHtmlHelper htmlHelper, string routeName, AjaxOptions ajaxOptions)
        {
            return htmlHelper.BeginRouteForm(routeName, FormMethod.Post, GetFormHtmlAttributes(htmlHelper, ajaxOptions, null));
        }

        /// <summary>
        /// Writes an opening&lt;form&gt;tag to the response using the specified routing information.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="routeName">The name of the route to use to obtain the form post URL.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <returns>An opening&lt;form&gt;tag.</returns>
        public static MvcForm AjaxBeginRouteForm(this IHtmlHelper htmlHelper, string routeName, object routeValues, AjaxOptions ajaxOptions)
        {
            return htmlHelper.BeginRouteForm(routeName, routeValues, FormMethod.Post, null, GetFormHtmlAttributes(htmlHelper, ajaxOptions, null));
        }

        /// <summary>
        /// Writes an opening&lt;form&gt;tag to the response using the specified routing information.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="routeName">The name of the route to use to obtain the form post URL.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An opening&lt;form&gt;tag.</returns>
        public static MvcForm AjaxBeginRouteForm(this IHtmlHelper htmlHelper, string routeName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            return htmlHelper.BeginRouteForm(routeName, routeValues, FormMethod.Post, null, GetFormHtmlAttributes(htmlHelper, ajaxOptions, htmlAttributes));
        }

        /// <summary>
        /// Writes an opening&lt;form&gt;tag to the response using the specified routing information.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="routeName">The name of the route to use to obtain the form post URL.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <returns>An opening&lt;form&gt;tag.</returns>
        public static MvcForm AjaxBeginRouteForm(this IHtmlHelper htmlHelper, string routeName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions)
        {
            return htmlHelper.BeginRouteForm(routeName, routeValues, FormMethod.Post, null, GetFormHtmlAttributes(htmlHelper, ajaxOptions, null));
        }

        /// <summary>
        /// Writes an opening&lt;form&gt;tag to the response using the specified routing information.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="routeName">The name of the route to use to obtain the form post URL.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An opening&lt;form&gt;tag.</returns>
        public static MvcForm AjaxBeginRouteForm(this IHtmlHelper htmlHelper, string routeName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.BeginRouteForm(routeName, routeValues, FormMethod.Post, null, GetFormHtmlAttributes(htmlHelper, ajaxOptions, htmlAttributes));
        }

        #region Other overloads
        /// <summary>
        /// Writes an opening&lt;form&gt;tag to the response using the specified routing information.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An opening&lt;form&gt;tag.</returns>
        public static MvcForm AjaxBeginRouteForm(this IHtmlHelper htmlHelper, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            return htmlHelper.BeginRouteForm(null, routeValues, FormMethod.Post, null, GetFormHtmlAttributes(htmlHelper, ajaxOptions, htmlAttributes));
        }

        /// <summary>
        /// Writes an opening&lt;form&gt;tag to the response using the specified routing information.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="antiforgery">If true,&lt;form&gt;elements will include an antiforgery token. If false, suppresses the generation an &lt;input&gt; of type "hidden" with an antiforgery token.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <returns>An opening&lt;form&gt;tag.</returns>
        public static MvcForm AjaxBeginRouteForm(this IHtmlHelper htmlHelper, object routeValues, bool? antiforgery, AjaxOptions ajaxOptions)
        {
            return htmlHelper.BeginRouteForm(null, routeValues, FormMethod.Post, antiforgery, GetFormHtmlAttributes(htmlHelper, ajaxOptions, null));
        }

        /// <summary>
        /// Writes an opening&lt;form&gt;tag to the response using the specified routing information.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="routeName">The name of the route to use to obtain the form post URL.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An opening&lt;form&gt;tag.</returns>
        public static MvcForm AjaxBeginRouteForm(this IHtmlHelper htmlHelper, string routeName, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            return htmlHelper.BeginRouteForm(routeName, null, FormMethod.Post, null, GetFormHtmlAttributes(htmlHelper, ajaxOptions, htmlAttributes));
        }

        /// <summary>
        /// Writes an opening &lt;form&gt; tag to the response using the specified routing information.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="routeName">The name of the route to use to obtain the form post URL.</param>
        /// <param name="antiforgery">If true,&lt;form&gt;elements will include an antiforgery token. If false, suppresses the generation an &lt;input&gt; of type "hidden" with an antiforgery token.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <returns>An opening &lt;form&gt; tag.</returns>
        public static MvcForm AjaxBeginRouteForm(this IHtmlHelper htmlHelper, string routeName, bool? antiforgery, AjaxOptions ajaxOptions)
        {
            htmlHelper.AjaxBeginRouteForm(routeName, antiforgery, ajaxOptions);
            return htmlHelper.BeginRouteForm(routeName, null, FormMethod.Post, antiforgery, GetFormHtmlAttributes(htmlHelper, ajaxOptions, null));
        }

        /// <summary>
        /// Writes an opening&lt;form&gt;tag to the response using the specified routing information.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <returns>An opening&lt;form&gt;tag.</returns>
        public static MvcForm AjaxBeginRouteForm(this IHtmlHelper htmlHelper, object routeValues, AjaxOptions ajaxOptions)
        {
            return htmlHelper.BeginRouteForm(null, routeValues, FormMethod.Post, null, GetFormHtmlAttributes(htmlHelper, ajaxOptions, null));
        }

        /// <summary>
        /// Writes an opening&lt;form&gt;tag to the response using the specified routing information.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="antiforgery">If true,&lt;form&gt;elements will include an antiforgery token. If false, suppresses the generation an &lt;input&gt; of type "hidden" with an antiforgery token.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An opening&lt;form&gt;tag.</returns>
        public static MvcForm AjaxBeginRouteForm(this IHtmlHelper htmlHelper, object routeValues, bool? antiforgery, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            return htmlHelper.BeginRouteForm(null, routeValues, FormMethod.Post, antiforgery, GetFormHtmlAttributes(htmlHelper, ajaxOptions, htmlAttributes));
        }

        /// <summary>
        /// Writes an opening&lt;form&gt;tag to the response using the specified routing information.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="routeName">The name of the route to use to obtain the form post URL.</param>
        /// <param name="antiforgery">If true,&lt;form&gt;elements will include an antiforgery token. If false, suppresses the generation an &lt;input&gt; of type "hidden" with an antiforgery token.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An opening&lt;form&gt;tag.</returns>
        public static MvcForm AjaxBeginRouteForm(this IHtmlHelper htmlHelper, string routeName, bool? antiforgery, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            return htmlHelper.BeginRouteForm(routeName, null, FormMethod.Post, antiforgery, GetFormHtmlAttributes(htmlHelper, ajaxOptions, htmlAttributes));
        }

        /// <summary>
        /// Writes an opening&lt;form&gt;tag to the response using the specified routing information.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="routeName">The name of the route to use to obtain the form post URL.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="antiforgery">If true,&lt;form&gt;elements will include an antiforgery token. If false, suppresses the generation an &lt;input&gt; of type "hidden" with an antiforgery token.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <returns>An opening&lt;form&gt;tag.</returns>
        public static MvcForm AjaxBeginRouteForm(this IHtmlHelper htmlHelper, string routeName, object routeValues, bool? antiforgery, AjaxOptions ajaxOptions)
        {
            return htmlHelper.BeginRouteForm(routeName, routeValues, FormMethod.Post, antiforgery, GetFormHtmlAttributes(htmlHelper, ajaxOptions, null));
        }

        /// <summary>
        /// Writes an opening&lt;form&gt;tag to the response using the specified routing information.
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="routeName">The name of the route to use to obtain the form post URL.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="antiforgery">If true,&lt;form&gt;elements will include an antiforgery token. If false, suppresses the generation an &lt;input&gt; of type "hidden" with an antiforgery token.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An opening&lt;form&gt;tag.</returns>
        public static MvcForm AjaxBeginRouteForm(this IHtmlHelper htmlHelper, string routeName, object routeValues, bool? antiforgery, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            return htmlHelper.BeginRouteForm(routeName, routeValues, FormMethod.Post, antiforgery, GetFormHtmlAttributes(htmlHelper, ajaxOptions, htmlAttributes));
        }
        #endregion

        #endregion

        #region Helpers
        private static IDictionary<string, object> GetFormHtmlAttributes(IHtmlHelper htmlHelper, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            htmlHelper.ViewContext.HttpContext.Items["UnobtrusiveAjaxScriptNeeded"] = true;
            ajaxOptions ??= new AjaxOptions();

            var ajaxAttributes = AjaxConfigurationExtensions.UnobtrusiveJavaScriptEnabled ?
                ajaxOptions.ToUnobtrusiveHtmlAttributes() :
                new Dictionary<string, object>
                {
                    ["onclick"] = FormOnClickValue,
                    ["onsubmit"] = GenerateAjaxScript(ajaxOptions, FormOnSubmitFormat)
                };

            return Utilities.MergeAttributes(htmlAttributes, ajaxAttributes);
        }

        private static IDictionary<string, object> GetLinkHtmlAttributes(IHtmlHelper htmlHelper, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            htmlHelper.ViewContext.HttpContext.Items["UnobtrusiveAjaxScriptNeeded"] = true;
            ajaxOptions ??= new AjaxOptions();

            var ajaxAttributes = AjaxConfigurationExtensions.UnobtrusiveJavaScriptEnabled ?
                ajaxOptions.ToUnobtrusiveHtmlAttributes() :
                new Dictionary<string, object> { ["onclick"] = GenerateAjaxScript(ajaxOptions, LinkOnClickFormat) };

            return Utilities.MergeAttributes(htmlAttributes, ajaxAttributes);
        }

        private static string GenerateAjaxScript(AjaxOptions ajaxOptions, string scriptFormat)
        {
            string optionsString = ajaxOptions.ToJavascriptString();
            return string.Format(CultureInfo.InvariantCulture, scriptFormat, optionsString);
        }
        #endregion

        /// <summary>
        /// Render The <script /> tag for jquery-unobtrusive-ajax based on configs (UseCdn or embedded - InjectScriptIfNeeded or always)
        /// </summary>
        /// <param name="htmlHelper">htmlHelper</param>
        /// <returns>The <script /> tag for jquery-unobtrusive-ajax</returns>
        public static IHtmlContent RenderUnobtrusiveAjaxScript(this IHtmlHelper htmlHelper)
        {
            if (AjaxConfigurationExtensions.InjectScriptIfNeeded &&
                htmlHelper.ViewContext.HttpContext.Items.ContainsKey("UnobtrusiveAjaxScriptNeeded") == false)
            {
                return HtmlString.Empty;
            }

            var script = AjaxConfigurationExtensions.UseCdn ?
                "<script src=\"https://cdnjs.cloudflare.com/ajax/libs/jquery-ajax-unobtrusive/3.2.6/jquery.unobtrusive-ajax.min.js\" integrity=\"sha512-DedNBWPF0hLGUPNbCYfj8qjlEnNE92Fqn7xd3Sscfu7ipy7Zu33unHdugqRD3c4Vj7/yLv+slqZhMls/4Oc7Zg==\" crossorigin=\"anonymous\"></script>" :
                "<script src=\"/scripts/jquery.unobtrusive-ajax.min.js\"></script>";

            return new HtmlString(script);
        }
    }
}