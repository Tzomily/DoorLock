using DoorsApi.Models;

namespace DoorsApi.Abstractions.Services;

public interface IUsersService
{
    public Task<User> GetAsync(Guid id, CancellationToken token = default);
    public Task<IEnumerable<User>> GetAllAsync(CancellationToken token = default);
    public Task<User> CreateAsync(
        //CreateUserRequest
        User user, CancellationToken token = default);

    // update user
    // delete user
}
