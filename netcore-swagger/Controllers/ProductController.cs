using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using netcore_swagger.Model;
using netcore_swagger.Services;

namespace netcore_swagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        //POST api/product
        [HttpPost]
        public IActionResult PostProduct([FromBody] Products products)
        {
            //check request parameter/body
            if (products == null)
                return BadRequest();
            //add data
            int retVal = _productService.Add(products);
            if (retVal > 0)
                return Ok();
            else
                return NotFound();
        }

        //GET api/products
        [HttpGet]
        public IEnumerable<Products> GetProducts() => _productService.GetAll();

        //GET api/product/id:
        [HttpGet("{id}")]
        public IActionResult GetFindProduct(int id)
        {
            Products product = _productService.FindProduct(id);
            if (product == null)
                return NotFound();
            else
                return new ObjectResult(product);
        }

        //PUT api/product/id:
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Products products)
        {
            if (products == null || id != products.Id)
                return BadRequest();
            if (_productService.FindProduct(id) == null)
                return NotFound();
            int retVal = _productService.UpdateProduct(products);
            if (retVal > 0)
                return Ok();
            else
                return NotFound();
        }

        //DELETE api/product/id:
        [HttpDelete("{id}")]
        public IActionResult DelProduct(int id)
        {
            int retVal = _productService.DelProduct(id);
            if (retVal > 0)
                return Ok();
            else
                return NotFound();
        }
    }
}
