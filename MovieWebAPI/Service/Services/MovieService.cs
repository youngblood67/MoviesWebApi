using Model.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _mRepo;

        public MovieService(IMovieRepository repo)
        {
            this._mRepo = repo;
        }

        public Movie Add(Movie movie)
        {
            var dbMovie = _mRepo.GetByTitle(movie.Title);
            if (dbMovie == null && CheckDate(movie.ReleasedAt))
            {
                return this._mRepo.Add(movie);
            }

            return null;
        }

        public Movie Update(int id, Movie movie)
        {
            var dbMovie = _mRepo.GetByTitle(movie.Title);
            if ((dbMovie == null || dbMovie.MovieId == id) && CheckDate(movie.ReleasedAt) )
            {
                return this._mRepo.Update(id, movie);
            }

            return null;
        }

        private bool CheckDate(DateTime? dateTime)
        {
            if (!dateTime.HasValue) return false;
            return dateTime.Value.Year >= 1980;
        }

        public bool Delete(int id)
        {
            var dbMovie = _mRepo.GetById(id);
            if (dbMovie == null)
            {
                return false;
            }
            else
            {
                _mRepo.Delete(id);
                return true;
            }
        }

        public List<Movie> GetAllMovies(String title)
        {
            return _mRepo.GetAllMovies(title);
        }

        public Movie GetById(int id)
        {
            return _mRepo.GetById(id);
        }

        /*
        public List<Movie> GetByStringInName(string str)
        {
            throw new NotImplementedException();
        }
        */

        public Movie GetByTitle(string title)
        {
            throw new NotImplementedException();
        }


    }
}
