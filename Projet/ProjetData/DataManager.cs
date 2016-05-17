using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetLibrary;

namespace ProjetData
{
    class DataManager : IDataManager
    {
        List<User> IDataManager.getUser()
        {
            List<User> Users = new List<User>();

            return Users;
        }

        //sefsefsefsefe IDataManager.getLivreCocktails()
        //{
        //    sefsefsefsefe livre = new sefsefsefsefe();

        //    return livre;
        //}
    }
}
