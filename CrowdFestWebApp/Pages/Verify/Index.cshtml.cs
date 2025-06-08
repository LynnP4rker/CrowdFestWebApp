using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using CrowdFestWebApp.ApiClient;
using CrowdFestWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrowdFestWebApp.Pages;

public class VerifyModel : PageModel
{
    private readonly AccountApiClient _apiClient;

    [BindProperty]
    public VerificationDto model { get; set; }

    [BindProperty(SupportsGet = true)]
    public string AccountId { get; set; }

    public VerifyModel(ILogger<LoginModel> logger, AccountApiClient apiClient)
    {
        _apiClient = apiClient;
        AccountId = String.Empty;
    }

    public async Task<IActionResult> OnPost()
    {
        model.Id = new Guid(AccountId);
        string? response = await _apiClient.VerifyAccountAsync(model);

        if (!ModelState.IsValid)
        {
            return Page();
        }

        return RedirectToPage("/Account/Login");
    }
}