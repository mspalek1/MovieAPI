namespace Domain.Repositories
{
    public interface IServiceManagerRepository
    {
        IProducerRepository ProducerRepository { get; }
        IMovieRepository MovieRepository { get; }
    }
}
