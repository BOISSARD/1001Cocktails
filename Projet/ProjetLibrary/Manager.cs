using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLibrary
{
    public class Manager
    {
        private Dictionary<string, Cocktail> livre = new Dictionary<string, Cocktail>();
        private List<IUser> utilisateurs = new List<IUser>();

        public Manager()
        {
            //livre = new Dictionary<string, Cocktail>();
            //utilisateurs = new List<User>();
        }

        public Manager(List<IUser> users) //: this ()
        {
            users.ForEach(i => utilisateurs.Add(new User(i.Pseudo,i.Mail,i.Password)));
        }

        //public Manager(Dictionary<string, Cocktail> bouquin)
        //{
        //    foreach(KeyValuePair<string, Cocktail> i in bouquin)
        //    {
        //        livre.Add(i.Key, i.Value);
        //    }
        //}

        //public Manager(Dictionary<string, Cocktail> bouquin, List<User> users) : this(bouquin)
        //{
        //    users.ForEach(i => utilisateurs.Add(new User(i.Pseudo, i.Mail, i.Password)));
        //}

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("");
            foreach (Cocktail c in livre.Values)
            {
                sb.AppendFormat("{0}\n", c.ToString());
            }
            return sb.ToString();
            //return "";
        }

        public Ingredient ajouterIngredient(string nom,int quantite,Unite unite)
        {
            return new Ingredient(nom,quantite,unite);
        }

        //public Commentaire ajouterCommentaire()
        //{

        //}

        //public Cocktail ajouterCocktail(string nom,string recette,List<Ingredient> ing,List<Commentaire> comm,string url)
        //{

        //}
    }
}
