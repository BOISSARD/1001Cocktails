using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLibrary
{
    /// <summary>
    /// La classe commentaire implémente l'interface IEquatable afin de redéfinir la comparaison.
    /// </summary>
    class Commentaire : IEquatable<Commentaire>
    {
        /// <summary>
        /// Titre est le titre du commentaire.
        /// </summary>
        public string Titre { private set; get; }
        /// <summary>
        /// Texte est le message du commentaire.
        /// </summary>
        public string Texte { private set; get; }
        /// <summary>
        /// Note est la note du cocktail laisser par l'utilisateur dans le commentaire entre 0 et 5 par pas de 0,5.
        /// </summary>
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

        /// <summary>
        /// Constructeur d'un commentaire.
        /// </summary>
        /// <param name="titre">prenant un titre</param>
        /// <param name="note">et une note</param>
        public Commentaire(string titre, short note)
        {
            this.Titre = titre;
            this.Note = note;
        }

        /// <summary>
        /// Constructeur numéro 2
        /// </summary>
        /// <param name="titre"></param>
        /// <param name="texte">prenant un texte en plus</param>
        /// <param name="note"></param>
        public Commentaire(string titre, string texte, short note) : this(titre, note)
        {
            this.Texte = texte;
        }

        /// <summary>
        /// Redéfinition de la méthode GetHashCode
        /// </summary>
        /// <returns>un entier : le code de hashage</returns>
        public override int GetHashCode()
        {
            return Titre.GetHashCode()*Texte.GetHashCode()*Note.GetHashCode();
        }

        /// <summary>
        /// Redéfinition de la méthode Equals
        /// </summary>
        /// <param name="obj">prenant un objet de type object</param>
        /// <returns>un booléen</returns>
        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(obj, null)) return false;
            if (object.ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return this.Equals(obj as Commentaire);
        }

        /// <summary>
        /// Création de la méthode Equals
        /// </summary>
        /// <param name="com">prenant un objet de type Commentaire</param>
        /// <returns>un booléen</returns>
        public bool Equals(Commentaire com)
        {
            return this.Titre.Equals(com.Titre) && this.Texte.Equals(com.Texte) && this.Note.Equals(com.Note);
        }

        /// <summary>
        /// Redéfinition de la méthode ToString
        /// </summary>
        /// <returns>rune chaîne de caractère</returns>
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Titre, Texte, Note);
        }
    }
}
