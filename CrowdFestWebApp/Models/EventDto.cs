using CrowdFestWebApp.Enums;

namespace CrowdFestWebApp.Models;

public class EventDto
{
    public Guid id { get; set; }
    public Guid groupId { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public Category category { get; set; }
    public Guid themeId { get; set; }
    public DateOnly date { get; set; }
    public TimeSpan time { get; set; }
    public Guid locationId { get; set; }
    public Priority priority { get; set; }
    public int attendees { get; set; }
    public int absentees { get; set; }

    public EventDto()
    {
        title = String.Empty;
        description = String.Empty;
    }

}