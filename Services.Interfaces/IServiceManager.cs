namespace Services.Interfaces
{
    public interface IServiceManager
    {
        public IMovieService MovieService { get; }
        public IProducerService ProducerService { get; }
    }
}
