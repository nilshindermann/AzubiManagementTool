using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

namespace AMT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly MainPage _mainPage;

        public MainWindow(MainPage mainPage)
        {
            InitializeComponent();
            _mainPage = mainPage;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            rootFrame.Navigate(_mainPage);
        }

        private void Logo_Click(object sender, RoutedEventArgs e)
        {
            while (rootFrame.CanGoBack)
            {
                rootFrame.GoBack();
            }
        }

        private void CommandGoBack_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = rootFrame?.CanGoBack ?? false;
        }

        private void CommandGoBack_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            rootFrame?.GoBack();
            e.Handled = true;
        }

        private void CommandGoForward_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = rootFrame?.CanGoForward ?? false;
        }

        private void CommandGoForward_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            rootFrame?.GoForward();
            e.Handled = true;
        }

        // NAVIGATION ANIMATION

        private void RootFrame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            var ta = new ThicknessAnimation
            {
                Duration = TimeSpan.FromSeconds(0.3),
                DecelerationRatio = 0.7,
                To = new Thickness(0, 0, 0, 0)
            };
            if (e.NavigationMode == NavigationMode.New || e.NavigationMode == NavigationMode.Forward)
            {
                ta.From = new Thickness(500, 0, 0, 0);
            }
            else if (e.NavigationMode == NavigationMode.Back)
            {
                ta.From = new Thickness(0, 0, 500, 0);
            }
                 (e.Content as Page)?.BeginAnimation(MarginProperty, ta);
        }
    }
}