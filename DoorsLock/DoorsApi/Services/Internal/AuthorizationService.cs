using DoorsApi.Abstractions.Services;
using DoorsApi.Abstractions.Services.Internal;

namespace DoorsApi.Services.Internal
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IBuildingsService _buildingsService;
        private readonly IDoorsService _doorsService;
        private readonly IUsersService _usersService;

        public AuthorizationService(
            IBuildingsService buildingsService,
            IDoorsService doorService,
            IUsersService usersService)
        {
            _buildingsService = buildingsService ?? throw new ArgumentNullException(nameof(buildingsService));
            _doorsService = doorService ?? throw new ArgumentNullException(nameof(doorService));
            _usersService = usersService ?? throw new ArgumentNullException(nameof(usersService));
        }

        public async Task<bool> IsDoorAuthorized(Guid userId, Guid buildingId, Guid doorId, CancellationToken token = default)
        {
            // get door role
            var door = await _doorsService.GetAsync(buildingId, doorId, token);
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
}
