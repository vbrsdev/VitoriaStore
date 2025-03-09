namespace VitoriaStore.API.Entities.Products
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }
        public int Stock { get; set; }

        public DateTime CreateBy { get; set; }
        public DateTime UpdateBy { get; set; }

        public bool IsDeleted { get; set; }
    }
}
