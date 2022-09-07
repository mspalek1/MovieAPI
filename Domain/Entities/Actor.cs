using System.Collections.Generic;

namespace Domain.Entities
{

    public class Actor : PersonData
    {
        public List<ActorMovieRelations> ActorMovieRelations { get; set; }
    }
}
