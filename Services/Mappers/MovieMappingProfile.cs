using AutoMapper;
using Domain.Entities;
using Models;
using Services.Function.Movie.Commands.CreateMovie;
using Services.Function.Movie.Commands.UpdateMovie;

namespace Services.Mappers
{
    public class MovieMappingProfile : Profile
    {
        public MovieMappingProfile()
        {
            CreateMap<Movie, MovieDto>();

           // CreateMap<CreateMovieDto, Movie>();

            CreateMap<CreatedMovieCommand, Movie>();

            CreateMap<UpdateMovieCommand, Movie>();
        }
    }
}
