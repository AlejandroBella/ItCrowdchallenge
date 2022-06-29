using ItCrowdChallenge.Datacontext;
using ItCrowdChallenge.Services;
using ItCrowdChallenge.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ItCrowdChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonService personService;
        public PersonController(MovieDbContext dbContext)
        {
            personService = new PersonService(dbContext);
        }

        // GET: api/<personController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(personService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return BadRequest("The Id of the person is missing");
            var result = personService.Get(id);

            if (result == null)
                return NotFound("person not found");

            return Ok(result);
        }


        // POST api/<personController>

        [HttpPost]
        public IActionResult Post([FromBody] PersonViewModel value)
        {
            try
            {
                if (!value.Id.HasValue)
                {
                    return BadRequest("Id is missing");
                }

                if(personService.Get(value.Id.Value) == null)
                {
                    return NotFound($"Person {value.Id} is not found");
                }

                personService.Save(value);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<personController>/5
        [HttpPut]
        public IActionResult Put([FromBody] PersonViewModel value)
        {
            try
            {
                if (value.Id.HasValue)
                {
                    return BadRequest("Id should not provided on creation");
                }
               
                personService.Create(value);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<personController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest("Id is missing or invalid (0)");
            }

            if (personService.Get(id) == null)
            {
                return NotFound($"Person {id} is not found");
            }
            personService.Delete(id);
            return Ok();
        }
    }
}
