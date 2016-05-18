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
        public List</*...*/> loadUser();

        public List</*...*/> loadCocktail();

        public void saveUser(List<User> list);

        public void saveCocktail();
    
    }
}
