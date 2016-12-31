using System.Collections.Generic;

namespace MissionImpossible.Models
{
    public class Actor : MovieEntity
    {
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
