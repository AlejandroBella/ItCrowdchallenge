using ItCrowdChallenge.Model;
using Microsoft.EntityFrameworkCore;

namespace ItCrowdChallenge.Datacontext
{
    public partial class MovieDbContext : DbContext
    {
        public MovieDbContext()
        {
        }
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Person> People { get; set; }
    }
}
