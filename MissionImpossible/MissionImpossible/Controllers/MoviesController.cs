using System;
using System.Linq;
using System.Windows.Forms;
using MissionImpossible.Models;
using MissionImpossible.Views;
using MissionImpossible.Helpers;
using MissionImpossible.Properties;
using System.Collections.Generic;
using MissionImpossible.Data;
using MissionImpossible.Helpers.Sort;

namespace MissionImpossible.Controllers
{
    internal class MoviesController
    {
        private MoviesView _moviesView;
        private SearchView _searchView;

        private readonly IRepository<Movie> _movieRepository;
        private readonly IRepository<Director> _directorRepository;
        private readonly IRepository<Actor> _actorRepository;

        private readonly MovieDbContext _dbCtx;

        private readonly GetMoviesAsyncHelper _movieGetter;

        internal MoviesController()
        {
            _dbCtx = new MovieDbContext();

            _movieRepository = new EfRepository<Movie>(_dbCtx.Movies, _dbCtx);
            _directorRepository = new EfRepository<Director>(_dbCtx.Directors, _dbCtx);
            _actorRepository = new EfRepository<Actor>(_dbCtx.Actors, _dbCtx);

            _dbCtx.Actors.ToList().ForEach(x => _dbCtx.Actors.Remove(x));
            _dbCtx.Directors.ToList().ForEach(x => _dbCtx.Directors.Remove(x));
            _dbCtx.Movies.ToList().ForEach(x => _dbCtx.Movies.Remove(x));

            _dbCtx.SaveChanges();

            if (!_dbCtx.Actors.Any())
            {
                DataInserter.InsertData(_movieRepository, _directorRepository, _actorRepository).Wait();
            }

            _movieGetter = new GetMoviesAsyncHelper(_movieRepository, _directorRepository, _actorRepository);
        }

        internal async void ReloadDb()
        {

            _dbCtx.Actors.ToList().ForEach(x => _dbCtx.Actors.Remove(x));
            _dbCtx.Directors.ToList().ForEach(x => _dbCtx.Directors.Remove(x));
            _dbCtx.Movies.ToList().ForEach(x => _dbCtx.Movies.Remove(x));

            _dbCtx.SaveChanges();
            var hasElement = _dbCtx.Actors.FirstOrDefault() != null;
            if (hasElement) return;
            await DataInserter
                .InsertData(_movieRepository, _directorRepository, _actorRepository)
                .ContinueWith(task => PerformMovieRequest());
            MoviesView.DontRunHandler = true;
        }

        internal Form InitMovieView()
        {
            _moviesView = new MoviesView();

            _moviesView.EditFilm += EditMovie;

            _moviesView.DeleteMovie += DeleteMovies;

            _moviesView.FindFilm += () =>
            {
                if (_searchView == null || _searchView.IsDisposed)
                {
                    _searchView = new SearchView(_moviesView);
                    _searchView.Search += (name, year, country, director, actor) =>
                    {
                        PerformMovieRequest(name, year, country, director, actor);
                    };
                    _searchView.FormClosed += ((s, e) =>
                    {
                        _moviesView.FindMovieMenuItem.Checked = false;
                        _moviesView.ExitMenuItem.Enabled = true;
                    });
                }
                _moviesView.FindMovieMenuItem.Checked = true;
                _moviesView.ExitMenuItem.Enabled = false;
                _searchView.Show();
            };

            _moviesView.AboutOpen += () =>
            {
                var aboutView = new AboutView();
                aboutView.ShowDialog();
            };

            _moviesView.OnSort += () => { PerformMovieRequest(); };

            _moviesView.OnReload += ReloadDb;

            _movieGetter.OnStarted += () => 
            {
                _moviesView.SetGridTitle(Resources.DownloadInProcess);
            };

            PerformMovieRequest();

            return _moviesView;
        }

        private async void PerformMovieRequest(
            string movieName = null,
            string year = null,
            string country = null,
            string director = null,
            string actor = null)
        {
            var isEmptySearch =
                string.IsNullOrEmpty(movieName) &&
                string.IsNullOrEmpty(year) &&
                string.IsNullOrEmpty(country) &&
                string.IsNullOrEmpty(director) &&
                string.IsNullOrEmpty(actor);

            GetMoviesAsyncHelper.OnCompletedEventHandler onCompletedHandler = null;
            onCompletedHandler = movies =>
            {
                movies = Sorter.Sort(movies, new SortHelper(_moviesView.SortColumn, _moviesView.SortDirection)).ToList();
                _movieGetter.OnCompleted -= onCompletedHandler;
                _moviesView.Invoke(new Action(() =>
                {
                    _moviesView.UpdateGridView(movies);

                    string gridTitle;
                    if (isEmptySearch)
                    {
                        gridTitle = "Все фильмы";
                    }
                    else
                    {
                        const string sep = ": ";
                        gridTitle = "Результаты поиска по критерию ";
                        gridTitle += Resources.AttributeName + sep + movieName + " ";
                        gridTitle += Resources.AttributeYear + sep + year + " ";
                        gridTitle += Resources.AttributeCountry + sep + country + " ";
                        gridTitle += Resources.AttributeDirector + sep + director + " ";
                        gridTitle += Resources.AttributeActor + sep + actor + " ";
                    }

                    _moviesView.SetGridTitle(gridTitle);
                }));
            };

            _movieGetter.OnCompleted += onCompletedHandler;
            await _movieGetter.GetMovies(movieName, director, actor, year, country);

            _moviesView.SortStarted = false;
            if (_searchView != null && !_searchView.IsDisposed)
            {
                _searchView.Invoke(new Action(() =>
                {
                    _searchView.ButtonEnable = true;

                }
            ));

            }
        }

        private async void EditMovie(string movieName)
        {
            var movie = (await _movieRepository.ToArrayAsync(_movieRepository.GetAll().Where(x => x.Name == movieName)))[0];
            var editController = new EditController(_dbCtx, movie);
            editController.Edited += () => { PerformMovieRequest(); };
            editController.ShowEditView();
        }

        private async void DeleteMovies(List<string> movieNames)
        {
            var movies = 
                await _movieRepository.ToArrayAsync(
                    _movieRepository
                    .GetAll()
                    .Where(repoMovie => movieNames.Any(movieName => movieName == repoMovie.Name)));

            for (int i = 0; i < movieNames.Count; i++)
            {
                var res = MessageBox.Show(
                    string.Format(Resources.MovieDeletePrompt, movies[i].Name),
                    Resources.MoviesController_DeleteMovie,
                    MessageBoxButtons.YesNo);

                if (!res.HasFlag(DialogResult.No))
                {
                    await _movieRepository.Delete(movies[i]);
                }
            }

            PerformMovieRequest();
        }
    }
}
