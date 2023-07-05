
namespace E_Commerce.DAL
{
     public interface ICartProductRepo : IGenericRepo<CartProduct> 
    {
        CartProduct? GetById(Guid productId,Guid cartId);
<<<<<<< Updated upstream
        CartProduct? GetCartProductByCustomerId(Guid CustomerId);


=======
        
>>>>>>> Stashed changes
    }
}
