using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.Repositories.Interfaces;

public interface IUserManagementRepository
{
    Task<int> CreateUserAsync(User user);
    Task<User> LoginAsync(string userName, string password);
    Task<User> IsUserExistsAsync(string userName);
}
