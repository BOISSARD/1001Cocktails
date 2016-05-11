using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLibrary
{
    public class Commentaire
    {
        public string Titre { private set; get; }
        public string Texte { private set; get; }
        private User Utilisateur { set; get; }
        public short Note
        {
            private set
            {
                if (value >= 0 && value <= 10)
                {
                    Note = value;
                }
                else return;
            }
            get
            {
                return Note;
            }
        }

        public Commentaire(string titre, User user, short note)
        {
            this.Titre = titre;
            this.Utilisateur = user;
            this.Note = note;
        }

        public Commentaire(string titre, string texte, User user, short note) : this(titre, user, note)
        {
            this.Texte = texte;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {4}", Titre, Texte, Utilisateur.Pseudo, Note);
        }
    }
}
