namespace CrowdFestWebApp.Models;

public class LoginDto
{
    public string EmailAddress { get; set; }
    public string Password { get; set; }

    public LoginDto()
    {
        EmailAddress = String.Empty;
        Password = String.Empty;
    }
}