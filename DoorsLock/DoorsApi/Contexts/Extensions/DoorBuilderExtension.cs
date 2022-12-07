using DoorsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DoorsApi.Contexts.Extensions;
public static class DoorBuilderExtension
{
    public static void RegisterDoorEntity(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Door>(entity =>
        {
            entity.ToTable("Door");

            entity.HasKey(d => d.Id);

            entity.Property(d => d.Id).ValueGeneratedNever();
            entity.Property(d => d.Name);
            entity.Property(d => d.BuildingId);

            entity.HasOne(d => d.Building)
            .WithMany(b => b.Doors)
            .HasForeignKey(b => b.BuildingId);

            entity.HasMany(d => d.DoorRoles)
            .WithOne(dr => dr.Door)
            .HasForeignKey(dr => dr.DoorId);
        });
    }
}

