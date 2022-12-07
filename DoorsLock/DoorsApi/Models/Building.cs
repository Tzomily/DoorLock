namespace DoorsApi.Models;

public record Building
{
    // Parent to door
    // One to Many
    public Guid Id { get; set; }
    public string? Name { get; set; }

    public ICollection<Door> Doors { get; set; }
    public ICollection<Role> Roles { get; set; }

    public Building(string? name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}