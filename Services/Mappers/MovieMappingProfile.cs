using AutoMapper;
using Domain.Entities;
using Models;

namespace Services.Mappers
{
    public class MovieMappingProfile : Profile
    {
        public MovieMappingProfile()
        {
            CreateMap<Movie, MovieDto>();

            CreateMap<CreateMovieDto, Movie>();
        }
    }
}
