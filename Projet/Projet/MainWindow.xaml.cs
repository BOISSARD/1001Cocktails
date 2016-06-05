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

            DataContext = MyManager;
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
    }
}
