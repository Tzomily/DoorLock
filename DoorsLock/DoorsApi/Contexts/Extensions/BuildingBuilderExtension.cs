using DoorsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DoorsApi.Contexts.Extensions;
public static class BuildingBuilderExtension
{
    public static void RegisterBuildingEntity(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Building>(entity =>
        {
            entity.ToTable("Building");

            entity.HasKey(b => b.Id);

            entity.Property(b => b.Id).ValueGeneratedNever();
            entity.Property(b => b.Name);

            entity.HasMany(b => b.Doors)
            .WithOne(d => d.Building)
            .HasForeignKey(d => d.BuildingId);

            entity.HasMany(b => b.Roles)
            .WithOne(r => r.Building)
            .HasForeignKey(d => d.BuildingId);
        });
    }
}

