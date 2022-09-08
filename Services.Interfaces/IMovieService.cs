using Contracts;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Services.Interfaces
{
    public interface IMovieService
    {
        ActionResult<IEnumerable<MovieDto>> GetAll();
        ActionResult<MovieDto> GetById(int id);
        int Create(CreateMovieDto dto);
    }
}
