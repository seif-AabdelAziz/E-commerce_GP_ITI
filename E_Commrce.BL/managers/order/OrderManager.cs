using E_Commerce.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL;

public class OrderManager : IOrderManager
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public List<OrderReadDto> GetAllOrdersDto()
    {
        List<Order> orders = _unitOfWork.OrderRepo.GetAll();
        if (orders is null) { return null!; }
        return orders.Select(o => new OrderReadDto{
            OrderData=o.OrderData,
            PaymentStatus=o.PaymentStatus,
            PaymentMethod=o.PaymentMethod,
            OrderStatus=o.OrderStatus,
            Discount=o.Discount,
            ArrivalDate=o.ArrivalDate,
            Street=o.Street,
            City=o.City,
            Country=o.Country,
        }).ToList();
    }

    public OrderReadDto GetOrderByIdDto(Guid id)
    {
        Order? order = _unitOfWork.OrderRepo.GetById(id);
        if (order is null) { return null!; }
        return new OrderReadDto
        {
            OrderData = order.OrderData,
            PaymentStatus = order.PaymentStatus,
            PaymentMethod = order.PaymentMethod,
            OrderStatus = order.OrderStatus,
            Discount = order.Discount,
            ArrivalDate = order.ArrivalDate,
            Street = order.Street,
            City = order.City,
            Country = order.Country,
        };
    }
    public void AddOrderDto(OrderAddDto orderAddDto)
    {
        _unitOfWork.OrderRepo.Add(new Order
        {
            Id = Guid.NewGuid(),
            OrderData = orderAddDto.OrderData,
            PaymentStatus = orderAddDto.PaymentStatus,
            PaymentMethod = orderAddDto.PaymentMethod,
            OrderStatus = orderAddDto.OrderStatus,
            Discount = orderAddDto.Discount,
            ArrivalDate = orderAddDto.ArrivalDate,
            Street = orderAddDto.Street!,
            City = orderAddDto.City!,
            Country = orderAddDto.Country,
        });
        _unitOfWork.SaveChange();
    }
    public void UpdateOrderDto(OrderUpdateDto orderUpdateDto)
    {
        Order? order = _unitOfWork.OrderRepo.GetById(orderUpdateDto.Id);
        if (order is null) return;

        order.PaymentStatus = orderUpdateDto.PaymentStatus;
        order.PaymentMethod = orderUpdateDto.PaymentMethod;
        order.OrderStatus = orderUpdateDto.OrderStatus;
        order.Discount = orderUpdateDto.Discount;
        order.ArrivalDate = orderUpdateDto.ArrivalDate;
        order.Street = orderUpdateDto.Street!;
        order.City = orderUpdateDto.City!;
        order.Country = orderUpdateDto.Country;

        _unitOfWork.OrderRepo.Update(order);
        _unitOfWork.SaveChange();
    }
    public OrderWithProductsAndCustomerReadDto? OrderWithProductsAndCustomerReadDto(Guid id)
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
            CustomerFname=order.Customer.FirstName,
            CustomerMname=order.Customer.MidName,
            CustomerLname=order.Customer.LastName,
            

            OrderProducts = order.OrderProducts.Select(op => new ProductChildReadDto
            {
                Id = op.OrderId,
                Name = op.Product!.Name,
                Description = op.Product!.Description,
                Price = op.Product.Price,
                Discount = op.Product.Discount,
            }).ToList()

        };
    }

    public OrderWithProductsReadDto? OrderWithProductsReadDto(Guid id)
    {
        Order? order = _unitOfWork.OrderRepo.GetOrderProducts(id);
        if (order is null) { return null; }
        return new OrderWithProductsReadDto
        {
            Id = order.Id,
            OrderData=order.OrderData,
            PaymentStatus=order.PaymentStatus,
            PaymentMethod=order.PaymentMethod,
            OrderStatus=order.OrderStatus,
            Discount=order.Discount,
            ArrivalDate=order.ArrivalDate,
            Street=order.Street,
            City=order.City,
            Country=order.Country,

            OrderProducts = order.OrderProducts.Select(op=>new ProductChildReadDto 
            { 
                Id=op.OrderId,
                Name = op.Product!.Name,
                Description=op.Product!.Description,
                Price=op.Product.Price,
                Discount=op.Product.Discount,
            }).ToList()

        };
    }

    public void DeleteOrderDto(Guid id)
    {
        Order? order=_unitOfWork.OrderRepo.GetById(id);
        if (order != null) 
        {
            _unitOfWork.OrderRepo.Delete(order);
            _unitOfWork.SaveChange();
        }
    }
}
