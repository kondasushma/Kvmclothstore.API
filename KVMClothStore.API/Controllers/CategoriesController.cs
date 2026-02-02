using KVMClothStore.API.Data;
using KVMClothStore.API.DTOs;
using KVMClothStore.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KVMClothStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _context.categories
                .Select(c => new CategoryDto
                {
                    CategoryId = c.Id,
                    CategoryName = c.Name
                })
                .ToList();
            if (!categories.Any())
                return Ok(new { message = "No categories found", data = (object?)null });

            return Ok(new { message = "Categories fetched successfully", data = categories });
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int? id)
        {
            if (id == null || id <= 0)
                return Ok(new { message = "Invalid category ID", data = (object?)null });
            var category = _context.categories
                .Where(c => c.Id == id)
                .Select(c => new CategoryDto
                {
                    CategoryId = c.Id,
                    CategoryName = c.Name
                })
                .FirstOrDefault();
            if (category == null)
                return Ok(new { message = "category not found", data = (object?)null });

            return Ok(new { message = "Category fetched successfully", data = category });
        }

        [HttpPost]
        public IActionResult CreateCategories(CreateCategoryDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Name))
                return BadRequest("Invalid category data.");
            var exists = _context.categories.Any(c => c.Name == dto.Name);
            if (exists)
            {
                return Conflict("Category with the same name already exists.");
            }
            var category = new Category
            {
                Name = dto.Name,
            };
            _context.categories.Add(category);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCategoryById),
                    new { id = category.Id },
                      new { message = "Category Created Successfully", data = new { categoryId = category.Id, categoryName = category.Name } });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int? id)
        {
            if(id==null || id <= 0)
            {
                return BadRequest("Invalid category ID.");
            }
            var category = _context.categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            _context.categories.Remove(category);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
