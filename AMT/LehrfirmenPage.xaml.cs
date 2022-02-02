using AMTCore.Data;
using AMTCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AMT
{
    /// <summary>
    /// Interaktionslogik für LehrfirmenPage.xaml
    /// </summary>
    public partial class LehrfirmenPage : Page
    {
        private readonly AMTContext _db;

        public LehrfirmenPage(AMTContext db)
        {
            InitializeComponent();
            _db = db;
        }

        /// <summary>
        /// Aktualisiert die Liste mit Lehrfirmen
        /// </summary>
        private async void Fetch()
        {
            listView.ItemsSource = await _db.Lehrfirmen.ToListAsync();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Fetch();
            listView.Focus();
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            // Handle external Links
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
            e.Handled = true;
        }

        private void ApplicationSelectAll_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = listView != null;
        }

        private void ApplicationSelectAll_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            listView.SelectAll();
            listView.Focus();
        }

        private void ApplicationNew_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = listView != null;
        }

        private void ApplicationNew_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            LehrfirmaDetails page = new(null);
            page.SetContext(_db);
            page.SetMode(Model.Mode.NEW);
            NavigationService.Navigate(page);
        }

        private void ApplicationDelete_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = listView != null && listView.SelectedItems.Count == 1;
        }

        private void ApplicationDelete_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // open delete dialog for selected item
            if (listView.SelectedItem is Lehrfirma firma)
            {
                var page = new LehrfirmaDetails(firma);
                page.SetContext(_db);
                page.SetMode(Model.Mode.DELETE);
                NavigationService.Navigate(page);
            }
        }

        private void CommandUpdate_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = listView != null && listView.SelectedItems.Count == 1;
        }

        private void CommandUpdate_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            LehrfirmaDetails page = new((Lehrfirma)listView.SelectedItem);
            page.SetContext(_db);
            page.SetMode(Model.Mode.EDIT);
            NavigationService.Navigate(page);
            e.Handled = true;
        }

        private void CommandRefresh_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = listView != null;
        }

        private void CommandRefresh_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // refresh list
            listView.ItemsSource = null;
            Fetch();
        }
    }
}