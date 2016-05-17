using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLibrary
{
    public interface IDataManager
    {
        public IEnumerable<IUser> loadUsers();
    }
}
