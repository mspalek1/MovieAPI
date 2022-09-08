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

    }
}
