using DoorsApi.Abstractions.Repositories;
using DoorsApi.Models;

namespace DoorsApi.Repositories;

public class RolesRepository : IRolesRepository
{
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
