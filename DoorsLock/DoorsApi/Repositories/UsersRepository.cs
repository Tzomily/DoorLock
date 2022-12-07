using DoorsApi.Abstractions.Repositories;
using DoorsApi.Contexts;
using DoorsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DoorsApi.Repositories;

public class UsersRepository : IUsersRepository
{
    private DoorsDbContext _dbContext;

    public UsersRepository(DoorsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<User> CreateAsync(User user, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAllAsync(CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetAsync(Guid id, CancellationToken token = default)
    {
        return await _dbContext.Users
            .Where(u => u.Id.Equals(id))
            .Include(u => u.UserRoles)
            .FirstOrDefaultAsync(token);
    }
}
