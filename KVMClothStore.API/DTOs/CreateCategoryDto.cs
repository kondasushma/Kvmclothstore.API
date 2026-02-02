using KVMClothStore.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace KVMClothStore.API.DTOs
{
    public class CreateCategoryDto
    {
        //Only includes Name — Id and Products are handled by EF Core automatically.
        public string Name { get; set; }= string.Empty;
    }
}
