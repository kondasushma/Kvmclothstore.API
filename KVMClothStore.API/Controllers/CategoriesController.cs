using KVMClothStore.API.Data;
using KVMClothStore.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace KVMClothStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController:ControllerBase
    {
        private readonly AppDbContext _context;
        public CategoriesController(AppDbContext context)
        {
            _context=context;
        }
        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _context.categories.ToList();
            return Ok(categories);
        }
        [HttpPost]
        public IActionResult CreateCategories(Category category) 
        {
            _context.categories.Add(category);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCategories), new { id = category.ID },category);
        }
    }
}
