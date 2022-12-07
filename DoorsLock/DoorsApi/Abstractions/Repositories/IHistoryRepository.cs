using DoorsApi.Models;

namespace DoorsApi.Abstractions.Repositories;

public interface IHistoryRepository
{
    public Task<History> GetAsync(int id, CancellationToken token = default);
    public Task<IEnumerable<History>> GetAllAsync(
        Guid buildingId,
        Guid? doorId,
        Guid? userId,
        DateTime? dateTime,
        Status? status,
        CancellationToken token = default);
    public Task<History> CreateAsync(History history, CancellationToken token = default);
}
