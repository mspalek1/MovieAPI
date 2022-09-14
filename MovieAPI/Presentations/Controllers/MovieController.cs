using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;

namespace MovieAPI.Presentations.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MovieController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public MovieController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MovieDto>> GetAll()
        {
            var movieDto = _serviceManager.MovieService.GetAll();
            return Ok(movieDto);
        }

        [HttpGet("{id}")]
        public ActionResult<MovieDto> Get([FromRoute] int id)
        {
            var movieDto = _serviceManager.MovieService.GetById(id);

            return Ok(movieDto);
        }

        [HttpPost]
        public ActionResult Create([FromBody] CreateMovieDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = _serviceManager.MovieService.Create(dto);

            return Created($"/api/movie/{id}", null);
        }
    }
}
