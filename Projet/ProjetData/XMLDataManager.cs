using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using ProjetLibrary;
using System;

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
            dirData = dirInfo.FullName + "\\ProjetData\\XML\\";
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
            IEnumerable<ICocktail> liste = new List<ICocktail>();
            liste = cocktailFile.Descendants("cocktail").Select(cocktail => FabriqueCocktail.creerCocktail
            (
               cocktail.Element("nom").Value,
               cocktail.Element("recette").Value,
               cocktail.Element("ingredients").Descendants("ingredient").Select(ing => new Ingredient(ing.Element("nom_ingredient").Value,
                                                                                                      Convert.ToInt32(ing.Element("quantite").Value),
                                                                                                      recupUnite(ing.Element("unite").Value))) as List<Ingredient>,
               cocktail.Element("url").Value
            ));

            return liste;
        }


        public Unite recupUnite(string unite)
        {
            switch (unite)
            {
                case "baton":
                    return Unite.baton;
                case "cl":
                    return Unite.cl;
                case "cuillere":
                    return Unite.cuillere;
                case "feuille":
                    return Unite.feuille;
                case "g":
                    return Unite.g;
                case "goutte":
                    return Unite.goutte;
                case "l":
                    return Unite.l;
                case "morceau":
                    return Unite.morceau;
                case "sachet":
                    return Unite.sachet;
                case "tranche":
                    return Unite.tranche;
                case "trait":
                    return Unite.trait;
                case "zeste":
                    return Unite.zeste;
                default :
                    return Unite.unite;
            }
        }

        /// <summary>
        /// Méthode de chargement des utilisateurs
        /// </summary>
        /// <returns>en retournant une collection d'utilisateurs</returns>
        public List<User> loadUser()
        {
            List<User> liste = new List<User>();
            liste = userFile.Descendants("user").Select(user => new User(
                user.Element("pseudo").Value,
                user.Element("mail").Value,
                user.Element("password").Value
            )).ToList();
            return liste;
        }

        /// <summary>
        /// Méthode de sauvegarde des cocktails
        /// </summary>
        /// <param name="list">prend une collection de Cocktail en passant par la façade immuable ICocktail</param>
        public void saveCocktail(IEnumerable<ICocktail> list)
        {
            var cocktailElts = list.Select(cocktail => 
                                    new XElement("cocktail",
                                        new XElement("nom", cocktail.Nom),
                                        new XElement("recette", cocktail.Recette),
                                        new XElement("ingredients", cocktail.IngredientRead.Select(ing => 
                                                                                            new XElement("ingredient",
                                                                                                new XElement("nom", ing.Nom),
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
        public void saveUser(ReadOnlyCollection<User> list)
        {
            var userElts = list.Select(user => new XElement("user",
                                                            new XElement("peudo", user.Pseudo),
                                                            new XElement("mail", user.Mail),
                                                            new XElement("password", user.Password)));
            userFile.Add(new XElement("users", userElts));
            userFile.Save(dirData + "user.xml");
        }
    }
}
