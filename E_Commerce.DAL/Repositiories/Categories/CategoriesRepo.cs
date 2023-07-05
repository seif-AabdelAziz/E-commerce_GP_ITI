using Microsoft.EntityFrameworkCore;

namespace E_Commerce.DAL;

public class CategoriesRepo : GenericRepo<Category>, ICategoriesRepo
{

    public readonly E_CommerceContext _context;

    public CategoriesRepo(E_CommerceContext context) : base(context)
    {

        _context = context;

    }

    public List<Category>? GetParentCategory()
    {
        var category = _context.Set<Category>().ToList();

        List<Category> categories = new List<Category>();   
        for (int i = 0; i < category.Count; i++)
        {
            if(category[i].ParentCategory == null)
            {
            categories.Add(category[i]);
            }

        }

        return categories;
    }


    public List<Category>? GetSubCategories(Guid parentCategoryId)
    {
        return _context.Set<Category>().Include(c => c.Products).ThenInclude(c => c.ProductImages)
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
            .Include(c => c.Products).ThenInclude(c=>c.ProductImages)
            .FirstOrDefault(c => c.Id == categoryId);



        return category.Products.ToList(); 
    }

    public List<Product>? GetProductsByName(string productName)
    {
        List<Product>? products = _context.Set<Product>().Where(c => c.Name==productName).ToList();


        return products;

    }

    public List<Product> GetProductsByParentCategory(Guid parentCategoryId)
    {
        var subcategories = _context.Set<Category>()
            .Include(c => c.Products)
                .ThenInclude(p => p.ProductImages)
            .Where(c => c.ParentCategoryId == parentCategoryId)
            .ToList();
        var products = new List<Product>();

        foreach (var category in subcategories)
        {
            products.AddRange(category.Products);
        }

        return products;
    }

}
