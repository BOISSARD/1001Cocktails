using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Projet
{
    /// <summary>
    /// Logique d'interaction pour Commentaire.xaml
    /// </summary>
    public partial class Commentaire : Window
    {
        public Commentaire()
        {
            InitializeComponent();
        }

        private void Annuler(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ChoixValeurNote(object sender, RoutedEventArgs e)
        {
            short laNote = (short)note.Value;
            float laVraieNote = (float)laNote / 2;
            valNote.Text = laVraieNote.ToString("0.0");
        }
    }
}
