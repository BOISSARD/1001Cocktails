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

namespace Projet
{
    /// <summary>
    /// Logique d'interaction pour MainWindowBis.xaml
    /// </summary>
    public partial class MainWindowBis : Window
    {
        public MainWindowBis()
        {
            InitializeComponent();
        }

        private void Connect(object sender, RoutedEventArgs e)
        {
            new Connexion().Show();
            this.Close();
        }

        private void Comment(object sender, RoutedEventArgs e)
        {
            new Commentaire().Show();
        }
    }
}
