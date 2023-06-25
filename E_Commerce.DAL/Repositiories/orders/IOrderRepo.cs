

namespace E_Commerce.DAL
{
    public interface IOrderRepo :IGenericRepo<Order>
    {
        Customer? GetCustomerByOrderId(Guid id);
        Order? GetOrderProducts(Guid id);
        Order? GetOrderProductsAndCustomer(Guid id);
        Order? GetOrderDetails(Guid id);
    }
}
