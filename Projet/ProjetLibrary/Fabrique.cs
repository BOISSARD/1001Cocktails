using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLibrary
{
    /// <summary>
    /// Classe static permettant de créer des objets dont le type est inaccessible.
    /// </summary>
    static public class Fabrique
    {
        /// <summary>
        /// Méthode static permettant de récupérer une nouvelle instance d'un cocktail.
        /// </summary>
        /// <param name="nom">le nom du nouveau cocktail</param>
        /// <param name="recette">la recette de ce cocktail</param>
        /// <param name="ingredients">une collection d'ingredient</param>
        /// <param name="url">le lien de l'image qui correspond à ce cocktail</param>
        /// <returns>la nouvelle instance de cocktail</returns>
        public static Cocktail creerCocktail(string nom, string recette, List<Ingredient> ingredients, string url)
        {
            return new Cocktail(nom, recette, ingredients, url);
        }

        /// <summary>
        /// Méthode static permettant de récupérer une nouvelle instance d'un cocktail comprenant en plus un dictionnaire de commentaire.
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="recette"></param>
        /// <param name="ingredients"></param>
        /// <param name="commentaires">dictionnaire de commentaires en fonction de l'utilisateur</param>
        /// <param name="url"></param>
        /// <returns>le cocktail</returns>
        public static Cocktail creerCocktail(string nom, string recette, List<Ingredient> ingredients, Dictionary<User, Commentaire> commentaires, string url)
        {
            return new Cocktail(nom, recette, ingredients, commentaires, url);
        }

        /// <summary>
        /// Méthode static permettant de convertir une chaine de caractères en Unite
        /// </summary>
        /// <param name="unite">string </param>
        /// <returns>l'unité de type Unite</returns>
        public static Unite convertToUnite(string unite)
        {
            switch (unite)
            {
                case "baton":
                    return Unite.baton;
                case "cl":
                    return Unite.cl;
                case "cuillere":
                    return Unite.cuillere;
                case "feuille":
                    return Unite.feuille;
                case "g":
                    return Unite.g;
                case "goutte":
                    return Unite.goutte;
                case "l":
                    return Unite.l;
                case "morceau":
                    return Unite.morceau;
                case "sachet":
                    return Unite.sachet;
                case "tranche":
                    return Unite.tranche;
                case "trait":
                    return Unite.trait;
                case "zeste":
                    return Unite.zeste;
                default:
                    return Unite.unite;
            }
        }
    }
}
