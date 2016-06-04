using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ProjetLibrary
{
    /// <summary>
    /// La classe User qui implémente l'interface IEquatable afin de redéfinir la comparaison.
    /// Et qui implémente l'interface IUser afin d'avoir une façade immuable.
    /// </summary>
    public class User : IEquatable<User>
    {
        /// <summary>
        /// Pseudo est le pseudo du cocktail, il est unique pour tous les cocktails.
        /// </summary>
        public string Pseudo { private set; get; }
        /// <summary>
        /// Mail est le mail de l'utilisateur.
        /// </summary>
        public string Mail { private set; get; }
        /// <summary>
        /// Password est le mot de passe que l'utilisateur à choisit pour son compte.
        /// </summary>
        public string Password { private set; get; }

        /// <summary>
        /// Constructeur de User numéro 1.
        /// </summary>
        /// <param name="pseudo">prend un pseudo</param>
        public User(string pseudo)
        {
            this.Pseudo = pseudo;
        }

        /// <summary>
        /// Constructeur de User numéro 2.
        /// </summary>
        /// <param name="pseudo">prend un pseudo</param>
        /// <param name="password">et un mot de passe</param>
        public User(string pseudo, string password) : this(pseudo)
        {
            this.Password = password;
        }

        /// <summary>
        /// Constructeur numéro 2.
        /// </summary>
        /// <param name="pseudo"></param>
        /// <param name="mail">prend un mail en plus</param>
        /// <param name="password"></param>
        public User(string pseudo, string mail, string password) : this(pseudo, password)
        {
            this.Mail = mail;
        }

        /// <summary>
        /// Redéfinition de la méthode GetHashCode.
        /// </summary>
        /// <returns>un entier : le code de hashage</returns>
        public override int GetHashCode()
        {
            return Pseudo.GetHashCode();
        }

        /// <summary>
        /// Redéfinition de la méthode Equals.
        /// </summary>
        /// <param name="obj">prenant un objet de type object</param>
        /// <returns>un booléen</returns>
        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(obj, null)) return false;
            if (object.ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return this.Equals(obj as User);
        }

        /// <summary>
        /// Création de la méthode Equals.
        /// </summary>
        /// <param name="user">prenant un objet de type User</param>
        /// <returns>un booléen</returns>
        public bool Equals(User user)
        {
            return this.Pseudo.Equals(user.Pseudo);
        }

        /// <summary>
        /// Redéfinition de la méthode ToString.
        /// </summary>
        /// <returns>rune chaîne de caractère</returns>
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Pseudo, Mail, Password);
        }
    }
}
