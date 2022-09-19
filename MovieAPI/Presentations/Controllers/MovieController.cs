using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Function.Movie.Queries;
using Services.Interfaces;

namespace MovieAPI.Presentations.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MovieController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly IMediator _mediator;

        public MovieController(IServiceManager serviceManager, IMediator mediator)
        {
            _serviceManager = serviceManager;
            _mediator = mediator;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<MovieDto>> GetAll()
        {
            var movieDto = _serviceManager.MovieService.GetAll();
            return Ok(movieDto);
        }

        [HttpGet("search")]
        public ActionResult<IEnumerable<MovieDto>> GetPagedWithQuery([FromQuery]MovieQuery query)
        {
            var movieDto = _serviceManager.MovieService.GetPagedWithQuery(query);
            return Ok(movieDto);
        }

        [HttpGet("{id}")]
        public ActionResult<MovieDto> Get([FromRoute] int id)
        {
            var movieDto = _serviceManager.MovieService.GetById(id);

            return Ok(movieDto);
        }

        [HttpGet("async/{id}")]
        public async Task<ActionResult<MovieDto>> GetAsync([FromRoute] int id)
        {
            var movieDetail = await _mediator.Send(new GetMovieDetailQuery(){ Id = id });
            return Ok(movieDetail);
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
