using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models.Entities;

public class Employee
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [MaxLength(100)]
    public string? SecondName { get; set; }

    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [MaxLength(150)]
    public string Email { get; set; } = string.Empty;

    [Phone]
    [MaxLength(10)]
    public string? Mobile { get; set; }

    [MaxLength(250)]
    public string? Address { get; set; }
}
