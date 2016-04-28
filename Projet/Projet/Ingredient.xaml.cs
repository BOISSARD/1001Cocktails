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
    /// Logique d'interaction pour Ingredient.xaml
    /// </summary>
    public partial class Ingredient : UserControl
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private IEnumerable<Unite> ddlItemSource;
        public IEnumerable<Unite> DDLItemSource
        {
            get
            {
                return Enum.GetValues(typeof(Unite)).Cast<Unite>();
            }
            set
            {
                ddlItemSource = value;
                RaisePropertyChanged("DDLItemSource");
            }
        }

        public Ingredient()
        {
            InitializeComponent();
        }
    }
}
