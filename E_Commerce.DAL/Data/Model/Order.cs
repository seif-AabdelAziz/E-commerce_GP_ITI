using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DAL;

public class Order
{
    public Guid Id { get; set; }
    public DateTime OrderData { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public OrderStatus OrderStatus { get; set; }
    [Range(0, 1)]
    public decimal Discount { get; set; }
    public DateTime ArrivalDate { get; set; }
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public Countries Country { get; set; }

    public Guid CustomerId { get; set; }
    public Customer? Customer { get; set; }
}
