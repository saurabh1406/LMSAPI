namespace LMSAPI;
using LMS.Infrasturcture;
using LMS.Application;

public static class APIAppDependencyInjection
{
    public static IServiceCollection AddMainAppDI(this IServiceCollection services)
    {
        // Register your API application services here
        // Example: services.AddScoped<IYourService, YourServiceImplementation>();
        // Registering Application and Infrastructure dependencies
        services.AddApplicationDI(); // Ensure AddApplicationDI is defined in the Application namespace
        services.AddInfrastructureDI(); // Ensure AddInfrastructureDI is defined in the Infrastructure namespace
        return services;
    }
}

