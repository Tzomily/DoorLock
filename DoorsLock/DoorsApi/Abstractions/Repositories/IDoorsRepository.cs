using DoorsApi.Models;

namespace DoorsApi.Abstractions.Repositories;

public interface IDoorsRepository
{
    public Task<Door?> GetAsync(Guid buildingId, Guid doorId, CancellationToken token = default);
    public Task<IEnumerable<Door>> GetAllAsync(Guid buildingId, CancellationToken token = default);
    public Task<Door> CreateAsync(Door door, CancellationToken token = default);
}
