﻿using System;
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
        private Cocktail co;
        private short laNote;

        public Commentaire()
        {
            InitializeComponent();
        }

        public Commentaire(Cocktail c) : this()
        {
            //DataContext = c;
            co = c;

            if (MyManager.CurrentUser != null)
            {
                Pseudo.Text = MyManager.CurrentUser.Pseudo;
                if (c.CommentaireObs.ContainsKey(MyManager.CurrentUser))
                {
                    Titre.Text = c.returnComment(MyManager.CurrentUser).Titre;
                    Texte.Text = c.returnComment(MyManager.CurrentUser).Texte;
                    Note.Value = c.returnComment(MyManager.CurrentUser).Note;
                }
            }
        }

        private void Annuler(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Poster(object sender, RoutedEventArgs e)
        {
            if (Pseudo.Text != "" || Pseudo.Text != null)
            {
                if (!co.CommentaireObs.ContainsKey(new User(Pseudo.Text)))
                {
                    if (MyManager.Connected && Pseudo.Text == MyManager.CurrentUser.Pseudo)
                    {
                        co.laisserCommentaire(MyManager.CurrentUser, new ProjetLibrary.Commentaire(Titre.Text, Texte.Text, (short)Note.Value));
                    }
                    else if(!MyManager.UserRead.Contains(new User(Pseudo.Text)))
                    {
                        co.laisserCommentaire(new User(Pseudo.Text), new ProjetLibrary.Commentaire(Titre.Text, Texte.Text, (short)Note.Value));
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Vous devez vous connecter avec le compte de {0} pour pouvoir laisser un avis en son nom.",Pseudo.Text));
                        Pseudo.Text = "";
                        return;
                    }
                }
                else
                {
                    //MessageBox.Show("Vous avez déjà laisser un commentaire pour ce cocktail");
                    co.supprimerCommentaire(new User(Pseudo.Text));
                    Poster(sender, e);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Veuillez rentrer un pseudo.");
                return;
            }
        }

        private void ChoixValeurNote(object sender, RoutedEventArgs e)
        {
            laNote = (short)Note.Value;
            float laVraieNote = (float)laNote / 2;
            //valNote.Text = laVraieNote.ToString("0.0");
        }
    }
}
