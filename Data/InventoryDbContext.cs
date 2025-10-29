using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Models.Entities
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Inbound> Inbounds { get; set; }
        public DbSet<Outbound> Outbounds { get; set; }
        public DbSet<StockAdjustment> StockAdjustments { get; set; }
        public DbSet<ReorderAlert> ReorderAlerts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<PurchaseOrderItemTax> PurchaseOrderItemTaxes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
      
         modelBuilder.Entity<ReorderAlert>()
        .HasKey(r => r.ReorderId);

        modelBuilder.Entity<StockAdjustment>()
        .HasKey(sa => sa.AdjustmentId);
            // Category → Item
            
            modelBuilder.Entity<Item>()
                .HasOne(i => i.Category)
                .WithMany(c => c.Items)
                .HasForeignKey(i => i.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Warehouse → Stock
            modelBuilder.Entity<Stock>()
                .HasOne(s => s.Warehouse)
                .WithMany(w => w.Stocks)
                .HasForeignKey(s => s.WarehouseId)
                .OnDelete(DeleteBehavior.Restrict);

            // Item → Stock
            modelBuilder.Entity<Stock>()
                .HasOne(s => s.Item)
                .WithMany()
                .HasForeignKey(s => s.ItemId)
                .OnDelete(DeleteBehavior.Restrict);

            // Supplier → Inbound
            modelBuilder.Entity<Inbound>()
                .HasOne(i => i.Supplier)
                .WithMany(s => s.Inbounds)
                .HasForeignKey(i => i.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);

            // Warehouse → Inbound
            modelBuilder.Entity<Inbound>()
                .HasOne(i => i.Warehouse)
                .WithMany()
                .HasForeignKey(i => i.WarehouseId)
                .OnDelete(DeleteBehavior.Restrict);

            // Item → Inbound
            modelBuilder.Entity<Inbound>()
                .HasOne(i => i.Item)
                .WithMany()
                .HasForeignKey(i => i.ItemId)
                .OnDelete(DeleteBehavior.Restrict);

            // Warehouse → Outbound
            modelBuilder.Entity<Outbound>()
                .HasOne(o => o.Warehouse)
                .WithMany()
                .HasForeignKey(o => o.WarehouseId)
                .OnDelete(DeleteBehavior.Restrict);

            // Item → Outbound
            modelBuilder.Entity<Outbound>()
                .HasOne(o => o.Item)
                .WithMany()
                .HasForeignKey(o => o.ItemId)
                .OnDelete(DeleteBehavior.Restrict);

            // Warehouse → ReorderAlert
            modelBuilder.Entity<ReorderAlert>()
                .HasOne(r => r.Warehouse)
                .WithMany()
                .HasForeignKey(r => r.WarehouseId)
                .OnDelete(DeleteBehavior.Restrict);

            // Item → ReorderAlert
            modelBuilder.Entity<ReorderAlert>()
                .HasOne(r => r.Item)
                .WithMany()
                .HasForeignKey(r => r.ItemId)
                .OnDelete(DeleteBehavior.Restrict);

            // Warehouse → Manager
            modelBuilder.Entity<Warehouse>()
                .HasOne(w => w.Manager)
                .WithOne()
                .HasForeignKey<Warehouse>(w => w.ManagerId)
                .OnDelete(DeleteBehavior.SetNull);

            // StockAdjustment → Item & Warehouse
            modelBuilder.Entity<StockAdjustment>()
                .HasOne(sa => sa.Item)
                .WithMany()
                .HasForeignKey(sa => sa.ItemId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StockAdjustment>()
                .HasOne(sa => sa.Warehouse)
                .WithMany()
                .HasForeignKey(sa => sa.WarehouseId)
                .OnDelete(DeleteBehavior.Restrict);

            // User Role enum conversion
            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasConversion<string>();

            // PurchaseOrder → Supplier
            modelBuilder.Entity<PurchaseOrder>()
                .HasOne(po => po.Supplier)
                .WithMany(s => s.PurchaseOrders) // make sure Supplier has PurchaseOrders collection
                .HasForeignKey(po => po.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);

            // PurchaseOrder → Warehouse
            modelBuilder.Entity<PurchaseOrder>()
                .HasOne(po => po.Warehouse)
                .WithMany(w => w.PurchaseOrders) // make sure Warehouse has PurchaseOrders collection
                .HasForeignKey(po => po.WarehouseId)
                .OnDelete(DeleteBehavior.Restrict);

            // PurchaseOrderItem → PurchaseOrder & Item
            modelBuilder.Entity<PurchaseOrderItem>()
                .HasOne(poi => poi.PurchaseOrder)
                .WithMany(po => po.PurchaseOrderItems)
                .HasForeignKey(poi => poi.PurchaseOrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PurchaseOrderItem>()
                .HasOne(poi => poi.Item)
                .WithMany()
                .HasForeignKey(poi => poi.ItemId)
                .OnDelete(DeleteBehavior.Restrict);

            // PurchaseOrderItemTax → PurchaseOrderItem & Tax
            modelBuilder.Entity<PurchaseOrderItemTax>()
                .HasOne(poit => poit.PurchaseOrderItem)
                .WithMany(poi => poi.PurchaseOrderItemTaxes)
                .HasForeignKey(poit => poit.PurchaseOrderItemId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PurchaseOrderItemTax>()
                .HasOne(poit => poit.Tax)
                .WithMany(t => t.PurchaseOrderItemTaxes)
                .HasForeignKey(poit => poit.TaxId)
                .OnDelete(DeleteBehavior.Restrict);

            // Optional: Configure property constraints
            modelBuilder.Entity<Item>()
                .Property(i => i.ItemName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Category>()
                .Property(c => c.CategoryName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Warehouse>()
                .Property(w => w.WarehouseName)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
