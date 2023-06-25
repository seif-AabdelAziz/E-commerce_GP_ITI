using System.Text.Json;
namespace E_Commerce.DAL;

public class ECommerceContextSeed
{

    public static async Task SeedAsync(E_CommerceContext context)
    {
        if (!context.Products.Any())
        {

            var ProductsData = File.ReadAllText("../E_Commerce.DAL/Data/SeedData/Products.json");
            var Products = JsonSerializer.Deserialize<List<Product>>(ProductsData);
            context.Products.AddRange(Products!);
        }

        if (!context.Categories.Any())
        {

            var CategoriesData = File.ReadAllText("../E_Commerce.DAL/Data/SeedData/Categories.json");
            var Categories = JsonSerializer.Deserialize<List<Category>>(CategoriesData);
            context.Categories.AddRange(Categories!);
        }

        if (!context.Orders.Any())
        {

            var OrdersData = File.ReadAllText("../E_Commerce.DAL/Data/SeedData/Orders.json");
            var Orders = JsonSerializer.Deserialize<List<Order>>(OrdersData);
            context.Orders.AddRange(Orders!);
        }

        if (!context.Customers.Any())
        {

            var CustomersData = File.ReadAllText("../E_Commerce.DAL/Data/SeedData/Customers.json");
            var Customers = JsonSerializer.Deserialize<List<Customer>>(CustomersData);
            context.Customers.AddRange(Customers!);
        }
        if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();



    }





}
