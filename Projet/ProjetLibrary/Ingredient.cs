using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLibrary
{
    public class Ingredient
    {
        private string nom { set; get; }
        private int quantite { set; get;}
        private Unite unite { set; get; }

        public Ingredient(string nom, int quantite, Unite unite)
        {
            this.nom = nom;
            this.quantite = quantite;
            this.unite = unite;
        }
    }
}
