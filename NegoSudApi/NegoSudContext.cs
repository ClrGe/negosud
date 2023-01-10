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
            entity.HasKey(b => new {b.Id, b.Producer_Id});
            entity.Property(p => p.Created_By).HasMaxLength(200);
            entity.Property(p => p.Updated_at).HasMaxLength(200);
            entity.Property(t => t.Created_at).HasPrecision(0);
            entity.Property(t => t.Updated_at).HasPrecision(0);
        });
        
        modelBuilder.Entity<BottleGrape>(entity =>
        {
            entity.Property(p => p.Created_By).HasMaxLength(200);
            entity.Property(p => p.Updated_at).HasMaxLength(200);
            entity.Property(t => t.Created_at).HasPrecision(0);
            entity.Property(t => t.Updated_at).HasPrecision(0);
            entity.HasKey(k => new {k.Bottle_Id, k.Grape_Id});

            entity.HasOne(k => k.Bottle)
                .WithMany(k => k.Grapes)
                .HasForeignKey(k => k.Bottle_Id)
                .HasPrincipalKey(k => k.Id);
            
            entity.HasOne(k => k.Grape)
                .WithMany(k => k.Bottles)
                .HasForeignKey(k => k.Grape_Id)
                .HasPrincipalKey(k => k.Id);
            
        });
        
        modelBuilder.Entity<Country>(entity =>
        {
            entity.Property(p => p.Created_By).HasMaxLength(200);
            entity.Property(p => p.Updated_at).HasMaxLength(200);
            entity.Property(t => t.Created_at).HasPrecision(0);
            entity.Property(t => t.Updated_at).HasPrecision(0);
            entity.HasKey(k => k.Id);

            entity.HasMany(k => k.Regions).WithOne(k => k.Country);
        });

        modelBuilder.Entity<Grape>(entity =>
        {
            entity.Property(p => p.Created_By).HasMaxLength(200);
            entity.Property(p => p.Updated_at).HasMaxLength(200);
            entity.Property(t => t.Created_at).HasPrecision(0);
            entity.Property(t => t.Updated_at).HasPrecision(0);
            entity.HasKey(k => k.Id);
        });
        
        modelBuilder.Entity<Location>(entity =>
        {
            entity.Property(p => p.Created_By).HasMaxLength(200);
            entity.Property(p => p.Updated_at).HasMaxLength(200);
            entity.Property(t => t.Created_at).HasPrecision(0);
            entity.Property(t => t.Updated_at).HasPrecision(0);
            entity.HasKey(k => k.Id);
        });
        
        modelBuilder.Entity<Producer>(entity =>
        {
            entity.Property(p => p.Created_By).HasMaxLength(200);
            entity.Property(p => p.Updated_at).HasMaxLength(200);
            entity.Property(t => t.Created_at).HasPrecision(0);
            entity.Property(t => t.Updated_at).HasPrecision(0);
            entity.HasKey(k => k.Id);
            entity.HasMany(k => k.Bottles).WithOne(k => k.Producer);
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.Property(p => p.Created_By).HasMaxLength(200);
            entity.Property(p => p.Updated_at).HasMaxLength(200);
            entity.Property(t => t.Created_at).HasPrecision(0);
            entity.Property(t => t.Updated_at).HasPrecision(0);
            entity.HasKey(k => k.Id);
            entity.HasMany(k => k.Producers).WithOne(k => k.Region);
        });

        modelBuilder.Entity<Storage>(entity =>
        {
            
            entity.Property(p => p.Created_By).HasMaxLength(200);
            entity.Property(p => p.Updated_at).HasMaxLength(200);
            entity.Property(t => t.Created_at).HasPrecision(0);
            entity.Property(t => t.Updated_at).HasPrecision(0);
            entity.HasKey(k => new {k.Bottle_Id, k.Location_Id});
            
            entity.HasOne(k => k.Bottle)
                .WithMany(k => k.Locations)
                .HasForeignKey(k => k.Bottle_Id)
                .HasPrincipalKey(k => k.Id);
            
            entity.HasOne(k => k.Location)
                .WithMany(k => k.Bottles)
                .HasForeignKey(k => k.Location_Id)
                .HasPrincipalKey(k => k.Id);
        });
    }
}