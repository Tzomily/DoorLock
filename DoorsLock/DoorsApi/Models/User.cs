namespace DoorsApi.Models;

public record User
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }

    public ICollection<UserRole> UserRoles { get; set; }

    public User(string? firstName, string? lastName, string? email, string? phone)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
    }
}