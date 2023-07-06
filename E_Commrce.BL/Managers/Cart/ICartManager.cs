
namespace E_Commerce.BL
{
    public interface ICartManager
    {
        GetCartProductByCustomerIdDto GetCartProductsByCustomerId(Guid customerId);

        void AddToCart(AddToCartDto addToCartDto,string customerId);
        bool UpdateCartProduct(Guid CustomerId);
        bool DeleteCartProduct(DeleteCardProductDto deleteCardProductDto);
        bool DeleteCart(Guid cartId);

        bool ClearCartProducts(Guid CustomerId);

    }
}
