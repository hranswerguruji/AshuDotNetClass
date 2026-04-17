using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Repositories.Interfaces;

namespace UserManagement.Infrastructure.Repositories;

public class UserManagementRepository : IUserManagementRepository
{
    private readonly UserManagementDbContext _dbContext;

    public UserManagementRepository(UserManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    // This method is responsible for creating a new user in the database.
    // It takes a User object as input, adds it to the Users DbSet, and then saves the changes to the database.
    // The method returns the number of state entries written to the database,
    // which is typically 1 if the user was successfully created.
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
