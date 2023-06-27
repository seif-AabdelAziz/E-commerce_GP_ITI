namespace E_Commerce.BL;

public interface IWishListManager
{
    bool AddToWishList(WishListIDsDto IDsDto);
    bool DeleteFromWishList(WishListIDsDto IDsDto);
    WishListDisplayDto GetWishList(Guid customerId);
}
