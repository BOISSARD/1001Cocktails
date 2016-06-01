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
    /// Logique d'interaction pour CreaCompte.xaml
    /// </summary>
    public partial class CreaCompte : Window
    {
        private Manager MyManager
        {
            get
            {
                return ((Application.Current as App).Resources["MyManager"] as ObjectDataProvider).Data as Manager;
            }
        }

        public CreaCompte()
        {
            InitializeComponent();

            DataContext = MyManager;
        }

        private void Creer(object sender, RoutedEventArgs e)
        {
            if (mdp1.Password != mdp2.Password)
            {
                MessageBox.Show("Les mot de passe ne sont pas égaux !");
            }
            else
            { 
                User newUser = new User(pseudo.Text,mail.Text,mdp1.Password);
                if (!MyManager.UserRead.Contains(newUser))
                {
                    MyManager.ajouterUser(pseudo.Text, mail.Text, mdp1.Password);
                    MessageBox.Show("Le compte a bien été créé");
                    new Connexion().Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Identifiant déjà utilisé !");
                }
            }
        }

        private void Annuler(object sender, RoutedEventArgs e)
        {
            new Connexion().Show();
            this.Close();
        }
    }
}
