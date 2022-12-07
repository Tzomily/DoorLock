using DoorsApi.Models;

namespace DoorsApi.Dtos.History
{
    public class GetHistoryRequest
    {
        public Guid BuildingId { get; set; }
        public Guid? DoorId { get; set; }
        public Guid? UserId { get; set; }
        public DateTime? DateTime { get; set; }
        public Status? Status { get; set; }

        public GetHistoryRequest(Guid buildingId)
        {
            BuildingId = buildingId;
        }
    }
}
