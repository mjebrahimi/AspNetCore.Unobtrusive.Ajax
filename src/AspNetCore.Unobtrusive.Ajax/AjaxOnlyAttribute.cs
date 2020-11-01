using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Routing;
using System;

namespace AspNetCore.Unobtrusive.Ajax
{
    /// <summary>
    /// Determines whether the annotated action is ajax only.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class AjaxOnlyAttribute : ActionMethodSelectorAttribute
    {
        /// <summary>
        /// Determines whether the annotated action is ajax only.
        /// </summary>
        public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
        {
            return routeContext.HttpContext.Request.IsAjaxRequest();
        }
    }
}