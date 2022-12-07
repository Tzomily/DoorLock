using DoorsApi.Abstractions.Repositories;
using DoorsApi.Contexts;
using DoorsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DoorsApi.Repositories;

public class HistoryRepository : IHistoryRepository
{
    private DoorsDbContext _dbContext;

    public HistoryRepository(DoorsDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public Task<History> CreateAsync(History history)
    {
        throw new NotImplementedException();
    }

    public async Task<History> CreateAsync(History history, CancellationToken token = default)
    {
        _dbContext.History.Add(history);
        await _dbContext.SaveChangesAsync();
        return history;
    }

    public async Task<IEnumerable<History>> GetAllAsync(
        Guid buildingId,
        Guid? doorId,
        Guid? userId,
        DateTime? dateTime,
        Status? status,
        CancellationToken token = default)
    {
        var historiesQuery = _dbContext.History.AsQueryable();

        historiesQuery = historiesQuery.Where(h => h.BuildingId == buildingId);

        if (doorId.HasValue)
        {
            historiesQuery = historiesQuery.Where(h => h.DoorId.Equals(doorId.Value));
        }

        if (userId.HasValue)
        {
            historiesQuery = historiesQuery.Where(h => h.UserId == userId.Value);
        }

        if (dateTime.HasValue)
        {
            historiesQuery = historiesQuery.Where(h => h.DateTime.Equals(dateTime.Value));
        }

        if (status.HasValue)
        {
            historiesQuery = historiesQuery.Where(h => h.Status.Equals(status.Value));
        }

        return await historiesQuery.ToListAsync(token);
    }

    public Task<History> GetAsync(int id, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }
}
