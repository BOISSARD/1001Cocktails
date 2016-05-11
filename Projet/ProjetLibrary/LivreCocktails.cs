using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLibrary
{
    public class LivreCocktails
    {
        public List<Cocktail> livre = new List<Cocktail>();

        public LivreCocktails(List<Cocktail> livre)
        {
            livre.ForEach(i => this.livre.Add(new Cocktail(i.Nom,i.Recette,i.ajouterIngredients,i.commentaires,i.url)));
        }

        public void ajouterCocktail(Cocktail cocktail)
        {
            livre.Add(cocktail);
        }

        public void ajouterCocktails(List<Cocktail> cocktails)
        {
            foreach (Cocktail c in cocktails)
            {
                livre.Add(c);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("");
            foreach (Cocktail c in livre)
            {
                sb.AppendFormat("{0}\n", c.ToString());
            }
            return sb.ToString();
        }
    }
}
