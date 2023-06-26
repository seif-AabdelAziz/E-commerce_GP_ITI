
namespace E_Commerce.BL
{
    public interface ICartManager
    {
        GetCartProductByCustomerIdDto GetCartProductsByCustomerId(Guid customerId);
        void AddToCart(AddToCartDto addToCartDto);
        void UpdateCartProduct(UpdateToCartDto updateToCartDto);
        void DeleteCartProduct(DeleteCardProductDto deleteCardProductDto);
        bool DeleteCart(DeleteCartDto deleteCartDto);
        decimal Checkout(CheckOutDto checkoutDto);
    }
}
