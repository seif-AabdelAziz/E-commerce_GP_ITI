using E_Commerce.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderManager _orderManager;

        public OrdersController(IOrderManager orderManager) 
        {
            _orderManager = orderManager;
        }
        [HttpGet]
        public ActionResult<List<OrderReadDto>> AllOrders() 
        {
            return _orderManager.GetAllOrders();
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<OrderReadDto> GetOrder(Guid id) 
        {
            return _orderManager.GetOrderById(id);
        }
        [HttpPost]
        public ActionResult AddOrder(OrderAddDto order) 
        {
            bool req =_orderManager.AddOrder(order);
            if(!req) return BadRequest(req);
            return Ok();
        }
        [HttpPut]
        [Route("{id}")]
        public ActionResult UpdateOrder(OrderUpdateDto orderUpdate) 
        {
            bool req=_orderManager.UpdateOrder(orderUpdate);
            if(!req) return BadRequest(req);
            return Ok("Updated Sucessfully");
        }
        [HttpDelete]
        public ActionResult DeleteOrder(Guid id) 
        {
            bool req =_orderManager.DeleteOrder(id);
            if(!req) return BadRequest(req);
            return Ok("Deleted Sucessfully");
        }

        [HttpGet]
        [Route("Details/{id}")]
        public ActionResult<OrderWithProductsAndCustomerReadDto> Details(Guid id) 
        {
            OrderWithProductsAndCustomerReadDto? orderDetails =_orderManager.OrderWithProductsAndCustomerRead(id);
            if (orderDetails is null) return BadRequest();
            return orderDetails;
        }

        [HttpGet]
        [Route("OrderProducts/{id}")]
        public ActionResult<OrderWithProductsReadDto> OrderProducts(Guid id)
        {
            OrderWithProductsReadDto? OrderProducts = _orderManager.OrderWithProductsRead(id);
            if (OrderProducts is null) return BadRequest();
            return OrderProducts;
        }




    }
}
