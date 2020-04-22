using Theatres.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Theatres.DataAccess.Context
{
    public partial class TheatreContext : DbContext
    {
        public TheatreContext()
        {
        }

        public TheatreContext(DbContextOptions<TheatreContext> options) : base(options)
        {
        }

        public virtual DbSet<Theatre> Theatre { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<Perfomance> Perfomance { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Theatre>(entity =>
                {
                    entity.Property(c => c.Id).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
                    entity.Property(c => c.Name).IsRequired();
                    entity.Property(c => c.Address).IsRequired();
                });

            modelBuilder.Entity<Perfomance>(entity =>
                {
                    entity.Property(m => m.Id).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
                    entity.Property(m => m.Title).IsRequired();
                    entity.Property(m => m.Director).IsRequired();
                    entity.Property(m => m.DateOfPremiere).IsRequired();
                });

            modelBuilder.Entity<Schedule>(entity =>
                {
                    entity.Property(s=>s.Id).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
                    entity.Property(s => s.Date).IsRequired();
                    entity.Property(s => s.Time).IsRequired();
                    entity.HasOne(s => s.Theatre)
                        .WithMany(c => c.Schedule)
                        .HasForeignKey(s => s.TheatreId)
                        .HasConstraintName("FK_Schedule_Theatre");
                    entity.HasOne(s => s.Perfomance)
                        .WithMany(m => m.Schedule).HasForeignKey(s=>s.PerfomanceId)
                        .HasConstraintName("FK_Schedule_Perfomance");
                });
            
            this.OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}