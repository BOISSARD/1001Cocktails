 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetLibrary;

namespace ProjetLibrary
{
    /// <summary>
    /// La classe cocktail qui implémente l'interface IEquatable afin de redéfinir la comparaison.
    /// </summary>
    class Cocktail : IEquatable<Cocktail>
    {
        /// <summary>
        /// Nom est le nom du cocktail.
        /// </summary>
        public string Nom { private set; get;}
        /// <summary>
        /// Recette est du texte composé des étapes de la réalisation du cocktail.
        /// </summary>
        public string Recette { private set; get; }
        /// <summary>
        /// ingredients est la liste d'ingrédients.
        /// </summary>
        private List<Ingredient> ingredients = new List<Ingredient>();
        /// <summary>
        /// commentaires est la liste des commentaires laisser par un utilisateurs de type User.
        /// </summary>
        private Dictionary<User, Commentaire> commentaires = new Dictionary<User, Commentaire>();
        /// <summary>
        /// urlImage est le chemin de l'image dans le projet.
        /// </summary>
        public string urlImage { private set; get; }

        /// <summary>
        /// la façade immuable de la liste d'ingrédients.
        /// </summary>
        public IEnumerable<IIngredient> Ingredient { get { return ingredients; } }

        /// <summary>
        /// constructeur d'un cocktail.
        /// </summary>
        /// <param name="nom">prenant un nom</param>
        /// <param name="ingredients">et une liste d'ingrédients</param>
        public Cocktail(string nom, List<Ingredient> ingredients)
        {
            this.Nom = nom;
            this.Recette = "Pas de recette !";
            ingredients.ForEach(i => this.ingredients.Add(new Ingredient(i.Nom, i.Quantite, i.Unite)));
        }

        /// <summary>
        /// constructeur numéro 2.
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="recette">prenant une recette</param>
        /// <param name="ingredients"></param>
        public Cocktail(string nom, string recette, List<Ingredient> ingredients) : this(nom, ingredients)
        {
            this.Recette = recette;
        }

        /// <summary>
        /// constructeur numéro 3.
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="recette"></param>
        /// <param name="ingredients"></param>
        /// <param name="url"></param>
        public Cocktail(string nom, string recette, List<Ingredient> ingredients, string url) : this(nom, recette, ingredients)
        {
            this.urlImage = url;
        }

        public Cocktail(string nom, string recette , List<Ingredient> ingredients, Dictionary<User, Commentaire> commentaires, string url) : this(nom, recette, ingredients, url)
        {
            /*
            foreach (var com in commentaires.Values)
            {
                this.commentaires.Add(com,com)
            }*/
        }

        public void ajouterIngredients(Ingredient ingredient)
        {
            if (ingredients == null)
            {
                ingredients = new List<Ingredient>();
            }
            ingredients.Add(ingredient);
        }

        public void supprimerIngredients(Ingredient ingredient)
        {
            if (ingredients.Contains(ingredient))
            {
                ingredients.Remove(ingredient);
            }
        }

        public override int GetHashCode()
        {
            return Nom.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(obj, null)) return false;
            if (object.ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return this.Equals(obj as Cocktail);
        }

        public bool Equals(Cocktail cocktail)
        {
            return this.Nom.Equals(cocktail.Nom);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(Nom);
            sb.Append("\n");
            foreach (Ingredient ing in ingredients)
            {
                sb.AppendFormat("{0}\n", ing.ToString());
            }
            sb.AppendFormat("{0}\n", Recette);
            foreach (Commentaire comm in commentaires.Values)
            {
                sb.AppendFormat("{0}\n", comm.ToString());
            }
            return sb.ToString();
        }
    }
}
