﻿using AMT.Model;
using AMTCore.Data;
using AMTCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AMT
{
    /// <summary>
    /// Interaktionslogik für NotenDetails.xaml
    /// </summary>
    public partial class NotenDetails : Page
    {
        private readonly AMTContext _db;
        private readonly Mode _mode = Mode.NONE;

        public NotenDetails(AMTContext db, Mode mode, Note? note)
        {
            InitializeComponent();

            _db = db;
            _mode = mode;

            // Refresh List
            comboLernender.ItemsSource = _db.Lernende.Include(l => l.Lehrfirma).ToList();

            DataContext = note ?? new Note();

            // Title and Elements
            switch (_mode)
            {
                case Mode.NEW:
                    lblTitle.Content = "Note erfassen";
                    break;

                case Mode.EDIT:
                    lblTitle.Content = "Note korrigieren";
                    break;

                case Mode.DELETE:
                    lblTitle.Content = "Note löschen ??";
                    comboLernender.IsReadOnly = true;
                    comboModul.IsReadOnly = true;
                    txtWert.IsReadOnly = true;
                    txtGewicht.IsReadOnly = true;
                    checkMP.IsEnabled = false;
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
            NavigationService.GoBack();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
