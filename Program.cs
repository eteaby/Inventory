


using Inventory.Repositories.Implementations;
using Inventory.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// === Database Connection ===
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<InventoryDbContext>(options =>
    options.UseNpgsql(connectionString));

// === Controllers ===
builder.Services.AddControllers();

// === AutoMapper ===
builder.Services.AddAutoMapper(typeof(MappingProfile));

// === Services ===

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IItemService, ItemService>();

builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IWarehouseService, WarehouseService>();

//builder.Services.AddScoped<IStockService, StockService>();

builder.Services.AddScoped<IReorderRuleService, ReorderRuleService>();

builder.Services.AddScoped<IStockAdjustmentService, StockAdjustmentService>();

//builder.Services.AddScoped<IContainerService, ContainerService>();


// === Swagger ===
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Inventory API", Version = "v1" });
});

// === Add Authorization (Optional) ===
builder.Services.AddAuthorization();

var app = builder.Build();

// === Database Seeding ===
/*using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<InventoryDbContext>();
    db.SeedData();
}*/

// === Middleware ===
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Inventory API v1");
    });
}

app.UseHttpsRedirection();

// Authorization middleware (optional if you plan to protect endpoints in future)
app.UseAuthorization();

app.MapControllers();

app.Run();
