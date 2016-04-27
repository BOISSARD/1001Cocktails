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
    /// Logique d'interaction pour CreaCompte.xaml
    /// </summary>
    public partial class CreaCompte : Window
    {
        public CreaCompte()
        {
            InitializeComponent();
        }

        private void Creer(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Annuler(object sender, RoutedEventArgs e)
        {
            new Connexion().Show();
            this.Close();
        }
    }
}
