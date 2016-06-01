using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetLibrary;

namespace ProjetLibrary
{
    /// <summary>
    /// La classe Cocktail qui implémente l'interface IEquatable afin de redéfinir la comparaison.
    /// Et qui implémente l'interface ICocktail afin d'avoir une façade immuable.
    /// </summary>
    class Cocktail : ICocktail, IEquatable<Cocktail>
    {
        /// <summary>
        /// Nom est le nom du cocktail, il est unique pour tous les cocktails.
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
        /// la façade immuable de la liste d'ingrédients.
        /// </summary>
        public ReadOnlyCollection<Ingredient> IngredientRead
        {
            private set
            {
                ingredients = value.ToList();
            }
            get
            {
                return ingredients.AsReadOnly();
            }
        }
        /// <summary>
        /// commentaires est la liste des commentaires laisser par un utilisateurs de type User.
        /// </summary>
        private Dictionary<User, Commentaire> commentaires = new Dictionary<User, Commentaire>();
        public ReadOnlyDictionary<User, Commentaire> CommentaireRead
        {
            get
            {
                return new ReadOnlyDictionary<User, Commentaire>(commentaires.ToDictionary(kvp => kvp.Key as User, kvp => kvp.Value as Commentaire));
            }
        }

        /// <summary>
        /// urlImage est le chemin de l'image dans le projet.
        /// </summary>
        public string urlImage { private set; get; }


        /// <summary>
        /// constructeur d'un cocktail.
        /// </summary>
        /// <param name="nom">prenant un nom</param>
        /// <param name="ingredients">et une liste d'ingrédients</param>
        public Cocktail(string nom, List<Ingredient> ingredients)
        {
            this.Nom = nom;
            this.Recette = "Pas de recette !";
            if (ingredients == null)
                this.ingredients.Add(new Ingredient("Pas d ingredient",0,Unite.unite));
            else
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

        /// <summary>
        /// Méthode pour ajouter un ingrédient au cocktail.
        /// </summary>
        /// <param name="ingredient">prent un ingrédient</param>
        public void ajouterIngredients(Ingredient ingredient)
        {
            if (ingredients == null)
            {
                ingredients = new List<Ingredient>();
            }
            ingredients.Add(ingredient);
        }

        /// <summary>
        /// Méthode pour supprimer un ingrédient au cocktail.
        /// </summary>
        /// <param name="ingredient"></param>
        public void supprimerIngredients(Ingredient ingredient)
        {
            if (ingredients.Contains(ingredient))
            {
                ingredients.Remove(ingredient);
            }
        }

        /// <summary>
        /// Redéfinition de la méthode GetHashCode.
        /// </summary>
        /// <returns>un entier : le code de hashage</returns>
        public override int GetHashCode()
        {
            return Nom.GetHashCode();
        }

        /// <summary>
        /// Redéfinition de la méthode Equals.
        /// </summary>
        /// <param name="obj">prenant un objet de type object</param>
        /// <returns>un booléen</returns>
        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(obj, null)) return false;
            if (object.ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return this.Equals(obj as Cocktail);
        }

        /// <summary>
        /// Création de la méthode Equals.
        /// </summary>
        /// <param name="com">prenant un objet de type Cocktail</param>
        /// <returns>un booléen</returns>
        public bool Equals(Cocktail cocktail)
        {
            return this.Nom.Equals(cocktail.Nom);
        }

        /// <summary>
        /// Redéfinition de la méthode ToString.
        /// </summary>
        /// <returns>rune chaîne de caractère</returns>
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
