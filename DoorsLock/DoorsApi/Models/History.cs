namespace DoorsApi.Models;

public record History
{
    public Guid Id { get; set; }
    public Guid BuildingId { get; set; }
    public Guid DoorId { get; set; }
    public Guid UserId { get; set; }
    public DateTime DateTime { get; set; }
    public Status Status { get; set; }

    public History(Guid buildingId, Guid doorId, Guid userId, Status status)
    {
        Id = Guid.NewGuid();
        BuildingId = buildingId;
        DoorId = doorId;
        UserId = userId;
        DateTime = DateTime.UtcNow;
        Status = status;
    }
}

public enum Status
{
    Open, //0
    Locked, //1
    Error, //2
    UserUnauthorized //3
}
