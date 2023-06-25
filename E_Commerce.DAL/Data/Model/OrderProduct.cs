using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DAL;

[PrimaryKey(nameof(ProductId), nameof(OrderId))]
public class OrderProduct
{
    public int ProductCount { get; set; }
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
    public Guid OrderId { get; set; }
    public Order? Order { get; set; }
}
