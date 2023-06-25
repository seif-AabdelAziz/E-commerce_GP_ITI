
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.DAL;


[PrimaryKey(nameof(CartId))]
public class Cart
{
    public Guid CartId { get; set; }

    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    public List<Product> Products { get; set; } = null!;
}
