namespace VitoriaStore.API.Entities.Categories
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreateBy { get; set; }
        public DateTime UpdateBy { get; set; }

        public int Description { get; set; }

    }
}
