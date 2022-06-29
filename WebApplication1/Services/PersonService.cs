using ItCrowdChallenge.Datacontext;
using ItCrowdChallenge.Model;
using ItCrowdChallenge.ViewModel;

namespace ItCrowdChallenge.Services
{
    public class PersonService : IService<ViewModel.PersonViewModel, int>
    {
        private readonly MovieDbContext _dbContext;
        public PersonService(MovieDbContext dbCntext)
        {
            _dbContext = dbCntext;
        }
        public void Delete(int key)
        {
            var item =_dbContext.People.Find(key);
            _dbContext.People.Remove(item);
            _dbContext.SaveChanges(true);
        }

        public PersonViewModel Get(int key)
        {
            return MapModelViewModel(_dbContext.People.Find(key));
        }

        public List<PersonViewModel> GetAll()
        {
            var resultList = new List<PersonViewModel>();
            foreach (var item in _dbContext.People)
            {
                resultList.Add(MapModelViewModel(item));

            }
            return resultList;
        }

        public void Create(PersonViewModel value)
        {
            var item = _dbContext.Movies.Find(value.Id);

            if (item != null)
                throw new Exception("The Movie already exists");

            _dbContext.People.Add(MapModelViewModel(value));
            _dbContext.SaveChanges(true);

        }

        public void Save(PersonViewModel value)
        {
            var item = MapModelViewModel(value);
            _dbContext.Update(item);
            _dbContext.SaveChanges(true);
        }
        private PersonViewModel MapModelViewModel(Person? person)
        {
            if (person == null)
                return null;

            return new PersonViewModel()
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Aliases = person.Aliases.Split(',').ToList(),
                MoviesAsActorActress = person.MoviesAsActorActress.Split(',').ToList(),
                MoviesAsDirector = person.MoviesAsDirector.Split(',').ToList(),
                MoviesAsProducer = person.MoviesAsProducer.Split(',').ToList(),
            };
        }
        private Person MapModelViewModel(PersonViewModel person)
        {
            return new Person()
            {
                Id = person.Id.HasValue ? person.Id.Value : 0,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Aliases = String.Join(',', person.Aliases),
                MoviesAsActorActress = String.Join(',', person.MoviesAsActorActress),
                MoviesAsDirector = String.Join(',', person.MoviesAsDirector),
                MoviesAsProducer = String.Join(',', person.MoviesAsProducer)
            };
        }
    }
}
