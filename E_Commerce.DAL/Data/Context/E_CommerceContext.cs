using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace E_Commerce.DAL;

public class E_CommerceContext : IdentityDbContext
{
    public E_CommerceContext(DbContextOptions options) : base(options)
    {

    }
    //Customer Tables
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<CustomerReview> CustomersReviews => Set<CustomerReview>();
    //Product Tables
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductColorSizeQuantity> ProductsInfo => Set<ProductColorSizeQuantity>();
    public DbSet<Product_IMG> ProductImages => Set<Product_IMG>();

    //Cart
    public DbSet<Cart> Carts => Set<Cart>();


    //Order
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderProduct> OrderProducts => Set<OrderProduct>();

    //WishList
    public DbSet<WishList> WishLists => Set<WishList>();

    //Category

    public DbSet<Category> Categories => Set<Category>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


    }


}
