using ItCrowdChallenge.Datacontext;
using ItCrowdChallenge.Model;
using ItCrowdChallenge.ViewModel;

namespace ItCrowdChallenge.Services
{
    public class MovieService : IService<MovieViewModel, int>
    {
        private readonly MovieDbContext _dbContext;
        public MovieService(MovieDbContext dbCntext)
        {
            _dbContext = dbCntext;
        }

        public void Delete(int key)
        {
            var item = _dbContext.Movies.Find(key);
            _dbContext.Movies.Remove(item);
            _dbContext.SaveChanges(true);
        }

        public MovieViewModel Get(int key)
        {
            return MapModelViewModel(_dbContext.Movies.Find(key));
        }

        public List<MovieViewModel> GetAll()
        {
            var resultList = new List<MovieViewModel>();
            foreach (var item in _dbContext.Movies)
            {
                resultList.Add(MapModelViewModel(item));

            }
            return resultList;
        }

        public void Create(MovieViewModel value)
        {
            var item = _dbContext.Movies.Find(value.Id);

            if (item != null)
                throw new Exception("The Movie already exists");

            _dbContext.Movies.Add(MapModelViewModel(value));
            _dbContext.SaveChanges(true);

        }

        public void Save(MovieViewModel value)
        {
            var item = MapModelViewModel(value);
            _dbContext.Update(item);
            _dbContext.SaveChanges(true);
        }

        MovieViewModel MapModelViewModel(Movie model)
        {
            if (model == null)
                return null;

            return new MovieViewModel()
            {
                Id = model.Id,
                Title = model.Title,
                ReleaseYear = model.ReleaseYear,
                Casting = model.Casting.Split(',').ToList(),
                Directors = model.Directors.Split(',').ToList(),
                Producers = model.Casting.Split(',').ToList(),
            };
        }
        Movie MapModelViewModel(MovieViewModel model)
        {
            return new Movie()
            {
                Id = model.Id.HasValue ? model.Id.Value : 0,
                Title = model.Title,
                ReleaseYear = model.ReleaseYear,
                Casting = String.Join(',', model.Casting),
                Directors = String.Join(',', model.Directors),
                Producers = String.Join(',', model.Producers),
            };
        }      
           
    }
}
