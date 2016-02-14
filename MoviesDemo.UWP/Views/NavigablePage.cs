using MoviesDemo.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace MoviesDemo.UWP.Views
{
    public partial class NavigablePage : Page
    {
        private INavigable NavigableViewModel => DataContext as INavigable;

        public NavigablePage()
        {
            Loaded += OnLoaded;            
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            NavigableViewModel?.Start();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            NavigableViewModel?.Activate(e.Parameter);
        }
    }
}
