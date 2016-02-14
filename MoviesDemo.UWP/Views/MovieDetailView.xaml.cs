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
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MoviesDemo.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MovieDetailView : NavigablePage
    {
        public MovieDetailView()
        {
            this.InitializeComponent();
            SizeChanged += OnSizeChanged;
            
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width > 720)
                Messenger.Default.Send<NarrowMessage>(new NarrowMessage(Const.MOVIESDATAIL_VIEW, false));
            
        }
    }
}
