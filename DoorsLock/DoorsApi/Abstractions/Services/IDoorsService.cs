using DoorsApi.Models;

namespace DoorsApi.Abstractions.Services;

public interface IDoorsService
{
    public Task OpenDoor(Guid buildingId, Guid doorId, Guid userId, CancellationToken token = default);

    public Task<Door> CreateAsync(Guid buildingId, string name, CancellationToken token = default);
    public Task<Door?> GetAsync(Guid buildingId, Guid doorId, CancellationToken token = default);
    public Task<IEnumerable<Door>> GetDoors(Guid buildingId, CancellationToken token = default);
}
