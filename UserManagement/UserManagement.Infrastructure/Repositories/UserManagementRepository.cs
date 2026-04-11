using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Repositories.Interfaces;

namespace UserManagement.Infrastructure.Repositories;

internal class UserManagementRepository : IUserManagementRepository
{
    private readonly UserManagementDbContext _dbContext;

    public UserManagementRepository(UserManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CreateUserAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
        return await _dbContext.SaveChangesAsync();        
    }

    public async Task<User> IsUserExistsAsync(string userName)
    {
       return await _dbContext.Users.FirstAsync(u => u.UserName == userName);
    }

    public Task<User> LoginAsync(string userName, string password)
    {
        return _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password);
    }
}
