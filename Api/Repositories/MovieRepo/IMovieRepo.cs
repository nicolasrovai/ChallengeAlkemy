using Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repositories.MovieRepo
{
    public interface IMovieRepo
    {
        bool SaveChanges();
        IEnumerable<Movie> GetMovie();
        Movie GetMovieById(int id);
        void CreateMovie(Movie newMovie);
        void UpdateMovie(Movie updateMovie);
        void DeleteMovie(Movie deleteMovie);
    }
}

