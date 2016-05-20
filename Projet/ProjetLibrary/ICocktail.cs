using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ReadOnlyDictionary<IUser, ICommentaire> CommentaireIEnum { get; }
        string urlImage { get; }
    }
}
