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

        public Manager(IDataManager dataManager) 
        {
            this.dataManager = dataManager;
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
            utilisateurs.Add(new User(pseudo,mail,mdp));
        }

        public void ajouterCocktail(string nom, string recette, List<IIngredient> ing, string image)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            ing.ForEach(i => ingredients.Add(new Ingredient(i.Nom,i.Quantite,i.Unite)));
            livre.Add(new Cocktail(nom,recette,ingredients,image));
        }

        public void sauvegarder()
        {
            dataManager.saveUser(utilisateurs);
        }
    }
}
