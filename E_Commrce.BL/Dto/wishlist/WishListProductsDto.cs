﻿namespace E_Commerce.BL;

public class WishListProductsDto
{
    public string ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
}
