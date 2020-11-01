using Microsoft.AspNetCore.Http;
using System;

namespace AspNetCore.Unobtrusive.Ajax
{
    /// <summary>
    /// Represents a class that extends the HttpRequest class by adding the ability to determine whether an HTTP request is an AJAX request.
    /// </summary>
    public static class AjaxRequestExtensions
    {
        /// <summary>
        /// Determines whether the specified HTTP request is an AJAX request.
        /// </summary>
        /// <param name="request">The HTTP request.</param><exception cref="T:System.ArgumentNullException">The <paramref name="request"/> parameter is null (Nothing in Visual Basic).</exception>
        /// <returns>true if the specified HTTP request is an AJAX request; otherwise, false.</returns>
        public static bool IsAjaxRequest(this HttpRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return request.Headers != null && request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }
    }
}
