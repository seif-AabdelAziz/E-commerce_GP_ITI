namespace E_Commerce.DAL;

public interface ICustomerReviewRepo:IGenericRepo<CustomerReview>
{
    List<CustomerReview> GetCustomerProductsReviews(Guid customerId);
    List<CustomerReview> GetProductCustomersReviews(Guid productId);
    List<CustomerReview> GetAllReviewsCustomersProducts();
}
