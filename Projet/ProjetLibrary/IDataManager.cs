using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ProjetLibrary;
using System.IO;

namespace ProjetLibrary
{
    /// <summary>
    /// Interface dont héritera les classes de DataManager.
    /// </summary>
    public interface IDataManager
    {
        /// <summary>
        /// Getter Url.
        /// </summary>
        string Url { get; }
        /// <summary>
        /// Méthode loadUser permettant de charger la liste d'utilisateurs.
        /// </summary>
        /// <returns>une collection de IUser</returns>
        List<User> loadUser();
        /// <summary>
        /// Méthode loadCocktail permettant de charger la liste livre.        
        /// </summary>
        /// <returns></returns>
        IEnumerable<ICocktail> loadCocktail();
        /// <summary>
        /// Méthode saveUSer permettant de sauvergarder la liste d'utilisateurs.
        /// </summary>
        /// <param name="list">prend une collection de IUser</param>
        void saveUser(ReadOnlyCollection<User> list);
        /// <summary>
        /// Méthode saveCocktail permettant de sauvergarder la liste de cocktails livre.
        /// </summary>
        /// <param name="list">prend une collection de ICocktail</param>
        void saveCocktail(IEnumerable<ICocktail> list);
    }
}
