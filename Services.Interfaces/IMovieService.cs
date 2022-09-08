using Contracts;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Services.Interfaces
{
    public interface IMovieService
    {
        ActionResult<IEnumerable<MovieDto>> GetAll();
    }
}
