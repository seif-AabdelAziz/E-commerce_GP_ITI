namespace E_Commerce.DAL;

public interface IProductsRepo : IGenericRepo<Product>
{

    List<Product> GetAllProductsPagination(int page, int countPerPage);
    int GetCount();
    Product? GetProductDetails(Guid id);
    Product? GetProductReviews(Guid id);
    Product? GetProductCategories(Guid id);
    Product? GetProductToUpdate(Guid id);
    List<Product> GetProductsWithImages();


}
