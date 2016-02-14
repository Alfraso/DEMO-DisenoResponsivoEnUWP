using GalaSoft.MvvmLight.Messaging;
using MoviesDemo.Core;
using MoviesDemo.Core.Messages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Streaming.Adaptive;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MoviesDemo.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MoviesView : NavigablePage
    {
        public MoviesView()
        {
            this.InitializeComponent();
            Loaded += OnLoaded;
        }


        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            PublishNarrowMessage(AdaptiveStates.CurrentState);
        }

        private void OnAdaptiveStatesCurrentStateChanged(object sender, VisualStateChangedEventArgs e)
        {
            PublishNarrowMessage(e.NewState);
        }

        private void PublishNarrowMessage(VisualState currentVisualState)
        {
            bool isNarrow = currentVisualState == NarrowState;

            var navTransition = Transitions[0] as NavigationThemeTransition;
            navTransition.DefaultNavigationTransitionInfo = MasterListView.SelectedItem != null ?
                (NavigationTransitionInfo)new DrillInNavigationTransitionInfo() :
                (NavigationTransitionInfo)new SuppressNavigationTransitionInfo();

            Messenger.Default.Send<NarrowMessage>(new NarrowMessage(Const.MOVIES_VIEW, isNarrow));
        }
    }
}
