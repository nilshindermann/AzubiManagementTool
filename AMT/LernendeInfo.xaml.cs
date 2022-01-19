using AMTCore.Data;
using AMTCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace AMT
{
    /// <summary>
    /// Interaktionslogik für LernendeInfo.xaml
    /// </summary>
    public partial class LernendeInfo
    {
        private readonly AMTContext _db;

        public LernendeInfo(Lernende lernende, AMTContext db)
        {
            InitializeComponent();
            DataContext = lernende;
            _db = db;

            listBesuche.ItemsSource = _db.Besuche.Where(b => b.Lernender!.Id == lernende.Id)
                .Include(b => b.Kontaktperson).ToList();
            listNoten.ItemsSource = _db.Noten.Where(b => b.Lernender!.Id == lernende.Id).ToList();
        }

        private void CommandSendMail_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = e.Parameter is string;
        }

        private void CommandSendMail_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Parameter is string mail)
            {
                Process.Start(new ProcessStartInfo($"mailto:{mail}") { UseShellExecute = true });
                e.Handled = true;
            }
        }

        private void CommandEdit_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // only can execute if parameter is a specific string and an item is selected
            e.CanExecute = e.Parameter is string s && (
                (s == "NOTE" && listNoten != null && listNoten.SelectedItem != null) ||
                (s == "BESUCH" && listBesuche != null && listBesuche.SelectedItem != null));
        }

        private void CommandEdit_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Parameter is string param)
            {
                var besuch = (Besuch)listBesuche.SelectedItem;
                var note = (Note)listNoten.SelectedItem;

                // page navigating to, if not null
                object? page =
                    param == "BESUCH" ? new BesuchDetails(_db, Model.Mode.EDIT, besuch) :
                    param == "NOTE" ? new NotenDetails(_db, Model.Mode.EDIT, note) : null;

                if (page != null)
                {
                    NavigationService.Navigate(page);
                    e.Handled = true;
                }
            }
        }

        private void ApplicationNew_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // only can execute if parameter is a specific string
            e.CanExecute = e.Parameter is string s && (
                (s == "NOTE" && listNoten != null) ||
                (s == "BESUCH" && listBesuche != null));
        }

        private void ApplicationNew_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Parameter is string param)
            {
                var besuch = new Besuch { Lernender = (Lernende)DataContext };
                var note = new Note { Lernender = (Lernende)DataContext };

                object? page =
                    param == "BESUCH" ? new BesuchDetails(_db, Model.Mode.NEW, besuch) :
                    param == "NOTE" ? new NotenDetails(_db, Model.Mode.NEW, note) : null;

                if (page != null)
                {
                    NavigationService.Navigate(page);
                    e.Handled = true;
                }
            }
        }

        private void ApplicationDelete_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // only can execute if parameter is a specific string and an item is selected
            e.CanExecute = e.Parameter is string s && (
                (s == "NOTE" && listNoten != null && listNoten.SelectedItem != null) ||
                (s == "BESUCH" && listBesuche != null && listBesuche.SelectedItem != null));
        }

        private void ApplicationDelete_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Parameter is string param)
            {
                var besuch = (Besuch)listBesuche.SelectedItem;
                var note = (Note)listNoten.SelectedItem;

                object? page =
                    param == "BESUCH" ? new BesuchDetails(_db, Model.Mode.DELETE, besuch) :
                    param == "NOTE" ? new NotenDetails(_db, Model.Mode.DELETE, note) : null;

                if (page != null)
                {
                    NavigationService.Navigate(page);
                    e.Handled = true;
                }
            }
        }
    }
}