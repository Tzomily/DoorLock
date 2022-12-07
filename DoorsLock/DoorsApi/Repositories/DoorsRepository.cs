using DoorsApi.Abstractions.Repositories;
using DoorsApi.Contexts;
using DoorsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DoorsApi.Repositories;

public class DoorsRepository : IDoorsRepository
{
    private DoorsDbContext _dbContext;

    public DoorsRepository(DoorsDbContext context)
    {
        _dbContext = context;
    }

    public async Task<Door> CreateAsync(Door door, CancellationToken token = default)
    {
        _dbContext.Doors.Add(door);
        await _dbContext.SaveChangesAsync();
        return door;
    }

    public async Task<Door?> GetAsync(Guid buildingId, Guid doorId, CancellationToken token = default)
    {
        return await _dbContext.Doors
            .Where(d => d.Id.Equals(doorId) && d.BuildingId.Equals(buildingId))
            .Include(d => d.DoorRoles)
            .FirstOrDefaultAsync(token);
    }

    public async Task<IEnumerable<Door>> GetAllAsync(Guid buildingId, CancellationToken token = default)
    {
        return await _dbContext.Doors
           .Where(d => d.BuildingId.Equals(buildingId))
           .ToListAsync();
    }
}
