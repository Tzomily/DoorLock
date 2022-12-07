using DoorsApi.Abstractions.Repositories;
using DoorsApi.Abstractions.Services;
using DoorsApi.Models;

namespace DoorsApi.Services;

public class RolesService : IRolesService
{
    private readonly IRolesRepository _rolesRepository;

    public RolesService(IRolesRepository rolesRepository)
    {
        _rolesRepository = rolesRepository ?? throw new ArgumentNullException(nameof(rolesRepository));
    }

    public Task<Role> CreateAsync(Role role, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Role>> GetAllAsync(Guid buildingId, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task<Role> GetAsync(Guid buildingId, Guid id, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }
}
