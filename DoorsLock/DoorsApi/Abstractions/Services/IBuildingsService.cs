using DoorsApi.Models;

namespace DoorsApi.Abstractions.Services;

public interface IBuildingsService
{
    public Task<Building> GetAsync(Guid id, CancellationToken token = default);
    public Task<IEnumerable<Building>> GetAllAsync(CancellationToken token = default);
    public Task<Building> CreateAsync(Building building, CancellationToken token = default);
}
