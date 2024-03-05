using Business.Abstracts;
using Core.Entities;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _categoryService.GetAllAsync());
        }


        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _categoryService.GetByIdAsync(id));
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Category category)
        {
            return Ok(await _categoryService.AddAsync(category));
        }


        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Category category)
        {
            return Ok(await _categoryService.UpdateAsync(category));
        }


        [HttpDelete("DeleteById/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _categoryService.DeleteByIdAsync(id);
            return Ok();
        }
    }
}

