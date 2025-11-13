using AutoMapper;


public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Item
        CreateMap<Item, ItemDto>().ReverseMap();
        CreateMap<Item, ItemCreateDto>().ReverseMap();

        // Category
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Category, CategoryCreateDto>().ReverseMap();

        //  Warehouse
        CreateMap<Warehouse, WarehouseDto>().ReverseMap();
        CreateMap<Warehouse, WarehouseCreateDto>().ReverseMap();

        // Stock
        CreateMap<Stock, StockDto>().ReverseMap();
        CreateMap<Stock, StockCreateDto>().ReverseMap();

        // Reorder Rule
        CreateMap<ReorderRule, ReorderRuleDto>().ReverseMap();
        CreateMap<ReorderRule, ReorderRuleCreateDto>().ReverseMap();
        CreateMap<ReorderRule, ReorderAlertDto>().ReverseMap();
        
        // Stock Adjustment
        CreateMap<StockAdjustment, StockAdjustmentDto>().ReverseMap();
        CreateMap<StockAdjustment, StockAdjustmentCreateDto>().ReverseMap();

        CreateMap<Container, ContainerDto>().ReverseMap();
        CreateMap<Container, ContainerCreateDto>().ReverseMap();




             /*


                                                

                                                // Storage Location
                                                CreateMap<StorageLocation, StorageLocationDto>().ReverseMap();

                                                // Stock Transaction
                                                CreateMap<StockTransaction, StockTransactionDto>().ReverseMap();

                                                // Batch & Serial Number
                                                CreateMap<Batch, BatchDto>().ReverseMap();
                                                CreateMap<SerialNumber, SerialNumberDto>().ReverseMap();

                                                // Reorder Rule
                                                CreateMap<ReorderRule, ReorderRuleDto>().ReverseMap();

                                                // Stock Transfer
                                                CreateMap<StockTransfer, StockTransferDto>().ReverseMap();

                                                // Quality Inspection
                                                CreateMap<QualityInspection, QualityInspectionDto>().ReverseMap();

                                                // Barcode Tag
                                                CreateMap<BarcodeTag, BarcodeTagDto>().ReverseMap();

                                                // Cycle Count
                                                CreateMap<CycleCount, CycleCountDto>().ReverseMap();

                                                // Container
                                                CreateMap<Container, ContainerDto>().ReverseMap();

                                                // Inventory Valuation
                                                CreateMap<InventoryValuation, InventoryValuationDto>().ReverseMap();*/
    }
}
