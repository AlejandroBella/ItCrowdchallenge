using ItCrowdChallenge.Datacontext;
using ItCrowdChallenge.Services;
using ItCrowdChallenge.ViewModel;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ItCrowdChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieService movieService;

        public MovieController(MovieDbContext dbContext)
        {
            //This should be replaced by parameters on the ctor and DI to be done properly.
            movieService = new MovieService(dbContext);
        }

        // GET: api/<MovieController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(movieService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return BadRequest("The Id of the movie is missing");
            var result = movieService.Get(id);

            if (result == null)
                return NotFound("Movie not found");

            return Ok(result);
        }


        // POST api/<MovieController>
        //In this case I use post as create and update

        [HttpPost]
        public IActionResult Post([FromBody] MovieViewModel value)
        {
            try
            {
                if (!value.Id.HasValue)
                {
                    return BadRequest("Id is missing");
                }

                if (movieService.Get(value.Id.Value) == null)
                {
                    return NotFound($"Movie {value.Id} is not found");
                }
                movieService.Save(value);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<MovieController>/5
        [HttpPut]
        public IActionResult Put([FromBody] MovieViewModel value)
        {
            try
            {
                if (value.Id.HasValue)
                {
                    return BadRequest("Id should not provided on creation");
                }

                movieService.Create(value);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest("Id is missing or invalid (0)");
            }

            if (movieService.Get(id) == null)
            {
                return NotFound($"Movie {id} is not found");
            }
            movieService.Delete(id);
            return Ok();
        }
    }
}
