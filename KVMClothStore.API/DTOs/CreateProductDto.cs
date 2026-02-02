using KVMClothStore.API.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace KVMClothStore.API.DTOs
{
    public class CreateProductDto
    {
        public string Name { get; set; }= string.Empty;
        public Decimal Price { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }// Must reference existing category
    }
}
