using System.ComponentModel.DataAnnotations;

namespace UserManagement.Domain.Entities;

public class User : BaseEntity
{
    [Required]
    public string FirstName { get; set; }

    public string? LastName { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public bool IsActive { get; set; }

}