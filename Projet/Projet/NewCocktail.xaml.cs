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
        private static int nbIng, exNbIng;
        private string nom, exNom, url, recette;
        private List<Ingredient> ingredients = new List<Ingredient>();
        //private Cocktail cocktail;

        public NewCocktail()
        {
            InitializeComponent();
            exNbIng = 1;
        }

        public NewCocktail(Cocktail c) : this()
        {
            DataContext = c;
            int num = 0;
            exNom = c.Nom;
            nbIngredientsC_DropDownClosed(new object(), new EventArgs());
            nbIng = c.IngredientRead.Count();
            nbIngredientsC.SelectedIndex = nbIng - 1;
            nbIngredientsC_DropDownClosed(new object(),new EventArgs());
            foreach(NewIngredient ni in ListIng.Items)
            {
                ni.nomIngredientC.Text = c.IngredientRead.ElementAt(num).Nom;
                ni.quantiteIngredientC.Text = c.IngredientRead.ElementAt(num).Quantite.ToString();
                ni.unitesIngredientC.SelectedValue = c.IngredientRead.ElementAt(num).Unite;
                num++;
            }
            url = UrlC.Text;
        }

        private void Annuler(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Ajout(object sender, RoutedEventArgs e)
        {
            nom = nomC.Text;
            recette = recetteC.Text;
            url = UrlC.Text;

            if ((nom != null || nom != "") && (recette != null || recette != ""))
            {
                ingredients.Clear();
                foreach (NewIngredient o in ListIng.Items)
                {
                    if (o.MyIngredient != null)
                        ingredients.Add(o.MyIngredient);
                    else
                    {
                        MessageBox.Show("Tous les éléments n'ont pas été remplis !");
                        return;
                    }
                }

                MyManager.supprimerCocktail(exNom);
                MyManager.ajouterCocktail(nom,recette,ingredients,url);
                //MessageBox.Show(MyManager.ToString());
                this.Close();
            }
            else
            {
                MessageBox.Show("Tous les éléments n'ont pas été remplis !");
                return;
            }
        }

        private void Rechercher(object sender, RoutedEventArgs e)
        {
            string filename = "";
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.InitialDirectory = "C:\\Users\\Public\\Pictures";
            dlg.FileName = "Images";
            dlg.DefaultExt = ".jpg | .png | .gif";
            dlg.Filter = "All images files (.jpg, .png, .gif)|*.jpg;*.png;*.gif|JPG files (.jpg)|*.jpg|PNG files (.png)|*.png|GIF files (.gif)|*.gif"; // Filter files by extension 
            
            bool? result = dlg.ShowDialog();
            
            if (result == true)
            {
                filename = dlg.FileName;
            }
            UrlC.Text = filename;
        }

        private void nbIngredientsC_DropDownClosed(object sender, EventArgs e)
        {
            nbIng = nbIngredientsC.SelectedIndex + 1;

            if (nbIng < exNbIng)
            {
                for (int i = exNbIng - 1; i >= nbIng; i--)
                {
                    ListIng.Items.RemoveAt(i);
                }
                exNbIng -= exNbIng - nbIng;
            }
            else if (nbIng > exNbIng)
            {
                for (int i = exNbIng+1; i <= nbIng; i++)
                {
                    ListIng.Items.Add(new NewIngredient() { Name = "ingredient" + nbIng });
                }
                exNbIng += nbIng - exNbIng;
            }
            else
            {
                return;
            }
            if (exNbIng == 1)
            {
                grid.RowDefinitions[4].Height = new GridLength(95, GridUnitType.Star);
                this.Height = 520;
            }
            if (exNbIng == 2)
            {
                grid.RowDefinitions[4].Height = new GridLength(190, GridUnitType.Star);
                this.Height = 604;
            }
            if (exNbIng >= 3)
            {
                grid.RowDefinitions[4].Height = new GridLength(285, GridUnitType.Star);
                this.Height = 688;
            }
        }
    }
}
