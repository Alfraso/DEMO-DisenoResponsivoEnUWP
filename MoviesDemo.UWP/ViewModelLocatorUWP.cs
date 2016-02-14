using GalaSoft.MvvmLight.Views;
using MoviesDemo.Core;
using MoviesDemo.Core.ViewModels;
using MoviesDemo.UWP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDemo.UWP
{
    public class ViewModelLocatorUWP : ViewModelLocator
    {
        public ViewModelLocatorUWP() : base()
        {

        }

        protected override INavigationService CreateNavigationService()
        {
            var navigationService = new NavigationService();

            navigationService.Configure(Const.MOVIES_VIEW, typeof(MoviesView));
            navigationService.Configure(Const.MOVIESDATAIL_VIEW, typeof(MovieDetailView));

            return navigationService;
        }
    }
}
