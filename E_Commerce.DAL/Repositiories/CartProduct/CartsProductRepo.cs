
namespace E_Commerce.DAL
{
    public class CartsProductRepo : GenericRepo<CartProduct>, ICartProductRepo
    {
        private readonly E_CommerceContext _context;

        public CartsProductRepo(E_CommerceContext context) : base(context)
        {
            _context = context;
        }

        public CartProduct? GetById(Guid productId, Guid cartId)
        {
           return _context.CartProduct.FirstOrDefault(p => p.ProductId == productId && p.CartId == cartId);
            
        }
    }
}
