using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databázový_projekt
{
    public class ObchodMenu
    {
        private ObchodMenu()
        {

        }
        /// <summary>
        /// Menu pro Obchod
        /// </summary>
        /// <param name="user">Obchod, který se přihlasil</param>
        public static void Menu(Zakaznik user)
        {
            int input = 0;
            bool run = true;
            int strike = 0;
            int maxStrike = 3;
            while (run)
            {
                Console.WriteLine();
                Console.WriteLine("MENU - Obchod\n1 - Přidat položku\n2 - Položky na skladě\n3 - Nákupy od zákazníků\n4 - Editovat vlastní údaje\n5 - Zpět do hlavní nabídky");
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
                        Console.WriteLine("In Progress..");
                        break;
                    case 5:
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
