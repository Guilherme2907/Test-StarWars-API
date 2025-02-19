using RestEase;
using UDS.Test.Repositories.Responses;

namespace UDS.Test.Repositories.Restease;

public interface IStarWarsApi
{
    [Get("all.json")]
    Task<IEnumerable<CharacterResponse>> GetCharacteres(CancellationToken cancellationToken);
}
