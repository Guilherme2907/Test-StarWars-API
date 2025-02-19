using Microsoft.Extensions.DependencyInjection;
using RestEase;
using UDS.Test.Repositories.Restease;

namespace UDS.Test.Api.Configurations;

public static class RestEaseConfigurations
{
    public static IServiceCollection AddRestEaseConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(RestClient.For<IStarWarsApi>(configuration["BaseAddress"]));

        return services;
    }
}
