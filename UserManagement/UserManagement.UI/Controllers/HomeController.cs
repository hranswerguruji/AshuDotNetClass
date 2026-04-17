using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UserManagement.DTO;
using UserManagement.Infrastructure.Services.Interfaces;
using UserManagement.UI.Helpers;
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
            // validate 
            string result = await _iUserManagementService.CreateUserAsync(createUserRequestDto);
            ViewBag.Message = result;
            return View();
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
        {
            if (!ValidationHelper.IsValidUserName(loginRequestDto.UserName))
            {
                ViewBag.Message = "Invalid username format.";
                return View();
            }

            if (!ValidationHelper.IsValidPassword(loginRequestDto.Password))
            {
                ViewBag.Message = "Invalid password format.";
                return View();
            }

            // validate 
            var result = await _iUserManagementService.LoginAsync(loginRequestDto.UserName, loginRequestDto.Password);

            if (result != null && result.Email != null)
            {
                //ViewBag.Message = $"Welcome {result.FirstName} {result.LastName}";
                // Store user information in session or cookie as needed

                HttpContext.Session.SetString("Name", result.FirstName +" "+ result.LastName);
                HttpContext.Session.SetString("Email", result.Email);

                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                ViewBag.Message = "Invalid username or password.";
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
