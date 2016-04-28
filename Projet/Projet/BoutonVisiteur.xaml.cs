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

namespace Projet
{
    /// <summary>
    /// Logique d'interaction pour BoutonVisiteur.xaml
    /// </summary>
    public partial class BoutonVisiteur : UserControl
    {
        public BoutonVisiteur()
        {
            InitializeComponent();
        }

        private void Comment(object sender, RoutedEventArgs e)
        {
            new Commentaire().Show();
        }

        private void Connect(object sender, RoutedEventArgs e)
        {
            new Connexion().Show();
            Window.GetWindow(this).Close();
        }
    }
}
