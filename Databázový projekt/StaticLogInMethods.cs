using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Databázový_projekt.StaticImportMethods;
using static Databázový_projekt.StaticExportMethods;

namespace Databázový_projekt
{
    public static class StaticLogInMethods
    {

        private static List<Zakaznik> zakaznici = new List<Zakaznik>();
        private static List<Obchod> obchody = new List<Obchod>();

        public static void MainMenu() 
        {
            int input = 0;
            bool run = true;
            int strike = 0;
            int maxStrike = 3;
            while (run)
            {
                Console.WriteLine();
                Console.WriteLine("Hlavní MENU\n1 - Přihlašení\n2 - Registrace\n3 - Exit");
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
                        ChooseLogIn();
                        break;
                    case 2:
                        Registration();
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

        #region Registration
        public static void Registration()
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

        public static void ZakaznikRegistration()
        {

        }

        public static void ObchodRegistration()
        {

        }
        #endregion

        #region Log In Methods
        public static void ChooseLogIn() 
        {
            int input = 0;
            bool run = true;
            int strike = 0;
            int maxStrike = 3;
            while (run)
            {
                Console.WriteLine();
                Console.WriteLine("Vstoupit jako\n1 - Zákazník\n2 - Prodejce(Obchod)\n3 - Zpět do Hlavní nabídky");
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
                        ZakaznikLogIn();
                        run = false;
                        break;
                    case 2:
                        ObchodLogIn();
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

        public static void ZakaznikLogIn()
        {
            zakaznici = DatabaseSingleton.GetValuesFromZakaznik();
            int input = 0;
            bool run = true;
            int strike = 0;
            int maxStrike = 3;
            while (run)
            {
                Console.WriteLine();
                Console.Write("Zadejte své přihlašovací email: ");
                string username = Console.ReadLine();
                Console.Write("Zadejte své přihlašovací heslo: ");
                string password = Console.ReadLine();
                Zakaznik user = zakaznici.FirstOrDefault(u => u.Email == username && u.Heslo == password);
                if (user != null)
                {
                    Console.WriteLine();
                    Console.WriteLine("Vitejte, " + user.Jmeno + " " + user.Prijmeni);
                    
                    // Spuštění Menu pro obchody

                    run = false;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Neplatné přihlašovací email nebo heslo.");
                    strike++;
                    if (strike < maxStrike)
                    {
                        Console.WriteLine("Máte " + strike + " striků, jestli dosáhnete " + maxStrike + " striků aplikace vás vrátí do hlavní nabídky.");
                        Console.WriteLine("Zkuste to prosím znovu.");
                    }
                    else
                    {
                        Console.WriteLine("Dosáhli jste " + strike + " striků. ");
                        run = false;
                    }
                }
            }
        }
        

        public static void ObchodLogIn()
        {
            obchody = DatabaseSingleton.GetValuesFromObchod();
            int input = 0;
            bool run = true;
            int strike = 0;
            int maxStrike = 3;
            while (run)
            {
                Console.WriteLine();
                Console.Write("Zadejte své přihlašovací email: ");
                string username = Console.ReadLine();
                Console.Write("Zadejte své přihlašovací heslo: ");
                string password = Console.ReadLine();
                Obchod user = obchody.FirstOrDefault(u => u.Email == username && u.Heslo == password);
                if (user != null)
                {
                    Console.WriteLine();
                    Console.WriteLine("Vitejte, " + user.Nazev);

                    // Spuštění zakaznického Menu

                    run = false;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Neplatné přihlašovací email nebo heslo.");
                    strike++;
                    if (strike < maxStrike)
                    {
                        Console.WriteLine("Máte " + strike + " striků, jestli dosáhnete " + maxStrike + " striků aplikace vás vrátí do hlavní nabídky.");
                        Console.WriteLine("Zkuste to prosím znovu.");
                    }
                    else
                    {
                        Console.WriteLine("Dosáhli jste " + strike + " striků. ");
                        run = false;
                    }
                }
            }
        }
    #endregion

    }
}
