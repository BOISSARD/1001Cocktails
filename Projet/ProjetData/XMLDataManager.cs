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
        XDocument cocktailFile;

        public XMLDataManager()
        {
            dirInfo = Directory.GetParent(Directory.GetCurrentDirectory());
            dirData = dirInfo.FullName + "\\ProjetData\\XML";
            userFile = new XDocument();
            cocktailFile = new XDocument();
        }

        public XMLDataManager(string url) : this()
        {
            Url = url;
            dirData = dirInfo.FullName + "\\ProjetData\\" + url;
        }

        public IEnumerable<ICocktail> loadCocktail()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IUser> loadUser()
        {
            throw new NotImplementedException();
        }

        public void saveCocktail(IEnumerable<ICocktail> list)
        {
            var cocktailElts = list.Select(cocktail => new XElement("cocktail",
                                        new XElement("nom", cocktail.Nom),
                                        new XElement("recette", cocktail.Recette),
                                        new XElement("ingredients", cocktail.IngredientIEnum.Select(ing => new XElement("ingredient",
                                                                                                new XElement("nom_ingredient", ing.Nom),
                                                                                                new XElement("quantite", ing.Quantite),
                                                                                                new XElement("unite", ing.Unite)))),
                                        new XElement("url", cocktail.urlImage)));

            cocktailFile.Add(new XElement("cocktails", cocktailElts));
            cocktailFile.Save(dirData + "cocktail.xml");
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
