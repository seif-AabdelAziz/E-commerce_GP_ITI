
namespace E_Commerce.BL
{
    public class AddToCartDto
    {

        public Guid CustomerId { get; set; }
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public int ProductCount { get; set; }

    }
}
