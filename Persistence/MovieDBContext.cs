using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class MovieDBContext : DbContext
    {
        public MovieDBContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<ActorMovieRelations> ActorMovieRelations { get; set; }
        public DbSet<Producer> Producers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieDBContext).Assembly);
        }
    }
}
