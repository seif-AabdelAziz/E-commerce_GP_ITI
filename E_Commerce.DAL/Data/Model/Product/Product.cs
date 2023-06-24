namespace E_Commerce.DAL;

public class Product
{
    public Guid ID { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal Discount { get; set; } = 0;
    public decimal Rate { get; set; } = 0;
    public List<Product_IMG> ProductImages { get; set; } = new List<Product_IMG>();
    public List<ProductColorSizeQuantity> Product_Color_Size_Quantity { get; set; } = new List<ProductColorSizeQuantity>();
    public List<CustomerReview>? Reviews { get; set; }

    public List<CartProduct>? Carts { get; set; }

}
