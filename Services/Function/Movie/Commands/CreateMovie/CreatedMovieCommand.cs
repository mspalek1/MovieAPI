using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Services.Function.Movie.Commands.CreateMovie
{
    public class CreatedMovieCommand : IRequest<CreatedMovieCommandResponse>
    {
        public int MovieId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public int MovieLength { get; set; }
        public decimal Price { get; set; }
        public int MovieCategory { get; set; }
        [Range(1, int.MaxValue)]
        public int AgeCategory { get; set; }
        public int ProducerId { get; set; }
        public int UserId { get; set; }
    }
}
