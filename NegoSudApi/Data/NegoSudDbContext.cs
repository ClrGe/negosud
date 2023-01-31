using Microsoft.EntityFrameworkCore;
using NegoSudApi.Models;

namespace NegoSudApi.Data;

public class NegoSudDbContext : DbContext
{
    public NegoSudDbContext(DbContextOptions<NegoSudDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Bottle> Bottles { get; set; }
    public virtual DbSet<WineLabel> WineLabels { get; set; }
    public virtual DbSet<Country> Countries { get; set; }
    public virtual DbSet<Grape> Grapes { get; set; }
    public virtual DbSet<StorageLocation> StorageLocations { get; set; }
    public virtual DbSet<Producer> Producers { get; set; }
    public virtual DbSet<Region> Regions { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<City> Cities { get; set; }
    public virtual DbSet<Address> Addresses { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<Permission> Permissions { get; set; }
    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<CustomerOrder> CustomerOrders { get; set; }
    public virtual DbSet<SupplierOrder> SupplierOrders { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bottle>(entity =>
        {
            entity.ToTable(nameof(Bottle));
            entity.HasKey(b => b.Id);
            entity.Property(i => i.Id).UseIdentityColumn();
            entity.Property(p => p.CreatedBy).HasMaxLength(200);
            entity.Property(p => p.UpdatedBy).HasMaxLength(200);
            entity.Property(t => t.CreatedAt).HasPrecision(0).ValueGeneratedOnAdd().HasDefaultValue(DateTime.UtcNow);
            entity.Property(t => t.UpdatedAt).HasPrecision(0).ValueGeneratedOnUpdate().HasDefaultValue(DateTime.UtcNow);
            entity.HasIndex(i => i.WineType);
        });

        modelBuilder.Entity<WineLabel>(entity =>
        {
            entity.ToTable(nameof(WineLabel));
            entity.HasKey(b => b.Id);
            entity.Property(i => i.Id).UseIdentityColumn();
            entity.Property(p => p.CreatedBy).HasMaxLength(200);
            entity.Property(p => p.UpdatedBy).HasMaxLength(200);
            entity.Property(t => t.CreatedAt).HasPrecision(0).ValueGeneratedOnAdd().HasDefaultValue(DateTime.UtcNow);
            entity.Property(t => t.UpdatedAt).HasPrecision(0).ValueGeneratedOnUpdate().HasDefaultValue(DateTime.UtcNow);
        });

        modelBuilder.Entity<BottleGrape>(entity =>
        {
            entity.ToTable(nameof(BottleGrape));
            entity.Property(p => p.CreatedBy).HasMaxLength(200);
            entity.Property(p => p.UpdatedBy).HasMaxLength(200);
            entity.Property(t => t.CreatedAt).HasPrecision(0).ValueGeneratedOnAdd().HasDefaultValue(DateTime.UtcNow);
            entity.Property(t => t.UpdatedAt).HasPrecision(0).ValueGeneratedOnUpdate().HasDefaultValue(DateTime.UtcNow);
            entity.HasKey(k => new {k.BottleId,k.GrapeId});

            entity.HasOne(k => k.Bottle)
                .WithMany(k => k.BottleGrapes)
                .HasForeignKey(k => k.BottleId)
                .HasPrincipalKey(k => k.Id);

            entity.HasOne(k => k.Grape)
                .WithMany(k => k.BottleGrapes)
                .HasForeignKey(k => k.GrapeId)
                .HasPrincipalKey(k => k.Id);

        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable(nameof(Country));
            entity.Property(p => p.CreatedBy).HasMaxLength(200);
            entity.Property(p => p.UpdatedBy).HasMaxLength(200);
            entity.Property(t => t.CreatedAt).HasPrecision(0).ValueGeneratedOnAdd().HasDefaultValue(DateTime.UtcNow);
            entity.Property(t => t.UpdatedAt).HasPrecision(0).ValueGeneratedOnUpdate().HasDefaultValue(DateTime.UtcNow);
            entity.HasKey(k => k.Id);
            entity.Property(i => i.Id).UseIdentityColumn();

            entity.HasMany(k => k.Regions).WithOne(k => k.Country);
        });

        modelBuilder.Entity<Grape>(entity =>
        {
            entity.ToTable(nameof(Grape));
            entity.Property(p => p.CreatedBy).HasMaxLength(200);
            entity.Property(p => p.UpdatedBy).HasMaxLength(200);
            entity.Property(t => t.CreatedAt).HasPrecision(0).ValueGeneratedOnAdd().HasDefaultValue(DateTime.UtcNow);
            entity.Property(t => t.UpdatedAt).HasPrecision(0).ValueGeneratedOnUpdate().HasDefaultValue(DateTime.UtcNow);
            entity.HasKey(k => k.Id);
            entity.Property(i => i.Id).UseIdentityColumn();
        });

        modelBuilder.Entity<StorageLocation>(entity =>
        {
            entity.ToTable(nameof(StorageLocation));
            entity.Property(p => p.CreatedBy).HasMaxLength(200);
            entity.Property(p => p.UpdatedBy).HasMaxLength(200);
            entity.Property(t => t.CreatedAt).HasPrecision(0).ValueGeneratedOnAdd().HasDefaultValue(DateTime.UtcNow);
            entity.Property(t => t.UpdatedAt).HasPrecision(0).ValueGeneratedOnUpdate().HasDefaultValue(DateTime.UtcNow);
            entity.HasKey(k => k.Id);
            entity.Property(i => i.Id).UseIdentityColumn();
        });
        
        modelBuilder.Entity<BottleSupplier>(entity =>
        {
            entity.ToTable(nameof(BottleSupplier));
            entity.Property(p => p.CreatedBy).HasMaxLength(200);
            entity.Property(p => p.UpdatedBy).HasMaxLength(200);
            entity.Property(t => t.CreatedAt).HasPrecision(0).ValueGeneratedOnAdd().HasDefaultValue(DateTime.UtcNow);
            entity.Property(t => t.UpdatedAt).HasPrecision(0).ValueGeneratedOnUpdate().HasDefaultValue(DateTime.UtcNow);
            entity.HasKey(k => new { k.BottleId, k.SupplierId});
            
            entity.HasOne(k => k.Bottle)
                .WithMany(k => k.BottleSuppliers)
                .HasForeignKey(k => k.BottleId)
                .HasPrincipalKey(k => k.Id);
            
            entity.HasOne(k => k.Supplier)
                .WithMany(k => k.BottleSuppliers)
                .HasForeignKey(k => k.SupplierId)
                .HasPrincipalKey(k => k.Id);
        });

        modelBuilder.Entity<Producer>(entity =>
        {
            entity.ToTable(nameof(Producer));
            entity.Property(p => p.CreatedBy).HasMaxLength(200);
            entity.Property(p => p.UpdatedBy).HasMaxLength(200);
            entity.Property(t => t.CreatedAt).HasPrecision(0).ValueGeneratedOnAdd().HasDefaultValue(DateTime.UtcNow);
            entity.Property(t => t.UpdatedAt).HasPrecision(0).ValueGeneratedOnUpdate().HasDefaultValue(DateTime.UtcNow);
            entity.HasKey(k => k.Id);
            entity.Property(i => i.Id).UseIdentityColumn();
            entity.HasMany(k => k.Bottles).WithOne(k => k.Producer);
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.ToTable(nameof(Region));
            entity.Property(p => p.CreatedBy).HasMaxLength(200);
            entity.Property(p => p.UpdatedBy).HasMaxLength(200);
            entity.Property(t => t.CreatedAt).HasPrecision(0).ValueGeneratedOnAdd().HasDefaultValue(DateTime.UtcNow);
            entity.Property(t => t.UpdatedAt).HasPrecision(0).ValueGeneratedOnUpdate().HasDefaultValue(DateTime.UtcNow);
            entity.HasKey(k => k.Id);
            entity.Property(i => i.Id).UseIdentityColumn();
            entity.HasMany(k => k.Producers).WithOne(k => k.Region);
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.ToTable(nameof(City));
            entity.Property(p => p.CreatedBy).HasMaxLength(200);
            entity.Property(p => p.UpdatedBy).HasMaxLength(200);
            entity.Property(t => t.CreatedAt).HasPrecision(0).ValueGeneratedOnAdd().HasDefaultValue(DateTime.UtcNow);
            entity.Property(t => t.UpdatedAt).HasPrecision(0).ValueGeneratedOnUpdate().HasDefaultValue(DateTime.UtcNow);
            entity.HasKey(k => k.Id);
            entity.Property(i => i.Id).UseIdentityColumn();
            entity.HasMany(k => k.Addresses).WithOne(k => k.City);
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.ToTable(nameof(Address));
            entity.Property(p => p.CreatedBy).HasMaxLength(200);
            entity.Property(p => p.UpdatedBy).HasMaxLength(200);
            entity.Property(t => t.CreatedAt).HasPrecision(0).ValueGeneratedOnAdd().HasDefaultValue(DateTime.UtcNow);
            entity.Property(t => t.UpdatedAt).HasPrecision(0).ValueGeneratedOnUpdate().HasDefaultValue(DateTime.UtcNow);
            entity.HasKey(k => k.Id);
            entity.Property(i => i.Id).UseIdentityColumn();
        });

        modelBuilder.Entity<BottleStorageLocation>(entity =>
        {
            entity.ToTable(nameof(BottleStorageLocation));
            entity.Property(p => p.CreatedBy).HasMaxLength(200);
            entity.Property(p => p.UpdatedBy).HasMaxLength(200);
            entity.Property(t => t.CreatedAt).HasPrecision(0).ValueGeneratedOnAdd().HasDefaultValue(DateTime.UtcNow);
            entity.Property(t => t.UpdatedAt).HasPrecision(0).ValueGeneratedOnUpdate().HasDefaultValue(DateTime.UtcNow);
            entity.HasKey(k => new { k.BottleId, k.StorageLocationId});
            
            entity.HasOne(k => k.Bottle)
                .WithMany(k => k.BottleStorageLocations)
                .HasForeignKey(k => k.BottleId)
                .HasPrincipalKey(k => k.Id);

            entity.HasOne(k => k.StorageLocation)
                .WithMany(k => k.BottleStorageLocations)
                .HasForeignKey(k => k.StorageLocationId)
                .HasPrincipalKey(k => k.Id);
        });

        modelBuilder.Entity<CustomerOrder>(entity =>
        {
            entity.ToTable(nameof(CustomerOrder));
            entity.Property(cO => cO.CreatedBy).HasMaxLength(200);
            entity.Property(cO => cO.UpdatedBy).HasMaxLength(200);
            entity.Property(cO => cO.CreatedAt).HasPrecision(0).ValueGeneratedOnAdd().HasDefaultValue(DateTime.UtcNow);
            entity.Property(cO => cO.UpdatedAt).HasPrecision(0).ValueGeneratedOnUpdate().HasDefaultValue(DateTime.UtcNow);
            entity.HasKey(cO => cO.Id);
            entity.Property(cO => cO.Id).UseIdentityColumn();
            entity.HasOne(cO => cO.Customer);
            entity.HasMany(cO => cO.Lines).WithOne(k => k.CustomerOrder);
        });

        modelBuilder.Entity<CustomerOrderLine>(entity =>
        {
            entity.ToTable(nameof(CustomerOrderLine));
            entity.Property(l => l.CreatedBy).HasMaxLength(200);
            entity.Property(l => l.UpdatedBy).HasMaxLength(200);
            entity.Property(l => l.CreatedAt).HasPrecision(0).ValueGeneratedOnAdd().HasDefaultValue(DateTime.UtcNow);
            entity.Property(l => l.UpdatedAt).HasPrecision(0).ValueGeneratedOnUpdate().HasDefaultValue(DateTime.UtcNow);
            entity.HasKey(l => l.Id);
            entity.Property(l => l.Id).UseIdentityColumn();
            entity.HasOne(l => l.CustomerOrder).WithMany(k => k.Lines);
            entity.HasOne(l => l.Bottle);
        });

        modelBuilder.Entity<SupplierOrder>(entity =>
        {
            entity.ToTable(nameof(SupplierOrder));
            entity.Property(sO => sO.CreatedBy).HasMaxLength(200);
            entity.Property(sO => sO.UpdatedBy).HasMaxLength(200);
            entity.Property(sO => sO.CreatedAt).HasPrecision(0).ValueGeneratedOnAdd().HasDefaultValue(DateTime.UtcNow);
            entity.Property(sO => sO.UpdatedAt).HasPrecision(0).ValueGeneratedOnUpdate().HasDefaultValue(DateTime.UtcNow);
            entity.HasKey(cO => cO.Id);
            entity.Property(cO => cO.Id).UseIdentityColumn();
            entity.HasOne(cO => cO.Supplier);
            entity.HasMany(cO => cO.Lines).WithOne(k => k.SupplierOrder);
        });

        modelBuilder.Entity<SupplierOrderLine>(entity =>
        {
            entity.ToTable(nameof(SupplierOrderLine));
            entity.Property(l => l.CreatedBy).HasMaxLength(200);
            entity.Property(l => l.UpdatedBy).HasMaxLength(200);
            entity.Property(l => l.CreatedAt).HasPrecision(0).ValueGeneratedOnAdd().HasDefaultValue(DateTime.UtcNow);
            entity.Property(l => l.UpdatedAt).HasPrecision(0).ValueGeneratedOnUpdate().HasDefaultValue(DateTime.UtcNow);
            entity.HasKey(l => l.Id);
            entity.Property(l => l.Id).UseIdentityColumn();
            entity.HasOne(l => l.SupplierOrder).WithMany(k => k.Lines);
            entity.HasOne(l => l.Bottle);
        });


        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable(nameof(User));
            entity.HasKey(k => k.Id);
            entity.Property(i => i.Id).UseIdentityColumn();
            entity.Property(p => p.CreatedBy).HasMaxLength(200);
            entity.Property(p => p.UpdatedBy).HasMaxLength(200);
            entity.Property(t => t.CreatedAt).HasPrecision(0).ValueGeneratedOnAdd().HasDefaultValue(DateTime.UtcNow);
            entity.Property(t => t.UpdatedAt).HasPrecision(0).ValueGeneratedOnAdd().ValueGeneratedOnUpdate().HasDefaultValue(DateTime.UtcNow);
            entity.HasMany(a => a.Addresses).WithOne(u => u.User);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable(nameof(Role));
            entity.HasKey(k => k.Id);
            entity.Property(i => i.Id).UseIdentityColumn();
            entity.Property(p => p.CreatedBy).HasMaxLength(200);
            entity.Property(p => p.UpdatedBy).HasMaxLength(200);
            entity.Property(t => t.CreatedAt).HasPrecision(0).ValueGeneratedOnAdd().HasDefaultValue(DateTime.UtcNow);
            entity.Property(t => t.UpdatedAt).HasPrecision(0).ValueGeneratedOnAdd().ValueGeneratedOnUpdate().HasDefaultValue(DateTime.UtcNow);
            entity.HasMany(a => a.Users).WithOne(r => r.Role);
        });
        
       
        modelBuilder.Entity<Permission>(entity =>
        {
            entity.ToTable(nameof(Permission));
            entity.HasKey(k => k.Id);
            entity.Property(i => i.Id).UseIdentityColumn();
            entity.Property(p => p.CreatedBy).HasMaxLength(200);
            entity.Property(p => p.UpdatedBy).HasMaxLength(200);
            entity.Property(t => t.CreatedAt).HasPrecision(0).ValueGeneratedOnAdd().HasDefaultValue(DateTime.UtcNow);
            entity.Property(t => t.UpdatedAt).HasPrecision(0).ValueGeneratedOnUpdate().HasDefaultValue(DateTime.UtcNow);
            entity.HasMany(p => p.Roles).WithMany(r => r.Permissions);
        });
        
        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.ToTable(nameof(Supplier));
            entity.Property(p => p.CreatedBy).HasMaxLength(200);
            entity.Property(p => p.UpdatedBy).HasMaxLength(200);
            entity.Property(t => t.CreatedAt).HasPrecision(0).ValueGeneratedOnAdd().HasDefaultValue(DateTime.UtcNow);
            entity.Property(t => t.UpdatedAt).HasPrecision(0).ValueGeneratedOnUpdate().HasDefaultValue(DateTime.UtcNow);
            entity.HasKey(k => k.Id);
            entity.Property(i => i.Id).UseIdentityColumn();
            entity.HasMany(k => k.Bottles).WithMany(k => k.Suppliers);
        });
    }
}