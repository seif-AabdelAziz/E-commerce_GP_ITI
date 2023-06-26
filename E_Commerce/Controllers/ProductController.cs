using E_Commerce.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductManager productManager;

        public ProductsController(IProductManager _productManager)
        {
            productManager = _productManager;
        }

        [HttpGet]
        public ActionResult<List<ProductReadDto>> AllProducts()
        {
            List<ProductReadDto> products = productManager.AllProducts();
            return products;
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult AddProduct(ProductAddDto product)
        {
            bool request = productManager.Add(product);

            if (!request)
            {
                return BadRequest();
            }
            return Ok("Product Added Sucessfully");
        }
    }
}
