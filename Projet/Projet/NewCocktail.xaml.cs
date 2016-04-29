﻿using System;
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
        }

        private void Annuler(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Ajout(object sender, RoutedEventArgs e)
        {
            nom = nomC.Text;
            recette = recetteC.Text;
            Cocktail c = new Cocktail(nom, recette);
            this.Close();
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
                    /*if (i == 2 || i == 3)
                    {
                        this.Height = this.ActualHeight - 100;
                        ListIng.Height = ListIng.ActualHeight - 80;
                    }*/
                }
                exNbIng -= nbIng;
            }
            else
            {
                for (int i = 2; i <= nbIng; i++)
                {
                    Ingredient ing = new Ingredient() { Name = "ingredient" + nbIng };
                    ListIng.Items.Add(ing);
                    if (i == 2 || i == 3)
                    {
                        this.Height = this.ActualHeight + 100;
                        ListIng.Height = ListIng.ActualHeight + 80;
                    }
                }
                exNbIng += nbIng-exNbIng;
            }
            MessageBox.Show(exNbIng.ToString());

        }
    }
}
