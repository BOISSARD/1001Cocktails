using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
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
    /// Logique d'interaction pour IngredientIEnum.xaml
    /// </summary>
    public partial class Ingredient : UserControl
    {
        public Ingredient()
        {
            InitializeComponent();

            Unite u = new Unite();

            DataContext = u;
        }
    }
}
