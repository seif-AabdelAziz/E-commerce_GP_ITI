using E_Commerce.DAL;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.BL;

public class OrderManager : IOrderManager
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public List<OrderReadDto> GetAllOrders()
    {
        List<Order> orders = _unitOfWork.OrderRepo.GetAll();
        if (orders is null) { return null!; }
        return orders.Select(o => new OrderReadDto
        {
            OrderData = o.OrderData,
            PaymentStatus = o.PaymentStatus.ToString(),
            PaymentMethod = o.PaymentMethod.ToString(),
            OrderStatus = o.OrderStatus.ToString(),
            Discount = o.Discount,
            ArrivalDate = o.ArrivalDate,
            Street = o.Street,
            City = o.City,
            Country = o.Country.ToString(),
        }).ToList();
    }

    public OrderReadDto GetOrderById(Guid id)
    {
        Order? order = _unitOfWork.OrderRepo.GetById(id);
        if (order is null) { return null!; }
        return new OrderReadDto
        {
            OrderData = order.OrderData,
            PaymentStatus = order.PaymentStatus.ToString(),
            PaymentMethod = order.PaymentMethod.ToString(),
            OrderStatus = order.OrderStatus.ToString(),
            Discount = order.Discount,
            ArrivalDate = order.ArrivalDate,
            Street = order.Street,
            City = order.City,
            Country = order.Country.ToString(),
        };
    }
    public bool AddOrder(OrderAddDto orderAdd)
    {
        Order order = new()
        {
            Id = Guid.NewGuid(),
            OrderData = orderAdd.OrderData,
            PaymentStatus = orderAdd.PaymentStatus,
            PaymentMethod = orderAdd.PaymentMethod,
            OrderStatus = orderAdd.OrderStatus,
            Discount = orderAdd.Discount,
            ArrivalDate = orderAdd.ArrivalDate,
            Street = orderAdd.Street!,
            City = orderAdd.City!,
            Country = orderAdd.Country,
            CustomerId =orderAdd.CustomerId.ToString(),
        };
        order.OrderProducts = orderAdd.OrderProducts!.Select(op => new OrderProduct
        {
            OrderId = order.Id,
            ProductId = op.ProductId,
            ProductCount = op.ProductCount,

        }).ToList();

        _unitOfWork.OrderRepo.Add(order);
        return _unitOfWork.SaveChange() > 0;
    }
    public bool UpdateOrder(OrderUpdateDto orderUpdate)
    {
        Order? order = _unitOfWork.OrderRepo.GetById(orderUpdate.Id);
        if (order is null) return false;

        order.PaymentStatus = orderUpdate.PaymentStatus;
        order.PaymentMethod = orderUpdate.PaymentMethod;
        order.OrderStatus = orderUpdate.OrderStatus;
        order.Discount = orderUpdate.Discount;
        order.ArrivalDate = orderUpdate.ArrivalDate;
        order.Street = orderUpdate.Street!;
        order.City = orderUpdate.City!;
        order.Country = orderUpdate.Country;
        

        _unitOfWork.OrderRepo.Update(order); //add
        return _unitOfWork.SaveChange() > 0;
    }
    public OrderWithProductsAndCustomerReadDto? OrderWithProductsAndCustomerRead(Guid id)
    {
        Order? order = _unitOfWork.OrderRepo.GetOrderProductsAndCustomer(id);
        if (order is null) { return null; }
        return new OrderWithProductsAndCustomerReadDto
        {
            Id = order.Id,
            OrderData = order.OrderData,
            PaymentStatus = order.PaymentStatus,
            PaymentMethod = order.PaymentMethod,
            OrderStatus = order.OrderStatus,
            Discount = order.Discount,
            ArrivalDate = order.ArrivalDate,
            Street = order.Street,
            City = order.City,
            Country = order.Country,

            CustomerId = order.CustomerId,
            CustomerFname = order.Customer.FirstName,
            CustomerMname = order.Customer.MidName,
            CustomerLname = order.Customer.LastName,


            OrderProducts = order.OrderProducts.Select(op => new ProductChildReadDto
            {
                Id = op.OrderId,
                Name = op.Product!.Name,
                Description = op.Product!.Description,
                Price = op.Product.Price,
                Discount = (double)op.Product.Discount,
            }).ToList()

        };
    }

    public OrderWithProductsReadDto? OrderWithProductsRead(Guid id)
    {
        Order? order = _unitOfWork.OrderRepo.GetOrderProducts(id);
        if (order is null) { return null; }
        return new OrderWithProductsReadDto
        {
            Id = order.Id,
            OrderData = order.OrderData,
            PaymentStatus = order.PaymentStatus,
            PaymentMethod = order.PaymentMethod,
            OrderStatus = order.OrderStatus,
            Discount = order.Discount,
            ArrivalDate = order.ArrivalDate,
            Street = order.Street,
            City = order.City,
            Country = order.Country,

            OrderProducts = order.OrderProducts.Select(op => new ProductChildReadDto
            {
                Id = op.OrderId,
                Name = op.Product!.Name,
                Description = op.Product!.Description,
                Price = op.Product.Price,
                Discount = (double)op.Product.Discount,
            }).ToList()

        };
    }

    public bool DeleteOrder(Guid id)
    {
        Order? order = _unitOfWork.OrderRepo.GetById(id);
        if (order != null)
        {
            _unitOfWork.OrderRepo.Delete(order);
            return _unitOfWork.SaveChange() > 0;
        }
        return false;
    }

    public bool DeleteProductFromOrder(Guid orderId, Guid productId)
    {
        Order? order = _unitOfWork.OrderRepo.GetById(orderId);
        if (order == null)
        {
            return false;
        }
        OrderProduct? orderProduct = order.OrderProducts.FirstOrDefault(op => op.ProductId == productId);

        if (orderProduct == null)
        {
            return false;
        }
        _unitOfWork.OrderRepo.DeleteFromOrderProductsByProductId(orderProduct.OrderId);
        //order.OrderProducts.Remove(orderProduct);

        return _unitOfWork.SaveChange() > 0; 
    }
}
