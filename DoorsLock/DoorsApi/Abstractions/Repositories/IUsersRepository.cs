using DoorsApi.Models;

namespace DoorsApi.Abstractions.Repositories;

public interface IUsersRepository
{
    public Task<User> GetAsync(Guid id, CancellationToken token = default);
    public Task<IEnumerable<User>> GetAllAsync(CancellationToken token = default);
    public Task<User> CreateAsync(User user, CancellationToken token = default);

    // update user
    // delete user
}
