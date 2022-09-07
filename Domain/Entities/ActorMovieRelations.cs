using Microsoft.Win32.SafeHandles;

namespace Domain.Entities
{
    public class ActorMovieRelations
    {
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        public int ActorId { get; set; }
        public virtual Actor Actor { get; set; }
    }
}
