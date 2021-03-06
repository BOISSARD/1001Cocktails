﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using ProjetLibrary;
using System;
using System.Text.RegularExpressions;

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
            Directory.SetCurrentDirectory(Regex.Split(Directory.GetCurrentDirectory(), @"(?<=Projet)")[0]);
            //dirInfo = Directory.GetParent(Directory.GetCurrentDirectory());
            //dirData = dirInfo.FullName + "\\ProjetData\\XML\\";
            dirData = Directory.GetCurrentDirectory() + "\\ProjetData\\XML\\";
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
        public IEnumerable<Cocktail> loadCocktail()
        {
            cocktailFile = XDocument.Load(dirData + "cocktails.xml");
            IEnumerable<Cocktail> liste = new List<Cocktail>();
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

            return liste;
        }

        /// <summary>
        /// Méthode de chargement des utilisateurs
        /// </summary>
        /// <returns>en retournant une collection d'utilisateurs</returns>
        public IEnumerable<User> loadUser()
        {
            userFile = XDocument.Load(dirData + "users.xml");
            IEnumerable<User> liste = new List<User>();
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
        public void saveCocktail(IEnumerable<Cocktail> list)
        {
            var cocktailElts = list.Select(cocktail => 
                                    new XElement("cocktail",
                                        new XElement("nom", cocktail.Nom),
                                        new XElement("recette", cocktail.Recette),
                                        new XElement("ingredients", cocktail.IngredientObs.Select(ing => 
                                                                                            new XElement("ingredient",
                                                                                                new XElement("nom", ing.Nom),
                                                                                                new XElement("quantite", ing.Quantite),
                                                                                                new XElement("unite", ing.Unite)))),
                                        new XElement("commentaires", cocktail.CommentaireObs.Select(com =>
                                                                                            new XElement("commentaire",
                                                                                                new XAttribute("pseudo", com.Key.Pseudo),
                                                                                                new XElement("titre", com.Value.Titre),
                                                                                                new XElement("texte", com.Value.Texte),
                                                                                                new XElement("note", com.Value.Note)))),
                                        new XElement("url", cocktail.UrlImage)));
            XDocument xdom = new XDocument(new XElement("cocktails", cocktailElts));
            xdom.Save(dirData + "cocktails.xml");
        }

        /// <summary>
        /// Méthode de sauvegarde des utilisateurs
        /// </summary>
        /// <param name="list">prend une collection de User en passant par IUser</param>
        public void saveUser(IEnumerable<User> list)
        {
            var userElts = list.Select(user => new XElement("user",
                                                            new XElement("pseudo", user.Pseudo),
                                                            new XElement("mail", user.Mail),
                                                            new XElement("password", user.Password)));
            XDocument xdom = new XDocument(new XElement("users", userElts));
            xdom.Save(dirData + "users.xml");
        }
    }
}
