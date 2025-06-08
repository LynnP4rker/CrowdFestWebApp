using CrowdFestWebApp.ApiClient;
using CrowdFestWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrowdFestWebApp.Pages;

public class RegisterModel : PageModel
{
    private readonly AccountApiClient _apiClient;
    private readonly ILogger<RegisterModel> _logger;

    [BindProperty]
    public RegisterDto model { get; set; }

    public RegisterModel(ILogger<RegisterModel> logger, AccountApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public async Task<IActionResult> OnPost()
    {
        string? accountId = await _apiClient.CreatePlannerAccountAsync(model);

        if (!ModelState.IsValid)
        {
            return Page();
        }

        return RedirectToPage("/Verify/Index", new { accountId });
    }
}