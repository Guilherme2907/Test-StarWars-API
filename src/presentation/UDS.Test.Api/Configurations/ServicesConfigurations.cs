using Microsoft.Extensions.DependencyInjection;
using RestEase;
using UDS.Test.Application.Interfaces;
using UDS.Test.Application.Services.Character;
using UDS.Test.Domain.Models;
using UDS.Test.Repositories.Respositories;
using UDS.Test.Repositories.Restease;

namespace UDS.Test.Api.Configurations;

public static class ServicesConfigurations
{
    public static IServiceCollection AddServicesConfig(this IServiceCollection services)
    {
        services
            .AddScoped<IStarWarRepository, StarWarRepository>()
            .AddScoped<CharacterService, CharacterService>();

        return services;
    }
}
