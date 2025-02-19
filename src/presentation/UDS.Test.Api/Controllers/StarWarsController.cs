using Microsoft.AspNetCore.Mvc;
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

    [HttpGet("characters")]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        return Ok(await _characterService.GetCharacters(cancellationToken));
    }
}
