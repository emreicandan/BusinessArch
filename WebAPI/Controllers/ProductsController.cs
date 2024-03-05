using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstracts;
using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {

        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _productService.GetByIdAsync(id));
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productService.GetAllAsync());
        }


        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody]AddProductDto addProductDto)
        {
            return Ok(await _productService.AddAsync(addProductDto));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody]Product product)
        {
            return Ok(await _productService.UpdateAsync(product));
        }

        [HttpDelete("DeleteById/{id}")]
        public async Task<IActionResult> DeleteById (Guid id)
        {
            await _productService.DeleteByIdAsync(id);
            return Ok("Product deleted");
        }
    }
}

