using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure
{
    public class Class1
    {
        User user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = "John",
            LastName = "Doe",
            Email = ""
        };
    }
}
