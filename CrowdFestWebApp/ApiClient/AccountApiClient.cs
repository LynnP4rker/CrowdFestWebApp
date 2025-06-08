using CrowdFestWebApp.Models;

namespace CrowdFestWebApp.ApiClient;

public class AccountApiClient
{
    private readonly HttpClient _httpClient;
    public AccountApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string?> CreatePlannerAccountAsync(RegisterDto content)
    {
        var response = await _httpClient.PostAsJsonAsync("Account/Planner", content);
        if (!response.IsSuccessStatusCode) return null;

        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string?> VerifyAccountAsync(VerificationDto content)
    {
        var response = await _httpClient.PostAsJsonAsync("Account/Planner/otp/verify", content);
        if (!response.IsSuccessStatusCode) return null;

        return await response.Content.ReadAsStringAsync();
    }
}