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
        public User Utilisateur { private set; get; }
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

        public override int GetHashCode()
        {
            return Titre.GetHashCode()*Texte.GetHashCode()*Utilisateur.GetHashCode()*Note.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(obj, null)) return false;
            if (object.ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return this.Equals(obj as Commentaire);
        }

        public bool Equals(Commentaire com)
        {
            return this.Titre.Equals(com.Titre) && this.Texte.Equals(com.Texte) && this.Utilisateur.Equals(com.Utilisateur) && this.Note.Equals(com.Note);
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {4}", Titre, Texte, Utilisateur.Pseudo, Note);
        }
    }
}
