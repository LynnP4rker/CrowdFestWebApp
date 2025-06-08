using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using CrowdFestWebApp.ApiClient;
using CrowdFestWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrowdFestWebApp.Pages;

public class VerifyPageModel : PageModel
{
    private readonly AccountApiClient _apiClient;

    [BindProperty]
    public VerificationModel verificationModel { get; set; }

    [BindProperty(SupportsGet = true)]
    public string AccountId { get; set; }

    public VerifyPageModel(ILogger<LoginModel> logger, AccountApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public void OnGet()
    {
        
    }

    public async Task<IActionResult> OnPost()
    {
        verificationModel.id = new Guid(AccountId);
        string? response = await _apiClient.VerifyAccountAsync(verificationModel);

        if (!ModelState.IsValid)
        {
            return Page();
        }

        return RedirectToPage("/Account/Login");
    }
}