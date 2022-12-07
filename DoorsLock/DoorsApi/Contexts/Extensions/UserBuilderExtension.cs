using DoorsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DoorsApi.Contexts.Extensions
{
    public static class UserBuilderExtension
    {
        public static void RegisterUserEntity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasKey(u => u.Id);

                entity.Property(u => u.Id).ValueGeneratedNever().HasConversion<string>();
                entity.Property(u => u.FirstName);
                entity.Property(u => u.LastName);
                entity.Property(u => u.Email);
                entity.Property(u => u.Phone);

                entity.HasMany(u => u.UserRoles)
                .WithOne(ur => ur.User)
                .HasForeignKey(ur => ur.UserId);
            });
        }
    }
}
