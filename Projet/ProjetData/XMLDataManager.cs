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
        /// <summary>
        /// Info de l'emplacement du répertoire
        /// </summary>
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
        public ObservableCollection<ICocktail> loadCocktail()
        {
            cocktailFile = XDocument.Load(dirData + "cocktails.xml");
            IEnumerable<ICocktail> liste = new List<ICocktail>();
            liste = cocktailFile.Descendants("cocktail").Select(cocktail => Fabrique.creerCocktail
            (
               cocktail.Element("nom").Value,
               cocktail.Element("recette").Value,
               cocktail.Element("ingredients").Descendants("ingredient").Select(ing => new Ingredient(ing.Element("nom").Value,
                                                                                                      Convert.ToInt32(ing.Element("quantite").Value),
                                                                                                      Fabrique.convertToUnite(ing.Element("unite").Value))).ToList(),
               cocktail.Element("commentaires").Descendants("commentaire").ToDictionary(item => new User(item.Attribute("pseudo").Value),
                                                                                        item => new Commentaire(item.Element("titre").Value,
                                                                                                                item.Element("texte").Value,
                                                                                                                Convert.ToInt16(item.Element("note").Value)                                                                                                                )
                                                                                       ),
               cocktail.Element("url").Value
            ));

            return new ObservableCollection<ICocktail>(liste);
        }

        /// <summary>
        /// Méthode de chargement des utilisateurs
        /// </summary>
        /// <returns>en retournant une collection d'utilisateurs</returns>
        public List<User> loadUser()
        {
            userFile = XDocument.Load(dirData + "users.xml");
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
        public void saveCocktail(ObservableCollection<ICocktail> list)
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
                                        new XElement("commentaires", cocktail.CommentaireRead.Select(com =>
                                                                                            new XElement("commentaire",
                                                                                                new XAttribute("pseudo", com.Key.Pseudo),
                                                                                                new XElement("titre", com.Value.Titre),
                                                                                                new XElement("texte", com.Value.Texte),
                                                                                                new XElement("note", com.Value.Note)))),
                                        new XElement("url", cocktail.UrlImage)));
            cocktailFile.Add(new XElement("cocktails", cocktailElts));
            cocktailFile.Save(dirData + "cocktails.xml");
        }

        /// <summary>
        /// Méthode de sauvegarde des utilisateurs
        /// </summary>
        /// <param name="list">prend une collection de User en passant par IUser</param>
        public void saveUser(ReadOnlyCollection<User> list)
        {
            var userElts = list.Select(user => new XElement("user",
                                                            new XElement("pseudo", user.Pseudo),
                                                            new XElement("mail", user.Mail),
                                                            new XElement("password", user.Password)));
            userFile.Add(new XElement("users", userElts));
            userFile.Save(dirData + "users.xml");
        }
    }
}
