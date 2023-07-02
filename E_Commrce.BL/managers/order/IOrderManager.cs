using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL;

public interface IOrderManager
{
    OrderWithProductsReadDto? OrderWithProductsRead(Guid id);
    OrderWithProductsAndCustomerReadDto? OrderWithProductsAndCustomerRead(Guid id);
    List<OrderReadDto> GetAllOrders();
    OrderReadDto GetOrderById(Guid id);
    bool AddOrder(OrderAddDto orderAddDto);  //[1]
    bool UpdateOrder(OrderUpdateDto orderUpdateDto);  //[2]
    bool DeleteOrder(Guid id);

    //new
    bool DeleteProductFromOrder(Guid orderId, Guid productId);

    //[1] +add (products)
    //[2] +update count of prouducts in(orderProduct table)
    //remove some products in order;
}
