using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VitoriaStore.API.Data;
using VitoriaStore.API.DTO.Persons;
using VitoriaStore.API.Entities.Persons;
using VitoriaStore.API.Entities.Products;

namespace VitoriaStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public VitoriaStoreDbContext Context { get; set; }
        public PersonController(VitoriaStoreDbContext context) //injeçao de dependentes usando o metodo construtor
        {
            Context = context;
        }

        [HttpGet()]
        public IActionResult GetPersons([FromQuery]FilterPerson filterPerson) //p em frente ao nome pra indicar que é parametro //? indica que pode inserir valor nulo
        {
            List<Person> personList = Context.Person.
            Where(x =>
            (filterPerson.Name == null || x.Name.Contains(filterPerson.Name)) &&
            (filterPerson.ContactNumber == null || x.ContactNumber.Contains(filterPerson.ContactNumber)) &&
            (filterPerson.Id == null || x.Id.ToString().Contains(filterPerson.Id.ToString()))).ToList();

            return Ok(personList);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetPerson(int id)
        {
            Person person = Context.Person.Single(x => x.Id == id);

            return Ok(person);
        }

        //rota post: api/person
        [HttpPost] 
        public IActionResult PostCreatePerson([FromBody] PersonDTO personDTO)
        {
            Person personCreate = new Person
            {
                ContactNumber = personDTO.ContactNumber,
                Name = personDTO.Name,
                CreateBy = DateTime.Now,
                
            };

            Context.Person.Add(personCreate);
            Context.SaveChanges();    
            return Created("", personCreate);
        }

        //rota put sempre vai precisar do ID e do body(propriedades da DTO)
        [HttpPut("{id}")] //parametro de rotas
        public IActionResult PutUpdatePerson(int id, [FromBody] PersonDTO personDTO)
        {
            Person personUpdateExist = Context.Person.FirstOrDefault(x => x.Id == id);
            if (personUpdateExist == null) return NotFound();

            personUpdateExist.Name = personDTO.Name;
            personUpdateExist.ContactNumber = personDTO.ContactNumber;
            Context.SaveChanges();
            return NoContent();
        }

        //rota:localhost:5232/api/Person/delete?id=1007
        [HttpGet("delete")]
        public IActionResult DeletePerson(int id)
        {
            Person person = Context.Person.Find(id);
            if (person == null){
                return NotFound();
            }
            Context.Person.Remove(person);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPatch("{id}")] //parametro de rotas
        public IActionResult PatchUpdatePerson(int id, [FromBody] JsonPatchDocument<Person> jsonDoc)
        {
            Person personUpdateExist = Context.Person.FirstOrDefault(x => x.Id == id);
            if (personUpdateExist == null) return NotFound();


            jsonDoc.ApplyTo(personUpdateExist, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Context.SaveChanges();
            return NoContent();
        }
    }
}
