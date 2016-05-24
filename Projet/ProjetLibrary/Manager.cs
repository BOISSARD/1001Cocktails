using System;
using System.Collections.Generic;
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
        public IEnumerable<ICocktail> CocktailIEnum { get { return livre; } }
        /// <summary>
        /// utilisateurs est la liste des utilisateurs inscrit.
        /// </summary>
        private List<User> utilisateurs = new List<User>();
        public IEnumerable<IUser> UserIEnum { get { return utilisateurs; } }
        /// <summary>
        /// dataManager est le DataManager afin de faire le lien avec le ProjetData.
        /// </summary>
        private IDataManager dataManager;
        /// <summary>
        /// currentUser de type User est l'utilisateur inscrit qui utilise l'application.
        /// </summary>
        public IUser CurrentUser
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
        /// Constructeur de Manager.
        /// </summary>
        /// <param name="dataManager">qui prend un DataManager</param>
        public Manager(IDataManager dataManager)
        {
            this.dataManager = dataManager;
            /// Créer un utilisateur par défault.
            utilisateurs.Add(new User("Admin", "admin@gmail.com", "admin63"));
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
        /// Méthode permettant de créer un ingrédient.
        /// Utile pour la création de cocktails.
        /// </summary>
        /// <param name="nom">prend un nom</param>
        /// <param name="quantite">prend une quantité</param>
        /// <param name="unite">prend une unité</param>
        /// <returns>un ingrédient de type IIngredient</returns>
        public IIngredient creerIngredient(string nom, int quantite, Unite unite)
        {
            return new Ingredient(nom, quantite, unite);
        }

        /// <summary>
        /// Méthode ajouterCocktail qui permet d'ajouter un cocktail à la liste de cocktails livre.
        /// </summary>
        /// <param name="nom">prenant un nom</param>
        /// <param name="recette">une recette</param>
        /// <param name="ing">une liste d'ingrédients</param>
        /// <param name="image">le chemin de l'image désiré</param>
        public void ajouterCocktail(string nom, string recette, List<IIngredient> ing, string image)
        {
            if (CurrentUser != null)
            {
                List<Ingredient> ingredients = new List<Ingredient>();
                ing.ForEach(i => ingredients.Add(new Ingredient(i.Nom, i.Quantite, i.Unite)));
                livre.Add(new Cocktail(nom, recette, ingredients, image));
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
            dataManager.saveUser(utilisateurs);
            dataManager.saveCocktail(livre);
        }

        /// <summary>
        /// Méthode permettant de charger les listes livre et utilisateurs.
        /// </summary>
        public void charger()
        {

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
