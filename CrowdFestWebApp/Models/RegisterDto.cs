namespace CrowdFestWebApp.Models;

public class RegisterDto
{
    public string DisplayName { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }

    public RegisterDto()
    {
        DisplayName = String.Empty;
        EmailAddress = String.Empty;
        Password = String.Empty;
    }
}