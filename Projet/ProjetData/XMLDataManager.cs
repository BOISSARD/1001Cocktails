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
    public class XMLDataManager : IDataManager
    {
        public string url { private set; get; }
        DirectoryInfo dirInfo ;
        string dirData;
        XDocument userFile;

        public XMLDataManager()
        {
            dirInfo = Directory.GetParent(Directory.GetCurrentDirectory());
            dirData = dirInfo.FullName + "\\ProjetData\\XML";
            userFile = new XDocument();
        }

        public XMLDataManager(string url) : this()
        {
            dirData = dirInfo.FullName + "\\ProjetData\\" + url;
        }


        public void saveUser(IEnumerable<IUser> list)
        {
            throw new NotImplementedException();
        }

        public void saveCocktail(IEnumerable<ICocktail> list)
        {
            throw new NotImplementedException();
        }


        public List<IUser> loadUser()
        {
            throw new NotImplementedException();
        }

        public List<ICocktail> loadCocktail()
        {
            throw new NotImplementedException();
        }
    }
}
