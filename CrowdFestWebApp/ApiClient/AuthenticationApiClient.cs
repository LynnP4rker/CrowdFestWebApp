using CrowdFestWebApp.Models;

namespace CrowdFestWebApp.ApiClient;

public class AuthenticationApiClient
{
    private readonly HttpClient _httpClient;
    public AuthenticationApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string?> LoginPlannerAsync(Login login)
    {
        var response = await _httpClient.PostAsJsonAsync("/Planner", login);
        if (!response.IsSuccessStatusCode) return null;

        return await response.Content.ReadAsStringAsync();
    }
    public async Task<string?> LoginOrganizationAsync(Login login)
    {
        var response = await _httpClient.PostAsJsonAsync("/Organisation", login);
        if (!response.IsSuccessStatusCode) return null;

        return await response.Content.ReadAsStringAsync();
    }
}