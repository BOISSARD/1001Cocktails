using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLibrary
{
    public class Ingredient
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

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Nom, Quantite.ToString(), Unite.ToString());
        }
    }
}
