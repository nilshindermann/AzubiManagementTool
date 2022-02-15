using AMT.Model;
using AMTCore.Data;
using AMTCore.Models;
using System.Windows;
using System.Windows.Navigation;

namespace AMT
{
    /// <summary>
    /// Interaktionslogik für LehrfirmaDetails.xaml
    /// </summary>
    public partial class LehrfirmaDetails
    {
        private readonly AMTContext? _db;
        private readonly Mode _mode = Mode.NONE;

        public LehrfirmaDetails(AMTContext db, Mode mode, Lehrfirma? lernende)
        {
            InitializeComponent();

            _db = db;
            _mode = mode;

            // set Data Context
            DataContext = lernende ?? new Lehrfirma();

            // Title and Elements
            switch (_mode)
            {
                case Mode.NONE:
                    break;

                case Mode.NEW:
                    lblTitle.Content = "Lehrfirma erstellen";
                    txtId.Text = string.Empty;
                    break;

                case Mode.EDIT:
                    lblTitle.Content = "Lehrfirma bearbeiten";
                    break;

                case Mode.DELETE:
                    lblTitle.Content = "Lehrfirma löschen?";
                    txtId.IsEnabled = false;
                    txtName.IsEnabled = false;
                    txtAdresse.IsEnabled = false;
                    txtOrt.IsEnabled = false;
                    txtPlz.IsEnabled = false;
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

            OnReturn(new ReturnEventArgs<Lehrfirma>((Lehrfirma)DataContext));
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            OnReturn(null);
        }
    }
}