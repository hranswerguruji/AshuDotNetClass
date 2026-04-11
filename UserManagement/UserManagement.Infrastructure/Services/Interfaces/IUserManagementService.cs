using UserManagement.DTO;

namespace UserManagement.Infrastructure.Services.Interfaces;

public interface IUserManagementService
{
    Task<string> CreateUserAsync(CreateUserRequestDto user);
    Task<UserDto> LoginAsync(string userName, string password);
    Task<bool> IsUserExistsAsync(string userName);
}
