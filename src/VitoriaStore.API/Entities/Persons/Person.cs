namespace VitoriaStore.API.Entities.Persons
{
    //criando classe Person CRUD
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateBy { get; set; }
        public DateTime UpdateBy { get; set; }

    }
}
