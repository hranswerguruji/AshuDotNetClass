using LibraryManagement.Models;
using LibraryManagement.Models.Dtos;
using LibraryManagement.Services.Interfaces;
using LibraryManagement.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;
using static Microsoft.CodeAnalysis.CSharp.SyntaxTokenParser;

namespace LibraryManagement.Controllers
{
    public class BookManageController(ILibraryManagementService libraryManagementService) : Controller
    {
        private readonly ILibraryManagementService _libraryManagementService = libraryManagementService;

        public async Task<IActionResult> Index()
        {
            IEnumerable<BookDto> books = await _libraryManagementService.GetAllBooksAsync();
            return View(books);
        }

        [HttpGet]
        public IActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(RequestCreateBookDto requestCreateBookDto)
        {
            bool isNameValid = ValidationClass.IsValidBookName(requestCreateBookDto.Name);
            if (!isNameValid)
            {
                ViewData["msg"] = "";
                ViewBag.Message = "Invalid book name. Please avoid special characters.";
                TempData["Error"] = "Invalid book name. Please avoid special characters.";
                TempData.Keep();
                Response.Redirect("Second");
                
                return View();
            }
            bool result = await _libraryManagementService.CreateBookAsync(requestCreateBookDto);
            if (result)
            {
                ViewBag.Message = "Book added successfully.";
            }
            else
            {
                ViewBag.Message = "Failed to add book.";
            }

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> UpdateBook(Guid Id)
        {
            RequestUpdateBookDto requestUpdateBookDto = new();
            var book = await _libraryManagementService.GetBookByBookIdAsync(Id);
            if (book != null)
            {
                requestUpdateBookDto.Id = book.Id;
                requestUpdateBookDto.Name = book.Name;
                requestUpdateBookDto.Quantity = book.Quantity;
                requestUpdateBookDto.Author = book.Author;
                requestUpdateBookDto.Edition = book.Edition;
                requestUpdateBookDto.Description = book.Description;
                requestUpdateBookDto.Status = book.Status;
            }
            return View(requestUpdateBookDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBook(RequestUpdateBookDto requestUpdateBookDto)
        {
            Guid bookId = requestUpdateBookDto.Id;
            bool result = await _libraryManagementService.UpdateAsync(bookId, requestUpdateBookDto);
            if (result)
            {
                ViewBag.Message = "Book Updated successfully.";
            }
            else
            {
                ViewBag.Message = "Failed to update book.";
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> DeleteBook(Guid Id)
        {
            RequestUpdateBookDto requestUpdateBookDto = new();
            var book = await _libraryManagementService.GetBookByBookIdAsync(Id);
            if (book != null)
            {
                requestUpdateBookDto.Id = book.Id;
                requestUpdateBookDto.Name = book.Name;
                requestUpdateBookDto.Quantity = book.Quantity;
                requestUpdateBookDto.Author = book.Author;
                requestUpdateBookDto.Edition = book.Edition;
                requestUpdateBookDto.Description = book.Description;
                requestUpdateBookDto.Status = book.Status;
            }
            return View(requestUpdateBookDto);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBook(RequestUpdateBookDto requestUpdateBookDto)
        {
            Guid bookId = requestUpdateBookDto.Id;
            bool result = await _libraryManagementService.DeleteAsync(bookId);
            if (result)
            {
                ViewBag.Message = "Book deleted successfully.";
            }
            else
            {
                ViewBag.Message = "Failed to delete book.";
            }
            return View();
        }

    }
}
