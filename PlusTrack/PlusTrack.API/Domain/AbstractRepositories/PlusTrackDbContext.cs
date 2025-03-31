using Microsoft.EntityFrameworkCore;
using PlusTrack.API.Domain.Entities;

namespace PlusTrack.API.Domain.AbstractRepositories;

public class PlusTrackDbContext : DbContext
{


    public PlusTrackDbContext(DbContextOptions<PlusTrackDbContext> options) : base(options) {}

    public DbSet<Company> Companies { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<License> Licenses { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Package> Packages { get; set; }
    public DbSet<Entities.Route> Routes { get; set; }
    public DbSet<RouteStop> RouteStops { get; set; }
    public DbSet<SavedLocation> SavedLocations { get; set; }
    public DbSet<Track> Tracks { get; set; }
    public DbSet<Truck> Trucks { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RouteStop>()
            .HasOne(e => e.Package)
            .WithOne(e => e.RouteStop)
            .HasForeignKey<Package>(e => e.RouteStopId)
            .IsRequired(false);

        modelBuilder.Entity<Entities.Route>()
            .HasOne(r => r.Truck)
            .WithMany(t => t.Routes)
            .HasForeignKey(r => r.TruckId)
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);
    }
}
