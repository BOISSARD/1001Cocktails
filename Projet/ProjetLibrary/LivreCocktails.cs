using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLibrary
{
    public class LivreCocktails
    {
        public Dictionary<string, Cocktail> livre;

        public LivreCocktails()
        {
            this.livre = new Dictionary<string, Cocktail>();
        }

        public LivreCocktails(Dictionary<string, Cocktail> livre)
        {
            this.livre = livre;
        }

        public void ajouterCocktail(Cocktail cocktail)
        {
            livre.Add(cocktail.nom.ToLower(), cocktail);
        }

        public void ajouterCocktails(List<Cocktail> cocktails)
        {
            foreach (Cocktail c in cocktails)
            {
                livre.Add(c.nom.ToLower(), c);
            }
        }

        public override string ToString()
        {
            string description = "";
            foreach (Cocktail c in livre.Values)
            {
                description += c.ToString() + "\n";
            }
            return description;
        }
    }
}
