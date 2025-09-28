using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VitoriaStore.API.Data;
using VitoriaStore.API.DTO.Products;
using VitoriaStore.API.Entities;
using VitoriaStore.API.Entities.Categories;
using VitoriaStore.API.Entities.Products;

namespace VitoriaStore.API.Controllers;

//atributo
[Route("api/[controller]")] //localhost:5232/api/Product 
[ApiController]   //atributos é obrigatorio
public class ProductController : ControllerBase //obrigatorio
{
    public VitoriaStoreDbContext Context { get; set; }  //propriedade global
    public ProductController(VitoriaStoreDbContext context) //injeçao de dependentes usando o metodo construtor
    {
        Context = context;
    }

    //atributo
    [HttpGet()]
    //é uma interface que aceita qualquer tipo retorno
    
    public IActionResult GetProducts([FromQuery]FilterProduct filterProduct)//endpoint   
    {
        List<Product> productList = Context.Product.
        Where(x => 
        (filterProduct.Name == null || x.Name.Contains(filterProduct.Name)) &&
        (filterProduct.Stock == null || x.Stock.ToString().Contains(filterProduct.Stock.ToString())) &&
         (filterProduct.Id == null || x.Id.ToString().Contains(filterProduct.Id.ToString()))).ToList();


        return Ok(productList);
    }

    
    //o metodo que não tiver um atributo, é do tipo query params
    // o metodo que tiver um atributo, é do tipo Attribute routing

    //api/product/Get-By-Id/4
    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
        Product product = Context.Product.Single(x => x.Id == id);
        return Ok(product);
    }

    // POST: api/home
    [HttpPost()] //post se usa para salvar registros/infos do front no BD
    public IActionResult PostCreateProduct([FromBody] ProductDTO productDTO)
    {
        Product productCreate = new Product
        {
            Name = productDTO.Name, 
            Price = productDTO.Price,
            Image = productDTO.Image,
            Stock = productDTO.Stock,
            CreateBy = DateTime.Now,
        };

        Context.Product.Add(productCreate);
        Context.SaveChanges();
        return Created("", productCreate);
    }

    [HttpPut("{id}")] //post se usa para salvar registros/infos do front no BD
    public IActionResult PutUpdateProduct(int id, [FromBody] ProductDTO productDTO)
    {
        Product productUpdateExist = Context.Product.FirstOrDefault(x => x.Id == id);
        if (productUpdateExist == null) return NotFound();

        productUpdateExist.Name = productDTO.Name;
        productUpdateExist.Stock = productDTO.Stock;
        productUpdateExist.Price = productDTO.Price;
        productUpdateExist.Image = productDTO.Image;
        Context.SaveChanges();
        return NoContent();
    }


    [HttpDelete("{id}")] //post se usa para salvar registros/infos do front no BD
    public IActionResult DeleteProduct(int id)  //[frombody] so se usa no metodo Post
    {
        Product product = Context.Product.Find(id);
        if(product == null)
        {
            return NotFound();
        }
        Context.Product.Remove(product);
        Context.SaveChanges();
        return Ok();
    }

    
    

}


