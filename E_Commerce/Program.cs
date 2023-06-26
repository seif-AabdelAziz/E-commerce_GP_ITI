using E_Commerce.BL;
using E_Commerce.DAL;
using Microsoft.AspNetCore.Identity;
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
builder.Services.AddScoped<IWishListRepo, WishListRepo>();
builder.Services.AddScoped<ICartProductRepo, CartsProductRepo>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
#endregion

#region InjectionForMangers
builder.Services.AddScoped<ICustomerManager, CustomerManager>();
builder.Services.AddScoped<IProductManager, ProductManager>();

#endregion


<<<<<<< Updated upstream
=======


>>>>>>> Stashed changes
#region Identity

//Mainly specify the context and the type of the user that the UserManger will use
builder.Services.AddIdentity<Customer, IdentityRole>(options =>
{
    options.Password.RequiredUniqueChars = 3;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 3;
    options.User.RequireUniqueEmail = false;

}).AddEntityFrameworkStores<E_CommerceContext>();



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
