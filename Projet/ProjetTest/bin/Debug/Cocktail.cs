using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetLibrary;

namespace ProjetLibrary
{
    public class Cocktail
    {
        public string nom { set; get;}
        public string recette { set; get; }
        public List<Ingredient> ingredients;
        public List<Commentaire> commentaires;

        public Cocktail(string nom, List<Ingredient> ingredients)
        {
            this.nom = nom;
            this.recette = "Pas de recette !";
            this.ingredients = ingredients;
            this.commentaires = new List<Commentaire>();
        }

        public Cocktail(string nom, string recette, List<Ingredient> ingredients)
        {
            this.nom = nom;
            this.recette = recette;
            this.ingredients = ingredients;
            this.commentaires = new List<Commentaire>();
        }

        public Cocktail(string nom, string recette , List<Ingredient> ingredients, List<Commentaire> commentaires)
        {
            this.nom = nom;
            this.recette = recette;
            this.ingredients = ingredients;
            this.commentaires = commentaires;
        }

        public void ajouterIngredients(Ingredient ingredient)
        {
            if (ingredients.Count == 0)
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
            return nom.GetHashCode();
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
            return this.nom.Equals(cocktail.nom);
        }

        public override string ToString()
        {
            string description;
            description = nom +"\n";
            foreach (Ingredient ing in ingredients)
            {
                description += ing.ToString() + "\n";
            }
            description += recette + "\n";
            foreach (Commentaire ing in commentaires)
            {
                description += ing.ToString() + "\n";
            }
            return description;
        }
    }
}
