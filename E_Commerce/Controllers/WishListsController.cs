using E_Commerce.BL;
using E_Commerce.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WishListsController : ControllerBase
{
    private readonly IWishListManager wishListManager;
    private readonly UserManager<Customer> usersManager;

    public WishListsController(IWishListManager wishListManager,UserManager<Customer> _usersManager)
    {
        this.wishListManager = wishListManager;
        usersManager = _usersManager;
    }

    [HttpGet]
    [Authorize(Policy = "ForCustomer")]
    public ActionResult<WishListDisplayDto> GetWishList()
    {
        string customerId = usersManager.GetUserAsync(User).Result.Id;
        return wishListManager.GetWishList(new Guid(customerId));
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
