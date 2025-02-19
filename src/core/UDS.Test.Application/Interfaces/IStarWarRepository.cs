using UDS.Test.Domain.Models;

namespace UDS.Test.Application.Interfaces;

public interface IStarWarRepository
{
    Task<IEnumerable<Character>> GetCharacteres(CancellationToken cancellationToken);
}
