using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;
using System.Linq;

namespace MvcMovie.Services.Repository
{
    public class EFMovieRepository : IMovieRepository
    {
        // Se declara el contexto
        private readonly MvcMovieContext _movieRepository;

        //Constructor
        public EFMovieRepository()
        {
            string[] args = { "" };
            // Generador de contexto
            _movieRepository = new DesignTimeContextFactory().CreateDbContext(args);
        }

        public async Task<List<MovieModel>> GetAll()
        {
            return await _movieRepository.MovieModel.ToListAsync();
        }

        public async Task<List<MovieModel>> GetAllFilterable(string movieGenre, string searchString)
        {
            // Consulta LINQ que lista registros de películas para la tabla.
            var movies = from m in _movieRepository.MovieModel select m;

            // If the searchString parameter contains a string,
            // the movies query is modified to filter on the value of the search string
            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title!.Contains(searchString));
            }
            // If the movieGenre parameter contains a movie Genre,
            // the movies query is modified to filter on the value of the search movieGenre
            if (!string.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }
            return await movies.ToListAsync();
        }

        // Listado para el combo para filtar el género
        public IQueryable<string> GetGenreList()
        {
            if(_movieRepository.MovieModel is not null)
            {
                var query = (from m in _movieRepository.MovieModel
                            orderby m.Genre
                            select m.Genre).Distinct();

                return (IQueryable<string>)query;
            }
            return null;
        }

        public Task Add(MovieModel movie)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

     

        public Task<MovieModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(MovieModel movie)
        {
            throw new NotImplementedException();
        }
    }
}
