using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLibrary
{
    /// <summary>
    /// Interface pour la façade immuable du type Cocktail.
    /// </summary>
    public interface ICocktail
    {
        /// <summary>
        /// Getter Nom.
        /// </summary>
        string Nom { get; }
        /// <summary>
        /// Getter Recette.
        /// </summary>
        string Recette { get; }
        /// <summary>
        /// Getter de la liste d'ingrédient.
        /// </summary>
        IEnumerable<IIngredient> IngredientIEnum { get; }
        /// <summary>
        /// Getter du dictionnaire de commentaires.
        /// </summary>
        ReadOnlyDictionary<IUser, ICommentaire> CommentaireIEnum { get; }
        /// <summary>
        /// Getter urlImage.
        /// </summary>
        string urlImage { get; }
    }
}
