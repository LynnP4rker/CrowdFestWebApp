namespace CrowdFestWebApp.Models;

public class VerificationDto
{
    public Guid Id { get; set; }
    public string Otp { get; set; }

    public VerificationDto()
    {
        Otp = String.Empty;
    }
}