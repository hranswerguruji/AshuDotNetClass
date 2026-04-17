using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace UserManagement.UI.Controllers;

public class DashboardController : Controller
{
    public IActionResult Index()
    {
        string name = HttpContext.Session.GetString("Name");
        string email = HttpContext.Session.GetString("Email");
        ViewBag.Name = name;
        ViewBag.Email = email;
        return View();
    }

    [HttpGet]
    public IActionResult UserProfile()
    {
        return View();
    }

    [HttpGet]
    public IActionResult LogOut()
    {
        //HttpContext.Session.Clear();
        //HttpContext.Response.Cookies.Delete("UserSession");
        HttpContext.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}
