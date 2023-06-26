﻿using E_Commerce.DAL;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.BL;

public class ProductAddDto
{
    [MinLength(3)]
    [MaxLength(30)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    [Range(0, 1)]
    public decimal Discount { get; set; } = 0;
    [Range(0, 5)]
    public decimal Rate { get; set; } = 0;
    public List<ProductAddImageDto> ProductImages { get; set; } = null!;
    public List<ProductAdd_InfoDto> ProductInfo { get; set; } = null!;
}
