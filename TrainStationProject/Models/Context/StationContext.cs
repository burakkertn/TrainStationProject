
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Numerics;
using System.Text.RegularExpressions;
using TrainStationProject.Models.Entites;

namespace TrainStationProject.Models.Context
{
    public class StationContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=BURAK\\SQLEXPRESS;database= TrainStation;integrated security = true;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        

            modelBuilder.Entity<Voyage>()
                .HasOne(x => x.ArrivalStation)
                .WithMany(y => y.ArrivalStations)
                .HasForeignKey(z => z.ArrivalStationId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Voyage>()
               .HasOne(x => x.DepartureStation)
               .WithMany(y => y.DepartureStations)
               .HasForeignKey(z => z.DepartureStationId)
               .OnDelete(DeleteBehavior.ClientSetNull);
        }
     
        public DbSet<Station> Stations { get; set; }
        public DbSet<Voyage> Voyages { get; set; }
        public DbSet<User> Users { get; set; }
    }
}