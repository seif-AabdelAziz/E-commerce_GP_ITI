using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DAL;

public class OrderProdct
{
    public int ProductId { get; set; }
    public int OrderId { get; set; }
    [MinLength(1)]
    public int ProductCount { get; set; }

    public Product? Product { get; set; }
    public Order? Order { get; set; }
}
