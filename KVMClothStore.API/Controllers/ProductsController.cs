using KVMClothStore.API.Data;
using KVMClothStore.API.DTOs;
using KVMClothStore.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KVMClothStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _context.Products
            .Include(p => p.Category)
            .Select(p => new
            {
                p.Id,
                p.Name,
                p.Price,
                p.Stock,
                p.ImageUrl,
                Category = new
                {
                    p.Category.Id,
                    p.Category.Name
                }
            })
            .ToList();
            return Ok(products.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _context.Products
                .Include(p => p.Category)
                .Where(p => p.Id == id)
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Price,
                    p.Stock,
                    p.ImageUrl,
                    Category = new
                    {
                        p.Category.Id,
                        p.Category.Name
                    }


                }).FirstOrDefault();
            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto dto)
        {
            // Validate category exists
            var category = _context.categories.FirstOrDefault(c => c.Id == dto.CategoryId);
            if (category == null)
            {
                return BadRequest($"Category with Id {dto.CategoryId} does not exist.");
            }
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                Stock = dto.Stock,
                ImageUrl = dto.ImageUrl,
                CategoryId = dto.CategoryId,
            };
            _context.Products.Add(product);
            _context.SaveChanges();
            //Map to DTO to prevent cycles
            var result = new
            {
                product.Id,
                product.Name,
                product.Price,
                product.Stock,
                product.ImageUrl,
                Category = new
                {
                    category.Id,
                    category.Name
                }
            };
            return Ok(result);// Id is auto - generated

        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, CreateProductDto dto)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound($"Product with Id {id} not found.");
            }
            // Validate category exists
            var category = _context.categories.FirstOrDefault(c => c.Id == dto.CategoryId);
            if (category == null)
            {
                return BadRequest($"Category with Id {dto.CategoryId} does not exist.");
            }
            product.Name = dto.Name;
            product.Price = dto.Price;
            product.Stock = dto.Stock;
            product.ImageUrl = dto.ImageUrl;
            product.CategoryId = dto.CategoryId;
            _context.SaveChanges();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product=_context.Products.Find(id);
            if (product == null) 
                return NotFound();            
            _context.Products.Remove(product);
            _context.SaveChanges();
             return NoContent();
        }
    }
}
