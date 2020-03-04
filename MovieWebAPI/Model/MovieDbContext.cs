using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model.Entities;

namespace Model
{
    public class MovieDbContext : DbContext
    {
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<MovieActor> MovieActors { get; set; }
        public virtual DbSet<MovieActor> Persons { get; set; }

        private const string _connectionString = @"
                server=localhost;
                port=3306;
                database=moviedb;
                uid=dev;
                password=dev
        ";

        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               // optionsBuilder.UseMySql(_connectionString, b => b.MigrationsAssembly("MovieWebAPI"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>()
                .HasMany(bc => bc.DirectedMovies)
                .WithOne(x => x.Director);

            modelBuilder.Entity<Movie>()
                .HasMany(x => x.Actors)
                .WithOne(x => x.Movie);

            modelBuilder.Entity<Person>()
                .HasMany(x => x.PlayedMovies)
                .WithOne(x => x.Actor);

            modelBuilder.Entity<MovieActor>().HasKey(x => new { x.ActorId, x.MovieId });


        }

    }
}
