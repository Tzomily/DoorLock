using DoorsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DoorsApi.Contexts.Extensions
{
    public static class RoleBuilderExtension
    {
        public static void RegisterRoleEntity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.HasKey(r => r.Id);

                entity.Property(r => r.Id).ValueGeneratedNever().HasConversion<string>();
                entity.Property(r => r.Name);
                entity.Property(r => r.BuildingId);
                entity.Property(r => r.AccessLevel)
                //make enum to int. Make sure it's needed
                .HasConversion<int>();

                entity.HasOne(r => r.Building)
                .WithMany(b => b.Roles)
                .HasForeignKey(r => r.BuildingId);

                entity.HasMany(r => r.DoorRoles)
                .WithOne(dr => dr.Role)
                .HasForeignKey(dr => dr.RoleId);

                entity.HasMany(r => r.UserRoles)
                .WithOne(ur => ur.Role)
                .HasForeignKey(ur => ur.RoleId);
            });
        }
    }
}
