using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BeeEngineering.Learning.MoviesApp.Data
{
    public class MoviesAppContext : IdentityDbContext<IdentityUser<long>,IdentityRole<long>, long>
    {
        public MoviesAppContext(DbContextOptions<MoviesAppContext> options) : base(options)
        { }
            public DbSet<Actor> Actors { get; set; }

            public DbSet<Director> Directors  { get; set; }

            public DbSet<Genre> Genres { get; set; }

            public DbSet<Movie> Movies { get; set; }

            public DbSet<MovieActor> MovieActors { get; set; }

            public DbSet<MovieGenre> MovieGenres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Actor>().Property(x => x.Uuid).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Director>().Property(x => x.Uuid).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Genre>().Property(x => x.Uuid).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Movie>().Property(x => x.Uuid).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<MovieActor>().Property(x => x.Uuid).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<MovieGenre>().Property(x => x.Uuid).HasDefaultValueSql("NEWID()");

        }
    }
}
