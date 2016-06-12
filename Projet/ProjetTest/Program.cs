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

            m.chargerUsers();
            m.connexion("Admin", "admin63");
            m.chargerCocktails();

            Console.WriteLine();
            Console.WriteLine("Utilisateur actuel :");
            Console.WriteLine(m.CurrentUser);
            if(m.CurrentUser == null)
            {
                Console.Write("\tNull !");
            }

            //m.ajouterUser("Ben", "dragon@gmail.com", "blabla");
            //m.ajouterUser("Clem", "cleboi", "rez");
            //m.ajouterUser("Jacky", "jack", "jj");

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

            Dictionary<User, Commentaire> dic = new Dictionary<User, Commentaire>();
            dic.Add(m.recupUser("Clem"), new Commentaire("Bon","C'est très bon !",9));
            Dictionary < User, Commentaire > dic1 = new Dictionary<User, Commentaire>();
            dic1.Add(m.recupUser("Jacky"), new Commentaire("Potable", 3));
            //m.ajouterCocktail("Mojito", "Mélanger le rhum à la menthe", new List<Ingredient>() { new Ingredient("Rhum", 20, Unite.cl), new Ingredient("Menthes", 5, Unite.feuille) }, dic, "http://www.esprits-feminins.fr/wp-content/uploads/2012/07/mojito_gesneden_600x600.jpg");
            //m.ajouterCocktail("Pina Colada", "Mélanger le rhum avec le lait de coco et le jus d'ananas", new List<Ingredient>() { new Ingredient("Rhum", 10, Unite.cl), new Ingredient("Lait de coco", 5, Unite.cl), new Ingredient("Jus d'ananas", 5, Unite.cl), new Ingredient("Jus de pêche", 5, Unite.cl), new Ingredient("Orange", 1, Unite.tranche), new Ingredient("Fraise", 3, Unite.morceau) }, "http://az659704.vo.msecnd.net/v1/image/c_lpad,w_1500,h_1500/v1400603728/cocktail_bora_bora-1.png");
            //m.ajouterCocktail("Vodka-Orange", "Mélangez la vodka et le jus d'orange", liste1, dic1, "http://image.org");
            //m.ajouterCocktail("Vodka-Pomme", "Mélangez la vodka et le jus de pomme", liste2, "http://image.org"); 
            //m.ajouterCocktail("Vodka-RedBull", "Mélanger la vodka et le redbull", liste3, "http://image.org");

            Console.WriteLine("Cocktails lu  :");
            foreach (ICocktail c in m.Livre)
            {
                Console.WriteLine(" + " + c.ToString());
            }

            //m.sauvegarder();

            Console.ReadLine();
        }
    }
} 