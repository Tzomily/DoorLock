using DoorsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DoorsApi.Contexts.Extensions
{
    public static class HistoryBuilderExtension
    {
        public static void RegisterHistoryEntity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<History>(entity =>
            {
                entity.ToTable("History");
                entity.HasKey(h => h.Id);

                entity.Property(h => h.BuildingId);
                entity.Property(h => h.DoorId);
                entity.Property(h => h.UserId);
                entity.Property(h => h.DateTime);
                entity.Property(h => h.Status);
            });
        }
    }
}
