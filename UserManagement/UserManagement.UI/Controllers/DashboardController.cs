using Microsoft.AspNetCore.Mvc;

namespace UserManagement.UI.Controllers;

public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
