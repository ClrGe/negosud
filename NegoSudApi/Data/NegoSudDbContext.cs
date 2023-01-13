using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NegoSudApi.Models;

namespace NegoSudApi.Data;

public class NegoSudDbContext : IdentityDbContext
{
    public NegoSudDbContext(DbContextOptions<NegoSudDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Bottle> Bottles { get; set; }
    public virtual DbSet<Country> Countries { get; set; }
    public virtual DbSet<Grape> Grapes { get; set; }
    public virtual DbSet<StorageLocation> StorageLocations { get; set; }
    public virtual DbSet<Producer> Producers { get; set; }
    public virtual DbSet<Region> Regions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.HasNoKey());
        modelBuilder.Entity<IdentityUserRole<string>>(entity => entity.HasNoKey());
        modelBuilder.Entity<IdentityUserToken<string>>(entity => entity.HasNoKey());
        modelBuilder.Entity<Bottle>(entity =>
        {
            entity.ToTable(nameof(Bottle));
            entity.HasKey(b => b.Id);
            entity.Property(p => p.Created_By).HasMaxLength(200);
            entity.Property(p => p.Updated_By).HasMaxLength(200);
            entity.Property(t => t.Created_At).HasPrecision(0).ValueGeneratedOnAdd();
            entity.Property(t => t.Updated_At).HasPrecision(0).ValueGeneratedOnUpdate();
        });
        
        modelBuilder.Entity<BottleGrape>(entity =>
        {
            entity.ToTable(nameof(BottleGrape));
            entity.Property(p => p.Created_By).HasMaxLength(200);
            entity.Property(p => p.Updated_By).HasMaxLength(200);
            entity.Property(t => t.Created_At).HasPrecision(0).ValueGeneratedOnAdd();
            entity.Property(t => t.Updated_At).HasPrecision(0).ValueGeneratedOnUpdate();
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
            entity.Property(p => p.Updated_By).HasMaxLength(200);
            entity.Property(t => t.Created_At).HasPrecision(0).ValueGeneratedOnAdd();
            entity.Property(t => t.Updated_At).HasPrecision(0).ValueGeneratedOnUpdate();
            entity.HasKey(k => k.Id);

            entity.HasMany(k => k.Regions).WithOne(k => k.Country);
        });

        modelBuilder.Entity<Grape>(entity =>
        {
            entity.ToTable(nameof(Grape));
            entity.Property(p => p.Created_By).HasMaxLength(200);
            entity.Property(p => p.Updated_By).HasMaxLength(200);
            entity.Property(t => t.Created_At).HasPrecision(0).ValueGeneratedOnAdd();
            entity.Property(t => t.Updated_At).HasPrecision(0).ValueGeneratedOnUpdate();
            entity.HasKey(k => k.Id);
        });
        
        modelBuilder.Entity<StorageLocation>(entity =>
        {
            entity.ToTable(nameof(StorageLocation));
            entity.Property(p => p.Created_By).HasMaxLength(200);
            entity.Property(p => p.Updated_By).HasMaxLength(200);
            entity.Property(t => t.Created_At).HasPrecision(0).ValueGeneratedOnAdd();
            entity.Property(t => t.Updated_At).HasPrecision(0).ValueGeneratedOnUpdate();
            entity.HasKey(k => k.Id);
        });
        
        modelBuilder.Entity<Producer>(entity =>
        {
            entity.ToTable(nameof(Producer));
            entity.Property(p => p.Created_By).HasMaxLength(200);
            entity.Property(p => p.Updated_By).HasMaxLength(200);
            entity.Property(t => t.Created_At).HasPrecision(0).ValueGeneratedOnAdd();
            entity.Property(t => t.Updated_At).HasPrecision(0).ValueGeneratedOnUpdate();
            entity.HasKey(k => k.Id);
            entity.HasMany(k => k.Bottles).WithOne(k => k.Producer);
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.ToTable(nameof(Region));
            entity.Property(p => p.Created_By).HasMaxLength(200);
            entity.Property(p => p.Updated_By).HasMaxLength(200);
            entity.Property(t => t.Created_At).HasPrecision(0).ValueGeneratedOnAdd();
            entity.Property(t => t.Updated_At).HasPrecision(0).ValueGeneratedOnUpdate();
            entity.HasKey(k => k.Id);
            entity.HasMany(k => k.Producers).WithOne(k => k.Region);
        });

        modelBuilder.Entity<BottleStorageLocation>(entity =>
        {
            entity.ToTable(nameof(BottleStorageLocation));
            entity.Property(p => p.Created_By).HasMaxLength(200);
            entity.Property(p => p.Updated_By).HasMaxLength(200);
            entity.Property(t => t.Created_At).HasPrecision(0).ValueGeneratedOnAdd();
            entity.Property(t => t.Updated_At).HasPrecision(0).ValueGeneratedOnUpdate();
            entity.HasKey(k => new {k.Bottle_Id, k.StorageLocation_Id});
            
            entity.HasOne(k => k.Bottle)
                .WithMany(k => k.BottleStorageLocations)
                .HasForeignKey(k => k.Bottle_Id)
                .HasPrincipalKey(k => k.Id);
            
            entity.HasOne(k => k.StorageLocation)
                .WithMany(k => k.BottleStorageLocations)
                .HasForeignKey(k => k.StorageLocation_Id)
                .HasPrincipalKey(k => k.Id);
        });
    }
}