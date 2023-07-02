using Microsoft.EntityFrameworkCore;

namespace E_Commerce.DAL;

public class CategoriesRepo : GenericRepo<Category>, ICategoriesRepo
{

    public readonly E_CommerceContext _context;

    public CategoriesRepo(E_CommerceContext context) : base(context)
    {

        _context = context;

    }

    public Category? GetParentCategory(Guid subCategoryId)
    {
        var subCategory = _context.Set<Category>().FirstOrDefault(i => i.Id == subCategoryId);

        if (subCategory == null) { return null; }
        return _context.Set<Category>()
            .FirstOrDefault(i => i.Id == subCategory.ParentCategoryId);
    }


    public List<Category>? GetSubCategories(Guid parentCategoryId)
    {
        return _context.Set<Category>()
            .Where(i => i.ParentCategoryId == parentCategoryId)
            .ToList();

    }

    public Category? GetProductsForCategory(Guid categorytId)
    {
        return _context.Set<Category>()
         .Include(i => i.Products)
         .FirstOrDefault(i => i.Id == categorytId);
    }

    public List<Category>? GetAllCategoriesWithAllPrdoucts()
    {
        return _context.Set<Category>()
            .Include(i => i.Products)
            .ToList();
    }

    public Category? GetCategoryById(string  categorytId)
    {
        return _context.Set<Category>()
            .FirstOrDefault(i => i.Id ==Guid.Parse( categorytId));
    }


    public List<Product> GetProductsByCategoryId(Guid categoryId)
    {
        Category? category = _context.Set<Category>()
            .Include(c => c.Products)
            .FirstOrDefault(c => c.Id == categoryId);

        if (category != null)
        {
            return category.Products.ToList();
        }

        return new List<Product>(); 
    }

}
