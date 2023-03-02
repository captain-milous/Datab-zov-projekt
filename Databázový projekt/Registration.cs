using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databázový_projekt
{
    public class Registration
    {
        private static List<Zakaznik> zakaznici = new List<Zakaznik>();
        private static List<Obchod> obchody = new List<Obchod>();

        private Registration() { }

        /// <summary>
        /// Výběr Registrace (Zakazník/Obchod)
        /// </summary>
        public static void Menu()
        {
            int input = 0;
            bool run = true;
            int strike = 0;
            int maxStrike = 3;
            while (run)
            {
                Console.WriteLine();
                Console.WriteLine("Registrovat\n1 - Zákazníka\n2 - Prodejce(Obchod)\n3 - Zpět do Hlavní nabídky");
                Console.Write("Vyberte možnost: ");
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Zadaná Hodnota musí být integer!");
                    input = 0;
                }
                switch (input)
                {
                    case 1:
                        ZakaznikRegistration();
                        run = false;
                        break;
                    case 2:
                        ObchodRegistration();
                        run = false;
                        break;
                    case 3:
                        run = false;
                        break;
                    default:
                        Console.WriteLine();
                        strike++;
                        if (strike < maxStrike)
                        {
                            Console.WriteLine("Máte " + strike + " striků, jestli dosáhnete " + maxStrike + " striků aplikace se automaticky ukončí.");
                            Console.WriteLine("Vyberte celé číslo z nabídky..");
                        }
                        else
                        {
                            Console.WriteLine("Dosáhli jste " + strike + " striků. Aplikace se teď automaticky ukončí.");
                            run = false;
                        }
                        break;
                }

            }
        }
        /// <summary>
        /// Registrace Zakaznika
        /// </summary>
        public static void ZakaznikRegistration()
        {
            List<Zakaznik> users = DatabaseSingleton.GetValuesFromZakaznik();
            bool run = true;
            string stringInput = "";
            int input = 0;
            Zakaznik user = new Zakaznik();
            while (run)
            {
                Console.WriteLine();
                Console.Write("Zadejte přihlašovací email nového uživatele: ");
                try
                {
                    stringInput = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    stringInput = "invalidName";
                }
                Console.WriteLine();
                Console.WriteLine(stringInput + " - Je tento email v pořádku? ");
                Console.WriteLine("1 - ANO\n2 - NE");
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Zadaná Hodnota musí být integer!");
                    input = 0;
                }
                if (input == 1)
                {
                    bool duplicita = false;
                    for (int i = 0; i < users.Count; i++)
                    {
                        if (stringInput == users[i].Email)
                        {
                            duplicita = true;
                        }
                    }
                    if (!duplicita)
                    {
                        user.Email = stringInput;
                        run = false;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Tento email byl již použit. Zadejte prosím jiný.");
                    }
                }
            }
            run = true;
            while (run)
            {
                Console.WriteLine();
                Console.Write("Zadejte přihlašovací heslo nového uživatele: ");
                try
                {
                    stringInput = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    stringInput = "invalidName";
                }
                Console.WriteLine();
                Console.WriteLine(stringInput + " - Je toto heslo v pořádku? ");
                Console.WriteLine("1 - ANO\n2 - NE");
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Zadaná Hodnota musí být integer!");
                    input = 0;
                }
                if (input == 1)
                {
                    user.Heslo = stringInput;
                    run = false;
                }
            }
            Console.WriteLine("Chcete přidat adresu? ");
            Console.WriteLine("1 - ANO\n2 - NE");
            try
            {
                input = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Zadaná Hodnota musí být integer!");
                input = 0;
            }
            if (input == 1)
            {
                run = true;
                while (run)
                {
                    Console.WriteLine();
                    Console.Write("Zadejte adresu nového uživatele: ");
                    try
                    {
                        stringInput = Console.ReadLine();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        stringInput = "invalidName";
                    }
                    Console.WriteLine();
                    Console.WriteLine(stringInput + " - Je tato adresa v pořádku? ");
                    Console.WriteLine("1 - ANO\n2 - NE");
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Zadaná Hodnota musí být integer!");
                        input = 0;
                    }
                    if (input == 1)
                    {
                        user.Heslo = stringInput;
                        run = false;
                    }
                }
            }
            run = true;
            while(run)
            {
                Console.WriteLine();
                Console.Write("Zadejte jméno nového uživatele: ");
                try
                {
                    stringInput = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    stringInput = "invalidName";
                }
                user.Jmeno = stringInput;
                Console.WriteLine();
                run = false;
            }
            run = true;
            while (run)
            {
                Console.WriteLine();
                Console.Write("Zadejte přijmení nového uživatele: ");
                try
                {
                    stringInput = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    stringInput = "invalidName";
                }
                user.Prijmeni = stringInput;
                Console.WriteLine();
                run = false;
            }

            DatabaseSingleton.InsertIntoTable(user);
        }
        /// <summary>
        /// Registrace Obchodu
        /// </summary>
        public static void ObchodRegistration()
        {
            List<Obchod> users = DatabaseSingleton.GetValuesFromObchod();
            bool run = true;
            string stringInput = "";
            int input = 0;
            Obchod user = new Obchod();
            while (run)
            {
                Console.WriteLine();
                Console.Write("Zadejte přihlašovací email nového obchodu: ");
                try
                {
                    stringInput = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    stringInput = "invalidName";
                }
                Console.WriteLine();
                Console.WriteLine(stringInput + " - Je tento email v pořádku? ");
                Console.WriteLine("1 - ANO\n2 - NE");
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Zadaná Hodnota musí být integer!");
                    input = 0;
                }
                if (input == 1)
                {
                    bool duplicita = false;
                    for (int i = 0; i < users.Count; i++)
                    {
                        if (stringInput == users[i].Email)
                        {
                            duplicita = true;
                        }
                    }
                    if (!duplicita)
                    {
                        user.Email = stringInput;
                        run = false;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Tento email byl již použit. Zadejte prosím jiný.");
                    }
                }
            }
            run = true;
            while (run)
            {
                Console.WriteLine();
                Console.Write("Zadejte přihlašovací heslo nového obchodu: ");
                try
                {
                    stringInput = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    stringInput = "invalidName";
                }
                Console.WriteLine();
                Console.WriteLine(stringInput + " - Je toto heslo v pořádku? ");
                Console.WriteLine("1 - ANO\n2 - NE");
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Zadaná Hodnota musí být integer!");
                    input = 0;
                }
                if (input == 1)
                {
                    user.Heslo = stringInput;
                    run = false;
                }
            }
            Console.WriteLine("Chcete přidat adresu? ");
            Console.WriteLine("1 - ANO\n2 - NE");
            try
            {
                input = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Zadaná Hodnota musí být integer!");
                input = 0;
            }
            if (input == 1)
            {
                run = true;
                while (run)
                {
                    Console.WriteLine();
                    Console.Write("Zadejte adresu nového uživatele: ");
                    try
                    {
                        stringInput = Console.ReadLine();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        stringInput = "invalidName";
                    }
                    Console.WriteLine();
                    Console.WriteLine(stringInput + " - Je tato adresa v pořádku? ");
                    Console.WriteLine("1 - ANO\n2 - NE");
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Zadaná Hodnota musí být integer!");
                        input = 0;
                    }
                    if (input == 1)
                    {
                        user.Heslo = stringInput;
                        run = false;
                    }
                }
            }
            run = true;
            while (run)
            {
                Console.WriteLine();
                Console.Write("Zadejte název nového obchodu: ");
                try
                {
                    stringInput = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    stringInput = "invalidName";
                }
                user.Nazev = stringInput;
                Console.WriteLine();
                run = false;
            }
            run = true;
            while (run)
            {
                Console.WriteLine();
                Console.Write("Zadejte web nového obchodu: ");
                try
                {
                    stringInput = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    stringInput = "invalidName";
                }
                user.Web = stringInput;
                Console.WriteLine();
                run = false;
            }

            DatabaseSingleton.InsertIntoTable(user);
        }
    }
}
