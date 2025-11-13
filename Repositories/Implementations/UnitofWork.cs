
using Inventory.Repositories.Interfaces;

namespace Inventory.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InventoryDbContext _context;

        public IGenericRepository<Item> Items { get; }
        public IGenericRepository<Category> Categories { get; }
        public IGenericRepository<Warehouse> Warehouses { get; }
        public IGenericRepository<Stock> Stocks { get; }
        public IGenericRepository<ReorderRule> ReorderRules { get; }
        public IGenericRepository<StockAdjustment> StockAdjustments { get; }
        public IGenericRepository<Container> Containers { get; }
        public IGenericRepository<StorageLocation> StorageLocations { get; }


        public UnitOfWork(InventoryDbContext context)
        {
            _context = context;

            Items = new GenericRepository<Item>(_context);

            Categories = new GenericRepository<Category>(_context);

            Warehouses = new GenericRepository<Warehouse>(_context);

            Stocks = new GenericRepository<Stock>(_context);

            ReorderRules = new GenericRepository<ReorderRule>(_context);

            StockAdjustments = new GenericRepository<StockAdjustment>(_context);

            Containers = new GenericRepository<Container>(_context);

            StorageLocations = new GenericRepository<StorageLocation>(_context);

        }

        public async Task<int> CommitAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
