using KVMClothStore.API.Data;
using KVMClothStore.API.DTOs;
using KVMClothStore.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace KVMClothStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController:ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetProducts() 
        { 
            var products= _context.Products.ToList();
            return Ok(products);
        }
        [HttpPost]
        public IActionResult CreateProduct(ProductCreateDTO dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                CategoryId = dto.CategoryId,
            };
            _context.Products.Add(product);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetProducts), new {id=product.Id}, product);
        }
    }
}
