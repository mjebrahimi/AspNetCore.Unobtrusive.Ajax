using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Unobtrusive.Ajax.Demo.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return SweetAlert("Oops!", "Please enter your name.", "warning");
        }

        return SweetAlert($"Hello {name}", "Message returned from Server!", "success");
    }

    [HttpPost]
    [AjaxOnly]
    public IActionResult AjaxMethod(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return SweetAlert("Oops!", "Please enter your name.", "warning");
        }

        return SweetAlert($"Hello {name}", "Message returned from Server!", "success");
    }

    [HttpPost]
    [AjaxOnly]
    [ValidateAntiForgeryToken]
    public IActionResult AntiForgeryMethod(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return SweetAlert("Oops!", "Please enter your name.", "warning");
        }

        return SweetAlert($"Hello {name}", "Message returned from Server!", "success");
    }

    [HttpPost]
    [AjaxOnly]
    [ValidateAntiForgeryToken]
    public IActionResult UploadFile(IFormFile file)
    {
        if (file == null)
        {
            return SweetAlert("Oops!", "Please select a file for upload.", "warning");
        }

        return SweetAlert("Upload Success", $"File: {file.FileName} - Size: {file.Length} Bytes", "success");
    }

    private IActionResult SweetAlert(string title, string message, string type)
    {
        return Content($"swal ('{title}',  '{message}',  '{type}')", "text/javascript");
    }
}
