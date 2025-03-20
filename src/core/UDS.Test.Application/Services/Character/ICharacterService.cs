using UDS.Test.Application.Common;
using UDS.Test.Application.Dtos;

namespace UDS.Test.Application.Services.Character;
public interface ICharacterService
{
    Task<CharacterDto> GetCharacterById(int id, CancellationToken cancellationToken);

    Task<PaginatedListInputOutput<CharacterDto>> GetCharacters(PaginatedListInput input, CancellationToken cancellationToken);
}
