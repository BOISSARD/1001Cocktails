using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLibrary
{
    public class Manager
    {
        private List<Cocktail> livre = new List<Cocktail>();
        public IEnumerable<ICocktail> CocktailIEnum { get { return livre; } }
        private List<User> utilisateurs = new List<User>();
        public IEnumerable<IUser> UserIEnum { get { return utilisateurs; } }
        private IDataManager dataManager;
        private User currentUser;
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
        private bool connected;

        public Manager(IDataManager dataManager)
        {
            this.dataManager = dataManager;
            connected = false;
            utilisateurs.Add(new User("Admin", "admin@gmail.com", "admin63"));
        }

        public bool connexion(string pseudo, string mdp)
        {
            //User util = (User)utilisateurs.Where(u => u.Pseudo == pseudo && u.Password == mdp);
            User util = new User(pseudo, mdp);
            if (utilisateurs.Contains(util))
            {
                CurrentUser = util;
                connected = true;
            }
            return connected;
        }

        public void deconnexion()
        {
            if (connected)
            {
                CurrentUser = null;
                connected = false;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("");
            foreach (Cocktail c in livre)
            {
                sb.AppendFormat("{0}\n", c.ToString());
            }
            return sb.ToString();
        }

        public void ajouterUser(string pseudo, string mail, string mdp)
        {
            if (CurrentUser != null)
            {
                utilisateurs.Add(new User(pseudo, mail, mdp));
            }
        }

        public void supprimerUser(string pseudo)
        {
            if (CurrentUser != null)
            {
                utilisateurs.RemoveAll(u => u.Pseudo == pseudo);
            }
        }

        public IIngredient creerIngredient(string nom, int quantite, Unite unite)
        {
            return new Ingredient(nom, quantite, unite);
        }

        public void ajouterCocktail(string nom, string recette, List<IIngredient> ing, string image)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            ing.ForEach(i => ingredients.Add(new Ingredient(i.Nom, i.Quantite, i.Unite)));
            livre.Add(new Cocktail(nom, recette, ingredients, image));
        }

        public void sauvegarder()
        {
            dataManager.saveUser(utilisateurs);
            dataManager.saveCocktail(livre);
        }
    }
}
