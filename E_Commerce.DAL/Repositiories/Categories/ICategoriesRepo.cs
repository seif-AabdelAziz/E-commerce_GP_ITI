namespace E_Commerce.DAL;

public interface ICategoriesRepo : IGenericRepo<Category>
{

    Category? GetParentCategory(Guid subCategoryId);
    List<Category>? GetSubCategories(Guid parentCategoryId);
    Category? GetProductsForCategory(Guid categorytId);
    List<Category>? GetAllCategoriesWithAllPrdoucts();
    Category? GetCategoryById(string categorytId);
    List<Product>? GetProductsByCategoryId(Guid categoryId);

}
