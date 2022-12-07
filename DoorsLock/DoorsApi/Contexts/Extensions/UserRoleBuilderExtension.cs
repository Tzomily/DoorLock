using DoorsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DoorsApi.Contexts.Extensions
{
    public static class UserRoleBuilderExtension
    {
        public static void RegisterUserRoleEntity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRole");
                entity.HasKey(ur => new { ur.RoleId, ur.UserId });

                entity.Property(ur => ur.RoleId);
                entity.Property(ur => ur.UserId);

                entity.HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

                entity.HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(u => u.UserId);
            });
        }
    }
}
