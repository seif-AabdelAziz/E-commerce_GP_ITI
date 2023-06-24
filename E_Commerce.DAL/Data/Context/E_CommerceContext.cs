using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL;

public class E_CommerceContext :DbContext
{
    public DbSet<Admin> Admins => Set<Admin>();
    //Customer Tables
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<CustomerPhones> CustomerPhones => Set<CustomerPhones>();
    public DbSet<CustomerReview> CustomersReviews => Set<CustomerReview>();
    //Product Tables
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductColorSizeQuantity> ProductsInfo => Set<ProductColorSizeQuantity>();
    public DbSet<Product_IMG> ProductImages => Set<Product_IMG>();

    //Cart
    public DbSet<Cart> Carts => Set<Cart>();
    public DbSet<CartProduct> CartProducts => Set<CartProduct>();


    //Order
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderProdct> OrderProducts => Set<OrderProdct>();

    //WishList
    public DbSet<WishList> WishLists => Set<WishList>();

    //Category

    public DbSet<Category> Categories => Set<Category>();

    public E_CommerceContext(DbContextOptions options):base(options)
    {
        
    }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());






    }


}
