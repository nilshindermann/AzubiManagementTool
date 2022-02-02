using AMTCore.Data;
using AMTCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using System.Windows.Navigation;

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

            RefreshLists();
        }

        /// <summary>
        /// Aktualisiert die Liste mit den Noten und die Liste mit den Besuchen
        /// </summary>
        private void RefreshLists()
        {
            listBesuche.ItemsSource = _db.Besuche.Where(b => b.Lernender!.Id == ((Lernende)DataContext).Id)
                .Include(b => b.Kontaktperson).ToList();
            listNoten.ItemsSource = _db.Noten.Where(b => b.Lernender!.Id == ((Lernende)DataContext).Id).ToList();
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
                switch (param)
                {
                    case "BESUCH":
                        var besuch = (Besuch)listBesuche.SelectedItem;
                        PageFunction<Besuch> pageBesuch = new BesuchDetails(_db, Model.Mode.EDIT, besuch);
                        pageBesuch.Return += (s, ev) => RefreshLists();
                        NavigationService.Navigate(pageBesuch);
                        e.Handled = true;
                        break;

                    case "NOTE":
                        var note = (Note)listNoten.SelectedItem;
                        PageFunction<Note> pageNote = new NotenDetails(_db, Model.Mode.EDIT, note);
                        pageNote.Return += (s, ev) => RefreshLists();
                        NavigationService.Navigate(pageNote);
                        e.Handled = true;
                        break;

                    default:
                        break;
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
                switch (param)
                {
                    case "BESUCH":
                        var besuch = new Besuch { Lernender = (Lernende)DataContext };
                        PageFunction<Besuch> pageBesuch = new BesuchDetails(_db, Model.Mode.NEW, besuch);
                        pageBesuch.Return += (s, ev) => RefreshLists();
                        NavigationService.Navigate(pageBesuch);
                        e.Handled = true;
                        break;

                    case "NOTE":
                        var note = new Note { Lernender = (Lernende)DataContext };
                        PageFunction<Note> pageNote = new NotenDetails(_db, Model.Mode.NEW, note);
                        pageNote.Return += (s, ev) => RefreshLists();
                        NavigationService.Navigate(pageNote);
                        e.Handled = true;
                        break;

                    default:
                        break;
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
                switch (param)
                {
                    case "BESUCH":
                        var besuch = (Besuch)listBesuche.SelectedItem;
                        PageFunction<Besuch> pageBesuch = new BesuchDetails(_db, Model.Mode.DELETE, besuch);
                        pageBesuch.Return += (s, ev) => RefreshLists();
                        NavigationService.Navigate(pageBesuch);
                        e.Handled = true;
                        break;

                    case "NOTE":
                        var note = (Note)listNoten.SelectedItem;
                        PageFunction<Note> pageNote = new NotenDetails(_db, Model.Mode.DELETE, note);
                        pageNote.Return += (s, ev) => RefreshLists();
                        NavigationService.Navigate(pageNote);
                        e.Handled = true;
                        break;

                    default:
                        break;
                }
            }
        }
    }
}