using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VitoriaStore.API.Data;
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
    [HttpGet("all")]
    //é uma interface que aceita qualquer tipo retorno
    //checklist: create ok  read ok update ok delete ok
    public IActionResult GetAllProducts()//endpoint   
    {
        List<Product> productList = Context.Product.Where(x => x.IsDeleted != true).ToList();
        
        return Ok(productList);
    }

    [HttpGet("allByName")]
    //é uma interface que aceita qualquer tipo retorno
    //checklist: create ok  read ok update ok delete ok
    public IActionResult GetAllProductsByName(string productName)//endpoint   
    {
        List<Product> productList = Context.Product.Where(x => x.Name == productName).ToList();

        return Ok(productList);
    }

    //o metodo que não tiver um atributo, é do tipo query params
    //api/product/allByNameFilter?productName=vestido
    [HttpGet("allByNameFilter")]
    public IActionResult GetAllProductsByNameFilter(string productName)//endpoint   
    {
        List<Product> productList = Context.Product.Where(x => x.Name.Contains(productName)).ToList();

        return Ok(productList);
    }

    // o metodo que tiver um atributo, é do tipo Attribute routing
    //api/product/Get-By-Id/4
    [HttpGet("Get-By-Id/{id}")]
    public IActionResult GetById(int id)
    {
        Product product = Context.Product.FirstOrDefault(x => x.Id == id);
        return Ok(product);
    }

    //api/product/GetByNameAndId/6?productName=calça
    [HttpGet("GetByNameAndId/{id}")]
    public IActionResult GetAllProductsByNameAndId(int id, string productName)//endpoint   
    {
        List<Product> productList = Context.Product.Where(x => x.Name == productName && x.Id == id).ToList();

        return Ok(productList);
    }



    // POST: api/home
    [HttpPost("create")] //post se usa para salvar registros/infos do front no BD
    public IActionResult PostCreateProduct([FromBody] Product product)
    {
        return Created("", product);
    }

    [HttpPost("update")] //post se usa para salvar registros/infos do front no BD
    public IActionResult PostUpdateProduct([FromBody] Product product)
    {
        return NoContent();
    }


    [HttpPost("delete")] //post se usa para salvar registros/infos do front no BD
    public IActionResult PostDeleteProduct([FromBody] int id)  //[frombody] so se usa no metodo Post
    {
        return NoContent();
    }

    
    

}


