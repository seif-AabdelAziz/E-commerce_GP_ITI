
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.DAL;

[PrimaryKey(nameof(ProductID), nameof(Color), nameof(Size))]
public class Product_Color_Size_Quantity
{
    public Guid ProductID { get; set; }
    public Product Product { get; set; } = null!;
    public Color Color { get; set; }
    public Size Size { get; set; }
    public int Quantity { get; set; }
}
