using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using ProjetLibrary;

namespace ProjetData
{
    public class DataManager : IDataManager
    {
        public void DataManager()
        {

        }

        public void SaveUser(List<IUser> list)
        {
            DirectoryInfo dirInfo = Directory.GetParent(Directory.GetCurrentDirectory());
            string dirData = dirInfo.FullName + "\\ProjetData\\XML\\";
            XDocument usersFile = new XDocument();

            usersFile.Save(dirData + "Users.xml");
        }
    }
}
