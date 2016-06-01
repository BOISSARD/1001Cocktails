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
        private Manager MyManager
        {
            get
            {
                return ((Application.Current as App).Resources["MyManager"] as ObjectDataProvider).Data as Manager;
            }
        }
        private static int nbIng, exNbIng = 1;
        private string nom, url, recette;
        private List<Ingredient> ingredients = new List<Ingredient>();

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
            nom = nomC.Text;
            recette = recetteC.Text;
            foreach (NewIngredient o in ListIng.Items)
            {
                ingredients.Add(o.getIngredient());
            }
            if ((nom != null || nom != "") && (recette != null || recette != "") && (ingredients.ElementAt(0).Nom != null/* || ingredients.ElementAt(0).Nom != ""*/))
            {
                MyManager.ajouterCocktail(nom,recette,ingredients);
                this.Close();
            }
            else
            {
                MessageBox.Show("Test");
                return;
            }
        }

        private void nbIngredientsC_DropDownClosed_1(object sender, EventArgs e)
        {
            nbIng = nbIngredientsC.SelectedIndex + 1;

            if (nbIng == exNbIng) return;
            else if (nbIng < exNbIng)
            {
                for (int i = exNbIng - 1; i >= nbIng; i--)
                {
                    ListIng.Items.RemoveAt(i);
                    if (i == 1 || i == 2)
                    {
                        grid.RowDefinitions[4].Height = new GridLength(grid.RowDefinitions[4].ActualHeight - 90, GridUnitType.Star);
                        this.Height = this.ActualHeight - 84;
                    }
                }
                exNbIng -= exNbIng - nbIng;
            }
            else
            {
                for (int i = exNbIng+1; i <= nbIng; i++)
                {
                    NewIngredient ing = new NewIngredient() { Name = "ingredient" + nbIng };
                    ListIng.Items.Add(ing);
                    if (i == 2 || i == 3)
                    {
                        grid.RowDefinitions[4].Height = new GridLength(grid.RowDefinitions[4].ActualHeight + 85, GridUnitType.Star);
                        this.Height = this.ActualHeight + 84;
                    }
                }
                exNbIng += nbIng-exNbIng;
            }
        }
    }
}
