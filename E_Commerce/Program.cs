using E_Commerce.DAL;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

#region Default

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

#region DataBase

builder.Services.AddDbContext<E_CommerceContext>(option =>
                option.UseSqlServer(builder.Configuration.GetConnectionString("E_CommerceDB")));

#endregion

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
