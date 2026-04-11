using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Domain.Entities;
using UserManagement.DTO;
using UserManagement.Infrastructure.Repositories.Interfaces;
using UserManagement.Infrastructure.Services.Interfaces;

namespace UserManagement.Infrastructure.Services;

public class UserManagementService : IUserManagementService
{
    private readonly IUserManagementRepository _userManagementRepository;
    public UserManagementService(IUserManagementRepository userManagementRepository)
    {
        _userManagementRepository = userManagementRepository;
    }
    public async Task<string> CreateUserAsync(CreateUserRequestDto createUserRequestDto)
    {
        // Map CreateUserRequestDto to User entity
        string result = string.Empty;
        User user = new User
        {
            FirstName = createUserRequestDto.FirstName,
            LastName = createUserRequestDto.LastName,
            Email = createUserRequestDto.Email,
            UserName = createUserRequestDto.UserName,
            Password = createUserRequestDto.Password,
            IsActive = createUserRequestDto.IsActive
        };

        int temp = await _userManagementRepository.CreateUserAsync(user);
        if (temp > 0)
        {
            result = "User created successfully.";
        }
        else
        {
            result = "Failed to create user.";
        }
        return result;
    }

    public async Task<bool> IsUserExistsAsync(string userName)
    {
        var user = await _userManagementRepository.IsUserExistsAsync(userName);
        if (user != null)
        {
            return true;
        }
        return false;
    }

    public async Task<UserDto> LoginAsync(string userName, string password)
    {
        UserDto user = new UserDto();
        var login = await _userManagementRepository.LoginAsync(userName, password);
        if (login != null)
        {
            user = new UserDto
            {
                Id = login.Id,
                FirstName = login.FirstName,
                LastName = login.LastName,
                Email = login.Email,
                UserName = login.UserName,
                Password = login.Password,
                IsActive = login.IsActive
            };           
        }
        return user;
    }
}
