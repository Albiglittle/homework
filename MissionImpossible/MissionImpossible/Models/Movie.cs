using System.Collections.Generic;

namespace MissionImpossible.Models
{
    public class Movie : MovieEntity
    {
        public string Country { get; set; }
        public uint Year { get; set; }
        public string ImagePath { get; set; }

        public Director Director { get; set; }
        public ICollection<Actor> Actors { get; set; }
    }
}
