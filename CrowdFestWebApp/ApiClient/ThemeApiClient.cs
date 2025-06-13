using CrowdFestWebApp.Models;

namespace CrowdFestWebApp.ApiClient;

public class ThemeApiClient
{
    private readonly HttpClient _httpClient;

    public ThemeApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string?> CreateNewThemeAsync(ThemeDto content)
    {
        var response = await _httpClient.PostAsJsonAsync("Theme", content);
        if (!response.IsSuccessStatusCode) return null;

        return await response.Content.ReadAsStringAsync();
    }
}