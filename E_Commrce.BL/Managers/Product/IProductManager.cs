namespace E_Commerce.BL;

public interface IProductManager
{
    List<ProductReadDto> AllProducts();
    bool Add(ProductAddDto productAdd);
    bool Delete(Guid productId);
    ProductDetailsReadDto? ProductDetails(Guid productId);
}
