using System.Collections.Generic;
using Domain.Pages;
using Domain.Queries;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Services.Interfaces
{
    public interface IMovieService
    {
        PageResult<MovieDto> GetPagedWithQuery(MovieQuery query);
        ActionResult<IEnumerable<MovieDto>> GetAll();
        ActionResult<MovieDto> GetById(int id);
        int Create(CreateMovieDto dto);
    }
}
