using ItCrowdChallenge.Model;
namespace ItCrowdChallenge.ViewModel
{
    public class PersonViewModel
    {

        public int? Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public List<string> Aliases { get; set; }
        public List<string> MoviesAsActorActress { get; set; }
        public List<string> MoviesAsDirector { get; set; }
        public List<string> MoviesAsProducer { get; set; }
    }
}
