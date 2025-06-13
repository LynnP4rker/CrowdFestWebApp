using System.Security.Claims;
using CrowdFestWebApp.ApiClient;
using CrowdFestWebApp.Enums;
using CrowdFestWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CrowdFestWebApp.Pages;

public class EventModel : PageModel
{
    private readonly EventApiClient _eventApiClient;
    private readonly LocationApiClient _locationApiClient;
    private readonly PlannerApiClient _plannerApiClient;
    private readonly ILogger<EventModel> _logger;

    [BindProperty]
    public EventDto eventModel { get; set; }

    [BindProperty]
    public LocationDto locationModel { get; set; }

    [BindProperty]
    public Guid SelectedGroupId { get; set; }

    [BindProperty]
    public Guid SelectedThemeId { get; set; }

    [BindProperty]
    public County County { get; set; }
    public List<SelectListItem> groups { get; set; }
    public List<SelectListItem> themes { get; set; }

    [BindProperty(SupportsGet = true)]
    public Guid PlannerId { get; set; }

    public EventModel(
        ILogger<EventModel> logger,
        PlannerApiClient plannerApiClient,
        EventApiClient eventApiClient,
        LocationApiClient locationApiClient
    )
    {
        _logger = logger;
        _eventApiClient = eventApiClient;
        _locationApiClient = locationApiClient;
        _plannerApiClient = plannerApiClient;
    }

    public async Task OnGetAsync()
    {
        var plannerId = User.FindFirst("sub")?.Value;
        PlannerId = new Guid(plannerId);

        var apiGroups = await _plannerApiClient.ListGroupsForPlannerAsync(PlannerId);
        var apiThemes = await _plannerApiClient.ListThemesForPlannerAsync(PlannerId);

        groups = apiGroups.Select(g => new SelectListItem
        {
            Value = g.id.ToString(),
            Text = g.name
        }).ToList();

        themes = apiThemes.Select(t => new SelectListItem
        {
            Value = t.themeId.ToString(),
            Text = t.name
        }).ToList();
    }

    public async Task<IActionResult> OnPost()
    {
        var plannerId = User.FindFirst("sub")?.Value;
        PlannerId = new Guid(plannerId);

        locationModel.county = County;
        locationModel.plannerid = PlannerId;
        var responseLocation = await _locationApiClient.CreateNewLocationAsync(locationModel);

        eventModel.groupId = SelectedGroupId;
        eventModel.themeId = SelectedThemeId;
        eventModel.locationId = responseLocation;

        string? responseEvent = await _eventApiClient.CreateNewEventAsync(eventModel);

        return Page();
    }
}