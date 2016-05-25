﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLibrary
{
    /// <summary>
    /// La classe Ingredient qui implémente l'interface IEquatable afin de redéfinir la comparaison.
    /// Et qui implémente l'interface IIngredient afin d'avoir une façade immuable.
    /// </summary>
    public class Ingredient : IEquatable<Ingredient>
    {
        /// <summary>
        /// Nom est le nom de l'ingrédient .
        /// </summary>
        public string Nom { private set; get; }
        /// <summary>
        /// Quantite est la valeur de quantite.
        /// </summary>
        public int Quantite { private set; get;}
        /// <summary>
        /// Unite qui vient d'une énumération.
        /// </summary>
        public Unite Unite { private set; get; }

        /// <summary>
        /// Constructeur de l'ingrédient.
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="quantite"></param>
        /// <param name="unite"></param>
        public Ingredient(string nom, int quantite, Unite unite)
        {
            this.Nom = nom;
            this.Quantite = quantite;
            this.Unite = unite;
        }

        /// <summary>
        /// Redéfinition de la méthode GetHashCode.
        /// </summary>
        /// <returns>un entier : le code de hashage</returns>
        public override int GetHashCode()
        {
            return Nom.GetHashCode()*Quantite*Unite.GetHashCode();
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
            return this.Equals(obj as Ingredient);
        }

        /// <summary>
        /// Création de la méthode Equals.
        /// </summary>
        /// <param name="com">prenant un objet de type Ingrédient</param>
        /// <returns>un booléen</returns>
        public bool Equals(Ingredient ing)
        {
            return this.Nom.Equals(ing.Nom) && this.Quantite.Equals(ing.Quantite) && this.Unite.Equals(ing.Unite);
        }

        /// <summary>
        /// Redéfinition de la méthode ToString.
        /// </summary>
        /// <returns>rune chaîne de caractère</returns>
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Nom, Quantite.ToString(), Unite.ToString());
        }
    }
}
