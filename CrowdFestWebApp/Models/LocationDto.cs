using CrowdFestWebApp.Enums;

namespace CrowdFestWebApp.Models;

public class LocationDto
{
    public Guid locationid { get; set; }
    public Guid plannerid { get; set; }
    public string address1 { get; set; }
    public string? address2 { get; set; }
    public string city { get; set; }
    public County county { get; set; }
    public string postCode { get; set; }

    public LocationDto()
    {
        address1 = String.Empty;
        city = String.Empty;
        postCode = String.Empty;
    }
}