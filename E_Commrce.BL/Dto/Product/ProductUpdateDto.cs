using System.ComponentModel.DataAnnotations;

namespace E_Commerce.BL;

public class ProductUpdateDto
{
    public Guid Id { get; set; }
    [MinLength(3)]
    [MaxLength(30)]
    public string Name { get; set; } = null!;
    [MaxLength(500)]
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    [Range(0, 1)]
    public decimal Discount { get; set; }
    [Range(0, 5)]
    public decimal Rate { get; set; }
    public List<ProductImageDto> ProductImages { get; set; } = null!;
    public List<ProductInfoDto> ProductInfo { get; set; } = null!;
    public List<ProductAddCategoryDto> ProductCategories { get; set; } = null!;
}
