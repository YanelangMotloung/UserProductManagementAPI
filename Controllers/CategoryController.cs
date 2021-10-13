using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserProductManagementAPI.Infrastructure;
using UserProductManagementAPI.Models;

namespace UserProductManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IBaseService<Category> _categoryService;
        public CategoryController(IBaseService<Category> categoryService)
        {
            this._categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _categoryService.GetAll();
            return new OkObjectResult(products);
        }


        [HttpPost]
        [Route("{CreateCategory}")]
        public IActionResult Post([FromBody] Category category)
        {
            // check if User Exist

            _categoryService.Create(category);
            return CreatedAtAction(nameof(Get), new { id = category.CategoryCode }, category);
        }

        // PUT: api/Product/5       
        [HttpPut("/{categoryCode}")]
        [Route("{Update}")]
        public IActionResult Put(string categoryCode, [FromBody] Category category)
        {
            var categories = _categoryService.Get(x => x.CategoryCode == categoryCode);

            if (categories != null && categories.First().CategoryCode == categoryCode)
            {
                _categoryService.Update(category);
                return new OkResult();
            }
            return new NoContentResult();
        }

        [HttpDelete("/{categoryCode}")]
        [Route("{Delete}")]
        public IActionResult Delete(string categoryCode)
        {
            var categories = _categoryService.Get(x => x.CategoryCode == categoryCode);
            if (!categories.Any())
            {
                return new NoContentResult();
            }
            _categoryService.Delete(categories.First());
            return new OkResult();
        }

        [HttpGet("/{userId}"),
        Route("{GetUserCategories}")]
        public IActionResult GetUserCategories(string userId)
        {
            var products = _categoryService.Get(x => x.CreatedBy == userId);
            return new OkObjectResult(products);
        }
        
        [Route("{GetByCategoryCode}/{categorycode}")]
        public IActionResult GetByCategoryCode(string categorycode)
        {
            //we want to find the product by id and load the category        
            var category = _categoryService.Get(x => x.CategoryCode == categorycode);
            if (!category.Any())
            {
                return new NoContentResult();
            }
            return new OkObjectResult(category.First());
        }
    }
}
