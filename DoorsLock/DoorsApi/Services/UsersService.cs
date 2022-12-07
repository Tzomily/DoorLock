using DoorsApi.Abstractions.Repositories;
using DoorsApi.Abstractions.Services;
using DoorsApi.Models;

namespace DoorsApi.Services;

public class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;

    public UsersService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
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
        return await _usersRepository.GetAsync(id, token);
    }
}
