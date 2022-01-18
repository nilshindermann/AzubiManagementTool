using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace AMT
{
    /// <summary>
    /// Interaktionslogik für MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private readonly LernendePage _lernendePage;
        private readonly LehrfirmenPage _lehrfirmenPage;
        private readonly KontaktpersonenPage _kontaktpersonenPage;

        public MainPage(LernendePage lernendePage, LehrfirmenPage lehrfirmenPage, KontaktpersonenPage kontaktpersonenPage)
        {
            InitializeComponent();
            _lernendePage = lernendePage;
            _lehrfirmenPage = lehrfirmenPage;
            _kontaktpersonenPage = kontaktpersonenPage;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                switch ((string)btn.DataContext)
                {
                    case "l":
                        NavigationService.Navigate(_lernendePage);
                        break;
                    case "f":
                        NavigationService.Navigate(_lehrfirmenPage);
                        break;
                    case "k":
                        NavigationService.Navigate(_kontaktpersonenPage);
                        break;
                    default:
                        return;
                }
            }
        }
    }
}
