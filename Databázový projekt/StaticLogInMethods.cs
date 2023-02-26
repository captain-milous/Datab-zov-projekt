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

        public static void Registration()
        {

        }
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
                        break;
                    case 2:
                        ObchodLogIn();
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

        }

        public static void ObchodLogIn()
        {

        }


    }
}
