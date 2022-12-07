namespace DoorsApi.Models;

public record Door
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public Guid BuildingId { get; set; }

    public Building Building { get; set; }
    public ICollection<DoorRole> DoorRoles { get; set; }
}
