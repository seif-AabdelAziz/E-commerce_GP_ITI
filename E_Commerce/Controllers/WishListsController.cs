using E_Commerce.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WishListsController : ControllerBase
{
    private readonly IWishListManager wishListManager;

    public WishListsController(IWishListManager wishListManager)
    {
        this.wishListManager = wishListManager;
    }

    [HttpGet]
    public ActionResult<WishListDisplayDto> GetWishList([FromQuery] Guid customerId)
    {
        return wishListManager.GetWishList(customerId);
    }

    [HttpPatch]
    [Route("add")]
    public ActionResult AddToWishList(WishListIDsDto iDsDto)
    {
        return wishListManager.AddToWishList(iDsDto) ? Ok("Added") : BadRequest();
    }

    [HttpPatch]
    [Route("delete")]
    public ActionResult DeleteFromWishList(WishListIDsDto iDsDto)
    {
        return wishListManager.DeleteFromWishList(iDsDto) ? Ok("Deleted") : BadRequest();
    }

}
