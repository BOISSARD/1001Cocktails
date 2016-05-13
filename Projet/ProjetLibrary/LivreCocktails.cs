using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLibrary
{
    public class LivreCocktails
    {
        private Dictionary<string, Cocktail> livre;

        public LivreCocktails() { livre = new Dictionary<string, Cocktail>(); }

        public LivreCocktails(Dictionary<string, Cocktail> livre) : this()
        {

        }

        public void ajouterCocktail(Cocktail cocktail)
        {

        }

        public void ajouterCocktails(List<Cocktail> cocktails)
        {
            foreach (Cocktail c in cocktails)
            {
                livre.Add(c.Nom, c);
            }
        }

        public override string ToString()
        {
            //StringBuilder sb = new StringBuilder("");
            //foreach (Cocktail c in livre)
            //{
            //    sb.AppendFormat("{0}\n", c.ToString());
            //}
            //return sb.ToString();
            return "";
        }
    }
}
