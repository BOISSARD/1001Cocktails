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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            Cocktail c1 = new Cocktail("VodkaOrange","Mélange la vodka au jus d'orange", new List<ProjetLibrary.Ingredient>(){
                new ProjetLibrary.Ingredient("Vodka",10,Unite.cl),
                new ProjetLibrary.Ingredient("Jus d'Orange",25,Unite.cl)
            });

            Cocktail c2 = new Cocktail("VodkaPomme", "Mélange la vodka au jus de pomme", new List<ProjetLibrary.Ingredient>(){
                new ProjetLibrary.Ingredient("Vodka",10,Unite.cl),
                new ProjetLibrary.Ingredient("Jus de Pomme",25,Unite.cl)
            });

            LivreCocktails livre = new LivreCocktails();

            livre.ajouterCocktail(c1);
            livre.ajouterCocktail(c2);

            //List.ItemsSource = livre;
            


        }

        public MainWindow(bool type)
        {
            InitializeComponent();
            if (type)
            {
                connecte.Visibility = Visibility.Visible;
                visiteur.Visibility = Visibility.Hidden;
            }
            else
            {
                connecte.Visibility = Visibility.Hidden;
                visiteur.Visibility = Visibility.Visible;
            }
        }
    }
}
