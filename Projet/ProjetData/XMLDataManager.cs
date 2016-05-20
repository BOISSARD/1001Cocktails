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
        public string Url { private set; get; }
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
            Url = url;
            dirData = dirInfo.FullName + "\\ProjetData\\" + url;
        }

        public IEnumerable<ICocktail> loadCocktail()
        {
        }

        public IEnumerable<IUser> loadUser()
        {
        }

        public void saveCocktail(IEnumerable<ICocktail> list)
        {
        }

        public void saveUser(IEnumerable<IUser> list)
        {
            var userElts = list.Select(user => new XElement("user",
                                                            new XElement("peudo",user.Pseudo),
                                                            new XElement("mail", user.Mail),
                                                            new XElement("password",user.Password)));
            userFile.Add(new XElement("users",userElts));
            userFile.Save(dirData + "user.xml");
        }
    }
}
