
namespace Inventory.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Item> Items { get; }
        IGenericRepository<Category> Categories { get; }
        IGenericRepository<Warehouse> Warehouses { get; }
        IGenericRepository<Stock> Stocks { get; }
        IGenericRepository<ReorderRule> ReorderRules { get; }
        IGenericRepository<StockAdjustment> StockAdjustments { get; }
        IGenericRepository<Container> Containers { get; }
        IGenericRepository<StorageLocation> StorageLocations { get; }

        Task<int> CommitAsync();
    }
}
