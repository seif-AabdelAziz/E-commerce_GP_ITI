﻿
namespace E_Commerce.BL
{
    public class UpdateToCartDto
    {
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

    }
}