using Microsoft.EntityFrameworkCore;
using AutoLab.Models;

namespace AutoLab.Data
{
    public class AutoDbContext : DbContext
    {
        public AutoDbContext(DbContextOptions<AutoDbContext> options) : base(options)
        {
        }

        public DbSet<Automobil> Automobile { get; set; }

        public DbSet<Programare> Programari { get; set; }

        public DbSet<Filiala> Filiale { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Filiala>().HasData(Baza.Filiale);
            modelBuilder.Entity<Automobil>().HasData(Baza.Automobile);

            // Lecția 12: o filială care are automobile nu se poate șterge.
            modelBuilder.Entity<Automobil>()
                .HasOne(a => a.Filiala)
                .WithMany(f => f.Automobile)
                .HasForeignKey(a => a.FilialaId)
                .OnDelete(DeleteBehavior.Restrict);

            // Lecția 12: două filiale nu pot avea aceeași denumire.
            modelBuilder.Entity<Filiala>()
                .HasIndex(f => f.Denumire)
                .IsUnique();
        }
    }
}
