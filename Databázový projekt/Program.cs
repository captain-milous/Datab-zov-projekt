using MySql.Data.MySqlClient;
using static Databázový_projekt.StaticLogInMethods;

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

            MainMenu();

            Console.WriteLine();
            Console.WriteLine(lajna);
            Console.WriteLine("Aplikace byla ukončena.");
            Console.WriteLine(lajna);
        }
    }
}