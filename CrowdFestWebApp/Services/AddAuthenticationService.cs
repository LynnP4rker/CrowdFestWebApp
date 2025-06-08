using CrowdFestWebApp.ApiClient;

namespace CrowdFestWebApp.Services;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterWebServices(this IServiceCollection services)
    {
        services.AddHttpClient<AuthenticationApiClient>(client =>
        {
            client.BaseAddress = new Uri("http://localhost:5253/api/");
        });

        services.AddHttpClient<AccountApiClient>(client =>
        {
            client.BaseAddress = new Uri("http://localhost:5253/api/");
        });

        services.AddHttpContextAccessor();

        return services;
    }
}