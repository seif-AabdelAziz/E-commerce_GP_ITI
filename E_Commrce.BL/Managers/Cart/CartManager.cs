using E_Commerce.DAL;
namespace E_Commerce.BL
{
    public class CartManager : ICartManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddToCart(AddToCartDto addToCartDto, Guid customerId)
        {
            Cart? cart = _unitOfWork.CartRepo.GetCartProductByCustomerId(addToCartDto.CustomerId);
            if(cart != null)
            {
                var cartProducts = cart.Products.ToList();
                cartProducts.Add(new CartProduct
                {
                    ProductId = addToCartDto.ProductId,
                    CartId = cart.CartId,
                });
            }
            
            if (cart == null)
            {
                cart = new Cart
                {
                    CartId = Guid.NewGuid(),
                    CustomerId = addToCartDto.CustomerId,
                    Products = new List<CartProduct>()
                   
                };
                cart.Products.Add(new CartProduct
                {
                    ProductId = addToCartDto.ProductId,
                    CartId = cart.CartId,
                });

                _unitOfWork.CartRepo.Add(cart);
            }

            CartProduct? existingProduct = cart.Products.FirstOrDefault(p => p.ProductId == addToCartDto.ProductId);
            if (existingProduct == null)
            {
                CartProduct newProduct = new CartProduct
                {
                    ProductId = addToCartDto.ProductId,
                    ProductCount = addToCartDto.ProductCount
                };

                cart.Products.Add(newProduct);
            }
            else
            {
                existingProduct.ProductCount += addToCartDto.ProductCount;
            }
            _unitOfWork.SaveChange();
        }


        public bool DeleteCart(Guid cartId)
        {
            Cart cart = _unitOfWork.CartRepo.GetById(cartId);
            if (cart == null)
            {
                return false;
            }

            _unitOfWork.CartRepo.Delete(cart);
            return _unitOfWork.SaveChange() > 0;

        }


        public bool DeleteCartProduct(DeleteCardProductDto deleteCardProductDto)
        {
            Cart? cart = _unitOfWork.CartRepo.GetById(deleteCardProductDto.CartId);

            if (cart == null || cart.Products == null)
            {

                return false;
            }
            CartProduct cartProduct = new CartProduct
            {
                ProductId = deleteCardProductDto.ProductId,
                CartId = deleteCardProductDto.CartId
            };

            if (cartProduct == null)
            {
                return false;

            }
            _unitOfWork.CartProductRepo.Delete(cartProduct);
            _unitOfWork.SaveChange();

            return true;
        }

        public GetCartProductByCustomerIdDto GetCartProductsByCustomerId(Guid customerId)
        {
            Cart cart = _unitOfWork.CartRepo.GetCartProductByCustomerId(customerId);

            if (cart == null)
            {
                return new GetCartProductByCustomerIdDto
                {
                    CartId = Guid.Empty,
                    CustomerId = customerId,
                    Products = new List<ProductDto>()
                };
            }

            List<ProductDto> products = new List<ProductDto>();
            foreach (var cp in cart.Products) { 
              
                foreach (var info in cp.Product.Product_Color_Size_Quantity)
                {
                    products.Add(new ProductDto
                    {
                        ProductId = cp.ProductId,
                        Name = cp.Product.Name,
                        Description = cp.Product.Description,
                        Price = cp.Product.Price,
                        Image = cp.Product.ProductImages.FirstOrDefault()?.ImageURL,
                        Quantity = cp.ProductCount,
                        Color = info.Color,
                        Size = info.Size,
                    });
                }
            }

            GetCartProductByCustomerIdDto cartDto = new GetCartProductByCustomerIdDto
            {
                CartId = cart.CartId,
                CustomerId = cart.CustomerId,
                Products = products,



                //Products = cart.Products.Select(cp => new 
                //{  
                //    ProductId = cp.ProductId,
                //    Name = cp.Product.Name,
                //    Description = cp.Product.Description,
                //    Price = cp.Product.Price,
                //    Image = cp.Product.ProductImages.FirstOrDefault()?.ImageURL,
                //    Quantity = cp.ProductCount,
                //    Color = cp.Product.Product_Color_Size_Quantity.FirstOrDefault()?.Color ?? 0,
                //    Size = cp.Product.Product_Color_Size_Quantity.FirstOrDefault()?.Size ?? 0,
                //})
                //.Select(cp => new ProductDto
                //{
                //    ProductId = cp.ProductId,
                //    Name = cp.Product.Name,
                //    Description = cp.Product.Description,
                //    Price = cp.Product.Price,
                //    Image = cp.Product.ProductImages.FirstOrDefault()?.ImageURL,
                //    Quantity = cp.ProductCount,

                //}).ToList()
            };

            return cartDto;
        }


        public bool UpdateCartProduct(UpdateToCartDto updateToCartDto)
        {
            CartProduct? cart = _unitOfWork.CartProductRepo.GetById(updateToCartDto.ProductId, updateToCartDto.CartId);

            if (cart != null) 
            {
                //from dto (edit)
                var color = updateToCartDto.Color;
                var size = updateToCartDto.Size;
                var productInfo =  cart.Product.Product_Color_Size_Quantity.First(c => c.ProductID == updateToCartDto.ProductId &&
                c.Color == color && c.Size == size);
                if (productInfo == null || productInfo.Quantity < updateToCartDto.Quantity)
                {
                    return false;
                }
                cart.ProductCount = updateToCartDto.Quantity;
                _unitOfWork.SaveChange();
                return true;
            }
            return false;
        }

    }

}