
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.DAL;

public class Cart
{
    [Required]
    [Key]
    public Guid CartId { get; set; }

    [ForeignKey("Customer")]
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }


    public List<CartProduct> Products { get; set; }
}
