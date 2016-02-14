using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using MoviesDemo.Core.Messages;
using MoviesDemo.Core.Models;
using MoviesDemo.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDemo.Core.ViewModels
{
    public class MovieDetailViewModel : ViewModelBase, INavigable
    {
        uint _movieId;

        private MovieModel _movie;
        public MovieModel Movie
        {
            get { return _movie; }
            set { Set(ref _movie, value); }
        }

        readonly INavigationService _navigationService;
        readonly IMoviesService _moviesService;

        public MovieDetailViewModel(INavigationService navigationService, IMoviesService moviesService)
        {
            _navigationService = navigationService;
            _moviesService = moviesService;

            Messenger.Default.Register<NarrowMessage>(this, OnNarrowMessageReceived);
        }

        private void OnNarrowMessageReceived(NarrowMessage n)
        {
            if (n.SerderView != Const.MOVIESDATAIL_VIEW || n.IsNarrow)
                return;

            _navigationService.GoBack();
        }

        public void Activate(object parameter)
        {
            if (parameter is uint)
                _movieId = (uint)parameter;
        }

        public async void Start()
        {
            var movieList = await _moviesService.GetMovies();

            Movie = movieList.FirstOrDefault(m => m.Id == _movieId);
        }
    }
}
