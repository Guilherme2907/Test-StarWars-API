using UDS.Test.Application.Interfaces;
using UDS.Test.Domain.Models;
using UDS.Test.Repositories.Restease;

namespace UDS.Test.Repositories.Respositories;

public class StarWarRepository : IStarWarRepository
{
    private readonly IStarWarsApi _starWarsApi;

    public StarWarRepository(IStarWarsApi starWarsApi)
    {
        _starWarsApi = starWarsApi;
    }

    public async Task<IEnumerable<Character>> GetCharacteres(CancellationToken cancellationToken)
    {
        var apiResponse = await _starWarsApi.GetCharacteres(cancellationToken);

        var characteres = apiResponse.Select(a =>
        {
            return new Character(
                a.Id,
                a.Name,
                a.Height,
                a.Mass,
                a.Gender,
                a.Homeworld,
                a.Wiki,
                a.Image,
                a.Born,
                a.BornLocation,
                a.Died,
                a.DiedLocation,
                a.Affiliations,
                a.Masters
            );
        });

        return characteres;
    }
}
