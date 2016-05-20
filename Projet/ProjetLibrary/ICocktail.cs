using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLibrary
{
    public interface ICocktail
    {
        string Nom { get; }
        string Recette { get; }
        IEnumerable<IIngredient> IngredientIEnum { get; }

        string urlImage { get; }
    }
}
