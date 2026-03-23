using ExampleThaiBevApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleThaiBevApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Queue> Queues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(250);
                entity.Property(e => e.LastName).HasMaxLength(250);
                entity.Property(e => e.Address).HasMaxLength(500);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Username).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Password).IsRequired().HasMaxLength(500);
                entity.Property(e => e.Fullname).HasMaxLength(250);
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.DocumentName).IsRequired().HasMaxLength(250);
                entity.Property(e => e.Remark).HasMaxLength(250);
                entity.Property(e => e.Status).HasMaxLength(100);
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(250);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(250);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(250);
                entity.Property(e => e.Phone).IsRequired().HasMaxLength(50);
                entity.Property(e => e.BirthDate).IsRequired();
                entity.Property(e => e.Occupation).IsRequired().HasMaxLength(250);
                entity.Property(e => e.Sex).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Queue>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.QueueNo).IsRequired().HasMaxLength(5);
            });
        }
    }
}
