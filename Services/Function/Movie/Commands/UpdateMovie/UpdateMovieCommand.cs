using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Services.Function.Movie.Commands.UpdateMovie
{
    public class UpdateMovieCommand : IRequest<BaseResponse>
    {
        public int MovieId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
