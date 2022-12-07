using DoorsApi.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace DoorsApi.Controllers;

[ApiController]
[Route("api/buildings/{buildingId}/doors")]
public class DoorsController : ControllerBase
{
    private readonly IDoorsService _doorService;

    public DoorsController(IDoorsService doorService)
    {
        _doorService = doorService ?? throw new ArgumentNullException(nameof(doorService));
    }

    [HttpPost("{doorId}/open")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> OpenDoor(
        [FromRoute] Guid buildingId,
        [FromRoute] Guid doorId,
        [FromHeader] Guid userId)
    {
        await _doorService.OpenDoor(buildingId, doorId, userId);
        return Ok();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateDoor(
        [FromRoute] Guid buildingId,
        [FromBody] string name)
    {
        var result = await _doorService.CreateAsync(buildingId, name);
        return Ok(result);
    }

    [HttpGet("{doorId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetDoor([FromRoute] Guid buildingId, [FromRoute] Guid doorId)
    {
        //await _doorService.OpenDoor(doorId, buildingId);
        var result = await _doorService.GetAsync(buildingId, doorId);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetDoors([FromRoute] Guid buildingId)
    {
        //await _doorService.OpenDoor(doorId, buildingId);
        var result = await _doorService.GetDoors(buildingId);

        return Ok(result);
    }
}
