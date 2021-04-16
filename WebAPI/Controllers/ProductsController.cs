using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            
            var result =_productService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }


        [HttpPost("Add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
                
            }
            return BadRequest(result);  
        }


        [HttpGet("getbyCategory")]
        public IActionResult GetByCategoryId (int id )
        {

            var result = _productService.GetAllByCategoryId(id);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
                

        }
    }
}
