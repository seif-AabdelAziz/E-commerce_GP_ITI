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
            var cartProducts = cart.Products.ToList();
            cartProducts.Add(new CartProduct{
                ProductId= addToCartDto.ProductId,
                CartId= cart.CartId,
            });
            if (cart == null)
            {
                cart = new Cart
                {
                    CartId = Guid.NewGuid(),
                    CustomerId = addToCartDto.CustomerId,
                    Products = new List<CartProduct>()
                };

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
            GetCartProductByCustomerIdDto cartDto = new GetCartProductByCustomerIdDto
            {
                CartId = cart.CartId,
                CustomerId = cart.CustomerId,
                Products = cart.Products.Select(cp => new ProductDto
                {
                    ProductId = cp.ProductId,
                    Name = cp.Product.Name,
                    Description = cp.Product.Description,
                    Price = cp.Product.Price
                }).ToList()
            };

            return cartDto;
        }


        public bool UpdateCartProduct(UpdateToCartDto updateToCartDto)
        {
            CartProduct? cart = _unitOfWork.CartProductRepo.GetById(updateToCartDto.ProductId, updateToCartDto.CartId);

            if (cart != null) 
            {
                cart.ProductCount = updateToCartDto.Quantity;
                _unitOfWork.SaveChange();
                return true;
            }
            return false;
        }

    }

}