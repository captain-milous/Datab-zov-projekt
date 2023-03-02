using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databázový_projekt
{
    public class ZakaznikMenu
    {
        private ZakaznikMenu()
        {

        }
        /// <summary>
        /// Menu pro zákazníka
        /// </summary>
        /// <param name="user">Zakazník co se přihlásil</param>
        public static void Menu(Zakaznik user)
        {
            int input = 0;
            bool run = true;
            int strike = 0;
            int maxStrike = 3;
            while (run)
            {
                Console.WriteLine();
                Console.WriteLine("MENU - Zákazník\n1 - Nový Nákup\n2 - Obchody a jejich položky\n3 - Editovat vlastní údaje\n4 - Zpět do hlavní nabídky");
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
                        Console.WriteLine("In Progress..");
                        break;
                    case 2:
                        Console.WriteLine("In Progress..");
                        break;
                    case 3:
                        Console.WriteLine("In Progress..");
                        break;
                    case 4:
                        run = false;
                        break;
                    default:
                        Console.WriteLine();
                        strike++;
                        if (strike < maxStrike)
                        {
                            Console.WriteLine("Máte " + strike + " striků, jestli dosáhnete " + maxStrike + " striků aplikace vás vrátí do hlavní nabídky.");
                            Console.WriteLine("Vyberte celé číslo z nabídky..");
                        }
                        else
                        {
                            Console.WriteLine("Dosáhli jste " + strike + " striků.");
                            run = false;
                        }
                        break;
                }
            }
        }


    }
}
