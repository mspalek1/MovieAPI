using System.Collections.Generic;

namespace MovieAPI.Entities
{
    public class Producer : PersonData
    {
        private List<Movie> Movies { get; set; }
    }
}
