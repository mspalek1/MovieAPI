using System.Collections.Generic;
using Domain.Data;

namespace Domain.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public int MovieLength { get; set; }
        public decimal Price { get; set; }
        public MovieCategory MovieCategory { get; set; }
        public AgeCategory AgeCategory { get; set; }


        public List<ActorMovieRelations> ActorMovieRelations { get; set; }

        public int ProducerId { get; set; }
        public virtual Producer Producer { get; set; }
    }
}
