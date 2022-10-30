using MvcMovie.Models;

namespace MvcMovie.Services.Repository
{
    public interface IMovieRepository
    {
        public Task<List<MovieModel>> GetAll();

        public Task<MovieModel> GetById(int id);

        //public Task<MovieModel> GetByName(string name);

        public Task Update(MovieModel movie);

        public Task DeleteById(int id);

        public Task Add(MovieModel movie);



        public Task<List<MovieModel>> GetAllFilterable(string movieGenre, string searchString);
        public IQueryable<string> GetGenreList();


    }
}
