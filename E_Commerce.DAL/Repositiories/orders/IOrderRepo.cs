using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL
{
    public interface IOrderRepo :IGenericRepo<Order>
    {
        Customer? GetCustomerByOrderId(Guid id);
        List<OrderProduct> GetOrderProducts(Guid id);
        Order? GetOrderProductsAndCustomer(Guid id);
        List<OrderProduct> GetOrderDetails(Guid id);
    }
}
