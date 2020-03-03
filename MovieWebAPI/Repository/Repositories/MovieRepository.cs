using Model.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Linq;

namespace Repository.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        public readonly MovieDbContext _context;

        public MovieRepository(MovieDbContext context)
        {
            this._context = context;
        }
        public List<Movie> GetAllMovies()
        {
            return _context.Movies.ToList();
        }

        public Movie Add(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return movie;
        }

        public bool Delete(int id)
        {
            //_context.Movies.Remove(_context.Movies.Find(id)); ???
            _context.Movies.Remove(GetAllMovies().Find(x => x.MovieId == id));
            _context.SaveChanges();
            return true;
        }

        public Movie Update(int id, Movie movie)
        {
            Movie toUpdate = GetAllMovies().Find(x => x.MovieId == id);
            movie.MovieId = id; //??
            _context.Entry(toUpdate).CurrentValues.SetValues(movie);
            _context.SaveChanges();
            return toUpdate;
        }

        public Movie GetById(int id)
        {
            Movie movie = GetAllMovies().Find(x => x.MovieId == id);
            return movie;
        }

        /*
        public List<Movie> GetByStringInName(string str)
        {
            List<Movie> listMovie = new List<Movie>();
            var movies = _context.Movies;
            foreach(Movie movie in movies)
            {
                if (movie.Title.Contains(str))
                {
                    listMovie.Add(movie);
                }
            }
            return listMovie.ToList();
        }*/

        public Movie GetByTitle(string title)
        {
            return _context.Movies.FirstOrDefault(x => x.Title == title);
        }

        public List<Movie> GetAllMovies(string title)
        {
            return _context.Movies.Where(x => x.Title.Contains(title)).ToList();
        }
    }
}
