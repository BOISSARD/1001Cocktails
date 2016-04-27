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
    /// Logique d'interaction pour NewCocktail.xaml
    /// </summary>
    public partial class NewCocktail : Window
    {
        static string nom;
        static string recette;
        static int nbIng;
        /*static string nomIngredient = "";
        static int quantiteIngredient = 0;
        static Unite uniteIngredient = Unite.unite;*/

        public NewCocktail()
        {
            InitializeComponent();
        }

        private void Annuler(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Ingredient(object sender, RoutedEventArgs e)
        {
            nbIng = Convert.ToInt32(nbIngredientsC.Text);
            MessageBox.Show(nbIng.ToString());
            if (nbIng < 1) return;
            for (int i = 1; i < nbIng; i++)
            {
                //main.RowDefinitions.Insert(4+nbIng,new RowDefinition());
                //this.main.
            }
        }

        private void Ajout(object sender, RoutedEventArgs e)
        {
            nom = nomC.Text;
            recette = recetteC.Text;
            Cocktail c = new Cocktail(nom, recette);
            this.Close();
        }
    }
}
