using AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Item, ItemDto>().ReverseMap();
        CreateMap<Warehouse, WarehouseDto>().ReverseMap();
        CreateMap<Stock, StockDto>().ReverseMap();
        CreateMap<Supplier, SupplierDto>().ReverseMap();
        CreateMap<Inbound, InboundDto>().ReverseMap();
        CreateMap<Outbound, OutboundDto>().ReverseMap();
        CreateMap<StockAdjustment, StockAdjustmentDto>().ReverseMap();
        CreateMap<ReorderAlert, ReorderAlertDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<PurchaseOrder, PurchaseOrderDto>().ReverseMap();
        CreateMap<PurchaseOrderItem, PurchaseOrderItemDto>().ReverseMap();
        CreateMap<Tax, TaxDto>().ReverseMap();
        CreateMap<PurchaseOrderItemTax, PurchaseOrderItemTaxDto>().ReverseMap();
    }
}
