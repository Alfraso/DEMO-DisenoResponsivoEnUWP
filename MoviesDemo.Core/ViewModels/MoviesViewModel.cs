using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using MoviesDemo.Core.Messages;
using MoviesDemo.Core.Models;
using MoviesDemo.Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDemo.Core.ViewModels
{
    public class MoviesViewModel : ViewModelBase, INavigable
    {
        private ObservableCollection<MovieModel> _movies;
        public ObservableCollection<MovieModel> Movies
        {
            get { return _movies; }
            set { Set(ref _movies, value); }
        }

        private static uint _currentMovieId;

        private MovieModel _selectedMovie;
        public MovieModel SelectedMovie
        {
            get { return _selectedMovie; }
            set
            {
                if (Set(ref _selectedMovie, value)
            && _selectedMovie != null)
                    _currentMovieId = _selectedMovie.Id;
            }
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { Set(ref _isLoading, value); }
        }

        private bool _connectionRequired;

        public bool ConnectionRequired
        {
            get { return _connectionRequired; }
            set { Set(ref _connectionRequired, value); }
        }

        private bool _isNarrow = true;
        public bool IsNarrow
        {
            get { return _isNarrow; }
            set
            {
                if (Set(ref _isNarrow, value))
                    SelectMovieCommand.RaiseCanExecuteChanged();
            }
        }

        private RelayCommand<MovieModel> _selectMovieCommand;
        public RelayCommand<MovieModel> SelectMovieCommand
        {
            get
            {
                return _selectMovieCommand ??
                   (_selectMovieCommand = new RelayCommand<MovieModel>(OnSelectMovie, (o) => _isNarrow));
            }
        }

        private void OnSelectMovie(MovieModel selectedMovie)
        {
            if (selectedMovie != null)
                _currentMovieId = selectedMovie.Id;

            if (_currentMovieId != 0)
                _navigationService.NavigateTo(Const.MOVIESDATAIL_VIEW, _currentMovieId);
        }

        readonly INavigationService _navigationService;
        readonly IMoviesService _moviesService;

        public MoviesViewModel(INavigationService navigationService, IMoviesService moviesService)
        {
            _navigationService = navigationService;
            _moviesService = moviesService;

            Messenger.Default.Register<NarrowMessage>(this, OnNarrowMessageReceived);
        }

        private void OnNarrowMessageReceived(NarrowMessage n)
        {
            if (n.SerderView != Const.MOVIES_VIEW)
                return;

            var previosIsNarrow = IsNarrow;
            IsNarrow = n.IsNarrow;

            if (IsNarrow && !previosIsNarrow)
                SelectMovieCommand.Execute(null);
            else if (!IsNarrow && previosIsNarrow && _currentMovieId != 0)
                SelectedMovie = Movies.FirstOrDefault(m => m.Id == _currentMovieId);
        }

        public async void Start()
        {
            try
            {
                IsLoading = true;
                ConnectionRequired = false;

                var movieList = await _moviesService.GetMovies();
                Movies = new ObservableCollection<MovieModel>(movieList.OrderByDescending(m => m.RelaseDate).Take(3 * 15));

                SelectedMovie = (_currentMovieId != 0) ?
                    Movies.FirstOrDefault(m => m.Id == _currentMovieId) :
                    Movies.First();
            }
            catch (Exception)
            {
                ConnectionRequired = true;
            }
            finally
            {
                IsLoading = false;
            }
        }

        public void Activate(object parameter) { }
    }
}
