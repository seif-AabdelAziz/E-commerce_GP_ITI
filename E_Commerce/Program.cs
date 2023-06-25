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

#region InjectionForRepo
builder.Services.AddScoped<ICartRepo, CartRepo>();
builder.Services.AddScoped<ICategoriesRepo, CategoriesRepo>();
builder.Services.AddScoped<ICustomerReviewRepo, CustomerReviewRepo>();
builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
builder.Services.AddScoped<IOrderRepo, OrderRepo>();
builder.Services.AddScoped<IProductsRepo, ProductsRepo>();
builder.Services.AddScoped<IUsersRepo, UsersRepo>();
builder.Services.AddScoped<IWishListRepo,WishListRepo>();
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
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
