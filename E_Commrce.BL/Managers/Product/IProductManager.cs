namespace E_Commerce.BL;

public interface IProductManager
{
    List<ProductReadDto> AllProducts();
    bool Add(ProductAddDto productAdd);
}
