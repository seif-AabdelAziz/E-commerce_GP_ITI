namespace E_Commerce.DAL;

public interface IProductsRepo : IGenericRepo<Product>
{
    Product? GetProductDetails(Guid id);
    Product? GetProductReviews(Guid id);
    Product? GetProductCategories(Guid id);
    Product? GetProductToUpdate(Guid id);

}
