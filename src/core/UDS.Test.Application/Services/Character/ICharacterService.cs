namespace UDS.Test.Application.Services.Character;
using DomainModels = Domain.Models;

public interface ICharacterService
{
    Task<IEnumerable<DomainModels.Character>> GetCharacters(CancellationToken cancellationToken);
}
