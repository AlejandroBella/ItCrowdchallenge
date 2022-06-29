namespace ItCrowdChallenge.Model
{
    public class Person : IModel <int>
    {
        
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Aliases { get; set; }
        public string MoviesAsActorActress { get; set; }
        public string MoviesAsDirector { get; set; }
        public string MoviesAsProducer { get; set; }
    }
}
