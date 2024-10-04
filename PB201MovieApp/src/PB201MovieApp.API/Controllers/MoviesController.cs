using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PB201MovieApp.Business.DTOs.MovieDTOs;
using PB201MovieApp.Business.Exceptions;
using PB201MovieApp.Business.Services.Implementations;
using PB201MovieApp.Business.Services.Interfaces;


namespace PB201MovieApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieService movieService;

        public MoviesController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await movieService.GetByExpression(true));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] MovieCreateDTO dto)
        {
            MovieGetDTO movie = null;
            try
            {
                movie = await movieService.CreateAsync(dto);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Created(new Uri($"api/movies/{movie.Id}", UriKind.Relative), movie);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            MovieGetDTO dto = null;
            try
            {
                dto = await movieService.GetById(id);
            }
            catch (InvalidIdException)
            {
                return BadRequest();
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] MovieUpdateDto dto)
        {
            try
            {
                await movieService.UpdateAsync(id, dto);
            }
            catch (InvalidIdException)
            {
                return BadRequest();
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await movieService.DeleteAsync(id);
            }
            catch (InvalidIdException)
            {
                return BadRequest();
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
