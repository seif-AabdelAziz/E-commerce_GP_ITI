using E_Commerce.BL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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

        [HttpGet]
        [Route("ProductWithImages")]
        public ActionResult<List<ProductWithImagesDto>> AllProductsWithImages()
        {
            List<ProductWithImagesDto> products = productManager.ProductsWithImages();
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

        [HttpDelete]
        [Route("Delete/{id}")]
        public ActionResult Delete(Guid id)
        {
            bool request = productManager.Delete(id);
            if (!request)
            {
                return BadRequest();
            }
            return Ok("Product Deleted");
        }

        [HttpGet]
        [Route("Details/{id}")]
        public ActionResult<ProductDetailsReadDto> Details(Guid id)
        {
            ProductDetailsReadDto? productDetails = productManager.ProductDetails(id);
            if (productDetails is null)
            {
                return BadRequest();
            }

            return productDetails;
        }

        [HttpGet]
        [Route("Reviews/{id}")]
        public ActionResult<List<ProductReviewsDto>> Reviews(Guid id)
        {
            List<ProductReviewsDto>? reviews = productManager.ProductReviews(id);

            if (reviews is null)
            {
                return BadRequest();
            }
            else if (reviews.IsNullOrEmpty())
            {
                return NoContent();
            }
            return reviews!;
        }

        [HttpGet]
        [Route("Categories/{id}")]
        public ActionResult<List<ProductCategories>> Categories(Guid id)
        {
            List<ProductCategories>? categories = productManager.ProductCategories(id);
            if (categories is null)
            {
                return BadRequest();
            }
            else if (categories.IsNullOrEmpty())
            {
                return NoContent();
            }

            return categories!;
        }

        [HttpGet]
        [Route("Update/{id}")]
        public ActionResult<ProductUpdateDto> ProductToUpdate(Guid id)
        {
            ProductUpdateDto? product = productManager.ProductToUpdate(id);
            if (product is null)
            {
                return BadRequest();
            }
            return product;
        }

        [HttpPut]
        [Route("Update")]
        public ActionResult Update(ProductUpdateDto productUpdate)
        {
            bool request = productManager.Update(productUpdate);
            if (!request)
            {
                return BadRequest();
            }
            return Ok("Product Updated Successfully");
        }
    }
}
