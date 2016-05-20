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

        public List<ICocktail> loadCocktail()
        {
        }

        public List<IUser> loadUser()
        {
        }

        public void saveCocktail(List<Cocktail> list)
        {
        }

        public void saveUser(List<User> list)
        {
        }
    }
}
