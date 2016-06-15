using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetLibrary;
using ProjetData;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ProjetTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager m = new Manager(new XMLDataManager());

            //test6(m);

            test1(m);

            //test2(m);

            //test3(m);

            //test4(m);

            //test5(m);

            Console.ReadLine();
        }

        public static void test1(Manager m)
        {
            m.chargerUsers();
            m.connexion("Admin", "admin63");
            Console.WriteLine("Utilisateur actuel :");

            if (!m.Connected)
                Console.Write("\tNull !");
            else
                Console.WriteLine(m.CurrentUser);
            
            Console.WriteLine();
            Console.WriteLine("Utilisateurs lu :");
            foreach (User user in m.UserRead)
            {
                Console.WriteLine(user);
            }
        }

        public static void test2(Manager m)
        {
            m.ajouterUser("Ben", "dragon@gmail.com", "blabla");
            m.ajouterUser("Clem", "cleboi", "rez");
            m.ajouterUser("Jacky", "jack", "jj");

            Console.WriteLine();
            Console.WriteLine("Utilisateurs après ajout :");
            foreach (User user in m.UserRead)
            {
                Console.WriteLine(user);
            }
        }

        public static void test3(Manager m)
        {
            m.chargerCocktails();
            Console.WriteLine();
            Console.WriteLine("Cocktails lu  :");
            foreach (Cocktail c in m.Livre)
            {
                Console.WriteLine(" + " + c.ToString());
            }
        }

        public static void test4(Manager m)
        {
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
            dic.Add(m.recupUser("Clem"), new Commentaire("Bon", "C'est très bon !", 9));
            Dictionary<User, Commentaire> dic1 = new Dictionary<User, Commentaire>();
            dic1.Add(m.recupUser("Jacky"), new Commentaire("Potable", 3));
            m.ajouterCocktail("Mojito", "Mélanger le rhum à la menthe", new List<Ingredient>() { new Ingredient("Rhum", 20, Unite.cl), new Ingredient("Menthes", 5, Unite.feuille) }, dic, "http://www.esprits-feminins.fr/wp-content/uploads/2012/07/mojito_gesneden_600x600.jpg");
            m.ajouterCocktail("Pina Colada", "Mélanger le rhum avec le lait de coco et le jus d'ananas", new List<Ingredient>() { new Ingredient("Rhum", 10, Unite.cl), new Ingredient("Lait de coco", 5, Unite.cl), new Ingredient("Jus d'ananas", 5, Unite.cl), new Ingredient("Jus de pêche", 5, Unite.cl), new Ingredient("Orange", 1, Unite.tranche), new Ingredient("Fraise", 3, Unite.morceau) }, "http://az659704.vo.msecnd.net/v1/image/c_lpad,w_1500,h_1500/v1400603728/cocktail_bora_bora-1.png");
            m.ajouterCocktail("Vodka-Orange", "Mélangez la vodka et le jus d'orange", liste1, dic1, "http://image.org");
            m.ajouterCocktail("Vodka-Pomme", "Mélangez la vodka et le jus de pomme", liste2, "http://image.org");
            m.ajouterCocktail("Vodka-RedBull", "Mélanger la vodka et le redbull", liste3, "http://image.org");

            Console.WriteLine("Cocktails après ajout  :");
            foreach (ICocktail c in m.Livre)
            {
                Console.WriteLine(" + " + c.ToString());
            }
        }

        public static void test5(Manager m)
        {
            Console.WriteLine(m.sauvegardError());
        }

        public static void test6(Manager m)
        {
            Console.WriteLine("Current directory : {0}", Directory.GetCurrentDirectory());
            string path = Directory.GetCurrentDirectory();
            var tab = Regex.Split(path, @"(?<=Projet)");
            Console.WriteLine("Chemin            : {0}", tab);
            string chemin = tab[0];
            Console.WriteLine("Chemin en string  : {0}", chemin);
            Directory.SetCurrentDirectory(chemin);
            Console.WriteLine("Current directory : {0}", Directory.GetCurrentDirectory());
        }
    }
}