using KVMClothStore.API.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace KVMClothStore.API.DTOs
{
    public class ProductCreateDTO
    {
        public string Name { get; set; }= string.Empty;
        public Decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
