using E_Commerce.BL;
using E_Commerce.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartManager _cartmanager;
        private readonly UserManager<Customer> _customer;

        public CartController(ICartManager cartmanager,UserManager<Customer> customer)
        {
            _cartmanager = cartmanager;
            _customer = customer;
        }


        [HttpPost]
        [Route("AddCart")]
        [Authorize]
        public ActionResult AddProductToCart( AddToCartDto addToCartDto)
        {
           var customerID= _customer.GetUserAsync(User).Result.Id;


            try
            {
    
                _cartmanager.AddToCart(addToCartDto,customerID);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpGet]
        [Route("CartProducts")]
        [Authorize]
        public ActionResult<GetCartProductByCustomerIdDto> GetCartProductsByCustomerId()
        {
            Guid customerId =new Guid( _customer.GetUserAsync(User).Result.Id);
            if (customerId == Guid.Empty)
            {
                return BadRequest();
            }
            GetCartProductByCustomerIdDto cartDto = _cartmanager.GetCartProductsByCustomerId(customerId);
            if(cartDto == null)
            {
                return BadRequest();
            }

            return cartDto;
        }


        [HttpDelete]
        [Route("DeletePrdouctFromCart")]
        public IActionResult DeleteCartProduct(DeleteCardProductDto deleteCardProduct)
        {
            _cartmanager.DeleteCartProduct(deleteCardProduct);
            return Ok();
        }

        [HttpDelete]
        [Route("Clear/{customerId}")]
        public IActionResult ClearCartProducts(Guid customerId)
        {
            return _cartmanager.ClearCartProducts(customerId)? Ok():BadRequest();
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
