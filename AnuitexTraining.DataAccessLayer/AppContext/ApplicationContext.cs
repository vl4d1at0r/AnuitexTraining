using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Initialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AnuitexTraining.DataAccessLayer.AppContext
{
    public sealed class ApplicationContext : IdentityDbContext<ApplicationUser, IdentityRole<long>, long>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public override DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PrintingEdition> PrintingEditions { get; set; }
        public DbSet<AuthorInPrintingEdition> AuthorInPrintingEditions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AuthorInPrintingEdition>()
                .HasKey(item => new {item.AuthorId, item.PrintingEditionId});

            modelBuilder.Entity<AuthorInPrintingEdition>()
                .HasOne<Author>(item => item.Author)
                .WithMany(item => item.AuthorInPrintingEditions)
                .HasForeignKey(item => item.AuthorId);

            modelBuilder.Entity<AuthorInPrintingEdition>()
                .HasOne<PrintingEdition>(item => item.PrintingEdition)
                .WithMany(item => item.AuthorInPrintingEditions)
                .HasForeignKey(item => item.PrintingEditionId);
            
            DataBaseInitialization.SeedData(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}