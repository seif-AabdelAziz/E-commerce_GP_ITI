namespace E_Commerce.DAL;

public class CategoriesRepo : GenericRepo<Category>, ICategoriesRepo
{

    public readonly E_CommerceContext _context;

    public CategoriesRepo(E_CommerceContext context) : base(context)
    {

        _context = context;

    }
    public IEnumerable<Category> GetParentCategories(Guid categoryId)
    {
        var parentCategories = new List<Category>();

        var subcategory = _context.Set<Category>().FirstOrDefault(c => c.Id == categoryId);


        if (subcategory != null)
        {
            var parentCategory = subcategory.ParentCategory;

            while (parentCategory != null)
            {
                parentCategories.Add(parentCategory);
                parentCategory = parentCategory.ParentCategory;
            }
        }

        return parentCategories;
    }





    public IEnumerable<Category> GetSubCategories(Guid CategoryId)
    {
        var subCategories = new List<Category>();

        var parentCategory = _context.Set<Category>().FirstOrDefault(c => c.Id == CategoryId);

        if (parentCategory != null)
        {
            subCategories.AddRange(parentCategory.SubCategories);

        }

        if (parentCategory.SubCategories != null)

            // Recursively get subcategories from each subcategory
            foreach (var subCategory in parentCategory.SubCategories)
            {
                var subCategorySubCategories = subCategory.SubCategories;
                subCategories.AddRange(subCategorySubCategories);
            }

        return subCategories;
    }




    public IEnumerable<Product> GetProductsForCategory(Guid categoryId)
    {
        var products = new List<Product>();

        var category = _context.Set<Category>().FirstOrDefault(c => c.Id == categoryId);

        if (category != null)
        {
            products.AddRange(category.Products);

        }

        return products;
    }

}
