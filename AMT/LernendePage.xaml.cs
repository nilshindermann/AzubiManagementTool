using AMTCore.Data;
using AMTCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace AMT
{
    /// <summary>
    /// Interaktionslogik für LernendePage.xaml
    /// </summary>
    public partial class LernendePage : Page
    {
        private AMTContext _db;

        public LernendePage(AMTContext db)
        {
            InitializeComponent();
            _db = db;
        }

        /// <summary>
        /// Aktualisiert die Liste neu
        /// </summary>
        private async void Fetch()
        {
            listView.ItemsSource = await _db.Lernende.Include(l => l.Lehrfirma).ToListAsync();
        }

        /// <summary>
        /// Speichert Änderungen der Datenbank und aktualisiert die Liste
        /// </summary>
        private async void SaveAndFetch()
        {
            await _db.SaveChangesAsync();
            Fetch();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Fetch();
            listView.Focus();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
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
            LernendeDetails page = new(_db, Model.Mode.NEW, null);
            NavigationService.Navigate(page);
        }

        private void ApplicationDelete_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = listView != null && listView.SelectedItems.Count > 0;
        }

        private void ApplicationDelete_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // copy selected items
            List<Lernende> lernende = new();
            foreach (Lernende item in listView.SelectedItems)
            {
                lernende.Add(item);
            }
            // remove from listView
            foreach (var item in lernende)
            {
                _db.Lernende.Remove(item);
            }

            SaveAndFetch();
        }

        private void CommandSendMail_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // Link in ListView
            bool a = e.Parameter is string and not "all";
            // "Mail All" Button
            bool b = e.Parameter is string and "all" && listView != null && listView.Items.Count > 0;
            // "Mail" Button
            bool c = e.Parameter is null && listView != null && listView.SelectedItems.Count > 0;

            e.CanExecute = a || b || c;
        }

        private void CommandSendMail_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Parameter is string mail)
            {
                if (mail == "all")
                {
                    MailTo(listView.Items.Cast<Lernende>());
                }
                else
                {
                    Process.Start(new ProcessStartInfo($"mailto:{mail}") { UseShellExecute = true });
                }
            }
            else if (listView.SelectedItems.Count > 0)
            {
                MailTo(listView.SelectedItems.Cast<Lernende>());
            }
            else
            {
                MessageBox.Show("Nichts ausgewählt", "Fehler :(", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Öffnet das Standard-Mailprogramm mit bereits eingegebenen E-Mail Adressen der Lernenden
        /// </summary>
        /// <param name="lernende">Liste mit Lernenden</param>
        private static void MailTo(IEnumerable<Lernende> lernende)
        {
            string mails = string.Empty;
            foreach (Lernende item in lernende)
            {
                if (!mails.Contains(item.Email) && !item.Email.EndsWith(".invalid"))
                {
                    mails += $"{item.Email};";
                }
            }
            Process.Start(new ProcessStartInfo($"mailto:{mails}") { UseShellExecute = true });
        }

        private void CommandUpdate_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = listView != null && listView.SelectedItems.Count == 1;
        }

        private void CommandUpdate_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            LernendeDetails page = new(_db, Model.Mode.EDIT, (Lernende)listView.SelectedItem);
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

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // right click item
            if (sender is ListViewItem item && item.IsSelected)
            {
                if (item.Content is Lernende lernende)
                {
                    var page = new LernendeInfo(lernende, _db);
                    NavigationService.Navigate(page);
                }
            }
        }
    }
}