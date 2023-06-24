using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DAL;

public class OrderProdct
{
    public Guid ProductId { get; set; }
    public Guid OrderId { get; set; }
    [MinLength(1)]
    public int ProductCount { get; set; }

    public Product? Product { get; set; }
    public Order? Order { get; set; }
}
