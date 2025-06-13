using CrowdFestWebApp.Aggregate;
using CrowdFestWebApp.Models;

namespace CrowdFestWebApp.ApiClient;

public class PlannerApiClient
{
    private readonly HttpClient _httpClient;
    public PlannerApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<EventAggregate>> ListEventsForPlannerAsync(Guid id)
    {
        var response = await _httpClient.GetAsync($"PlannerGroup/{id}");
        if (!response.IsSuccessStatusCode)
            return Enumerable.Empty<EventAggregate>();

        IEnumerable<PlannerGroupDto>? plannerGroups = await response.Content.ReadFromJsonAsync<List<PlannerGroupDto>>()
            ?? new List<PlannerGroupDto>();

        var locationResponse = await _httpClient.GetAsync($"Location/planner/{id}");
        IEnumerable<LocationDto>? locations = await locationResponse.Content.ReadFromJsonAsync<List<LocationDto>>()
            ?? new List<LocationDto>();

        var locationMap = locations.ToDictionary(l => l.locationid);

        var eventTasks = plannerGroups.Select(async plannerGroup =>
        {
            var eventResponse = await _httpClient.GetAsync($"Event/groups/{plannerGroup.groupId}");
            if (!eventResponse.IsSuccessStatusCode)
                return Enumerable.Empty<EventAggregate>();

            var events = await eventResponse.Content.ReadFromJsonAsync<List<EventDto>>()
                ?? Enumerable.Empty<EventDto>();

            return events.Select(e => new EventAggregate
            {
                Event = e,
                Location = locationMap[e.locationId]
            });
        });

        var events = await Task.WhenAll(eventTasks);
        return events.SelectMany(e => e);
    }

    public async Task<IEnumerable<GroupDto>> ListGroupsForPlannerAsync(Guid id)
    {
        var response = await _httpClient.GetAsync($"PlannerGroup/{id}");
        if (!response.IsSuccessStatusCode)
            return Enumerable.Empty<GroupDto>();

        IEnumerable<PlannerGroupDto>? plannerGroups = await response.Content.ReadFromJsonAsync<List<PlannerGroupDto>>();
        if (plannerGroups is null)
            return Enumerable.Empty<GroupDto>();

        var groups = new List<GroupDto>();

        foreach (PlannerGroupDto plannerGroup in plannerGroups)
        {
            var responseMessage = await _httpClient.GetAsync($"Group/{plannerGroup.groupId}");
            if (!response.IsSuccessStatusCode)
                return Enumerable.Empty<GroupDto>();

            var group = await responseMessage.Content.ReadFromJsonAsync<GroupDto>();
            if (group is null)
                return Enumerable.Empty<GroupDto>();

            groups.Add(group);
        }

        return groups;
    }

    public async Task<IEnumerable<ThemeDto>> ListThemesForPlannerAsync(Guid plannerId)
    {
        var response = await _httpClient.GetAsync($"Theme/{plannerId}");
        if (!response.IsSuccessStatusCode) return Enumerable.Empty<ThemeDto>();

        var themes = await response.Content.ReadFromJsonAsync<List<ThemeDto>>();
        if (themes is null) return Enumerable.Empty<ThemeDto>();
        return themes;
    }
}