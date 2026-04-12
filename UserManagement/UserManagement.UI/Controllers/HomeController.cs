using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UserManagement.DTO;
using UserManagement.Infrastructure.Services.Interfaces;
using UserManagement.UI.Models;

namespace UserManagement.UI.Controllers
{
    public class HomeController : Controller
    {
        IUserManagementService _iUserManagementService;
        public HomeController(IUserManagementService iUserManagementService)
        {
            _iUserManagementService = iUserManagementService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateUserRequestDto createUserRequestDto)
        {
            string result = await _iUserManagementService.CreateUserAsync(createUserRequestDto);
            ViewBag.Message = result;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
