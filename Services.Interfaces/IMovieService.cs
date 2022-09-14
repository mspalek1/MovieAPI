using System.Collections.Generic;
using Domain.Queries;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Services.Interfaces
{
    public interface IMovieService
    {
        ActionResult<IEnumerable<MovieDto>> GetPagedWithQuery(MovieQuery query);
        ActionResult<IEnumerable<MovieDto>> GetAll();
        ActionResult<MovieDto> GetById(int id);
        int Create(CreateMovieDto dto);
    }
}
