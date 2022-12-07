using DoorsApi.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace DoorsApi.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;
    public UsersController(IUsersService usersService)
    {
        _usersService = usersService ?? throw new ArgumentNullException(nameof(usersService));
    }

    //Get user by id

    //Get all users / by criteria

    //Post/create user

    // update user... eg promotion
}