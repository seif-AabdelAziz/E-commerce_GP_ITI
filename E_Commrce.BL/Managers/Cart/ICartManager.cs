
namespace E_Commerce.BL
{
    public interface ICartManager
    {
        GetCartProductByCustomerIdDto GetCartProductsByCustomerId(Guid customerId);

        void AddToCart(AddToCartDto addToCartDto);
        bool UpdateCartProduct(UpdateToCartDto updateToCartDto);
        bool DeleteCartProduct(DeleteCardProductDto deleteCardProductDto);
        bool DeleteCart(Guid cartId);

    }
}
