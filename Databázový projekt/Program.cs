// using MySql.Data.MySqlClient;

namespace Databázový_projekt
{
    public class Program
    {
        static void Main(string[] args)
        {
            string lajna = "\n----------------------------------------------------------------------------------\n";
            Console.WriteLine(lajna);
            Console.WriteLine("Vítejte v aplikaci Databázový projekt!");
            Console.WriteLine("Autor: Miloš Tesař C3b");
            Console.WriteLine(lajna);
            Console.WriteLine();

            MainMenu.Menu();
            
            #region Testování

            // DatabaseSingleton.InsertIntoTable(new Zakaznik("test3@user.com", "ZajimaveHeslo"));
            // DatabaseSingleton.InsertIntoTable(new Obchod("test2@obchod.com", "ZajimaveHeslo"));

            /*
            Console.WriteLine();
            List<Zakaznik> zakaznici = DatabaseSingleton.GetValuesFromZakaznik();
            Console.WriteLine();
            for (int i = 0; i < zakaznici.Count; i++)
            {
                Console.WriteLine(zakaznici[i].ToString());
            }          
            Console.WriteLine();
            List<Obchod> obchody = DatabaseSingleton.GetValuesFromObchod();
            Console.WriteLine();
            for (int i = 0; i < obchody.Count; i++)
            {
                Console.WriteLine(obchody[i].ToString());
            }
            */

            #endregion

            Console.WriteLine();
            Console.WriteLine(lajna);
            Console.WriteLine("Aplikace byla ukončena.");
            Console.WriteLine(lajna);
        }
    }
}