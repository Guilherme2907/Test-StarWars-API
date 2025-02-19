using UDS.Test.Application.Interfaces;

namespace UDS.Test.Application.Services.Character;

public class CharacterService : ICharacterService
{
    private readonly IStarWarRepository _starWarRepository;

    public CharacterService(IStarWarRepository starWarRepository)
    {
        _starWarRepository = starWarRepository;
    }

    public Task<IEnumerable<Domain.Models.Character>> GetCharacters(CancellationToken cancellationToken)
    {
        var characters = _starWarRepository.GetCharacteres(cancellationToken);

        return characters;
    }
}
