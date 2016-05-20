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
        //static void Main(string[] args)
        //{
        //    //    // Création du livre
        //    //    Manager manager = new Manager();
        //    //    IngredientIEnum i1 = new IngredientIEnum("Vodka", 60, Unite.cl);
        //    //    //Console.WriteLine(i1.ToString());

        //    //    // Création d'une première liste d'ingrédients
        //    //    List<IngredientIEnum> ingredients = new List<IngredientIEnum>();
        //    //    ingredients.Add(i1);
        //    //    ingredients.Add(new IngredientIEnum("Orange", 1, Unite.zeste));
        //    //    // Création d'un premier cocktail avec la première liste
        //    //    Cocktail c1 = new Cocktail("Vodkorange", ingredients);
        //    //    // Ajout du cocktail dans le livre
        //    //    livre.ajouterCocktail(c1);

        //    //    // Création d'une deuxième liste d'ingrédients
        //    //    List<IngredientIEnum> ing = new List<IngredientIEnum>();
        //    //    ing.Add(new IngredientIEnum("Coca", 50, Unite.cl));
        //    //    ing.Add(new IngredientIEnum("Whisky", 10, Unite.cl));
        //    //    ing.Add(new IngredientIEnum("Sucre", 2, Unite.cuillere));
        //    //    // Ajout du deuxième cocktail contenant la deuxième liste dans le livre
        //    //    livre.ajouterCocktail(new Cocktail("blalbla", ing));

        //    //    ingredients.Clear();
        //    //    // Affichage du livre
        //    //    Console.WriteLine(livre.ToString());
        //    //    Console.ReadLine();


<<<<<<< HEAD
        //    Manager manager = new Manager(new XMLDataManager());
        //    manager.sauvegarder();
        //}
=======
            Manager manager = new Manager(new XMLDataManager());
            List<IIngredient> ing = new List<IIngredient>();

            manager.sauvegarder();

            Console.ReadLine();
        }
>>>>>>> 56526eba7afa16ecaa3dc946479fdc61675c8382
    } 
}
