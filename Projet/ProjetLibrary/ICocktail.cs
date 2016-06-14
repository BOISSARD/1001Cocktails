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
    /// Qui n'est finalement pas utile car nous avons besoins d'avoir la possibilité de modifier les cocktails.
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
        ReadOnlyCollection<Ingredient>IngredientRead { get; }
        /// <summary>
        /// Getter du dictionnaire de commentaires.
        /// </summary>
        ReadOnlyDictionary<User, Commentaire> CommentaireRead { get; }
        /// <summary>
        /// Getter urlImage.
        /// </summary>
        string UrlImage { get; }

        void laisserCommentaire(User u, Commentaire c);

        Commentaire returnComment(User u);

        void supprimerCommentaire(User u);
    }
}
