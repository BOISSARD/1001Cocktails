using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLibrary
{
    public class Commentaire
    {
        public string titre { set; get; }
        public string texte { set; get; }
        public User utilisateur { set; get; }
        public short note
        {
            set
            {
                if (value >= 0 && value <= 10)
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
