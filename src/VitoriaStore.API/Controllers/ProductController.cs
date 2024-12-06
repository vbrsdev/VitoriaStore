using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VitoriaStore.API.Controllers
{
    [Route("api/[controller]")] //localhost:5232/api/Product 
    [ApiController]   //atributos
    public class ProductController : ControllerBase //obrigatorio
    {
        [HttpGet]
        //é uma interface que aceita qualquer tipo retorno
        public IActionResult GetAllProducts()
        {
            return Ok("Trazendo todos os produtos");
        }
    }
}
