using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLibrary
{
    public class Ingredient
    {
        public string nom { set; get; }
        public int quantite { set; get;}
        public Unite unite { set; get; }

        public Ingredient(string nom, int quantite, Unite unite)
        {
            this.nom = nom;
            this.quantite = quantite;
            this.unite = unite;
        }

        public override string ToString()
        {
            return nom + " : " + quantite.ToString() + " " + unite.ToString();
        }
    }
}
