﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLibrary
{
    /// <summary>
    /// La classe manager est le lien entre métier et le reste, ce qui est à l'extérieur du package ProjetLibrary.
    /// </summary>
    public class Manager
    {
        /// <summary>
        /// livre est une liste de cocktail.
        /// </summary>
        private List<Cocktail> livre = new List<Cocktail>();
        public IEnumerable<ICocktail> CocktailIEnum {
            private set
            {
                livre = (List<Cocktail>)value;
            }
            get
            {
                return livre;
            }
        }
        /// <summary>
        /// utilisateurs est la liste des utilisateurs inscrit.
        /// </summary>
        private List<User> utilisateurs = new List<User>();
        public ReadOnlyCollection<User> UserRead 
        {
            private set;
            get; 
        }

        /// <summary>
        /// dataManager est le DataManager afin de faire le lien avec le ProjetData.
        /// </summary>
        private IDataManager dataManager;

        /// <summary>
        /// Constructeur de Manager.
        /// </summary>
        /// <param name="dataManager">qui prend un DataManager</param>
        public Manager(IDataManager dataManager)
        {
            this.dataManager = dataManager;
            /// Créer un utilisateur par défault.
            utilisateurs.Add(new User("Admin", "admin@gmail.com", "admin63"));
            Dictionary<User, Commentaire> dic = new Dictionary<User, Commentaire>();
            dic.Add(utilisateurs.Single(),new Commentaire("Bon", 9));
            livre.Add(new Cocktail("Mojito", "Mélanger le rhum à la menthe", new List<Ingredient>() { new Ingredient("Rhum", 20, Unite.cl), new Ingredient("Menthes", 5, Unite.feuille) }, new Dictionary<User, Commentaire>(), "image"));
            //livre.Add(new Cocktail("Pina Colada", "Mélanger le rhum avec le lait de coco et le jus d'ananas", new List<Ingredient>() { new Ingredient("Rhum", 10, Unite.cl), new Ingredient("Lait de coco", 5, Unite.cl), new Ingredient("Jus d'ananas", 5, Unite.cl), new Ingredient("Jus de pêche", 5, Unite.cl), new Ingredient("Orange", 1, Unite.tranche), new Ingredient("Fraise", 3, Unite.morceau) }, "image"));
            UserRead = new ReadOnlyCollection<User>(utilisateurs);
        }

        /// <summary>
        /// currentUser de type User est l'utilisateur inscrit qui utilise l'application.
        /// </summary>
        public User CurrentUser
        {
            private set
            {
                currentUser = value as User;
            }
            get
            {
                return currentUser;
            }
        }
        private User currentUser;

        /// <summary>
        /// Propriété calculé qui retourne true si le currentUser différent de null.
        /// </summary>
        private bool Connected
        {
            get
            {
                return CurrentUser != null;
            }
        }

        /// <summary>
        /// Méthode connexion permettant un utilisateur d'être le currentUser.
        /// Pour ce connecter l'uitlisateur doit donner ces identifiants.
        /// </summary>
        /// <param name="pseudo">son pseudo</param>
        /// <param name="mdp">et son mot de passe</param>
        /// <returns></returns>
        public bool connexion(string pseudo, string mdp)
        {
            deconnexion();
            User util = new User(pseudo, mdp);
            if (utilisateurs.Contains(util))
            {
                foreach (User u in utilisateurs)
                    if (u.Pseudo == pseudo && u.Password == mdp)
                    {
                        CurrentUser = u;
                        break;
                    }
            }
            return Connected;
        }

        /// <summary>
        /// Méthode deconnexion qui déconnecte le currentUser.
        /// </summary>
        public void deconnexion()
        {
            if (Connected)
            {
                CurrentUser = null;
            }
        }

        /// <summary>
        /// Méthode ajouterUser qui permet d'ajouter un utilisateur à la liste d'utilisateurs
        /// Prend les paramètres : 
        /// </summary>
        /// <param name="pseudo">un pseudo</param>
        /// <param name="mail">une adresse mail</param>
        /// <param name="mdp">un pseudo</param>
        public void ajouterUser(string pseudo, string mail, string mdp)
        {
            if (CurrentUser != null)
            {
                utilisateurs.Add(new User(pseudo, mail, mdp));
            }
        }

        /// <summary>
        /// Méthode permettant de supprimer un utilisateur.
        /// </summary>
        /// <param name="pseudo">prend juste le pseudo de l'utilisateur</param>
        public void supprimerUser(string pseudo)
        {
            if (CurrentUser != null)
            {
                utilisateurs.RemoveAll(u => u.Pseudo == pseudo);
            }
        }

        /// <summary>
        /// Méthode ajouterCocktail qui permet d'ajouter un cocktail à la liste de cocktails livre.
        /// </summary>
        /// <param name="nom">prenant un nom</param>
        /// <param name="recette">une recette</param>
        /// <param name="ing">une liste d'ingrédients</param>
        /// <param name="image">le chemin de l'image désiré</param>
        public void ajouterCocktail(string nom, string recette, List<Ingredient> ing, string image)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            ing.ForEach(i => ingredients.Add(new Ingredient(i.Nom, i.Quantite, i.Unite)));
            Cocktail c = new Cocktail(nom, recette, ingredients, image);
            if (CurrentUser != null && !livre.Contains(c))
            {
                livre.Add(c);
            }
        }

        /// <summary>
        /// Méthode supprimerCocktail qui permet de supprimer un cocktail de livre.
        /// </summary>
        /// <param name="nom">Besoin uniquement du nom du cocktail</param>
        public void supprimerCocktail(string nom)
        {
            if (CurrentUser != null)
            {
                livre.RemoveAll(c => c.Nom == nom);
            }
        }

        /// <summary>
        /// Méthode permettant de sauvergarder les listes livre et utilisateurs.
        /// </summary>
        public void sauvegarder()
        {
            dataManager.saveUser(UserRead);
            dataManager.saveCocktail(livre);
        }

        /// <summary>
        /// Méthode permettant de charger les listes livre et utilisateurs.
        /// </summary>
        public void charger()
        {
            dataManager.loadUser().ForEach(u => this.ajouterUser(u.Pseudo, u.Mail, u.Password));
            //livre = dataManager.loadCocktail() as List<Cocktail>;
            //livre = new List<Cocktail>();
            foreach (Cocktail c in dataManager.loadCocktail())
            {
                livre.Add(c);
            }
        }

        /// <summary>
        /// Redéfinition de la méthode ToString.
        /// </summary>
        /// <returns>rune chaîne de caractère</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("");
            foreach (Cocktail c in livre)
            {
                sb.AppendFormat("{0}\n", c.ToString());
            }
            return sb.ToString();
        }
    }
}
