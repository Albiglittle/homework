using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MissionImpossible.Models;
using System.Text.RegularExpressions;
using MissionImpossible.Data;

namespace MissionImpossible.Helpers
{
    internal class GetMoviesAsyncHelper: AsyncHelper<List<Movie>>
    {
        private readonly IRepository<Movie> _movieRepository;
        private IRepository<Director> _directorRepository;
        private IRepository<Actor> _actorRepository;

        internal GetMoviesAsyncHelper(
            IRepository<Movie> movieRepository,
            IRepository<Director> directorRepository,
            IRepository<Actor> actorRepository)
        {
            _movieRepository = movieRepository;
            _directorRepository = directorRepository;
            _actorRepository = actorRepository;
        }

        internal async Task GetMovies(string movieName, string director, string actor, string year, string country)
        {
            Started();

            // LINQ to Entities doesn't seem to support regexes, so fetching all the data first
            var movies = await _movieRepository.ToListAsync(_movieRepository.GetAll());
            
            movies =
                movies
                .FindAll(movie => IsMatch(movie.Country, country))
                .FindAll(movie => IsMatch(movie.Year.ToString(), year))
                .FindAll(movie => IsMatch(movie.Name, movieName))
                .FindAll(movie => IsMatch(movie.Director.Name, director))
                .FindAll(movie => movie.Actors.Any(a => IsMatch(a.Name, actor))
                );
            
            Completed(movies);
        }

        private bool IsMatch(string value, string wildcard)
        {
            return string.IsNullOrEmpty(wildcard) || Regex.IsMatch(value, ConvertToRegexp(wildcard));
        }

        private static string ConvertToRegexp(string wildcard)
        {
            const string possibleCharToMatch = @"[а-яА-ЯA-Za-zёЁ0-9-!?\.\s]";
            string anyCharSequence = possibleCharToMatch + @"*";
            return wildcard.Replace("?", possibleCharToMatch).Replace("*", anyCharSequence);
        }
    }
}
