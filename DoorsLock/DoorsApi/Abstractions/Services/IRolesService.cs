using DoorsApi.Models;

namespace DoorsApi.Abstractions.Services;

public interface IRolesService
{
    public Task<Role> GetAsync(Guid buildingId, Guid id, CancellationToken token = default);
    public Task<IEnumerable<Role>> GetAllAsync(Guid buildingId, CancellationToken token = default);
    public Task<Role> CreateAsync(Role role, CancellationToken token = default);
}
