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
            m.connexion("Admin", "admin63");
            Console.WriteLine(m.CurrentUser);
            if(m.CurrentUser == null)
            {
                Console.Write("\tNull !");
            }

            m.ajouterUser("Ben", "dragon@gmail.com", "blabla");
            m.ajouterUser("Clem", "cleboi", "rez");
            m.ajouterUser("zfzef", "clebzefzefoi", "zefzefzef");
            m.ajouterUser("arthur", "miours.misanglier@hotmail.com", "logre");
            m.ajouterUser("perceval", "provencal.legaulois@gmail.com", "cestpasfaux");
            m.ajouterUser("kadok", "akadok@gmail.com", "elleestoulapoulette");

            foreach (IUser user in m.UserIEnum)
            {
                Console.WriteLine(user);
            }

            Console.WriteLine();

            IIngredient ing1 = m.creerIngredient("Vodka", 10, Unite.cl);
            IIngredient ing2 = m.creerIngredient("jus d'orange", 20, Unite.cl);
            IIngredient ing3 = m.creerIngredient("jus de pomme", 20, Unite.cl);
            List<IIngredient> liste1 = new List<IIngredient>();
            liste1.Add(ing1);
            liste1.Add(ing2);
            List<IIngredient> liste2 = new List<IIngredient>();
            liste2.Add(ing1);
            liste2.Add(ing3);

            m.ajouterCocktail("Vodka-Orange", "Mélangez la vodka et le jus d'orange", liste1, "http://image.org");
            m.ajouterCocktail("Vodka-Pomme", "Mélangez la vodka et le jus de pomme", liste2, "http://image.org");

            foreach (ICocktail c in m.CocktailIEnum)
            {
                Console.WriteLine(" + " + c.ToString());
            }

            Console.ReadLine();
        }
    }
} 