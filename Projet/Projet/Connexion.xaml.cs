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
        private Manager MyManager
        {
            get
            {
                return ((Application.Current as App).Resources["MyManager"] as ObjectDataProvider).Data as Manager;
            }
        }

        public Connexion()
        {
            InitializeComponent();

            DataContext = MyManager;
            MyManager.charger();
        }

        private void Connect(object sender, RoutedEventArgs e)
        {
            if (MyManager.connexion(login.Text, password.Password))
            {
                new MainWindow(true).Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Identifiant et/ou mot de passe incorrect !");
            }
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
