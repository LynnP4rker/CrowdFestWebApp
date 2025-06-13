using System.ComponentModel.DataAnnotations;
using CrowdFestWebApp.Aggregate;
using CrowdFestWebApp.ApiClient;
using CrowdFestWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrowdFestWebApp.Pages;

[Authorize]
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly PlannerApiClient _apiClient;

    public Guid PlannerId { get; set; }
    public List<EventAggregate> EventAggregates { get; set; }


    public IndexModel(ILogger<IndexModel> logger, PlannerApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public async Task<IActionResult> OnGet()
    {
        var plannerId = User.FindFirst("sub")?.Value;
        PlannerId = new Guid(plannerId);

        var response = await _apiClient.ListEventsForPlannerAsync(PlannerId);
        EventAggregates = response.ToList();

        return Page();
    }
}
