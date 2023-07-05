
namespace E_Commerce.BL
{
    public class AddToCartDto
    {

        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public int ProductCount { get; set; }
        public string? Color { get; set; }
        public string? Size { get; set; }

    }
}
