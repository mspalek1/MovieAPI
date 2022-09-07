using System.Collections.Generic;

namespace Domain.Entities
{
    public class Producer : PersonData
    {
        private List<Movie> Movies { get; set; }
    }
}
