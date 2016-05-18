using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLibrary
{
    class Ingredient : IIngredient
    {
        public string Nom { private set; get; }
        public int Quantite { private set; get;}
        public Unite Unite { private set; get; }

        public Ingredient(string nom, int quantite, Unite unite)
        {
            this.Nom = nom;
            this.Quantite = quantite;
            this.Unite = unite;
        }

        public override int GetHashCode()
        {
            return Nom.GetHashCode()*Quantite*Unite.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(obj, null)) return false;
            if (object.ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return this.Equals(obj as Ingredient);
        }

        public bool Equals(Ingredient ing)
        {
            return this.Nom.Equals(ing.Nom) && this.Quantite.Equals(ing.Quantite) && this.Unite.Equals(ing.Unite);
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Nom, Quantite.ToString(), Unite.ToString());
        }
    }
}
