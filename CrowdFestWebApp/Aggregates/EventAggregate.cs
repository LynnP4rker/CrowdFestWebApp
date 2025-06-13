using CrowdFestWebApp.Models;

namespace CrowdFestWebApp.Aggregate;

public class EventAggregate
{
    public EventDto Event { get; set; }
    public LocationDto Location { get; set; }

    public EventAggregate()
    {
        Event = null!;
        Location = null!;
    }

}