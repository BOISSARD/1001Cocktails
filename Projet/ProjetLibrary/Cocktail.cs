 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetLibrary;

namespace ProjetLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class Cocktail : IEquatable<Cocktail>
    {
        /// <summary>
        /// 
        /// </summary>
        public string Nom { private set; get;}
        public string Recette { private set; get; }
        private List<Ingredient> ingredients = new List<Ingredient>();
        private List<Commentaire> commentaires = new List<Commentaire>();
        public string urlImage { private set; get; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Ingredient> ingredientIEnumerable
        {
            get
            {
                return ingredients;
            }
        }

        public IEnumerable<Commentaire> commentairesIEnumerable
        {
            get
            {
                return commentaires;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="ingredients"></param>
        public Cocktail(string nom, List<Ingredient> ingredients)
        {
            this.Nom = nom;
            this.Recette = "Pas de recette !";
            ingredients.ForEach(i => this.ingredients.Add(new Ingredient(i.Nom, i.Quantite, i.Unite)));
        }

        public Cocktail(string nom, string recette, List<Ingredient> ingredients) : this(nom, ingredients)
        {
            this.Recette = recette;
        }

        public Cocktail(string nom, string recette, List<Ingredient> ingredients, string url) : this(nom, recette, ingredients)
        {
            this.urlImage = url;
        }

        public Cocktail(string nom, string recette , List<Ingredient> ingredients, List<Commentaire> commentaires, string url) : this(nom, recette, ingredients, url)
        {
            commentaires.ForEach(i => this.commentaires.Add(new Commentaire(i.Titre, i.Texte, i.Utilisateur,i.Note)));
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
            foreach (Commentaire comm in commentaires)
            {
                sb.AppendFormat("{0}\n", comm.ToString());
            }
            return sb.ToString();
        }
    }
}
