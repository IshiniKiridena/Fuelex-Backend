using Fuelex_Backend.Models.Customer;
using Fuelex_Backend.Models.FuelStation;
using Fuelex_Backend.Models.FuelType;
using Fuelex_Backend.Models.Queue;
using Fuelex_Backend.Services.Customer;
using Fuelex_Backend.Services.FuelStation;
using Fuelex_Backend.Services.FuelType;
using Fuelex_Backend.Services.Queue;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<CustomerDBSettings>(
    builder.Configuration.GetSection(nameof(CustomerDBSettings)));

builder.Services.Configure<FuelStationDBSettings>(
    builder.Configuration.GetSection(nameof(FuelStationDBSettings)));

builder.Services.Configure<FuelTypeDBSettings>(
    builder.Configuration.GetSection(nameof(FuelTypeDBSettings)));

builder.Services.Configure<QueueDBSettings>(
    builder.Configuration.GetSection(nameof(QueueDBSettings)));

//add DB singletons
builder.Services.AddSingleton<ICustomerDBSettings>(sp => sp.GetRequiredService<IOptions<CustomerDBSettings>>().Value);

builder.Services.AddSingleton<IFuelStationDBSettings>(sp => sp.GetRequiredService<IOptions<FuelStationDBSettings>>().Value);

builder.Services.AddSingleton<IFuelTypeDBSetttings>(sp => sp.GetRequiredService<IOptions<FuelTypeDBSettings>>().Value);

builder.Services.AddSingleton<IQueueDBSettings>(sp => sp.GetRequiredService<IOptions<QueueDBSettings>>().Value);

//DB connection string
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("Connection:ConnectionString")));

//register services
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddScoped<IFuelStationService, FuelStationService>();

builder.Services.AddScoped<IFuelTypeService, FuelTypeService>();

builder.Services.AddScoped<IQueueService, QueueService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
