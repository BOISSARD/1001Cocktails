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
            Manager manager = new Manager(new XMLDataManager());

            manager.ajouterUser("arthur", "miours.misanglier@hotmail.com", "logre");
            manager.ajouterUser("perceval", "provencal.legaulois@gmail.com", "cestpasfaux");
            manager.ajouterUser("kadok", "akadok@gmail.com", "elleestoulapoulette");

            IIngredient ing1 = manager.creerIngredient("vodka", 10, Unite.cl);
            IIngredient ing2 = manager.creerIngredient("jus d'orange", 20, Unite.cl);
            IIngredient ing3 = manager.creerIngredient("jus de pomme", 20, Unite.cl);
            List<IIngredient> liste1 = new List<IIngredient>();
            liste1.Add(ing1);
            liste1.Add(ing2);
            List<IIngredient> liste2 = new List<IIngredient>();
            liste2.Add(ing1);
            liste2.Add(ing3);

            manager.ajouterCocktail("vodka-Orange", "Mélangez la vodka et le jus d'orange", liste1, "http://image.org");
            manager.ajouterCocktail("vodka-Pomme", "Mélangez la vodka et le jus de pomme", liste2, "http://image.org");

            manager.sauvegarder();
        }
    }
} 