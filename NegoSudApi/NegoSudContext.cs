using Microsoft.EntityFrameworkCore;
using NegoSudApi.Models;

namespace NegoSudApi;

public class NegoSudContext : DbContext
{
    public NegoSudContext()
    {
    }

    public NegoSudContext(DbContextOptions<NegoSudContext> options) : base(options)
    {
    }

    public virtual DbSet<Bottle> Bottles { get; set; }
    public virtual DbSet<Country> Countries { get; set; }
    public virtual DbSet<Grape> Grapes { get; set; }
    public virtual DbSet<Storage> Inventories { get; set; }
    public virtual DbSet<Location> Locations { get; set; }
    public virtual DbSet<Producer> Producers { get; set; }
    public virtual DbSet<Region> Regions { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql().UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bottle>(entity =>
        {
            entity.Property(b => b.Picture).HasColumnType("Image");
            entity.HasKey(b => new {b.Id, b.Grape_Id, b.Producer_Id});
            entity.HasOne(b => b.Inventory).WithMany(p => p.Bottles);
        });
        
        
        modelBuilder.Entity<Country>(entity =>
        {
            
        });
    }
}