namespace CrowdFestWebApp.Models;

public class ThemeDto
{
    public int id { get; set; }
    public Guid themeId { get; set; }
    public string name { get; set; }
    public ThemeDto()
    {
        name = String.Empty;
    }
}