using E_Commerce.BL;
using E_Commerce.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityManager securityManager;

        public SecurityController(ISecurityManager _securityManager)
        {
            securityManager = _securityManager;
        }
        [HttpPost]
        public ActionResult Register(RegisterDto register)
        {
            var request = securityManager.Register(register);
            if (request != null)
            {
                return BadRequest(request);
            }

            return NoContent();
        }
    }
}
