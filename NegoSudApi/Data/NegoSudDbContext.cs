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
    public virtual DbSet<VAT> Vat { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bottle>(entity =>
        {
            entity.ToTable(nameof(Bottle));
            entity.HasKey(b => b.Id);
            entity.Property(i => i.Id).UseIdentityColumn();
            entity.Property(p => p.CreatedBy).HasMaxLength(200);
            entity.Property(p => p.UpdatedBy).HasMaxLength(200);
            entity.Property(t => t.CreatedAt).HasPrecision(0).ValueGeneratedOnAdd().HasDefaultValueSql("NOW()");
            entity.Property(t => t.UpdatedAt).HasPrecision(0).ValueGeneratedOnAddOrUpdate();
            entity.HasIndex(i => i.WineType);
            entity.HasOne(a => a.Vat).WithMany(c => c.Bottles).HasForeignKey(a => a.VatId);
            entity.HasOne(a => a.Producer).WithMany(c => c.Bottles).HasForeignKey(a => a.ProducerId);
            entity.HasOne(a => a.WineLabel).WithMany(c => c.Bottles).HasForeignKey(a => a.WineLabelId);
        });

        modelBuilder.Entity<WineLabel>(entity =>
        {
            entity.ToTable(nameof(WineLabel));
            entity.HasKey(b => b.Id);
            entity.Property(i => i.Id).UseIdentityColumn();
            entity.Property(p => p.CreatedBy).HasMaxLength(200);
            entity.Property(p => p.UpdatedBy).HasMaxLength(200);
            entity.Property(t => t.CreatedAt).HasPrecision(0).ValueGeneratedOnAdd().HasDefaultValueSql("NOW()");
            entity.Property(t => t.UpdatedAt).HasPrecision(0).ValueGeneratedOnAddOrUpdate();
        });

        modelBuilder.Entity<BottleGrape>(entity =>
        {
            entity.ToTable(nameof(BottleGrape));
            entity.Property(p => p.CreatedBy).HasMaxLength(200);
            entity.Property(p => p.UpdatedBy).HasMaxLength(200);
            entity.Property(t => t.CreatedAt).HasPrecision(0).ValueGeneratedOnAdd().HasDefaultValueSql("NOW()");
            entity.Property(t => t.UpdatedAt).HasPrecision(0).ValueGeneratedOnAddOrUpdate();
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
            entity.Property(t => t.CreatedAt).HasPrecision(0).ValueGeneratedOnAdd().HasDefaultValueSql("NOW()");
            entity.Property(t => t.UpdatedAt).HasPrecision(0).ValueGeneratedOnAddOrUpdate();
            entity.HasKey(k => k.Id);
            entity.Property(i => i.Id).UseIdentityColumn();
        });

        modelBuilder.Entity<Grape>(entity =>
        {
            entity.ToTable(nameof(Grape));
            entity.Property(p => p.CreatedBy).HasMaxLength(200);
            entity.Property(p => p.UpdatedBy).HasMaxLength(200);
            entity.Property(t => t.CreatedAt).HasPrecision(0).ValueGeneratedOnAdd().HasDefaultValueSql("NOW()");
            entity.Property(t => t.UpdatedAt).HasPrecision(0).ValueGeneratedOnAddOrUpdate();
            entity.HasKey(k => k.Id);
            entity.Property(i => i.Id).UseIdentityColumn();
        });

        modelBuilder.Entity<StorageLocation>(entity =>
        {
            entity.ToTable(nameof(StorageLocation));
            entity.Property(p => p.CreatedBy).HasMaxLength(200);
            entity.Property(p => p.UpdatedBy).HasMaxLength(200);
            entity.Property(t => t.CreatedAt).HasPrecision(0).ValueGeneratedOnAdd().HasDefaultValueSql("NOW()");
            entity.Property(t => t.UpdatedAt).HasPrecision(0).ValueGeneratedOnAddOrUpdate();
            entity.HasKey(k => k.Id);
            entity.Property(i => i.Id).UseIdentityColumn();
        });
        
        modelBuilder.Entity<BottleSupplier>(entity =>
        {
            entity.ToTable(nameof(BottleSupplier));
            entity.Property(p => p.CreatedBy).HasMaxLength(200);
            entity.Property(p => p.UpdatedBy).HasMaxLength(200);
            entity.Property(t => t.CreatedAt).HasPrecision(0).ValueGeneratedOnAdd().HasDefaultValueSql("NOW()");
            entity.Property(t => t.UpdatedAt).HasPrecision(0).ValueGeneratedOnAddOrUpdate();
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
            entity.Property(t => t.CreatedAt).HasPrecision(0).ValueGeneratedOnAdd().HasDefaultValueSql("NOW()");
            entity.Property(t => t.UpdatedAt).HasPrecision(0).ValueGeneratedOnAddOrUpdate();
            entity.HasKey(k => k.Id);
            entity.Property(i => i.Id).UseIdentityColumn();
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.ToTable(nameof(Region));
            entity.Property(p => p.CreatedBy).HasMaxLength(200);
            entity.Property(p => p.UpdatedBy).HasMaxLength(200);
            entity.Property(t => t.CreatedAt).HasPrecision(0).ValueGeneratedOnAdd().HasDefaultValueSql("NOW()");
            entity.Property(t => t.UpdatedAt).HasPrecision(0).ValueGeneratedOnAddOrUpdate();
            entity.HasKey(k => k.Id);
            entity.Property(i => i.Id).UseIdentityColumn();
            entity.HasMany(k => k.Producers).WithOne(k => k.Region);
            entity.HasOne(c => c.Country).WithMany(c => c.Regions).HasForeignKey(a => a.CountryId);
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.ToTable(nameof(City));
            entity.Property(p => p.CreatedBy).HasMaxLength(200);
            entity.Property(p => p.UpdatedBy).HasMaxLength(200);
            entity.Property(t => t.CreatedAt).HasPrecision(0).ValueGeneratedOnAdd().HasDefaultValueSql("NOW()");
            entity.Property(t => t.UpdatedAt).HasPrecision(0).ValueGeneratedOnAddOrUpdate();
            entity.HasKey(k => k.Id);
            entity.Property(i => i.Id).UseIdentityColumn();
            entity.HasOne(c => c.Country).WithMany(c => c.Cities).HasForeignKey(a => a.CountryId);

        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.ToTable(nameof(Address));
            entity.Property(p => p.CreatedBy).HasMaxLength(200);
            entity.Property(p => p.UpdatedBy).HasMaxLength(200);
            entity.Property(t => t.CreatedAt).HasPrecision(0).ValueGeneratedOnAdd().HasDefaultValueSql("NOW()");
            entity.Property(t => t.UpdatedAt).HasPrecision(0).ValueGeneratedOnAddOrUpdate();
            entity.HasKey(k => k.Id);
            entity.Property(i => i.Id).UseIdentityColumn();
            entity.HasOne(a => a.City).WithMany(c => c.Addresses).HasForeignKey(a => a.CityId);
            entity.HasOne(a => a.User).WithMany(c => c.Addresses).HasForeignKey(a => a.UserId);
        });

        modelBuilder.Entity<BottleStorageLocation>(entity =>
        {
            entity.ToTable(nameof(BottleStorageLocation));
            entity.Property(p => p.CreatedBy).HasMaxLength(200);
            entity.Property(p => p.UpdatedBy).HasMaxLength(200);
            entity.Property(t => t.CreatedAt).HasPrecision(0).ValueGeneratedOnAdd().HasDefaultValueSql("NOW()");
            entity.Property(t => t.UpdatedAt).HasPrecision(0).ValueGeneratedOnAddOrUpdate();
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
            entity.Property(t => t.CreatedAt).HasPrecision(0).ValueGeneratedOnAdd().HasDefaultValueSql("NOW()");
            entity.Property(t => t.UpdatedAt).HasPrecision(0).ValueGeneratedOnAddOrUpdate();
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
            entity.Property(t => t.CreatedAt).HasPrecision(0).ValueGeneratedOnAdd().HasDefaultValueSql("NOW()");
            entity.Property(t => t.UpdatedAt).HasPrecision(0).ValueGeneratedOnAddOrUpdate();
            entity.HasKey(l => l.Id);
            entity.Property(l => l.Id).UseIdentityColumn();
            entity.HasOne(l => l.CustomerOrder).WithMany(k => k.Lines);
            entity.HasOne(l => l.Bottle);
            entity.HasMany(l => l.CustomerOrderLineStorageLocations).WithOne(sl => sl.CustomerOrderLine);
        });

        modelBuilder.Entity<SupplierOrder>(entity =>
        {
            entity.ToTable(nameof(SupplierOrder));
            entity.Property(sO => sO.CreatedBy).HasMaxLength(200);
            entity.Property(sO => sO.UpdatedBy).HasMaxLength(200);
            entity.Property(t => t.CreatedAt).HasPrecision(0).ValueGeneratedOnAdd().HasDefaultValueSql("NOW()");
            entity.Property(t => t.UpdatedAt).HasPrecision(0).ValueGeneratedOnAddOrUpdate();
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
            entity.Property(t => t.CreatedAt).HasPrecision(0).ValueGeneratedOnAdd().HasDefaultValueSql("NOW()");
            entity.Property(t => t.UpdatedAt).HasPrecision(0).ValueGeneratedOnAddOrUpdate();
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
            entity.Property(t => t.CreatedAt).HasPrecision(0).ValueGeneratedOnAdd().HasDefaultValueSql("NOW()");
            entity.Property(t => t.UpdatedAt).HasPrecision(0).ValueGeneratedOnAddOrUpdate();
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable(nameof(Role));
            entity.HasKey(k => k.Id);
            entity.Property(i => i.Id).UseIdentityColumn();
            entity.Property(p => p.CreatedBy).HasMaxLength(200);
            entity.Property(p => p.UpdatedBy).HasMaxLength(200);
            entity.Property(t => t.CreatedAt).HasPrecision(0).ValueGeneratedOnAdd().HasDefaultValueSql("NOW()");
            entity.Property(t => t.UpdatedAt).HasPrecision(0).ValueGeneratedOnAddOrUpdate();
            entity.HasMany(a => a.Users).WithOne(r => r.Role);
        });
        
       
        modelBuilder.Entity<Permission>(entity =>
        {
            entity.ToTable(nameof(Permission));
            entity.HasKey(k => k.Id);
            entity.Property(i => i.Id).UseIdentityColumn();
            entity.Property(p => p.CreatedBy).HasMaxLength(200);
            entity.Property(p => p.UpdatedBy).HasMaxLength(200);
            entity.Property(t => t.CreatedAt).HasPrecision(0).ValueGeneratedOnAdd().HasDefaultValueSql("NOW()");
            entity.Property(t => t.UpdatedAt).HasPrecision(0).ValueGeneratedOnAddOrUpdate();
        });
        
        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.ToTable(nameof(Supplier));
            entity.Property(p => p.CreatedBy).HasMaxLength(200);
            entity.Property(p => p.UpdatedBy).HasMaxLength(200);
            entity.Property(t => t.CreatedAt).HasPrecision(0).ValueGeneratedOnAdd().HasDefaultValueSql("NOW()");
            entity.Property(t => t.UpdatedAt).HasPrecision(0).ValueGeneratedOnAddOrUpdate();
            entity.HasKey(k => k.Id);
            entity.Property(i => i.Id).UseIdentityColumn();
            entity.HasOne(s => s.Address).WithOne(a => a.Supplier).HasForeignKey<Address>(a => a.SupplierId).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<PermissionRole>(entity =>
        {
            entity.ToTable(nameof(PermissionRole));
            entity.HasKey(k => new {k.PermissionId, k.RoleId});

            entity.HasOne(k => k.Permission)
                .WithMany(k => k.PermissionRoles)
                .HasForeignKey(k => k.PermissionId)
                .HasPrincipalKey(k => k.Id);

            entity.HasOne(k => k.Role)
                .WithMany(k => k.PermissionRoles)
                .HasForeignKey(k => k.RoleId)
                .HasPrincipalKey(k => k.Id);
        });
        
        modelBuilder.Entity<CustomerOrderLineStorageLocation>(entity =>
        {
            entity.ToTable(nameof(CustomerOrderLineStorageLocation));
            entity.HasKey(k => new {k.CustomerOrderLineId, k.StorageLocationId});

            entity.HasOne(k => k.StorageLocation)
                .WithMany(k => k.CustomerOrderLineStorageLocations)
                .HasForeignKey(k => k.StorageLocationId)
                .HasPrincipalKey(k => k.Id);

            entity.HasOne(k => k.CustomerOrderLine)
                .WithMany(k => k.CustomerOrderLineStorageLocations)
                .HasForeignKey(k => k.CustomerOrderLineId)
                .HasPrincipalKey(k => k.Id);
        });
        
        
        modelBuilder.Entity<VAT>(entity =>
        {
            entity.ToTable(nameof(VAT));
            entity.HasKey(k => k.Id);
            entity.Property(i => i.Id).UseIdentityColumn();
        });
    }
}