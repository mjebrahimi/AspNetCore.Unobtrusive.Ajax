using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Microsoft.AspNetCore.Mvc.Rendering
{
    /// <summary>
    /// Represents option settings for running Ajax scripts.
    /// </summary>
    public class AjaxOptions
    {
        private static readonly Regex _idRegex = new Regex(@"[.:[\]]");
        private string _confirm;
        private string _httpMethod;
        private InsertionMode _insertionMode = InsertionMode.Replace;
        private string _loadingElementId;
        private string _onBegin;
        private string _onComplete;
        private string _onFailure;
        private string _onSuccess;
        private string _updateTargetId;
        private string _url;

        /// <summary>
        /// Gets or sets the message to display in a confirmation window before a request is submitted.
        /// </summary>
        public string Confirm
        {
            get { return _confirm ?? string.Empty; }
            set { _confirm = value; }
        }

        /// <summary>
        /// Gets or sets the HTTP request method ("Get" or "Post").
        /// </summary>
        public string HttpMethod
        {
            get { return _httpMethod ?? string.Empty; }
            set { _httpMethod = value; }
        }

        /// <summary>
        /// Gets or sets the mode that specifies how to insert the response into the target DOM element.
        /// </summary>
        public InsertionMode InsertionMode
        {
            get { return _insertionMode; }
            set
            {
                switch (value)
                {
                    case InsertionMode.Replace:
                    case InsertionMode.InsertAfter:
                    case InsertionMode.InsertBefore:
                    case InsertionMode.ReplaceWith:
                        _insertionMode = value;
                        return;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(value));
                }
            }
        }

        internal string InsertionModeString
        {
            get
            {
                return InsertionMode switch
                {
                    InsertionMode.Replace => "Sys.Mvc.InsertionMode.replace",
                    InsertionMode.InsertBefore => "Sys.Mvc.InsertionMode.insertBefore",
                    InsertionMode.InsertAfter => "Sys.Mvc.InsertionMode.insertAfter",
                    _ => ((int)InsertionMode).ToString(CultureInfo.InvariantCulture),
                };
            }
        }

        internal string InsertionModeUnobtrusive
        {
            get
            {
                return InsertionMode switch
                {
                    InsertionMode.Replace => "replace",
                    InsertionMode.InsertBefore => "before",
                    InsertionMode.InsertAfter => "after",
                    InsertionMode.ReplaceWith => "replace-with",
                    _ => ((int)InsertionMode).ToString(CultureInfo.InvariantCulture),
                };
            }
        }

        /// <summary>
        /// Gets or sets a value, in milliseconds, that controls the duration of the animation when showing or hiding the loading element.
        /// </summary>
        public int LoadingElementDuration { get; set; }

        /// <summary>
        /// Gets or sets the id attribute of an HTML element that is displayed while the Ajax function is loading.
        /// </summary>
        public string LoadingElementId
        {
            get { return _loadingElementId ?? string.Empty; }
            set { _loadingElementId = value; }
        }

        /// <summary>
        /// Gets or sets the name of the JavaScript function to call immediately before the page is updated.
        /// </summary>
        public string OnBegin
        {
            get { return _onBegin ?? string.Empty; }
            set { _onBegin = value; }
        }

        /// <summary>
        /// Gets or sets the JavaScript function to call when response data has been instantiated but before the page is updated.
        /// </summary>
        public string OnComplete
        {
            get { return _onComplete ?? string.Empty; }
            set { _onComplete = value; }
        }

        /// <summary>
        /// Gets or sets the JavaScript function to call if the page update fails.
        /// </summary>
        public string OnFailure
        {
            get { return _onFailure ?? string.Empty; }
            set { _onFailure = value; }
        }

        /// <summary>
        /// Gets or sets the JavaScript function to call after the page is successfully updated.
        /// </summary>
        public string OnSuccess
        {
            get { return _onSuccess ?? string.Empty; }
            set { _onSuccess = value; }
        }

        /// <summary>
        /// Gets or sets the ID of the DOM element to update by using the response from the server.
        /// </summary>
        public string UpdateTargetId
        {
            get { return _updateTargetId ?? string.Empty; }
            set { _updateTargetId = value; }
        }

        /// <summary>
        /// Gets or sets the URL to make the request to.
        /// </summary>
        public string Url
        {
            get { return _url ?? string.Empty; }
            set { _url = value; }
        }

        //public bool AllowCache { get; set; }

        internal string ToJavascriptString()
        {
            //Creates a string of the form { key1: value1, key2 : value2, ... }
            //This method is used for generating obtrusive JavaScript (using MicrosoftMvcAjax.js) which is no longer 
            //actively maintained. Consequently, we'll ignore the AllowCache option if it's set for this code path.
            StringBuilder optionsBuilder = new StringBuilder("{");
            optionsBuilder.AppendFormat(CultureInfo.InvariantCulture, " insertionMode: {0},", InsertionModeString);
            optionsBuilder.Append(PropertyStringIfSpecified("confirm", Confirm));
            optionsBuilder.Append(PropertyStringIfSpecified("httpMethod", HttpMethod));
            optionsBuilder.Append(PropertyStringIfSpecified("loadingElementId", LoadingElementId));
            optionsBuilder.Append(PropertyStringIfSpecified("updateTargetId", UpdateTargetId));
            optionsBuilder.Append(PropertyStringIfSpecified("url", Url));
            optionsBuilder.Append(EventStringIfSpecified("onBegin", OnBegin));
            optionsBuilder.Append(EventStringIfSpecified("onComplete", OnComplete));
            optionsBuilder.Append(EventStringIfSpecified("onFailure", OnFailure));
            optionsBuilder.Append(EventStringIfSpecified("onSuccess", OnSuccess));
            optionsBuilder.Length--;
            optionsBuilder.Append(" }");
            return optionsBuilder.ToString();
        }

        /// <summary>
        /// Returns the Ajax options as a collection of HTML attributes to support unobtrusive JavaScript.
        /// </summary>
        /// <returns>The Ajax options as a collection of HTML attributes to support unobtrusive JavaScript.</returns>
        public IDictionary<string, object> ToUnobtrusiveHtmlAttributes()
        {
            var result = new Dictionary<string, object>
            {
                { "data-ajax", "true" },
            };

            AddToDictionaryIfSpecified(result, "data-ajax-url", Url);
            AddToDictionaryIfSpecified(result, "data-ajax-method", HttpMethod);
            AddToDictionaryIfSpecified(result, "data-ajax-confirm", Confirm);

            AddToDictionaryIfSpecified(result, "data-ajax-begin", OnBegin);
            AddToDictionaryIfSpecified(result, "data-ajax-complete", OnComplete);
            AddToDictionaryIfSpecified(result, "data-ajax-failure", OnFailure);
            AddToDictionaryIfSpecified(result, "data-ajax-success", OnSuccess);

            if (true /*AllowCache*/)
            {
                // On the client, the absence of the data-ajax-cache attribute is equivalent to setting it to false.
                // Consequently we'll only set it if the user wants to opt into caching. 
                AddToDictionaryIfSpecified(result, "data-ajax-cache", "true");
            }

            if (!string.IsNullOrWhiteSpace(LoadingElementId))
            {
                result.Add("data-ajax-loading", EscapeIdSelector(LoadingElementId));

                if (LoadingElementDuration > 0)
                {
                    result.Add("data-ajax-loading-duration", LoadingElementDuration);
                }
            }

            if (!string.IsNullOrWhiteSpace(UpdateTargetId))
            {
                result.Add("data-ajax-update", EscapeIdSelector(UpdateTargetId));
                result.Add("data-ajax-mode", InsertionModeUnobtrusive);
            }

            return result;
        }

        #region Helpers
        private static void AddToDictionaryIfSpecified(IDictionary<string, object> dictionary, string name, string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                dictionary.Add(name, value);
            }
        }

        private static string EventStringIfSpecified(string propertyName, string handler)
        {
            if (!string.IsNullOrEmpty(handler))
            {
                return string.Format(CultureInfo.InvariantCulture, " {0}: Function.createDelegate(this, {1}),", propertyName, handler);
            }
            return string.Empty;
        }

        private static string PropertyStringIfSpecified(string propertyName, string propertyValue)
        {
            if (!string.IsNullOrEmpty(propertyValue))
            {
                string escapedPropertyValue = propertyValue.Replace("'", @"\'");
                return string.Format(CultureInfo.InvariantCulture, " {0}: '{1}',", propertyName, escapedPropertyValue);
            }
            return string.Empty;
        }

        private static string EscapeIdSelector(string selector)
        {
            // The string returned by this function is used as a value for jQuery's selector. The characters dot, colon and 
            // square brackets are valid id characters but need to be properly escaped since they have special meaning. For
            // e.g., for the id a.b, $('#a.b') would cause ".b" to treated as a class selector. The correct way to specify
            // this selector would be to escape the dot to get $('#a\.b').
            // See http://learn.jquery.com/using-jquery-core/faq/how-do-i-select-an-element-by-an-id-that-has-characters-used-in-css-notation/
            return '#' + _idRegex.Replace(selector, @"\$&");
        }
        #endregion
    }
}
