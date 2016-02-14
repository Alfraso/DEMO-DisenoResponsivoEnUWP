using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using MoviesDemo.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDemo.Core.ViewModels
{
    public abstract class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            
            SimpleIoc.Default.Register<INavigationService>(() => CreateNavigationService());

            if (ViewModelBase.IsInDesignModeStatic)
                SimpleIoc.Default.Register<IMoviesService, FakeMoviesService>();
            else
                SimpleIoc.Default.Register<IMoviesService, MoviesService>();

            SimpleIoc.Default.Register<MoviesViewModel>();
            SimpleIoc.Default.Register<MovieDetailViewModel>();

        }
        protected abstract INavigationService CreateNavigationService();

        public MoviesViewModel Movies => ServiceLocator.Current.GetInstance<MoviesViewModel>();
        public MovieDetailViewModel MovieDetail => ServiceLocator.Current.GetInstance<MovieDetailViewModel>();
    }
}
