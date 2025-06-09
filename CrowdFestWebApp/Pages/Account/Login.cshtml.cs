using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using CrowdFestWebApp.ApiClient;
using CrowdFestWebApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrowdFestWebApp.Pages;

public class LoginModel : PageModel
{
    private readonly AuthenticationApiClient _apiClient;
    private readonly ILogger<LoginModel> _logger;

    [BindProperty]
    public LoginDto model { get; set; } 

    public LoginModel(ILogger<LoginModel> logger, AuthenticationApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public async Task<IActionResult> OnPost()
    {
        //Step 1: Check if model state is valid
        if (!ModelState.IsValid)
        {
            return Page();
        }

        //Step 2: Receive token from API
        string? token = await _apiClient.LoginPlannerAsync(model);

        if (token is null)
            return Page();

        //Step 3: Append jwt to a cookie
        Response.Cookies.Append("jwt_token", token, new CookieOptions
        {
            HttpOnly = true,
            Secure = false,
            SameSite = SameSiteMode.Strict,
            Expires = DateTimeOffset.UtcNow.AddMinutes(15)
        });

        //Step 4: Generate a cookie
        var handler = new JwtSecurityTokenHandler();
        var jwt = handler.ReadJwtToken(token);
        var claims = jwt.Claims.ToList();

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity));

        return RedirectToPage("/Index");
    }
}