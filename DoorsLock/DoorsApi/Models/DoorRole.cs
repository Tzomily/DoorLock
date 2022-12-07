namespace DoorsApi.Models;

public record DoorRole
{
    //What AccessRoles a door has.
    public Guid DoorId { get; set; }
    public Guid RoleId { get; set; }

    public Door Door { get; set; }
    public Role Role { get; set; }
}