using E_Commerce.DAL;
using System.Data;

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
            //if (cart != null) { 
            
            //    var cartProducts = cart.Products.ToList();
            //     cartProducts.Add(new CartProduct{
            //        ProductId= addToCartDto.ProductId,
            //        CartId= cart.CartId,
            //        Color=(Color) Enum.Parse<Color>(addToCartDto.Color),
            //        Size= (Size)Enum.Parse<Size>(addToCartDto.Size)
            //     });
            //}
            
            if (cart == null)
            {
                cart = new Cart();

                cart.CartId = Guid.NewGuid();
                cart.CustomerId = addToCartDto.CustomerId;
                cart.Products = new List<CartProduct>
                    {
                        new CartProduct
                        {
                            CartId = cart.CartId,
                            ProductId = addToCartDto.ProductId,
                            ProductCount = addToCartDto.ProductCount,
                            Color = (Color)Enum.Parse<Color>(addToCartDto.Color),
                            Size = (Size)Enum.Parse<Size>(addToCartDto.Size)
                        }
                    };
                _unitOfWork.CartRepo.Add(cart);
            }
            else
            {
                 var check = cart.Products.Where(c =>
                 
                     c.Color== (Color)Enum.Parse<Color>(addToCartDto.Color)&&
                     c.Size == (Size)Enum.Parse<Size>(addToCartDto.Size)
                  ).FirstOrDefault();

                if (cart.Products==null||check==null)
                {
                   var cartproduct = new CartProduct
                    {
                        ProductId = addToCartDto.ProductId,
                        CartId = cart.CartId,
                        ProductCount = addToCartDto.ProductCount,
                        Color = (Color)Enum.Parse<Color>(addToCartDto.Color),
                        Size = (Size)Enum.Parse<Size>(addToCartDto.Size)
                    };

                    cart.Products.Add(cartproduct);
                }
                else
                {
                    check.ProductCount += addToCartDto.ProductCount;
                }
            }
                _unitOfWork.SaveChange();

        }

        public bool ClearCartProducts(Guid CustomerId)
        {
            var cart =  _unitOfWork.CartRepo.GetCartProductByCustomerId(CustomerId);
            if (cart is null) return false;
            cart.Products.Clear();
            _unitOfWork.SaveChange();
            return true;
        }

        public bool DeleteCart(Guid cartId)
        {
            Cart cart = _unitOfWork.CartRepo.GetById(cartId);
            _unitOfWork.CartRepo.Delete(cart);
            if (cart == null)
            {
                return false;
            }

            _unitOfWork.CartRepo.Delete(cart);
            return _unitOfWork.SaveChange() > 0;

        }

        #region DeleteCartProduct
        public bool DeleteCartProduct(DeleteCardProductDto deleteCardProductDto)
        {
            Cart? cart = _unitOfWork.CartRepo.GetById(deleteCardProductDto.CartId);
            CartProduct cart2 = _unitOfWork.CartProductRepo.GetById(deleteCardProductDto.ProductId, deleteCardProductDto.CartId);

            if (cart == null || cart2 == null)
            {

                return false;
            }
            else
            {
                _unitOfWork.CartProductRepo.Delete(_unitOfWork.CartProductRepo.GetAll()
                    .FirstOrDefault(c => c.ProductId == deleteCardProductDto.ProductId
                    && c.CartId == deleteCardProductDto.CartId
                    && c.Color == (Color)Enum.Parse<Color>(deleteCardProductDto.Color)
                    && c.Size == (Size)Enum.Parse<Size>(deleteCardProductDto.Size)));
                _unitOfWork.SaveChange();
            }
            
            return true;
        }

        #endregion

        #region GetAllCarrtProducts
        public GetCartProductByCustomerIdDto GetCartProductsByCustomerId(Guid customerId)
        {
            Cart cart = _unitOfWork.CartRepo.GetCartProductByCustomerId(customerId);
            decimal total = 0;
            string strImge = "";
            int qty = 0;

            if (cart == null)
            {
                return new GetCartProductByCustomerIdDto
                {
                    CartId = Guid.NewGuid(),
                    CustomerId = customerId,
                    Products = new List<ProductDto>()
                };
            }
            else
            {

                List<ProductDto> products = new List<ProductDto>();
                foreach (var cp in cart.Products)
                {
                    if (_unitOfWork.ProductsRepo.GetProductDetails(cp.ProductId).ProductImages.Count==0)
                    {
                        strImge = "null";
                    }
                    else
                    {
                        strImge = _unitOfWork.ProductsRepo.GetProductDetails(cp.ProductId).ProductImages[0].ImageURL;
                    }

                    
                        products.Add(new ProductDto
                        {
                            ProductId = cp.ProductId,
                            Name = cp.Product.Name,
                            Description = cp.Product.Description,
                            Price = cp.Product.Price,
                            Image = strImge,
                            QuantityInStock = cp.Product.Product_Color_Size_Quantity
                            .FirstOrDefault(p => p.Color == cp.Color && p.Size == cp.Size).Quantity,
                            Quantity = cp.ProductCount,
                            Discount = cp.Product.Discount,
                            Color = cp.Color.ToString(),
                            Size = cp.Size.ToString()
                        });
                    
                    //int quantityInStock = info.Quantity;
                    //int userEnteredQuantity = cp.ProductCount;
                    
                    total += cp.Product.Price*cp.ProductCount;
                    
                }
                    GetCartProductByCustomerIdDto cartDto = new GetCartProductByCustomerIdDto
                    {
                        CartId = cart.CartId,
                        CustomerId = cart.CustomerId,
                        Products = products,
                        TotalCost = total
                    };

            return cartDto;
            }

            

        }
        #endregion

        #region UpdateCartProduct
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
        #endregion 

    }

}