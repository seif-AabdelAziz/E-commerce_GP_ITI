using E_Commerce.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ECommerceContext>(option =>
                option.UseSqlServer("Server=.; Database=MyE_Commerce; Trusted_Connection=true; Encrypt=false; "));

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

//#region Seeding

//using var scope = app.Services.CreateScope();
//    var Services = scope.ServiceProvider;
//    var context = Services.GetRequiredService<ECommerceContext>();
//    await ECommerceContextSeed.SeedAsync(context);


//#endregion



using var scope = app.Services.CreateScope();
var Services = scope.ServiceProvider;
var context = Services.GetRequiredService<ECommerceContext>();
var Logger = Services.GetRequiredService<ILogger<Program>>();

try
{
    await context.Database.MigrateAsync();
    await ECommerceContextSeed.SeedAsync(context);
}
catch (Exception ex)
{
    Logger.LogError(ex, "Error occured while migrating process");
}


app.Run();
