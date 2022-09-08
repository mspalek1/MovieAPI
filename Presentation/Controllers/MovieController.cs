using System.Collections.Generic;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Presentation.Controllers
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
            var id = _serviceManager.MovieService.Create(dto);

            return Created($"/api/movie/{id}", null);
        }
    }
}
