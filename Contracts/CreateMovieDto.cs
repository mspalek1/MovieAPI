using Domain.Data;

namespace Contracts
{
    public class CreateMovieDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public int MovieLength { get; set; }
        public decimal Price { get; set; }
        public int MovieCategory { get; set; }
        public int AgeCategory { get; set; }
        public int ProducerId { get; set; }
    }
}
