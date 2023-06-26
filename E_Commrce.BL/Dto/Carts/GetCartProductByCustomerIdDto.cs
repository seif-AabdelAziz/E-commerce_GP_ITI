
namespace E_Commerce.BL
{
    public class GetCartProductByCustomerIdDto
    {
        public Guid CartId { get; set; }
        public Guid CustomerId { get; set; }
        public List<ProductDto> Products { get; set;  }
        public decimal TotalCost { get; set; }
    }
          public class ProductDto
        {
            public Guid ProductId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
        }
    }
