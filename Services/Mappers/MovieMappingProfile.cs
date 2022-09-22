using AutoMapper;
using Domain.Entities;
using Models;
using Services.Function.Account.Commands.CreateAccount;
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

           CreateMap<CreatedMovieCommand, Movie>()
               .ForMember(m => m.Id
                   , c => c.MapFrom(i => i.MovieId));

            CreateMap<UpdateMovieCommand, Movie>();

            CreateMap<CreatedAccountCommand, User>();
        }
    }
}
