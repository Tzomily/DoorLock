using DoorsApi.Contexts.Extensions;
using DoorsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DoorsApi.Contexts;

public class DoorsDbContext : DbContext
{
    public DoorsDbContext(DbContextOptions<DoorsDbContext> options) : base(options)
    { }

    public DbSet<Building> Buildings { get; set; }
    public DbSet<Door> Doors { get; set; }
    public DbSet<DoorRole> DoorRoles { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<History> History { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.RegisterBuildingEntity();
        modelBuilder.RegisterDoorEntity();
        modelBuilder.RegisterUserEntity();
        modelBuilder.RegisterRoleEntity();
        modelBuilder.RegisterHistoryEntity();

        modelBuilder.RegisterDoorRoleEntity();
        modelBuilder.RegisterUserRoleEntity();
    }

}