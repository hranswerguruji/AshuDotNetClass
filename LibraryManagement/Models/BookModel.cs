using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models;

public class BookModel
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [StringLength(150)]
    public string Name { get; set; }

    [Range(0, int.MaxValue)]
    public int Quantity { get; set; }

    [Required]
    public string Author { get; set; }

    public string Edition { get; set; }

    public string Description { get; set; }

    public bool IsDelete { get; set; }

    public string Status { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? ModifiedDate { get; set; }
}