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
    /// Logique d'interaction pour Connexion.xaml
    /// </summary>
    public partial class Connexion : Window
    {
        public Connexion()
        {
            InitializeComponent();
        }

        private void Connect(object sender, RoutedEventArgs e)
        {
            User user = new User(login.Text, password.Password);
            if (true)
            {
                new MainWindow(true).Show();
                this.Close();
            }
            /*else
            {
                MessageBox.Show("Identifiant et/ou mot de passe incorrect !");
            }*/
        }

        private void Visit(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow(false);
            main.Show();
            this.Close();

        }

        private void CreatCompte(object sender, RoutedEventArgs e)
        {
            new CreaCompte().Show();
            this.Close();
        }
    }
}
