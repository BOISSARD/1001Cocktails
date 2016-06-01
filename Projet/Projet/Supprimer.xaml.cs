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
using ProjetLibrary;

namespace Projet
{
    /// <summary>
    /// Logique d'interaction pour Supprimer.xaml
    /// </summary>
    public partial class Supprimer : Window
    {
        public Supprimer()
        {
            InitializeComponent();
        }


        public Supprimer(ICocktail c)
        {
            InitializeComponent();
            text.Text = c.ToString();
        }

        private void Annuler(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
