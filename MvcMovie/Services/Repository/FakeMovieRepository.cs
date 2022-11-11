using MvcMovie.Models;

namespace MvcMovie.Services.Repository
{
    public class FakeMovieRepository: IMovieRepository
    {
        // Se declara el contexto.
        private readonly List<MovieModel> _movies;
        // Constructor al que se le inyecta el contexto.
        // En este caso, una colección de películas.
        public FakeMovieRepository()
        {
            _movies = new List<MovieModel>();
            _movies.Add(new MovieModel()
            {
                Id = 1,
                Title = "Star Wars IV - Una nueva esperanza",
                ReleaseDate = DateTime.Parse("1977-5-25"),
                Genre = "Science fiction",
                Price = 21.12M
            });
            _movies.Add(new MovieModel()
            {
                Id = 2,
                Title = "Star Wars V - El Imperio contraataca",
                ReleaseDate = DateTime.Parse("1980-5-21"),
                Genre = "Science fiction",
                Price = 20.17M
            });
            _movies.Add(new MovieModel()
            {
                Id = 3,
                Title = "Star Wars VI - El retorno del Jedi",
                ReleaseDate = DateTime.Parse("1983-5-25"),
                Genre = "Science fiction",
                Price = 23.95M
            });
        }

        public async Task<List<MovieModel>> GetAll()
        {
            return await Task.Run(() => _movies);
        }

        public async Task<MovieModel> GetById(int id)
        {
            return await Task.Run(() => _movies.Find(m => m.Id == id));
        }

        public async Task<List<MovieModel>> GetAllFilterable(string movieGenre, string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                return (List<MovieModel>)await Task.Run(() => _movies.Where(s => s.Title!.Contains(searchString)));
            }

            if (!string.IsNullOrEmpty(movieGenre))
            {
                return (List<MovieModel>)await Task.Run(() => _movies.Where(x => x.Genre == movieGenre));
            }

            return await Task.Run(() => _movies);
        }

        public IQueryable<string> GetGenreList()
        {
            return  (IQueryable<string>) _movies
                .OrderBy(x => x.Genre).Select(x => x.Genre).Distinct();
        }





        public Task Add(MovieModel movie)
        {
            throw new NotImplementedException();
        }    

        public Task Update(MovieModel movie)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
