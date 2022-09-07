using System.Collections.Generic;

namespace MovieAPI.Entities
{

    public class Actor : PersonData
    {
        public List<ActorMovieRelations> ActorMovieRelations { get; set; }
    }
}
