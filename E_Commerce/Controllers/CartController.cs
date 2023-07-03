using E_Commerce.BL;
using E_Commerce.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartManager _cartmanager;

        public CartController(ICartManager cartmanager)
        {
            _cartmanager = cartmanager;
        }


        [HttpPost]
        [Route("{customerId}")]
        public ActionResult AddProductToCart(AddToCartDto addToCartDto)
        {
            try
            {
    
                _cartmanager.AddToCart(addToCartDto, addToCartDto.CustomerId);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpGet]
        [Route("{customerId}")]
        public ActionResult<GetCartProductByCustomerIdDto> GetCartProductsByCustomerId(Guid customerId)
        {
            GetCartProductByCustomerIdDto cartDto = _cartmanager.GetCartProductsByCustomerId(customerId);
            if (cartDto.Products.Count == 0)
            {
                return NotFound();
            }

            return cartDto;
        }


        [HttpDelete]
        [Route("{cartId}/{productId}")]
        public IActionResult DeleteCartProduct(DeleteCardProductDto deleteCardProduct)
        {
            _cartmanager.DeleteCartProduct(deleteCardProduct);
            return Ok();
        }


        [HttpDelete]
        [Route("{cartId}")]
        public ActionResult DeleteCart(Guid cartId)
        {
            bool isDeleted = _cartmanager.DeleteCart(cartId);
            if (isDeleted)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPut]
        public ActionResult UpdateCart(UpdateToCartDto updateToCartDto )
        {
             var Updated =  _cartmanager.UpdateCartProduct(updateToCartDto);
            
            if (Updated)
            {
                return NoContent();
            }
            return NotFound();

        }

    }
}
