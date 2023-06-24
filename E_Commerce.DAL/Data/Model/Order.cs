using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DAL;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderData { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public Address? Address { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public OrderStatus OrderStatus { get; set; }
    [Range(0, 1)]
    public float Discount { get; set; }
    public DateTime ArrivalDate { get; set; }
    public int CustomerId { get; set; }

    public Customer? Customer { get; set; }
}
