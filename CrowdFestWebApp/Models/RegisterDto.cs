namespace CrowdFestWebApp.Models;

public class RegisterDto
{
    public string displayName { get; set; }
    public string emailAddress { get; set; }
    public string password { get; set; }

    public RegisterDto()
    {
        displayName = String.Empty;
        emailAddress = String.Empty;
        password = String.Empty;
    }
}