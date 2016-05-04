using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetLibrary;

namespace ProjetTest
{
    class Program
    {
        static void Main(string[] args)
        {
            LivreCocktails livre = new LivreCocktails();

            List<Ingredient> ing = new List<Ingredient>();
            ing.Add(new Ingredient("Coca",50,Unite.cl));
            ing.Add(new Ingredient("Whisky",10,Unite.cl));
            ing.Add(new Ingredient("Sucre",2,Unite.cuillere));
            livre.ajouterCocktail(new Cocktail("blalbla", ing));

            Ingredient i1 = new Ingredient("Vodka", 60, Unite.cl);

            List<Ingredient> ingredients = new List<Ingredient>();
            //Console.WriteLine(i1.ToString());
            ingredients.Add(i1);
            ingredients.Add(new Ingredient("Orange", 1, Unite.zeste));

            Cocktail c1 = new Cocktail("Vodkorange", ingredients);
            livre.ajouterCocktail(c1);

            Console.WriteLine(livre.ToString());
            Console.ReadLine();
        }
    } 
}
