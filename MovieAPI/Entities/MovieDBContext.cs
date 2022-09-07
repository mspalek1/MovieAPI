using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace MovieAPI.Entities
{
    public class MovieDBContext : DbContext
    {
        private string _connectionString = @"Server=.\sql2019; Database=MovieDB; Trusted_Connection=True";
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<ActorMovieRelations> ActorMovieRelations { get; set; }
        public DbSet<Producer> Producers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorMovieRelations>().HasKey(am => new
            {
                am.ActorId,
                am.MovieId
            });

            modelBuilder.Entity<ActorMovieRelations>()
                .HasOne(m => m.Movie)
                .WithMany(am => am.ActorMovieRelations)
                .HasForeignKey(m => m.MovieId);

            modelBuilder.Entity<ActorMovieRelations>()
                .HasOne(a => a.Actor)
                .WithMany(am => am.ActorMovieRelations)
                .HasForeignKey(a => a.ActorId);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
