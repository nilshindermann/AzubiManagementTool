using AMT.Model;
using AMTCore.Data;
using AMTCore.Models;
using System.Linq;
using System.Windows;
using System.Windows.Navigation;

namespace AMT
{
    /// <summary>
    /// Interaktionslogik für LernendeDetails.xaml
    /// </summary>
    public partial class KontaktpersonDetails
    {
        private AMTContext? _db = null;
        private Mode _mode = Mode.NONE;

        public KontaktpersonDetails(AMTContext db, Mode mode, Kontaktperson? kontaktperson)
        {
            InitializeComponent();

            _db = db;
            _mode = mode;

            // Refresh List
            comboFirma.ItemsSource = _db.Lehrfirmen.ToList();

            // set Data Context
            DataContext = kontaktperson ?? new Kontaktperson();

            // Title and Elements
            switch (_mode)
            {
                case Mode.NONE:
                    break;

                case Mode.NEW:
                    lblTitle.Content = "Kontaktperson erstellen";
                    txtId.Text = string.Empty;
                    break;

                case Mode.EDIT:
                    lblTitle.Content = "Kontaktperson bearbeiten";
                    break;

                case Mode.DELETE:
                    lblTitle.Content = "Kontaktperson löschen ?";
                    txtVorname.IsReadOnly = true;
                    txtNachname.IsReadOnly = true;
                    txtEmail.IsReadOnly = true;
                    btnOk.Content = "Löschen";
                    break;

                default:
                    break;
            }
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            if (_db == null)
            {
                return;
            }

            switch (_mode)
            {
                case Mode.NEW:
                    _db.Add(DataContext);
                    _db.SaveChanges();
                    break;

                case Mode.EDIT:
                    _db.Update(DataContext);
                    _db.SaveChanges();
                    break;

                case Mode.DELETE:
                    _db.Remove(DataContext);
                    _db.SaveChanges();
                    break;

                case Mode.NONE:
                default:
                    break;
            }

            NavigationService.GoBack();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void BtnFirmaErstellen_Click(object sender, RoutedEventArgs e)
        {
            if (_db == null)
            {
                return;
            }

            var page = new LehrfirmaDetails(null);
            page.SetContext(_db);
            page.SetMode(Mode.NEW);
            page.Return += new ReturnEventHandler<Lehrfirma>(Page_Return);
            NavigationService.Navigate(page);
        }

        private void Page_Return(object sender, ReturnEventArgs<Lehrfirma> e)
        {
            if (e != null && e.Result != null && _db != null)
            {
                // Refresh List
                comboFirma.ItemsSource = _db.Lehrfirmen.ToList();
                comboFirma.SelectedItem = e.Result;
            }
        }
    }
}