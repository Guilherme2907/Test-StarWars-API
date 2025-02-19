using UDS.Test.Application.Interfaces;
using UDS.Test.Application.Services.Character;
using UDS.Test.Repositories.Respositories;

namespace UDS.Test.Api.Configurations;

public static class ServicesConfigurations
{
    public static IServiceCollection AddServicesConfig(this IServiceCollection services)
    {
        services
            .AddScoped<IStarWarRepository, StarWarRepository>()
            .AddScoped<ICharacterService, CharacterService>();

        return services;
    }
}
