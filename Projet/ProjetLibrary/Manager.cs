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
        public IEnumerable<IUser> utilisateurs { get { return utilisateurs; } }

        public Manager()
        {
        }



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
