namespace LibraryManagement.Models.Dtos;

public class BookDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public int Quantity { get; set; }

    public string Author { get; set; }

    public string Edition { get; set; }

    public string Description { get; set; }

    public string Status { get; set; }
}

