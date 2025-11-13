using Microsoft.EntityFrameworkCore;

public class InventoryDbContext : DbContext
{
    public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options) { }

    public DbSet<Category> Categories { get; set; } = default!;
    public DbSet<Item> Items { get; set; } = default!;
    public DbSet<Warehouse> Warehouses { get; set; } = default!;
    public DbSet<StorageLocation> StorageLocations { get; set; } = default!;
    public DbSet<Stock> Stocks { get; set; } = default!;
    public DbSet<StockTransaction> StockTransactions { get; set; } = default!;
    public DbSet<Batch> Batches { get; set; } = default!;
    public DbSet<SerialNumber> SerialNumbers { get; set; } = default!;
    public DbSet<ReorderRule> ReorderRules { get; set; } = default!;
    public DbSet<StockAdjustment> StockAdjustments { get; set; } = default!;
    public DbSet<StockTransfer> StockTransfers { get; set; } = default!;
    public DbSet<QualityInspection> QualityInspections { get; set; } = default!;
    public DbSet<BarcodeTag> BarcodeTags { get; set; } = default!;
    public DbSet<CycleCount> CycleCounts { get; set; } = default!;
    public DbSet<Container> Containers { get; set; } = default!;
    public DbSet<InventoryValuation> InventoryValuations { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // === STOCK TRANSFER RELATIONSHIPS ===
        modelBuilder.Entity<StockTransfer>()
            .HasOne(st => st.FromWarehouse)
            .WithMany() // One warehouse can be the source of many transfers
            .HasForeignKey(st => st.FromWarehouseId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<StockTransfer>()
            .HasOne(st => st.ToWarehouse)
            .WithMany() // One warehouse can be the destination of many transfers
            .HasForeignKey(st => st.ToWarehouseId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<StockTransfer>()
            .HasOne(st => st.Item)
            .WithMany() // One item can appear in many stock transfers
            .HasForeignKey(st => st.ItemId)
            .OnDelete(DeleteBehavior.Restrict);

        // === REORDER RULE RELATIONSHIP ===
        modelBuilder.Entity<ReorderRule>()
            .HasOne(r => r.Item)
            .WithOne() // One-to-one: each item has one reorder rule
            .HasForeignKey<ReorderRule>(r => r.ItemId)
            .OnDelete(DeleteBehavior.Cascade);

        // === OPTIONAL: Timestamps configuration (if using Base class) ===
        modelBuilder.Entity<Category>().Property(c => c.DateCreated).HasDefaultValueSql("NOW()");
        modelBuilder.Entity<Category>().Property(c => c.DateModified).HasDefaultValueSql("NOW()");
    }
}
