using System.Data.Entity;
using MissionImpossible.Models;

namespace MissionImpossible.Data
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Actor> Actors { get; set; }
    }
}
