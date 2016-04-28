using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLibrary
{
    public class Commentaire
    {
        private string titre { set; get; }
        private string texte { set; get; }
        private User utilisateur { set; get; }
        private short note
        {
            set
            {
                if (value > 0 && value < 10)
                {
                    note = value;
                }
            }
            get
            {
                return note;
            }
        }

        public Commentaire(string titre, User user, short note)
        {
            this.titre = titre;
            this.utilisateur = user;
            this.note = note;
        }

        public Commentaire(string titre, string texte, User user, short note)
        {
            this.titre = titre;
            this.texte = texte;
            this.utilisateur = user;
            this.note = note;
        }
    }
}
