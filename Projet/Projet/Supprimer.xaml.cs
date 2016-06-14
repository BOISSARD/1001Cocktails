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
        private MainWindow main;
        private string nom;
        private Manager MyManager
        {
            get
            {
                return ((Application.Current as App).Resources["MyManager"] as ObjectDataProvider).Data as Manager;
            }
        }

        public Supprimer()
        {
            InitializeComponent();
            main = this.Parent as MainWindow;
        }


        public Supprimer(Cocktail c) : this()
        {
            nom = c.Nom;
            //MyManager.supprimerCocktail(nom);
        }

        private void Annuler(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Valider(object sender, RoutedEventArgs e)
        {
            MyManager.supprimerCocktail(nom);
            this.Close();
        }
    }
}
