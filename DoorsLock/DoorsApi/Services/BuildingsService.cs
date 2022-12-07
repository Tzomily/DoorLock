using DoorsApi.Abstractions.Repositories;
using DoorsApi.Abstractions.Services;
using DoorsApi.Models;

namespace DoorsApi.Services;

public class BuildingsService : IBuildingsService
{
    private readonly IBuildingsRepository _buildingsRepository;

    public BuildingsService(IBuildingsRepository buildingsRepository)
    {
        _buildingsRepository = buildingsRepository ?? throw new ArgumentNullException(nameof(buildingsRepository));
    }

    public Task<Building> CreateAsync(Building building, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Building>> GetAllAsync(CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Building> GetAsync(Guid id, CancellationToken token = default)
    {
        return await _buildingsRepository.GetAsync(id, token);
    }
}
