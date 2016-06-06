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
using ProjetLibrary;

namespace Projet
{
    /// <summary>
    /// Logique d'interaction pour BoutonConnecte.xaml
    /// </summary>
    public partial class BoutonConnecte : UserControl
    {
        private Manager MyManager
        {
            get
            {
                return ((Application.Current as App).Resources["MyManager"] as ObjectDataProvider).Data as Manager;
            }
        }

        private MainWindow main;

        public BoutonConnecte()
        {
            InitializeComponent();

            DataContext = MyManager;
            main = this.Parent as MainWindow;
        }

        private void Ajout(object sender, RoutedEventArgs e)
        {
            //new NewCocktail().Show();
            MyManager.ajouterCocktail("Test", "Ceci est un putin de test", new List<Ingredient>() { new Ingredient("ingredient", 5, Unite.unite) });
            MyManager.chargerCocktails();
        }

        private void Modif(object sender, RoutedEventArgs e)
        {
            //ICocktail c = (this.Parent as MainWindow).Liste.SelectedValue as ICocktail;
            //new NewCocktail(c);
        }

        private void Suppr(object sender, RoutedEventArgs e)
        {
            new Supprimer().Show();
        }

        private void Comment(object sender, RoutedEventArgs e)
        {
            new Commentaire(main.Liste.SelectedValue as ICocktail).Show();
        }
    }
}
