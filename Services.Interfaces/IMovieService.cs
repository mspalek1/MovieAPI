using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Services.Interfaces
{
    public interface IMovieService
    {
        ActionResult<IEnumerable<MovieDto>> GetAll();
        ActionResult<MovieDto> GetById(int id);
        int Create(CreateMovieDto dto);
    }
}
