using CrowdFestWebApp.Models;

namespace CrowdFestWebApp.ApiClient;

public class LocationApiClient
{
    private readonly HttpClient _httpClient;

    public LocationApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Guid> CreateNewLocationAsync(LocationDto content)
    {
        var response = await _httpClient.PostAsJsonAsync("Location", content);
        return await response.Content.ReadFromJsonAsync<Guid>();
    }

    public async Task<List<LocationDto>> ListLocationsForPlannerAsync()
    {
        var response = await _httpClient.GetAsync("Locations");
        response.EnsureSuccessStatusCode();

        var locations = await response.Content.ReadFromJsonAsync<List<LocationDto>>();

        return locations ?? new List<LocationDto>();
    }
}