namespace DoorsApi.Abstractions.Services.Internal
{
    public interface IAuthorizationService
    {
        public Task<bool> IsDoorAuthorized(Guid userId, Guid buildingId, Guid doorId, CancellationToken token = default);

        // TODO: maybe make HistoryRoles.
        public Task<bool> IsHistoryAuthorized(Guid userId, Guid buildingId, CancellationToken token = default);

    }
}
