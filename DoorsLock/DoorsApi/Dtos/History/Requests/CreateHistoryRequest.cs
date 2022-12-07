using DoorsApi.Models;

namespace DoorsApi.Dtos.History
{
    public record CreateHistoryRequest
    {
        public Guid BuildingId { get; set; }
        public Guid DoorId { get; set; }
        public Guid UserId { get; set; }
        public Status Status { get; set; }

        public CreateHistoryRequest(Guid buildingId, Guid doorId, Guid userId, Status status)
        {
            BuildingId = buildingId;
            DoorId = doorId;
            UserId = userId;
            Status = status;
        }
    }
}
