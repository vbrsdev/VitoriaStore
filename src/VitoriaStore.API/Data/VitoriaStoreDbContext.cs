using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using VitoriaStore.API.Entities.Categories;
using VitoriaStore.API.Entities.Persons;
using VitoriaStore.API.Entities.Products;

namespace VitoriaStore.API.Data
{
    //essa linha é uma classe que herda os recursos do entityFramework(EF) para gerenciar o bd
    //E esse gerenciamento inclui todos os metodos de CRUD para o projeto
    public class VitoriaStoreDbContext : DbContext
    {
        //repassa toda a configuracao feita no arquivo programs para o EF 
        //ex: conexao com o BD
        public VitoriaStoreDbContext(DbContextOptions<VitoriaStoreDbContext> option) : base(option)
        {
            
        }

        //metodo responsavel para transformar as classes da interface em BD
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        //uma classe do EF utilizado para informar ao DbContext qual entidade de classe deve ser transfomada em tabela do BD
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Person> Person { get; set; }

    }
}
