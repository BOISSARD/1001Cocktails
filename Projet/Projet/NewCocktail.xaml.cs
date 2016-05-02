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
        static int nbIng, exNbIng = 1;
        /*static string nomIngredient = "";
        static int quantiteIngredient = 0;
        static Unite uniteIngredient = Unite.unite;*/

        public NewCocktail()
        {
            InitializeComponent();
            nbIngredientsC.SelectedIndex = 0;
        }

        private void Annuler(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Ajout(object sender, RoutedEventArgs e)
        {
           /* nom = nomC.Text;
            recette = recetteC.Text;
            Cocktail c = new Cocktail(nom, recette);
            this.Close();*/
        }

        private void nbIngredientsC_DropDownClosed_1(object sender, EventArgs e)
        {
            nbIng = nbIngredientsC.SelectedIndex + 1;
            MessageBox.Show(nbIng.ToString());

            if (nbIng == exNbIng) return;
            else if (nbIng < exNbIng)
            {
                for (int i = exNbIng - 1; i >= nbIng; i--)
                {
                    ListIng.Items.RemoveAt(i);
                    if (i == 1 || i == 2)
                    {
                        grid.RowDefinitions[4].Height = new GridLength(grid.RowDefinitions[4].ActualHeight - 88, GridUnitType.Star);
                        this.Height = this.ActualHeight - 82;
                    }
                }
                exNbIng -= exNbIng - nbIng;
            }
            else
            {
                for (int i = exNbIng+1; i <= nbIng; i++)
                {
                    Ingredient ing = new Ingredient() { Name = "ingredient" + nbIng };
                    ListIng.Items.Add(ing);
                    if (i == 2 || i == 3)
                    {
                        grid.RowDefinitions[4].Height = new GridLength(grid.RowDefinitions[4].ActualHeight + 84, GridUnitType.Star);
                        this.Height = this.ActualHeight + 82;
                    }
                }
                exNbIng += nbIng-exNbIng;
            }
            MessageBox.Show(exNbIng.ToString());
        }
    }
}
