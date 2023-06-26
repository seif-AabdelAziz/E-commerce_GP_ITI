
namespace E_Commerce.BL
{
    public class AddToCartDto
    {

        public string CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public int ProductCount { get; set; }

    }
}
