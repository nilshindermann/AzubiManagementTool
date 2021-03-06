using AMTCore.Data;
using AMTCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace AMT
{
    /// <summary>
    /// Interaktionslogik für KontaktpersonenPage.xaml
    /// </summary>
    public partial class KontaktpersonenPage : Page
    {
        private readonly AMTContext _db;

        public KontaktpersonenPage(AMTContext db)
        {
            InitializeComponent();
            _db = db;
        }

        /// <summary>
        /// Aktualisiert die Liste mit Kontaktpersonen
        /// </summary>
        private async void Fetch()
        {
            // disable user input buttons
            btnNew.IsEnabled = false;
            btnEdit.IsEnabled = false;
            btnDelete.IsEnabled = false;
            btnRefresh.IsEnabled = false;
            btnMail.IsEnabled = false;
            btnMailAll.IsEnabled = false;

            try
            {
                listView.ItemsSource = await _db.Kontaktpersonen.Include(k => k.Lehrfirma).ToListAsync();
                // enable buttons if successfully connected
                btnNew.IsEnabled = true;
                btnEdit.IsEnabled = true;
                btnDelete.IsEnabled = true;
                btnRefresh.IsEnabled = true;
                btnMail.IsEnabled = true;
                btnMailAll.IsEnabled = true;
            }
            catch (System.Exception)
            {
                // error message
                MessageBox.Show("Es ist ein Fehler aufgetreten!\nKeine Verbindung zur Datenbank", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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

        private void ApplicationSelectAll_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = listView != null;
        }

        private void ApplicationSelectAll_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            listView.SelectAll();
            listView.Focus();
        }

        private void ApplicationNew_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = listView != null;
        }

        private void ApplicationNew_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            KontaktpersonDetails page = new(_db, Model.Mode.NEW, null);
            NavigationService.Navigate(page);
            e.Handled = true;
        }

        private void ApplicationDelete_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = listView != null && listView.SelectedItems.Count == 1;
        }

        private void ApplicationDelete_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            // open delete dialog for selected item
            if (listView.SelectedItem is Kontaktperson kontakt)
            {
                var page = new KontaktpersonDetails(_db, Model.Mode.DELETE, kontakt);
                NavigationService.Navigate(page);
            }
        }

        private void CommandSendMail_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            // Link in ListView
            bool a = e.Parameter is string and not "all";
            // "Mail All" Button
            bool b = e.Parameter is string and "all" && listView != null && listView.Items.Count > 0;
            // "Mail" Button
            bool c = e.Parameter is null && listView != null && listView.SelectedItems.Count > 0;

            e.CanExecute = a || b || c;
        }

        private void CommandSendMail_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            if (e.Parameter is string mail)
            {
                if (mail == "all")
                {
                    MailTo(listView.Items.Cast<Kontaktperson>());
                }
                else
                {
                    Process.Start(new ProcessStartInfo($"mailto:{mail}") { UseShellExecute = true });
                }
            }
            else if (listView.SelectedItems.Count > 0)
            {
                MailTo(listView.SelectedItems.Cast<Kontaktperson>());
            }
            else
            {
                MessageBox.Show("Nichts ausgewählt", "Fehler :(", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Öffnet das Standard-Mailprogramm mit bereits eingegebenen E-Mail Adressen der Kontaktpersonen
        /// </summary>
        /// <param name="kontaktpersonen">Liste mit Kontaktpersonen</param>
        private static void MailTo(IEnumerable<Kontaktperson> kontaktpersonen)
        {
            string mails = string.Empty;
            foreach (Kontaktperson item in kontaktpersonen)
            {
                if (!mails.Contains(item.Email) && !item.Email.EndsWith(".invalid"))
                {
                    mails += $"{item.Email};";
                }
            }
            Process.Start(new ProcessStartInfo($"mailto:{mails}") { UseShellExecute = true });
        }

        private void CommandUpdate_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = listView != null && listView.SelectedItems.Count == 1;
        }

        private void CommandUpdate_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            KontaktpersonDetails page = new(_db, Model.Mode.EDIT, (Kontaktperson)listView.SelectedItem);
            NavigationService.Navigate(page);
            e.Handled = true;
        }

        private void CommandRefresh_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = listView != null;
        }

        private void CommandRefresh_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            // refresh list
            listView.ItemsSource = null;
            Fetch();
        }
    }
}