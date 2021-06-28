using Api.Data;
using Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repositories.MovieRepo
{
    public class SqlMovieRepo : IMovieRepo
    {
        private readonly DisneyDBContext _context;

        public SqlMovieRepo(DisneyDBContext context)
        {
            _context = context;
        }

        public void CreateMovie(Movie newMovie)
        {
            if (newMovie == null)
            {
                throw new ArgumentNullException(nameof(newMovie));
            }

            _context.Movies.Add(newMovie);
            _context.SaveChanges();
        }

        public void DeleteMovie(Movie deleteMovie)
        {
            if (deleteMovie == null)
            {
                throw new ArgumentNullException(nameof(deleteMovie));
            }
            _context.Movies.Remove(deleteMovie);
        }

        public IEnumerable<Movie> GetMovie()
        {
            return _context.Movies;
        }

        public Movie GetMovieById(int id)
        {
            return _context.Movies.FirstOrDefault(c => c.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateMovie(Movie updateMovie)
        {
           
        }
    }
}
