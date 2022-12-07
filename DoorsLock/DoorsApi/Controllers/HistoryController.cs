using DoorsApi.Abstractions.Services;
using DoorsApi.Dtos.History;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/history")]
public class HistoryController : ControllerBase
{
    private readonly IHistoryService _historyService;
    public HistoryController(IHistoryService historyService)
    {
        _historyService = historyService ?? throw new ArgumentNullException(nameof(historyService));
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllAsync([FromHeader] Guid userClientId, [FromBody] GetHistoryRequest request)
    {
        var result = await _historyService.GetAllAsync(
            userClientId: userClientId,
            request);

        return Ok(result);
    }
}