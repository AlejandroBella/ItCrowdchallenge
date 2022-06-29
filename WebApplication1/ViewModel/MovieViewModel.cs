using ItCrowdChallenge.Model;

namespace ItCrowdChallenge.ViewModel
{
    public class MovieViewModel
    {
        
        public int? Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseYear { get; set; }
        public List<string> Casting { get; set; }
        public List<string> Directors { get; set; }
        public List<string> Producers { get; set; }

    }
}
