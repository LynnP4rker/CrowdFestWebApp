using CrowdFestWebApp.Models;

namespace CrowdFestWebApp.ApiClient;

public class EventApiClient
{
    private readonly HttpClient _httpClient;
    public EventApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string?> CreateNewEventAsync(EventDto content)
    {
        var response = await _httpClient.PostAsJsonAsync("Event", content);
        if (!response.IsSuccessStatusCode) return null;

        return await response.Content.ReadAsStringAsync();
    }
}