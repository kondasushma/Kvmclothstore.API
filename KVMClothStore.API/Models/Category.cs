namespace KVMClothStore.API.Models
{
    public class Category
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
