namespace LibraryManagement.Validation;

public class ValidationClass
{
    public static bool IsValidBookName(string bookName)
    {
        // Example validation: Book name should not be null or empty and should be at least 3 characters long
        return !string.IsNullOrWhiteSpace(bookName) && bookName.Length >= 3;
    }
}
