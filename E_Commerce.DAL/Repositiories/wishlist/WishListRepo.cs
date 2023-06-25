using Microsoft.EntityFrameworkCore;

namespace E_Commerce.DAL;

public class WishListRepo : GenericRepo<WishList>, IWishListRepo
{
    private readonly E_CommerceContext context;

    public WishListRepo(E_CommerceContext context) : base(context)
    {
        this.context = context;
    }

    public WishList? GetWishListProducts(Guid customerId)
    {
        return context.Set<WishList>()
                        .Include(wl => wl.Products)
                        .Include(wl=>wl.Customer)    
                        .FirstOrDefault(wl => new Guid(wl.Customer.Id) == customerId);
    }
}
