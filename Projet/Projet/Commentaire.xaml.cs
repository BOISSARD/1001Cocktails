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
    /// Logique d'interaction pour Commentaire.xaml
    /// </summary>
    public partial class Commentaire : Window
    {
        private Manager MyManager
        {
            get
            {
                return ((Application.Current as App).Resources["MyManager"] as ObjectDataProvider).Data as Manager;
            }
        }
        private ICocktail co;
        private short laNote;

        public Commentaire()
        {
            InitializeComponent();
        }

        public Commentaire(ICocktail c) : this()
        {
            co = c;
            if(c.CommentaireRead.ContainsKey(MyManager.CurrentUser))
            {
                Titre.Text = c.returnComment(MyManager.CurrentUser).Titre;
                Texte.Text = c.returnComment(MyManager.CurrentUser).Texte;
                note.Value = c.returnComment(MyManager.CurrentUser).Note;
            }
            if(MyManager.CurrentUser != null)
            {
                Pseudo.Text = MyManager.CurrentUser.Pseudo;
            }
        }

        private void Annuler(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Poster(object sender, RoutedEventArgs e)
        {   if (!co.CommentaireRead.ContainsKey(new User(Pseudo.Text)))
            {
                if (MyManager.CurrentUser != null)
                    co.laisserCommentaire(MyManager.CurrentUser, new ProjetLibrary.Commentaire(Titre.Text, Texte.Text, laNote));
                else co.laisserCommentaire(new User(Pseudo.Text), new ProjetLibrary.Commentaire(Titre.Text, Texte.Text, laNote));
            }
            else
            {
                //MessageBox.Show("Vous avez déjà laisser un commentaire pour ce cocktail");
                co.supprimerCommentaire(new User(Pseudo.Text));
                Poster(sender,e);
            }
            this.Close();
        }

        private void ChoixValeurNote(object sender, RoutedEventArgs e)
        {
            laNote = (short)note.Value;
            float laVraieNote = (float)laNote / 2;
            valNote.Text = laVraieNote.ToString("0.0");
        }
    }
}
