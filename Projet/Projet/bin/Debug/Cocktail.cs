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
        private string nom { set; get;}
        private string recette { set; get; }
        private List<Ingredient> ingredients;

        public Cocktail(string nom)
        {
            this.nom = nom;
        }

        public Cocktail(string nom, string recette)
        {
            this.nom = nom;
            this.recette = recette;
        }

        public Cocktail(string nom, List<Ingredient> ingredients)
        {
            this.nom = nom;
            this.ingredients = ingredients;
        }

        public Cocktail(string nom, string recette , List<Ingredient> ingredients)
        {
            this.nom = nom;
            this.recette = recette;
            this.ingredients = ingredients;
        }

        public override int GetHashCode()
        {
            return nom.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == this) return true;
            if (obj == null || obj.GetType() != this.GetType()) return false;
            Cocktail c = (Cocktail)obj;
            return this.nom.Equals(c.nom);
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

    }
}
