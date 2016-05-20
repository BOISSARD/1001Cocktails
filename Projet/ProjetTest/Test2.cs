using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetLibrary;
using ProjetData;

namespace ProjetTest
{
    class Test2
    {
        static void Main(string[] args)
        {
            Manager m = new Manager(new XMLDataManager());
            m.ajouterUser("Ben", "dragon@gmail.com", "blabla");
            m.ajouterUser("Clem", "cleboi", "rez");
            m.ajouterUser("zfzef", "clebzefzefoi", "zefzefzef");
            foreach (IUser user in m.UserIEnum)
            {
                Console.WriteLine(user);
            }

            m.connexion("Admin", "admin63");
            Console.WriteLine(m.CurrentUser);
            m.ajouterUser("Ben", "dragon@gmail.com", "blabla");
            m.ajouterUser("Clem", "cleboi", "rez");
            m.ajouterUser("zfzef", "clebzefzefoi", "zefzefzef");
            foreach (IUser user in m.UserIEnum)
            {
                Console.WriteLine(user);
            }

            Console.ReadLine();
        }
    }
}
