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
    /// <summary>
    /// La classe XMLDataManager implémente IDataManager.
    /// </summary>
    public class XMLDataManager : IDataManager
    {
        /// <summary>
        /// Nom du répertoire où sera enregistré les fichiers xml.
        /// </summary>
        public string Url { private set; get; }
        DirectoryInfo dirInfo;
        /// <summary>
        /// Chemin complet du répertoire où sera enregistré les fichiers xml.
        /// </summary>
        string dirData;
        /// <summary>
        /// Fichier xml d'enregistrement des utilisateurs.
        /// </summary>
        XDocument userFile;
        /// <summary>
        /// Fichier xml d'enregistrement des cocktails.
        /// </summary>
        XDocument cocktailFile;

        /// <summary>
        /// Constructeur de ce DataManager numéro 1.
        /// </summary>
        public XMLDataManager()
        {
            dirInfo = Directory.GetParent(Directory.GetCurrentDirectory());
            dirData = dirInfo.FullName;// + "\\ProjetData\\XML";
            userFile = new XDocument();
            cocktailFile = new XDocument();
        }

        /// <summary>
        /// Constructeur numéro 2.
        /// </summary>
        /// <param name="url">prend le nom du répertoire où sera enregistré les fichiers xml.</param>
        public XMLDataManager(string url) : this()
        {
            Url = url;
            dirData = dirInfo.FullName + "\\ProjetData\\" + url;
        }

        /// <summary>
        /// Méthode de chargement des cocktails
        /// </summary>
        /// <returns>en retournant une collection de cocktails</returns>
        public IEnumerable<ICocktail> loadCocktail()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Méthode de chargement des utilisateurs
        /// </summary>
        /// <returns>en retournant une collection d'utilisateurs</returns>
        public IEnumerable<IUser> loadUser()
        {
            //IEnumerable<IUser> liste = userFile.Descendants("user")
            //        .Select(u => new IUser()
            //        {
            //            Pseudo = u.Attribute("pseudo").Value,
            //            Mail = u.Attribute("mail").Value,
            //            Password = u.Attribute("password").Value
            //        });
            throw new NotImplementedException();
        }

        /// <summary>
        /// Méthode de sauvegarde des cocktails
        /// </summary>
        /// <param name="list">prend une collection de Cocktail en passant par la façade immuable ICocktail</param>
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

        /// <summary>
        /// Méthode de sauvegarde des utilisateurs
        /// </summary>
        /// <param name="list">prend une collection de User en passant par IUser</param>
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
