using Microsoft.EntityFrameworkCore;

namespace E_Commerce.DAL;

public class CustomerReviewRepo : GenericRepo<CustomerReview>, ICustomerReviewRepo
{
    private readonly E_CommerceContext context;

    public CustomerReviewRepo(E_CommerceContext context) : base(context)
    {
        this.context = context;
    }

    public List<CustomerReview> GetAllReviewsCustomersProducts()
    {
        return context.Set<CustomerReview>()
                        .Include(cr=>cr.Product)
                        .Include(cr=>cr.Customer)
                        .ToList();
    }

    public List<CustomerReview> GetCustomerProductsReviews(Guid customerId)
    {
        return context.Set<CustomerReview>()
                        .Include(cr => cr.Product)
                        .Where(cr => new Guid(cr.CustomerId) == customerId)
                        .ToList();
    }

    public List<CustomerReview> GetProductCustomersReviews(Guid productId)
    {
        return context.Set<CustomerReview>()
                        .Include(cr => cr.Customer)
                        .Where(cr => cr.ProductId == productId)
                        .ToList();
    }
}
