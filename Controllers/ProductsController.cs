using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UserProductManagementAPI.Infrastructure;
using UserProductManagementAPI.Models;



namespace UserProductManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IBaseService<Product> _productService;
        public ProductsController(IBaseService<Product> _productService)
        {
            this._productService = _productService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _productService.GetAll();
            return new OkObjectResult(products);
        }

        [Route("{CategoryProducts}/{CategoryCode}")]
        public IActionResult GetCategoryProducts(string categoryCode)
        {
            var products = _productService.Get(x => x.CategoryCode == categoryCode);
            return new OkObjectResult(products);
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            //we want to find the product by id and load the category        
            var products = _productService.Get(x => x.Productid == Id, i => i.Category);
            if (!products.Any())
            {
                return new NoContentResult();
            }
            return new OkObjectResult(products.First());
        }

        [HttpPost]
        [Route("{CreateProduct}")]
        public IActionResult Post([FromBody] Product product)
        {   
            _productService.Create(product);
            return CreatedAtAction(nameof(Get), new { id = product.Productid }, product);
        }

        // PUT: api/Product/5       
        [HttpPut("{id}")]
        [Route("{Update}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            var products = _productService.Get(x => x.Productid == id);

            if (products != null && products.First().Productid == product.Productid)
            {
                _productService.Update(product);
                return new OkResult();
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        [Route("{Deletete}")]
        public IActionResult Delete(int id)
        {
            var products = _productService.Get(x => x.Productid == id);
            if (!products.Any())
            {
                return new NoContentResult();
            }
            _productService.Delete(products.First());
            return new OkResult();
        }
    }
}
