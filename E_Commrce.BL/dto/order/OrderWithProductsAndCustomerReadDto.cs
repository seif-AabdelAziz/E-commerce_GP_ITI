using E_Commerce.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL;

public class OrderWithProductsAndCustomerReadDto
{
    public Guid Id { get; set; }
    public DateTime OrderData { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public OrderStatus OrderStatus { get; set; }
    [Range(0, 1)]
    public double Discount { get; set; }
    public DateTime ArrivalDate { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public Countries Country { get; set; }

    public string? CustomerId { get; set; }
    public string? CustomerFname { get; set; }
    public string? CustomerMname { get; set; }
    public string? CustomerLname { get; set; }

    public List<ProductChildReadDto>? OrderProducts { get; set; }

}
