namespace CrowdFestWebApp.Models;

public class GroupDto
{
    public Guid id { get; set; }
    public string name { get; set; }
    public string nameNormalised { get; set; }
    public string description { get; set; }
    public bool isOrganisationGroup { get; set; }

    public GroupDto()
    {
        name = String.Empty;
        nameNormalised = String.Empty;
        description = String.Empty;
    }
}