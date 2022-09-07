using Microsoft.EntityFrameworkCore;
using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Persistence.Configurations
{
    internal sealed class ActorMovieRelationsConfigurations : IEntityTypeConfiguration<ActorMovieRelations>

    {
        public void Configure(EntityTypeBuilder<ActorMovieRelations> modelBuilder)
        {
            modelBuilder.HasKey(am => new
            {
                am.ActorId,
                am.MovieId
            });

            modelBuilder.HasOne(m => m.Movie)
                .WithMany(am => am.ActorMovieRelations)
                .HasForeignKey(m => m.MovieId);

            modelBuilder.HasOne(a => a.Actor)
                .WithMany(am => am.ActorMovieRelations)
                .HasForeignKey(a => a.ActorId);
        }
    }
}
