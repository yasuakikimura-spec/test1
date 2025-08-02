using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        
        modelBuilder.Entity<Production>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Quantity).IsRequired();
            entity.Property(e => e.Description);
            entity.Property(e => e.RowVersion).IsRowVersion();
        });
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Production> Productions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Description);
                entity.Property(e => e.RowVersion)
                      .IsRowVersion();
            });
        }
    }
}