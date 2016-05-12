using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLibrary
{
    public class LivreCocktails
    {
        public List<Cocktail> livre;

        public LivreCocktails() { livre = new List<Cocktail>();  }

        public LivreCocktails(List<Cocktail> livre) : this()
        {
            foreach(Cocktail c in livre)
            {
                this.livre.Add(new Cocktail(c.Nom, c.Recette, c.getIngredients(), c.getCommentaire(), c.urlImage));
            };
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
