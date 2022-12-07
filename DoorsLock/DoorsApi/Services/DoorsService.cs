using DoorEmulator;
using DoorsApi.Abstractions.Repositories;
using DoorsApi.Abstractions.Services;
using DoorsApi.Dtos.History;
using DoorsApi.Models;
using MassTransit;

namespace DoorsApi.Services;

public class DoorsService : IDoorsService
{
    private readonly IDoorsRepository _doorRepository;
    private readonly IHistoryService _historyService;
    private readonly IUsersService _usersService;
    private readonly IBus _bus;

    public DoorsService(
        IBus bus,
        IHistoryService historyService,
        IUsersService usersService,
        IDoorsRepository doorRepository)
    {
        _bus = bus ?? throw new ArgumentNullException(nameof(bus));
        _historyService = historyService ?? throw new ArgumentNullException(nameof(historyService));
        _usersService = usersService ?? throw new ArgumentNullException(nameof(usersService));
        _doorRepository = doorRepository ?? throw new ArgumentNullException(nameof(doorRepository));
    }

    public async Task<Door> CreateAsync(Guid buildingId, string name, CancellationToken token = default)
    {
        // Check if building exists 

        // Create Door
        var door = new Door
        {
            Id = Guid.NewGuid(),
            // TODO: handling for no name
            Name = name,
            BuildingId = buildingId
        };

        return await _doorRepository.CreateAsync(door, token);
    }

    public async Task<Door?> GetAsync(Guid buildingId, Guid doorId, CancellationToken token = default)
    {
        // Check IfExists building => throw bad request exception
        var door = await _doorRepository.GetAsync(buildingId, doorId, token);

        return door;
    }

    public async Task<IEnumerable<Door>> GetDoors(Guid buildingId, CancellationToken token = default)
    {
        return await _doorRepository.GetAllAsync(buildingId, token);
    }

    public async Task OpenDoor(Guid buildingId, Guid doorId, Guid userId, CancellationToken token = default)
    {
        //Find user from context
        //var context = httpContextAccessor.HttpContext;

        //authorize user
        var isAuthorized = await IsDoorAuthorized(userId, buildingId, doorId, token);
        if (isAuthorized)
        {
            await _historyService.CreateAsync(new CreateHistoryRequest(buildingId, doorId, userId, Status.Open));

            //publish event for opening door
            var address = new Uri("rabbitmq://localhost/DoorService");
            var client = _bus.CreateRequestClient<OpenDoorCommand>();

            var response = await client.GetResponse<DoorOpened>(new { doorId });
        }
        // else return user not authorized & senc access denied event
        await _historyService.CreateAsync(new CreateHistoryRequest(buildingId, doorId, userId, Status.UserUnauthorized));
    }

    public async Task<bool> IsDoorAuthorized(Guid userId, Guid buildingId, Guid doorId, CancellationToken token = default)
    {
        // get door role
        var door = await _doorRepository.GetAsync(buildingId, doorId, token);
        //get user role
        var user = await _usersService.GetAsync(userId, token);

        // check if user has role
        if (user != null && door != null)
        {
            var authuser = user.UserRoles.Count(ur => door.DoorRoles.Any(dr => dr.RoleId.Equals(ur.RoleId)));
            if (authuser > 0)
            {
                return true;
            }
        }
        return false;
    }
}
