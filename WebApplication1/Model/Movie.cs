namespace ItCrowdChallenge.Model
{
    public class Movie:IModel<int>
    {  
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseYear { get; set; }
        public string Casting { get; set; }
        public string Directors { get; set; }
        public string Producers { get; set; }

    }
}
