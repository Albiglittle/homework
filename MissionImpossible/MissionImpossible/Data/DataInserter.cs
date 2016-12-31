using System.Collections.Generic;
using System.Threading.Tasks;
using MissionImpossible.Models;
using MissionImpossible.Properties;

namespace MissionImpossible.Data
{
    class DataInserter
    {
        internal static async Task InsertData(
            IRepository<Movie> movieRepository,
            IRepository<Director> directorRepository,
            IRepository<Actor> actorRepository)
        {
            var directors = new List<Director>
            {
                new Director { Name = Resources.DirectorCNolan },
                new Director { Name = Resources.DirectorFLawrence },
                new Director { Name = Resources.DirectorAKrasovskiy },
                new Director { Name = Resources.DirectorTShadyac },
                new Director { Name = Resources.DirectorRZemeckis },
                new Director { Name = Resources.DirectorONakache },
                new Director { Name = Resources.DirectorKWimmer },
                new Director { Name = Resources.DirectorLWachowski },
                new Director { Name = Resources.DirectorDFincher }
            };

            var actors = new List<Actor>
            {
                new Actor { Name = Resources.ActorMMcConaughey },
                new Actor { Name = Resources.ActorAHathaway },
                new Actor { Name = Resources.ActorJCarrey },
                new Actor { Name = Resources.ActorJFoster },
                new Actor { Name = Resources.ActorCBale },
                new Actor { Name = Resources.ActorFCluzet },
                new Actor { Name = Resources.ActorOSy },
                new Actor { Name = Resources.ActorENorton },
                new Actor { Name = Resources.ActorBPitt },
                new Actor { Name = Resources.ActorHBCarter },
                new Actor { Name = Resources.ActorTDiggs },
                new Actor { Name = Resources.ActorKReeves },
                new Actor { Name = Resources.ActorLFishburne },
                new Actor { Name = Resources.ActorKWimmer },
                new Actor { Name = Resources.ActorCHabenskiy },
                new Actor { Name = Resources.ActorWSmith },
                new Actor { Name = Resources.ActorMDouglas }
            };

            var movies = new List<Movie>
            {
                new Movie { Name = Resources.MovieInterstellar, Year = 2014u, Country = Resources.CountryUnitedKingdom, 
                    ImagePath = Resources.ImgPathInterstellar, Director = directors[0], 
                    Actors = new List<Actor> { actors[0], actors[1] } },

                new Movie { Name = Resources.MovieConstantine, Year = 2005u, Country = Resources.CountryUSA, 
                    ImagePath = Resources.ImgPathConstantine, Director = directors[1], 
                    Actors = new List<Actor> { actors[11] } },

                new Movie { Name = Resources.MovieIAmLegend, Year = 2007u, Country = Resources.CountryUSA, 
                    ImagePath = Resources.ImgPathIAmLegend, Director = directors[1], 
                    Actors = new List<Actor> { actors[15] } },

                new Movie { Name = Resources.MovieCollector, Year = 2016u, Country = Resources.CountryRussia, 
                    ImagePath = Resources.ImgPathCollector, Director = directors[2], 
                    Actors = new List<Actor> { actors[14] } },

                new Movie { Name = Resources.MovieBruceAlmighty, Year = 2003u, Country = Resources.CountryUSA, 
                    ImagePath = Resources.ImgPathBruce, Director = directors[3], 
                    Actors = new List<Actor> { actors[2] } },

                new Movie { Name = Resources.MovieContact, Year = 1997u, Country = Resources.CountryUSA, 
                    ImagePath = null, Director = directors[4], Actors = new List<Actor> { actors[3] } },

                new Movie { Name = Resources.MovieIntouchables, Year = 2011u, Country = Resources.CountryFrance, 
                    ImagePath = Resources.ImgPathIntouchables,  Director = directors[5], 
                    Actors = new List<Actor> { actors[5], actors[6] } },
      
                new Movie { Name = Resources.MovieEquilibrium, Year = 2002u, Country = Resources.CountryUSA, 
                    ImagePath = Resources.ImgPathEquilibrium, Director = directors[6], 
                    Actors = new List<Actor> { actors[4], actors[10] } },

                new Movie { Name = Resources.MovieMatrix, Year = 1999u, Country = Resources.CountryUSA, 
                    ImagePath = Resources.ImgPathMatrix, Director = directors[7], 
                    Actors = new List<Actor> { actors[11], actors[12], actors[13] } },

                new Movie { Name = Resources.MovieFightClub, Year = 1999u, Country = Resources.CountryUSA, 
                    ImagePath = Resources.ImgPathFightClub, Director = directors[8], 
                    Actors = new List<Actor> { actors[7], actors[8], actors[9] } },

                new Movie { Name = Resources.MovieGame, Year = 1997u, Country = Resources.CountryUSA, 
                    ImagePath = Resources.ImgPathTheGame, Director = directors[8], 
                    Actors = new List<Actor> { actors[16] } }
            };

            foreach (var director in directors)
            {
                await directorRepository.Save(director);
            }

            foreach (var actor in actors)
            {
                await actorRepository.Save(actor);
            }

            foreach (var movie in movies)
            {
                movie.ImagePath = string.IsNullOrEmpty(movie.ImagePath) ? null : @"..\..\Pictures\" + movie.ImagePath;
                await movieRepository.Save(movie);
            }
        }
    }
}
