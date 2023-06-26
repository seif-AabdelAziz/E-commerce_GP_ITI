using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL;

public interface IOrderManager
{
    OrderWithProductsReadDto? OrderWithProductsReadDto(Guid id);
    OrderWithProductsAndCustomerReadDto? OrderWithProductsAndCustomerReadDto(Guid id);
    List<OrderReadDto> GetAllOrdersDto();
    OrderReadDto GetOrderByIdDto(Guid id);
    void AddOrderDto(OrderAddDto orderAddDto);  //[1]
    void UpdateOrderDto(OrderUpdateDto orderUpdateDto);  //[2]
    void DeleteOrderDto(Guid id);

    //[1] +add (products)
    //[2] +update count of prouducts in(orderProduct table)
    //remove some products in order;
}
