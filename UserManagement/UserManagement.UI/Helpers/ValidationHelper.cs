namespace UserManagement.UI.Helpers;

public class ValidationHelper
{
    public static bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
    public static bool IsValidPassword(string password)
    {
        // Add your password validation logic here
        return !string.IsNullOrEmpty(password) && password.Length >= 6;
    }
    public static bool IsValidUserName(string userName)
    {
        // Add your username validation logic here
        return !string.IsNullOrEmpty(userName) && userName.Length >= 3;
    }

    public static bool IsValidName(string name)
    {
        // Add your name validation logic here
        return !string.IsNullOrEmpty(name) && name.Length >= 2;
    }

}