using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLibrary
{
    /// <summary>
    /// Interface pour la façade immuable du type Commentaire.
    /// </summary>
    public interface ICommentaire
    {
        /// <summary>
        /// Getter Titre.
        /// </summary>
        string Titre { get; }
        /// <summary>
        /// Getter Texte.
        /// </summary>
        string Texte { get; }
        /// <summary>
        /// Getter Note.
        /// </summary>
        short Note { get; }
    }
}
