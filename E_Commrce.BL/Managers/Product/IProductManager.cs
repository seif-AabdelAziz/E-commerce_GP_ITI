﻿namespace E_Commerce.BL;

public interface IProductManager
{
    List<ProductReadDto> AllProducts();
    bool Add(ProductAddDto productAdd);
    bool Delete(Guid productId);
    ProductDetailsReadDto? ProductDetails(Guid productId);
    List<ProductReviewsDto>? ProductReviews(Guid productId);
    List<ProductCategories>? ProductCategories(Guid productId);
    ProductUpdateDto? ProductToUpdate(Guid productId);
    bool Update(ProductUpdateDto productUpdate);
}