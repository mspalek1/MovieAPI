using AutoMapper;
using Contracts;
using Domain.Entities;

namespace Services
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
