using Refit;
using Shopping.Aggregator.RefitInterfaces;
using Shopping.Aggregator.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddHttpClient<ICatalogService, CatalogService>(c =>
// {
//     c.BaseAddress = new Uri(builder.Configuration["ApiSettings:CatalogUrl"]);
// });
// builder.Services.AddHttpClient<IBasketService, BasketService>(c =>
// {
//     c.BaseAddress = new Uri(builder.Configuration["ApiSettings:BasketUrl"]);
// });
// builder.Services.AddHttpClient<IOrderService, OrderService>(c =>
// {
//     c.BaseAddress = new Uri(builder.Configuration["ApiSettings:OrderUrl"]);
// });

builder.Services.AddRefitClient<IBasket>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(builder.Configuration["ApiSettings:BasketUrl"]));

builder.Services.AddRefitClient<ICatalog>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(builder.Configuration["ApiSettings:CatalogUrl"]));

builder.Services.AddRefitClient<IOrder>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(builder.Configuration["ApiSettings:OrderUrl"]));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();