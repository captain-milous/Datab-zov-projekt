using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databázový_projekt
{
    public class Objednavka
    {
        private List<Polozka> souhrnPolozek;
        private int? sleva;
        private double celkovaCena;

        public List<Polozka> SouhrnPolozek { get { return souhrnPolozek; } set { souhrnPolozek = value; GetCelkovaCena(); } }
        public int? Sleva { 
            get { return sleva; }
            set {
                if (value > 1 && value < 90)
                {
                    sleva = value;
                }
                else
                {
                    sleva = null;
                }
                GetCelkovaCena(); 
            } 
        }
        public double CelkovaCena { get { return celkovaCena; } }

        public Objednavka()
        {
            SouhrnPolozek = new List<Polozka>();
            Sleva = null;
            celkovaCena = 0;
        }

        public override string ToString()
        {
            string output = "V objednávce nejsou žádné položky.";
            if (SouhrnPolozek.Count() != 0)
            {
                output = "Souhrn objednávky: \n";
                for (int i = 0; i < SouhrnPolozek.Count(); i++)
                {
                    output = output + SouhrnPolozek[i].Nazev + ": " + SouhrnPolozek[i].Cena + " Kč\n";
                }
                if (sleva != null)
                {
                    double discount = Math.Round(CelkovaCena / 100 * Sleva.Value, 2);
                    output += "\nSleva: " + Sleva + "%   (" + discount + " Kč)\n";
                }
                output = output + "\nCena Celkem: " + CelkovaCena + " Kč";
            }           
            return output;
        }

        public void GetCelkovaCena()
        {
            double output = 0;
            for(int i = 0; i < SouhrnPolozek.Count(); i++)
            {
                output = output + SouhrnPolozek[i].Cena;
            }
            if(sleva != null)
            {
                double discount = Math.Round(output / 100 * Sleva.Value, 2);
                output = output - discount;
            }
            this.celkovaCena = Math.Round(output, 2);
        }

        public void AddPolozka(Polozka polozka)
        {
            SouhrnPolozek.Add(polozka);
            GetCelkovaCena();
        }
    }
}
