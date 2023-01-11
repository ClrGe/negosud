using Microsoft.EntityFrameworkCore;
using NegoSudApi.Models;

namespace NegoSudApi;

public class NegoSudDbContext : DbContext
{
    public NegoSudDbContext(DbContextOptions<NegoSudDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Bottle> Bottles { get; set; }
    public virtual DbSet<Country> Countries { get; set; }
    public virtual DbSet<Grape> Grapes { get; set; }
    public virtual DbSet<Location> Locations { get; set; }
    public virtual DbSet<Producer> Producers { get; set; }
    public virtual DbSet<Region> Regions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bottle>(entity =>
        {
            entity.ToTable(nameof(Bottle));
            entity.HasKey(b => b.Id);
            entity.Property(p => p.Created_By).HasMaxLength(200);
            entity.Property(p => p.Updated_at).HasMaxLength(200);
            entity.Property(t => t.Created_at).HasPrecision(0).ValueGeneratedOnAdd();
            entity.Property(t => t.Updated_at).HasPrecision(0).ValueGeneratedOnUpdate();
        });
        
        modelBuilder.Entity<BottleGrape>(entity =>
        {
            entity.ToTable(nameof(BottleGrape));
            entity.Property(p => p.Created_By).HasMaxLength(200);
            entity.Property(p => p.Updated_at).HasMaxLength(200);
            entity.Property(t => t.Created_at).HasPrecision(0).ValueGeneratedOnAdd();
            entity.Property(t => t.Updated_at).HasPrecision(0).ValueGeneratedOnUpdate();
            entity.HasKey(k => new {k.Bottle_Id, k.Grape_Id});

            entity.HasOne(k => k.Bottle)
                .WithMany(k => k.BottleGrapes)
                .HasForeignKey(k => k.Bottle_Id)
                .HasPrincipalKey(k => k.Id);
            
            entity.HasOne(k => k.Grape)
                .WithMany(k => k.BottleGrapes)
                .HasForeignKey(k => k.Grape_Id)
                .HasPrincipalKey(k => k.Id);
            
        });
        
        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable(nameof(Country));
            entity.Property(p => p.Created_By).HasMaxLength(200);
            entity.Property(p => p.Updated_at).HasMaxLength(200);
            entity.Property(t => t.Created_at).HasPrecision(0).ValueGeneratedOnAdd();
            entity.Property(t => t.Updated_at).HasPrecision(0).ValueGeneratedOnUpdate();
            entity.HasKey(k => k.Id);

            entity.HasMany(k => k.Regions).WithOne(k => k.Country);
        });

        modelBuilder.Entity<Grape>(entity =>
        {
            entity.ToTable(nameof(Grape));
            entity.Property(p => p.Created_By).HasMaxLength(200);
            entity.Property(p => p.Updated_at).HasMaxLength(200);
            entity.Property(t => t.Created_at).HasPrecision(0).ValueGeneratedOnAdd();
            entity.Property(t => t.Updated_at).HasPrecision(0).ValueGeneratedOnUpdate();
            entity.HasKey(k => k.Id);
        });
        
        modelBuilder.Entity<Location>(entity =>
        {
            entity.ToTable(nameof(Location));
            entity.Property(p => p.Created_By).HasMaxLength(200);
            entity.Property(p => p.Updated_at).HasMaxLength(200);
            entity.Property(t => t.Created_at).HasPrecision(0).ValueGeneratedOnAdd();
            entity.Property(t => t.Updated_at).HasPrecision(0).ValueGeneratedOnUpdate();
            entity.HasKey(k => k.Id);
        });
        
        modelBuilder.Entity<Producer>(entity =>
        {
            entity.ToTable(nameof(Producer));
            entity.Property(p => p.Created_By).HasMaxLength(200);
            entity.Property(p => p.Updated_at).HasMaxLength(200);
            entity.Property(t => t.Created_at).HasPrecision(0).ValueGeneratedOnAdd();
            entity.Property(t => t.Updated_at).HasPrecision(0).ValueGeneratedOnUpdate();
            entity.HasKey(k => k.Id);
            entity.HasMany(k => k.Bottles).WithOne(k => k.Producer);
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.ToTable(nameof(Region));
            entity.Property(p => p.Created_By).HasMaxLength(200);
            entity.Property(p => p.Updated_at).HasMaxLength(200);
            entity.Property(t => t.Created_at).HasPrecision(0).ValueGeneratedOnAdd();
            entity.Property(t => t.Updated_at).HasPrecision(0).ValueGeneratedOnUpdate();
            entity.HasKey(k => k.Id);
            entity.HasMany(k => k.Producers).WithOne(k => k.Region);
        });

        modelBuilder.Entity<BottleLocation>(entity =>
        {
            entity.ToTable(nameof(BottleLocation));
            entity.Property(p => p.Created_By).HasMaxLength(200);
            entity.Property(p => p.Updated_at).HasMaxLength(200);
            entity.Property(t => t.Created_at).HasPrecision(0).ValueGeneratedOnAdd();
            entity.Property(t => t.Updated_at).HasPrecision(0).ValueGeneratedOnUpdate();
            entity.HasKey(k => new {k.Bottle_Id, k.Location_Id});
            
            entity.HasOne(k => k.Bottle)
                .WithMany(k => k.BottleLocations)
                .HasForeignKey(k => k.Bottle_Id)
                .HasPrincipalKey(k => k.Id);
            
            entity.HasOne(k => k.Location)
                .WithMany(k => k.BottleLocations)
                .HasForeignKey(k => k.Location_Id)
                .HasPrincipalKey(k => k.Id);
        });
    }
}