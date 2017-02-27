using MissionImpossible.Models;
using MissionImpossible.Views;
using System.Linq;
using MissionImpossible.Data;

namespace MissionImpossible.Controllers
{
    internal class EditController
    {
        internal delegate void EditedEventHandler();
        internal event EditedEventHandler Edited;

        private readonly Movie _currentMovie;
        private readonly EditView _editView;

        private readonly IRepository<Movie> _movieRepository;
        private readonly IRepository<Director> _directorRepository;

        internal EditController(MovieDbContext dbCtx, Movie movie)
        {
            _currentMovie = movie;

            _movieRepository = new EfRepository<Movie>(dbCtx.Movies, dbCtx);
            _directorRepository = new EfRepository<Director>(dbCtx.Directors, dbCtx);

            _editView = new EditView(movie);
            _editView.SaveMovie += SaveMovies;
        }
       
        private async void SaveMovies()
        {
            Movie movie = (await _movieRepository.ToArrayAsync(
                _movieRepository.GetAll().Where(x => x.Id == _currentMovie.Id)))[0];

            movie.Name = _currentMovie.Name;
            movie.Year = _currentMovie.Year;

            Director[] existing =
                await _directorRepository.ToArrayAsync(
                    _directorRepository.GetAll().Where(x => x.Name == _currentMovie.Director.Name));
            movie.Director = existing.Length == 0 ? new Director() { Name = _currentMovie.Director.Name } : existing[0];
            
            movie.Actors = _currentMovie.Actors; // FIXME

            await _movieRepository.Save(movie);

            if (Edited != null) Edited();

            _editView.Close();
        }

        internal void ShowEditView()
        {
            _editView.ShowDialog();
        }
    }
}
