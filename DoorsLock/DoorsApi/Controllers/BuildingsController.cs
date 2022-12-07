using DoorsApi.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace DoorsApi.Controllers;

[ApiController]
[Route("[Contoller]")]
public class BuildingsController : ControllerBase
{
    private readonly IBuildingsService _buildingsService;

    public BuildingsController(IBuildingsService buildingsService)
    {
        _buildingsService = buildingsService ?? throw new ArgumentNullException(nameof(buildingsService));
    }

    //Get Building by Id

    //Get Buildings

    //Create Building
}