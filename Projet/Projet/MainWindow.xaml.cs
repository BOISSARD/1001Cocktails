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
using ProjetData;
using System.ComponentModel;

namespace Projet
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Manager MyManager
        {
            get
            {
                return ((Application.Current as App).Resources["MyManager"] as ObjectDataProvider).Data as Manager;
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            connecte.Main = this;

            DataContext = MyManager;
            if (MyManager.CurrentUser == null)
            {
                MyManager.connexion("Admin","admin63");
                MyManager.chargerCocktails();
                MyManager.deconnexion();
            }
            else
                MyManager.chargerCocktails();
        }

        public MainWindow(bool type) : this()
        {
            if (type)
            {
                connecte.Visibility = Visibility.Visible;
                visiteur.Visibility = Visibility.Hidden;
            }
            else
            {
                connecte.Visibility = Visibility.Hidden;
                visiteur.Visibility = Visibility.Visible;
            }
        }

        void Fermer(object sender, CancelEventArgs e)
        {
            MessageBox.Show(MyManager.sauvegardError());
            //MyManager.sauvegarder();
        }
    }
}
