using AutoMapper;
using Contracts;
using Domain.Entities;

namespace Services
{
    public class MovieMappingProfile : Profile
    {
        public MovieMappingProfile()
        {
            CreateMap<Movie, MovieDto>()
                .ForMember(m => m.MovieCategory, c => c.MapFrom(s => s.MovieCategory));
        }
    }
}
