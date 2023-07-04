using Azure;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.DAL;

public class ProductsRepo : GenericRepo<Product>, IProductsRepo
{
    private readonly E_CommerceContext _context;

    public ProductsRepo(E_CommerceContext context) : base(context)
    {
        _context = context;
    }


    public Product? GetProductDetails(Guid id)
    {
        return _context.Set<Product>()
            .Include(p => p.ProductImages)
            .Include(p => p.Product_Color_Size_Quantity)
            .FirstOrDefault(p => p.Id == id);
    }

    public Product? GetProductReviews(Guid id)
    {
        return _context.Set<Product>()
            .Include(p => p.Reviews!)
            .ThenInclude(c => c.Customer)
            .FirstOrDefault(p => p.Id == id);
    }
    public Product? GetProductCategories(Guid id)
    {
        return _context.Set<Product>()
            .Include(p => p.Categories)
            .FirstOrDefault(p => p.Id == id);
    }

    public Product? GetProductToUpdate(Guid id)
    {
        return _context.Set<Product>()
            .Include(p => p.ProductImages)
            .Include(p => p.Product_Color_Size_Quantity)
            .Include(p => p.Categories)
            .FirstOrDefault(p => p.Id == id);
    }

    public List<Product> GetAllProductsPagination(int page, int countPerPage)
    {

        return _context.Set<Product>().Include(a=>a.ProductImages).OrderBy(c => c.Price)
            .Skip((page - 1) * countPerPage)
            .Take(countPerPage).ToList();
    }

    public int GetCount()
    {
        return _context.Set<Product>().Count();
    }
}
