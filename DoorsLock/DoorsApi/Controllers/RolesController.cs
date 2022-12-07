using DoorsApi.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace DoorsApi.Controllers;

[ApiController]
[Route("api/roles")]
public class RolesController : ControllerBase
{
    private readonly IRolesService _rolesService;

    public RolesController(IRolesService rolesService)
    {
        _rolesService = rolesService;
    }
}