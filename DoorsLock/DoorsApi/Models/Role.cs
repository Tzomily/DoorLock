namespace DoorsApi.Models;

public record Role
{
    //roles per building.
    //parent entity??? building 

    public Guid Id { get; set; }
    public string? Name { get; set; }
    public AccessLevel AccessLevel { get; set; }
    public Guid BuildingId { get; set; }

    public Building Building { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }
    public ICollection<DoorRole> DoorRoles { get; set; }

    public Role(string? name, AccessLevel accessLevel, Guid buildingId)
    {
        Id = Guid.NewGuid();
        Name = name;
        AccessLevel = accessLevel;
        BuildingId = buildingId;
    }
}

public enum AccessLevel
{
    employee, //0
    admin, //1
}