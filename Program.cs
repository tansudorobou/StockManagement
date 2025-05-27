using Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// DI登録
builder.Services.AddSingleton<Infrastructure.Data.InMemoryDataStore>();
builder.Services.AddSingleton<IInventoryRepository, InMemoryInventoryRepository>();
builder.Services.AddSingleton<IInOutRepository, InMemoryInOutRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

// 在庫一覧取得
app.MapGet("/inventories", (IInventoryRepository repo) =>
{
    return repo.GetAll();
}).WithName("GetInventories");

// 入出庫履歴一覧取得
app.MapGet("/inouts", (IInOutRepository repo) =>
{
    return repo.GetAll();
}).WithName("GetInOuts");

// 在庫追加
app.MapPost("/inventories", (IInventoryRepository repo, Domain.Entities.Inventory inventory) =>
{
    Console.WriteLine(inventory.LotNo.ToString());
    repo.Add(inventory);
    return Results.Created($"/inventories/{inventory.Id}", inventory);
}).WithName("AddInventory");

// 入出庫履歴追加
app.MapPost("/inouts", (IInOutRepository repo, Domain.Entities.InOut inOut) =>
{
    repo.Add(inOut);
    return Results.Created($"/inouts/{inOut.Id}", inOut);
}).WithName("AddInOut");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
