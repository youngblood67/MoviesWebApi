using System;
using System.Collections.Generic;
using System.Text;
using Model.Entities;

namespace Repository.Interfaces
{
    public interface IMovieRepository
    {
        List<Movie> GetAllMovies();
        List<Movie> GetAllMovies(string title);
        Movie Add(Movie movie);
        bool Delete(int id);
        Movie Update(int id, Movie movie);

        Movie GetById(int id);

        Movie GetByTitle(string title);

        //List<Movie> GetByStringInName(String str);

    }
}
