using System.Linq.Expressions;
using System.Xml.Linq;
using UDS.Test.Application.Common;
using UDS.Test.Application.Dtos;
using UDS.Test.Application.Interfaces;
using Models = UDS.Test.Domain.Models;

namespace UDS.Test.Application.Services.Character;

public class CharacterService : ICharacterService
{
    private readonly IStarWarRepository _starWarRepository;

    public CharacterService(IStarWarRepository starWarRepository)
    {
        _starWarRepository = starWarRepository;
    }

    public async Task<CharacterDto> GetCharacterById(int id, CancellationToken cancellationToken)
    {
        var characters = await _starWarRepository.GetCharacteres(cancellationToken);

        var character = characters.Single(c => c.Id == id);

        return CharacterDto.FromCharacter(character);
    }

    public async Task<PaginatedListInputOutput<CharacterDto>> GetCharacters(PaginatedListInput input, CancellationToken cancellationToken)
    {
        var characters = await _starWarRepository.GetCharacteres(cancellationToken);

        var filteredCharacters = FilterCharacters(input.Search, input.SearchBy, characters.ToList());

        var paginatedCharacters = PagineCharacters(input, filteredCharacters);

        var total = filteredCharacters.Count();

        return new PaginatedListInputOutput<CharacterDto>
        (
            input.Page,
            input.PerPage,
            total,
            paginatedCharacters.Select(CharacterDto.FromCharacter).ToList().AsReadOnly()
        );
    }

    public IEnumerable<T> FilterCharacters<T>(string search, string searchBy, IList<T> list)
    {
        //if (string.IsNullOrWhiteSpace(searchBy) || !list.Any())
        //    return list;

        //var property = typeof(T).GetProperty(searchBy);
        //if (property is null)
        //    return list;

        //return list.Where(c =>
        //{
        //    var value = property.GetValue(c);
        //    return value != null && value.ToString()!.Contains(search, StringComparison.InvariantCultureIgnoreCase);
        //});

        if (string.IsNullOrWhiteSpace(searchBy)) return list;

        var parameter = Expression.Parameter(typeof(T), "x");
        var property = Expression.Property(parameter, searchBy);
        var toStringMethod = typeof(object).GetMethod("ToString");
        var toStringCall = Expression.Call(property, toStringMethod);
        var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
        var searchExpression = Expression.Constant(search, typeof(string));
        var containsCall = Expression.Call(toStringCall, containsMethod, searchExpression);
        var lambda = Expression.Lambda<Func<T, bool>>(containsCall, parameter);

        return list.AsQueryable().Where(lambda);
    }

    public IEnumerable<Models.Character> PagineCharacters(PaginatedListInput input, IEnumerable<Models.Character> characters)
    {
        var toSkip = (input.Page - 1) * input.PerPage;

        characters = characters.Skip(toSkip).Take(input.PerPage);

        return characters;
    }
}
