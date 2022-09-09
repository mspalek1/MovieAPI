using AutoMapper;
using Contracts;
using Domain.Entities;

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
