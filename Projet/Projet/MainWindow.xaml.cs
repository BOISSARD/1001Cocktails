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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projet
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Ajout(object sender, RoutedEventArgs e)
        {
            new NewCocktail().Show();
        }

        private void Modif(object sender, RoutedEventArgs e)
        {
            if (List.SelectedItem != null) {
                new NewCocktail().Show();
            }
            else
            {
                MessageBox.Show("Il faut sélectionner un cocktail à modifier !");
            }
        }

        private void Suppr(object sender, RoutedEventArgs e)
        {
            if (List.SelectedItem != null)
            {
                new Supprimer().Show();
            }
            else
            {
                MessageBox.Show("Il faut sélectionner un cocktail à supprimer !");
            }
        }

        private void Comment(object sender, RoutedEventArgs e)
        {
            new Commentaire().Show();
        }
    }
}
