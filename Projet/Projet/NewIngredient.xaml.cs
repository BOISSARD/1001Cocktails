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
    /// Logique d'interaction pour NewIngredient.xaml
    /// </summary>
    public partial class NewIngredient : UserControl
    {
        private Manager MyManager
        {
            get
            {
                return ((Application.Current as App).Resources["MyManager"] as ObjectDataProvider).Data as Manager;
            }
        }

        public NewIngredient()
        {
            InitializeComponent();
        }

        public Ingredient getIngredient() 
        {
            try
            {
                return new Ingredient(nomIngredientC.Text, Int32.Parse(quantiteIngredientC.Text), Fabrique.convertToUnite(unitesIngredientC.Text));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
    }
}
