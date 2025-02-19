using RestEase;

namespace UDS.Test.Repositories.Restease;

public interface IStarWarsApi
{
    [Get("all.json")]
    Task GetCharacteres(CancellationToken cancellationToken);
}
