using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrowdFestWebApp.Pages;

public class RegisterModel : PageModel
{
    private readonly ILogger<RegisterModel> _logger;

    public RegisterModel(ILogger<RegisterModel> logger)
    {
        _logger = logger;
    }

    public IActionResult OnPost()
    {
        return RedirectToPage("/Register/Index");
    }
}