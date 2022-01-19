using AMT.Model;
using AMTCore.Data;
using AMTCore.Models;
using System.Linq;
using System.Windows;
using System.Windows.Navigation;

namespace AMT
{
    /// <summary>
    /// Interaktionslogik für BesuchDetails.xaml
    /// </summary>
    public partial class BesuchDetails
    {
        private readonly AMTContext _db;
        private readonly Mode _mode = Mode.NONE;

        public BesuchDetails(AMTContext db, Mode mode, Besuch? besuch)
        {
            InitializeComponent();

            _db = db;
            _mode = mode;

            // Refresh List
            comboLernender.ItemsSource = _db.Lernende.ToList();
            comboKontaktperson.ItemsSource = _db.Kontaktpersonen.ToList();

            DataContext = besuch ?? new Besuch();

            // Title and Elements
            switch (_mode)
            {
                case Mode.NONE:
                    break;

                case Mode.NEW:
                    lblTitle.Content = "Besuch erfassen";
                    txtId.Text = string.Empty;
                    break;

                case Mode.EDIT:
                    lblTitle.Content = "Besuch korrigieren";
                    break;

                case Mode.DELETE:
                    lblTitle.Content = "Besuchstermin löschen ?";
                    dateDatum.IsEnabled = false;
                    comboLernender.IsReadOnly = true;
                    comboKontaktperson.IsReadOnly = true;
                    comboGrund.IsReadOnly = true;
                    btnOk.Content = "Löschen";
                    break;

                default:
                    break;
            }
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            // Title and Elements
            switch (_mode)
            {
                case Mode.NEW:
                    _db.Add(DataContext);
                    break;

                case Mode.EDIT:
                    _db.Update(DataContext);
                    break;

                case Mode.DELETE:
                    _db.Remove(DataContext);
                    break;

                default:
                    break;
            }

            _db.SaveChanges();
            OnReturn(new ReturnEventArgs<Besuch>((Besuch)DataContext));
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            OnReturn(null);
        }
    }
}
