using LibraryManagement.Models.Dtos;

namespace LibraryManagement.Services.Interfaces;

public interface ILibraryManagementService
{
    Task<bool> CreateBookAsync(RequestCreateBookDto requestCreateBookDto);
    Task<IEnumerable<BookDto>> GetAllBooksAsync();
    Task<BookDto> GetBookByBookIdAsync(Guid bookId);
    Task<bool> UpdateAsync(Guid bookId, RequestUpdateBookDto requestUpdateBookDto);
    Task<bool> DeleteAsync(Guid bookId);
}
