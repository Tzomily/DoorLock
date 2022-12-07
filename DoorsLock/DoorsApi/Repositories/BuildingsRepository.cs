using DoorsApi.Abstractions.Repositories;
using DoorsApi.Contexts;
using DoorsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DoorsApi.Repositories;

public class BuildingsRepository : IBuildingsRepository
{
    private DoorsDbContext _context;

    public BuildingsRepository(DoorsDbContext context)
    {
        _context = context;
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
        return await _context.Buildings.Include(b => b.Roles).FirstOrDefaultAsync(b => b.Id.Equals(id), token);
    }
}
