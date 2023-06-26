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

        public void AddToCart(AddToCartDto addToCartDto)
        {
            Cart? cart = _unitOfWork.CartRepo.GetCartProductByCustomerId(addToCartDto.CustomerId);
            if (cart == null)
            {
                cart = new Cart
                {
                    CartId =  Guid.NewGuid(),
                    CustomerId = new Guid(addToCartDto.CustomerId),
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


        public bool DeleteCart(DeleteCartDto deleteCartDto)
        {
            Cart? cart = _unitOfWork.CartRepo.GetById(deleteCartDto.CartId);
            if (cart == null )
            {
                return false;
            }
            cart?.Products.Clear();
            _unitOfWork.CartRepo.Delete(cart);
            return _unitOfWork.SaveChange() > 0;
          
        }

        public void DeleteCartProduct(DeleteCardProductDto deleteCardProductDto)
        {
            Cart? cart = _unitOfWork.CartRepo.GetById(deleteCardProductDto.CartId);

            CartProduct? cartProduct = cart.Products.FirstOrDefault(cp => cp.ProductId == deleteCardProductDto.ProductId);

            if (cartProduct != null)
            {
                cart.Products.Remove(cartProduct);
                _unitOfWork.SaveChange();
            }

            CartProduct? productToDelete = _unitOfWork.CartProductRepo.GetById(deleteCardProductDto.ProductId);
            if (productToDelete != null)
            {
                _unitOfWork.CartProductRepo.Delete(productToDelete);
                _unitOfWork.SaveChange();
            }

        }

        public GetCartProductByCustomerIdDto GetCartProductsByCustomerId(Guid customerId)
        {
            Cart? cart = _unitOfWork.CartRepo.GetById(customerId);

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

        public void UpdateCartProduct(UpdateToCartDto updateToCartDto)
        {
            Cart? cart = _unitOfWork.CartRepo.GetById(updateToCartDto.CartId);

            if (cart != null)
            {
                CartProduct? cartProduct = cart.Products.FirstOrDefault(cp => cp.ProductId == updateToCartDto.ProductId);

                if (cartProduct != null)
                {
                    cartProduct.ProductCount += updateToCartDto.Quantity;
                    cartProduct.ProductCount = Math.Max(cartProduct.ProductCount, 0);

                    _unitOfWork.SaveChange();
                }
            }

        }

        public decimal Checkout(CheckOutDto checkoutDto)
        {
            Cart? cart = _unitOfWork.CartRepo.GetCartProductByCustomerId(checkoutDto.CustomerId.ToString());

            decimal totalPrice = cart.Products.Sum(cp => cp.Product.Price * cp.ProductCount);

            // Delete sold items from the database
            foreach (var cartProduct in cart.Products)
            {
                Product? product = _unitOfWork.ProductsRepo.GetById(cartProduct.ProductId);
                if (product != null)
                {
                    //product.Quantity -= cartProduct.ProductCount;
                    //if (product.Quantity <= 0)
                    //{
                    //    _unitOfWork.ProductsRepo.Delete(product);
                    //}
                    //else
                    //{
                    //    _unitOfWork.ProductsRepo.Update(product);
                    //}
                    if (product != null)
                    {
                        _unitOfWork.ProductsRepo.Delete(product);
                    }
                }
            }
            Order newOrder = new Order
            {
                OrderData = DateTime.Now,
                PaymentStatus = checkoutDto.PaymentStatus,
                PaymentMethod = checkoutDto.PaymentMethod,
                OrderStatus = OrderStatus.Pending,
                Street = checkoutDto.Street,
                City = checkoutDto.City,
                Country = checkoutDto.Country,
                CustomerId = checkoutDto.CustomerId.ToString(),
                OrderProducts = cart.Products.Select(cp => new OrderProduct
                {
                    ProductId = cp.ProductId,
                    ProductCount = cp.ProductCount
                }).ToList()
            };

            cart.Products.Clear();

            _unitOfWork.SaveChange();

            return totalPrice;
        }

    }

}