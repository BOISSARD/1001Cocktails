using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetLibrary;
using ProjetData;

namespace ProjetTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager m = new Manager(new XMLDataManager());

            //m.charger();
            m.connexion("Admin", "admin63");

            Console.WriteLine();
            Console.WriteLine("Utilisateur actuel :");
            Console.WriteLine(m.CurrentUser);
            if(m.CurrentUser == null)
            {
                Console.Write("\tNull !");
            }

            m.ajouterUser("Ben", "dragon@gmail.com", "blabla");
            m.ajouterUser("Clem", "cleboi", "rez");
            m.ajouterUser("Jacky", "jack", "jj");

            Console.WriteLine();
            Console.WriteLine("Utilisateurs lu :");
            foreach (User user in m.UserRead)
            {
                Console.WriteLine(user);
            }

            Console.WriteLine();

            Ingredient ing1 = new Ingredient("Vodka", 10, Unite.cl);
            Ingredient ing2 = new Ingredient("jus d'orange", 20, Unite.cl);
            Ingredient ing3 = new Ingredient("jus de pomme", 20, Unite.cl);
            Ingredient ing4 = new Ingredient("Red Bull", 10, Unite.cl);
            List<Ingredient> liste1 = new List<Ingredient>();
            liste1.Add(ing1);
            liste1.Add(ing2);
            List<Ingredient> liste2 = new List<Ingredient>();
            liste2.Add(ing1);
            liste2.Add(ing3);
            List<Ingredient> liste3 = new List<Ingredient>();
            liste3.Add(ing1);
            liste3.Add(ing4);

            Dictionary<User, Commentaire> dic1 = new Dictionary<User, Commentaire>();
            dic1.Add(m.recupUser("Clem"), new Commentaire("Bon",9));

            m.ajouterCocktail("Vodka-Orange", "Mélangez la vodka et le jus d'orange", liste1, dic1, "http://image.org");
            m.ajouterCocktail("Vodka-Pomme", "Mélangez la vodka et le jus de pomme", liste2, "http://image.org");
            m.ajouterCocktail("Vodka-RedBull", "Mélanger la vodka et le redbull", liste3, "http://image.org");

            Console.WriteLine("Cocktails lu  :");
            foreach (ICocktail c in m.CocktailIEnum)
            {
                Console.WriteLine(" + " + c.ToString());
            }

            m.sauvegarder();

            Console.ReadLine();
        }
    }
} 