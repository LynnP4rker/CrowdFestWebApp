namespace CrowdFestWebApp.Models;

public class VerificationModel
{
    public Guid id { get; set; }
    public string otp { get; set; }

    public VerificationModel()
    {
        otp = String.Empty;
    }
}