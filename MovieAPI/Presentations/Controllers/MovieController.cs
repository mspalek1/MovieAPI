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

namespace MovieAPI.Presentations.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovieController(IMediator mediator)
        {
            _mediator = mediator;
        }

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
