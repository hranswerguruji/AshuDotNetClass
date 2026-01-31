using LibraryManagement.Data;
using LibraryManagement.Models;
using LibraryManagement.Models.Dtos;
using LibraryManagement.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Services;

public class LibraryManagementService : ILibraryManagementService
{
    private readonly LibraryDbContext _dbContext;
    public LibraryManagementService(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<bool> CreateBookAsync(RequestCreateBookDto requestCreateBookDto)
    {
        try
        {
            var book = new BookModel
            {
                Name = requestCreateBookDto.Name,
                Quantity = requestCreateBookDto.Quantity,
                Author = requestCreateBookDto.Author,
                Edition = requestCreateBookDto.Edition,
                Description = requestCreateBookDto.Description,
                Status = requestCreateBookDto.Status,
                CreateDate = DateTime.Now,
                ModifiedDate = null,
                IsDelete = false
            };
            _dbContext.Books.Add(book);
            return await _dbContext.SaveChangesAsync().ContinueWith(t => t.Result > 0);
        }
        catch (Exception)
        {
            return false;
        }
    }


    public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
    {
        IEnumerable<BookDto> bookDtos = await _dbContext.Books
            .Where(b => !b.IsDelete)
            .Select(book => new BookDto
            {
                Id = book.Id,
                Name = book.Name,
                Quantity = book.Quantity,
                Author = book.Author,
                Edition = book.Edition,
                Description = book.Description,
                Status = book.Status
            })
            .ToListAsync();
        return bookDtos;
    }

    public Task<bool> UpdateAsync(Guid bookId, RequestUpdateBookDto requestUpdateBookDto)
    {
        var book = _dbContext.Books.FirstOrDefault(b => b.Id == bookId && !b.IsDelete);
        if (book == null)
        {
            return Task.FromResult(false);
        }
        book.Name = requestUpdateBookDto.Name;
        book.Quantity = requestUpdateBookDto.Quantity;
        book.Author = requestUpdateBookDto.Author;
        book.Edition = requestUpdateBookDto.Edition;
        book.Description = requestUpdateBookDto.Description;
        book.Status = requestUpdateBookDto.Status;
        book.ModifiedDate = DateTime.Now;
        return _dbContext.SaveChangesAsync().ContinueWith(t => t.Result > 0);
    }

    public Task<bool> DeleteAsync(Guid bookId)
    {
        var book = _dbContext.Books.FirstOrDefault(b => b.Id == bookId && !b.IsDelete);
        if (book == null)
        {
            return Task.FromResult(false);
        }
        book.IsDelete = true;
        book.ModifiedDate = DateTime.Now;
        return _dbContext.SaveChangesAsync().ContinueWith(t => t.Result > 0);
    }

    public async Task<BookDto> GetBookByBookIdAsync(Guid bookId)
    {
      var getBook= await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == bookId && !b.IsDelete);
        return (new BookDto
        {
            Id = getBook.Id,
            Name = getBook.Name,
            Quantity = getBook.Quantity,
            Author = getBook.Author,
            Edition = getBook.Edition,
            Description = getBook.Description,
            Status = getBook.Status
        });
    }
}
