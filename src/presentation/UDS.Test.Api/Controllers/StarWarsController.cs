using Microsoft.AspNetCore.Mvc;
using UDS.Test.Api.Models.Response;
using UDS.Test.Application.Common;
using UDS.Test.Application.Dtos;
using UDS.Test.Application.Services.Character;

namespace UDS.Test.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class StarWarsController : ControllerBase
{
    private readonly ICharacterService _characterService;

    public StarWarsController(ICharacterService characterService)
    {
        _characterService = characterService;
    }

    [HttpGet("characters/{id}")]
    public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
    {
        var response = new ApiResponse<CharacterDto>(await _characterService.GetCharacterById(id, cancellationToken));
        return Ok(response);
    }

    [HttpGet("characters")]
    public async Task<IActionResult> Get(
        [FromQuery] int? perPage,
        [FromQuery] int? page,
        [FromQuery] string? search,
        [FromQuery] string? searchBy,
        CancellationToken cancellationToken
    )
    {
        var input = new PaginatedListInput(perPage, page, search, searchBy);

        var output = await _characterService.GetCharacters(input, cancellationToken);

        var response = new ApiResponseList<CharacterDto>(output);
       
        return Ok(response);
    }
}
