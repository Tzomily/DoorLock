using DoorsApi.Abstractions.Repositories;
using DoorsApi.Abstractions.Services;
using DoorsApi.Dtos.History;
using DoorsApi.Models;

namespace DoorsApi.Services;

public class HistoryService : IHistoryService
{
    private readonly IHistoryRepository _historyRepository;
    private readonly IBuildingsService _buildingsService;
    private readonly IUsersService _usersService;

    public HistoryService(
        IHistoryRepository historyRepository,
        IBuildingsService buildingsService,
        IUsersService usersService)
    {
        _historyRepository = historyRepository ?? throw new ArgumentNullException(nameof(historyRepository));
        _buildingsService = buildingsService ?? throw new ArgumentNullException(nameof(buildingsService));
        _usersService = usersService ?? throw new ArgumentNullException(nameof(usersService));
    }

    public async Task<History> CreateAsync(CreateHistoryRequest request, CancellationToken token = default)
    {
        var history = new History(request.BuildingId, request.DoorId, request.UserId, request.Status);
        return await _historyRepository.CreateAsync(history, token);
    }

    public async Task<IEnumerable<History>> GetAllAsync(Guid userClientId,
        GetHistoryRequest request,
        CancellationToken token = default)
    {
        // Authorize user
        var authUser = await IsHistoryAuthorized(userClientId, request.BuildingId, token);

        if (!authUser) return Enumerable.Empty<History>();

        // TODO: check if buildingId, DoorId, UserId exist.=> badrequest if they don't
        return await _historyRepository.GetAllAsync(
            request.BuildingId,
            request.DoorId,
            request.UserId,
            request.DateTime,
            request.Status,
            token);
    }

    public Task<History> GetAsync(int id, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> IsHistoryAuthorized(Guid userId, Guid buildingId, CancellationToken token = default)
    {
        var building = await _buildingsService.GetAsync(buildingId, token);
        //get user role
        var user = await _usersService.GetAsync(userId, token);

        // check if user has role
        if (user != null && building != null)
        {
            var authuser = user.UserRoles.Count(ur => building.Roles.Any(r => r.Id.Equals(ur.RoleId)));
            if (authuser > 0)
            {
                return true;
            }
        }
        return false;
    }
}
