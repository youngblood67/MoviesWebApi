using Model.Entities;
using System;
using System.Collections.Generic;

namespace Service
{
    public interface IMovieService
    {
        List<Movie> GetAllMovies(string title);
        Movie Add(Movie movie);
        bool Delete(int id);
        Movie Update(int id, Movie movie);
        Movie GetById(int id);

        Movie GetByTitle(string title);

        //List<Movie> GetByStringInName(String str);
    }
}
