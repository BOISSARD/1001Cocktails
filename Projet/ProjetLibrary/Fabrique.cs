using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLibrary
{
    static public class Fabrique
    {
        public static Cocktail creerCocktail(string nom, string recette, List<Ingredient> ingredients, string url)
        {
            return new Cocktail(nom, recette, ingredients, url);
        }

        public static Cocktail creerCocktail(string nom, string recette, List<Ingredient> ingredients, Dictionary<User, Commentaire> commentaires, string url)
        {
            return new Cocktail(nom, recette, ingredients, commentaires, url);
        }

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

        //public static KeyValuePair<User,Commentaire> creerUserCom(string pseudo, string titre, string texte, short note)
        //{
        //    return new KeyValuePair<Manager.recupUser(pseudo), Commentaire>();
        //}

        //public static User recupUser(string pseudo)
        //{
        //    return Manager.utilisateurs.Where(u => u.Pseudo == pseudo).SingleOrDefault();
        //}
    }
}
