using CrowdFestWebApp.Models;

namespace CrowdFestWebApp.ApiClient;

public class AuthenticationApiClient
{
    private readonly HttpClient _httpClient;
    public AuthenticationApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string?> LoginPlannerAsync(LoginDto content)
    {
        var response = await _httpClient.PostAsJsonAsync("/Planner", content);
        if (!response.IsSuccessStatusCode) return null;

        return await response.Content.ReadAsStringAsync();
    }
    public async Task<string?> LoginOrganizationAsync(LoginDto content)
    {
        var response = await _httpClient.PostAsJsonAsync("/Organisation", content);
        if (!response.IsSuccessStatusCode) return null;

        return await response.Content.ReadAsStringAsync();
    }
}