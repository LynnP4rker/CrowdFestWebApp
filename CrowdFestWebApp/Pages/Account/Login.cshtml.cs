using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using CrowdFestWebApp.ApiClient;
using CrowdFestWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrowdFestWebApp.Pages;

public class LoginModel : PageModel
{
    private readonly AuthenticationApiClient _apiClient;
    private readonly ILogger<LoginModel> _logger;

    [BindProperty]
    public Login Login { get; set; } 

    public LoginModel(ILogger<LoginModel> logger, AuthenticationApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public async Task<IActionResult> OnPost()
    {
        string? token = await _apiClient.LoginPlannerAsync(Login);
        
        if (!ModelState.IsValid)
        {
            return Page();
        }

        return Page();
    }
}