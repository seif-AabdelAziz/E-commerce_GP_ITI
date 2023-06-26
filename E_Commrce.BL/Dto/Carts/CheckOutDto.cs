using E_Commerce.DAL;

namespace E_Commerce.BL
{
    public class CheckOutDto
    {
        public Guid CustomerId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public Countries Country { get; set; }
    }
}
