using Domain.Data;

namespace Contracts
{
    public class MovieDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public int MovieLength { get; set; }
        public decimal Price { get; set; }
        public MovieCategory MovieCategory { get; set; }
        public AgeCategory AgeCategory { get; set; }
    }
}
