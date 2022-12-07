using DoorsApi.Dtos.History;
using DoorsApi.Models;

namespace DoorsApi.Abstractions.Services;

public interface IHistoryService
{
    public Task<History> GetAsync(int id, CancellationToken token = default);
    public Task<IEnumerable<History>> GetAllAsync(
        //user to be authorised
        Guid userClientId,
        GetHistoryRequest request,
        CancellationToken token = default);
    public Task<History> CreateAsync(CreateHistoryRequest request, CancellationToken token = default);
}
