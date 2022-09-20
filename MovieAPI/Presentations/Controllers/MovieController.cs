using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Function.Movie.Commands.CreateMovie;
using Services.Function.Movie.Commands.DeleteMovie;
using Services.Function.Movie.Commands.UpdateMovie;
using Services.Function.Movie.Queries.GetMovieDetail;
using Services.Function.Movie.Queries.GetMovieList;
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

        #region noAsync

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

        #endregion

        #region

        [HttpGet("async/{id}")]
        public async Task<ActionResult<MovieDto>> GetAsync([FromRoute] int id)
        {
            var movieDetail = await _mediator.Send(new GetMovieDetailQuery() { Id = id });
            return Ok(movieDetail);
        }

        [HttpGet("async/all")]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetAsyncAll()
        {
            var movieDto = await _mediator.Send(new GetMovieListQuery());
            return Ok(movieDto);
        }

        [HttpGet("async/search")]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetPagedAsyncWithQuery([FromQuery] MovieQuery query)
        {
            var movieDto = await _mediator.Send(new GetMovieListSearchQuery() { MovieQuery = query});
            return Ok(movieDto);
        }

        [HttpPost("async/create", Name="CreateMovie")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> Create([FromBody] CreatedMovieCommand createdMovieCommand)
        {

            var result = await _mediator.Send(createdMovieCommand);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result.MovieId);
        }

        [HttpDelete("async/delete/{id}", Name = "DeleteMovie")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete([FromRoute]int id)
        {
            var deleteMovieCommand = new DeleteMovieCommand() { MovieId = id };
            var result = await _mediator.Send(deleteMovieCommand);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return NoContent();
        }


        [HttpPut("async/update/{id}", Name = "UpdateMovie")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateMovieCommand updateMovieCommand, [FromRoute]int id)
        {
            updateMovieCommand.MovieId = id;

            var result = await _mediator.Send(updateMovieCommand);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return NoContent();
        }
        #endregion
    }
}
