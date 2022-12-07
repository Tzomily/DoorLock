using DoorsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DoorsApi.Contexts.Extensions
{
    public static class DoorRoleBuilderExtension
    {
        public static void RegisterDoorRoleEntity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DoorRole>(entity =>
            {
                entity.ToTable("DoorRole");
                entity.HasKey(dr => new { dr.DoorId, dr.RoleId });

                entity.Property(dr => dr.RoleId);
                entity.Property(dr => dr.DoorId);

                entity.HasOne(dr => dr.Role)
                .WithMany(r => r.DoorRoles)
                .HasForeignKey(dr => dr.RoleId);

                entity.HasOne(dr => dr.Door)
                .WithMany(d => d.DoorRoles)
                .HasForeignKey(u => u.DoorId);
            });
        }
    }
}
