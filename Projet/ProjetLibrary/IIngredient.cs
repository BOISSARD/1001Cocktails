using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLibrary
{
    /// <summary>
    /// Interface pour la façade immuable du type Ingredient.
    /// </summary>
    public interface IIngredient
    {
        /// <summary>
        /// Getter Nom.
        /// </summary>
        string Nom { get; }
        /// <summary>
        /// Getter Quantite.
        /// </summary>
        int Quantite { get; }
        /// <summary>
        /// Getter Unite.
        /// </summary>
        Unite Unite { get; }
    }
}
