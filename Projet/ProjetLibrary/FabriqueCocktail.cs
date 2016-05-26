using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLibrary
{
    public static class FabriqueCocktail
    {
        public static ICocktail creerCocktail(string nom, string recette, List<Ingredient> ingredients, string url)
        {
            return new Cocktail(nom, recette, ingredients, url);
        }

        public static ICocktail creerCocktail(string nom, string recette, List<Ingredient> ingredients, Dictionary<User, Commentaire> commentaires, string url)
        {
            return new Cocktail(nom, recette, ingredients, commentaires, url);
        }
    }
}
