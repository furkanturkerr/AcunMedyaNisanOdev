using Microsoft.Extensions.DependencyInjection;
using Business.Rules;
using Core.Rules;

namespace Business;

public static class BusinessServiceRegistration
{
    public static void AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<ApplicantBusinessRules>();
        services.AddScoped<BootcampBusinessRules>();
        services.AddScoped<ApplicationBusinessRules>();
        services.AddScoped<BlacklistBusinessRules>();
    }
}
