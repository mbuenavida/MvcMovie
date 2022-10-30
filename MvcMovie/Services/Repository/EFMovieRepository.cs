using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Services.Repository
{
    public class EFMovieRepository : IMovieRepository
    {
        // Se declara el contexto
        private readonly MvcMovieContext _context;

        //Constructor
        public EFMovieRepository()
        {
            string[] args = { "" };
            // Generador de contexto
            _context = new DesignTimeContextFactory().CreateDbContext(args);
        }

        public Task Add(MovieModel movie)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<MovieModel>> GetAll()
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
