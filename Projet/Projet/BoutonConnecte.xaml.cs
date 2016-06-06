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

        //private Window main;
        public MainWindow Main { set; get; }
        ICocktail cocktail;

        public BoutonConnecte()
        {
            InitializeComponent();

            DataContext = MyManager;
        }

        public BoutonConnecte(MainWindow w) : this()
        {
            Main = w;
        }

        private void Ajout(object sender, RoutedEventArgs e)
        {
            //new NewCocktail().Show();
            MyManager.ajouterCocktail("Test", "Ceci est un test", new List<Ingredient>() { new Ingredient("ingredient", 0, Unite.unite) });
            MyManager.chargerCocktails();
        }

        private void Modif(object sender, RoutedEventArgs e)
        {
            new NewCocktail(Main.Liste.SelectedValue as ICocktail);
        }

        private void Suppr(object sender, RoutedEventArgs e)
        {
            new Supprimer(Main.Liste.SelectedValue as ICocktail).Show();
        }

        private void Comment(object sender, RoutedEventArgs e)
        {
            if ((Main.Liste.SelectedValue as ICocktail).CommentaireRead.ContainsKey(MyManager.CurrentUser))
            {
                var result = MessageBox.Show("Déjà commenter","Vous avez déjà laisser un commentaire pour ce cocktail.\nVoulez-vous le modifier ?",MessageBoxButton.YesNo);
                if(result == MessageBoxResult.Yes)
                {
                    new Commentaire(Main.Liste.SelectedValue as ICocktail).Show();
                }
            }
            else
                new Commentaire(Main.Liste.SelectedValue as ICocktail).Show();
        }
    }
}
