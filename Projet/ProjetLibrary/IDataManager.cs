using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetLibrary;

namespace ProjetLibrary
{
    public interface IDataManager
    {
        string Url { get; }

        IEnumerable<IUser> loadUser();

        IEnumerable<ICocktail> loadCocktail();

        void saveUser(IEnumerable<IUser> list);

        void saveCocktail(IEnumerable<ICocktail> list);
    }
}
