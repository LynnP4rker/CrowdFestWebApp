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

        services.AddHttpClient<EventApiClient>((serviceProvider, client) =>
        {
            var contextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
            var context = contextAccessor.HttpContext;
            var token = context?.Request.Cookies["jwt_token"];

            if (!string.IsNullOrEmpty(token))
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            client.BaseAddress = new Uri("http://localhost:5253/api/");
        });

        services.AddHttpClient<LocationApiClient>((serviceProvider, client) =>
        {
            var contextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
            var context = contextAccessor.HttpContext;
            var token = context?.Request.Cookies["jwt_token"];

            if (!string.IsNullOrEmpty(token))
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            client.BaseAddress = new Uri("http://localhost:5253/api/");
        });

        services.AddHttpClient<ThemeApiClient>(client =>
        {
            client.BaseAddress = new Uri("http://localhost:5253/api/");
        });

        services.AddHttpClient<PlannerApiClient>((serviceProvider, client) =>
        {
            var contextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
            var context = contextAccessor.HttpContext;
            var token = context?.Request.Cookies["jwt_token"];

            if (!string.IsNullOrEmpty(token))
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            client.BaseAddress = new Uri("http://localhost:5253/api/");
        });

        services.AddHttpContextAccessor();

        return services;
    }
}