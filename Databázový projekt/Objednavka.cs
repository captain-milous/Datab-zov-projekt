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
        private Zakaznik zakaznik;
        private int? sleva;
        private bool doruceniNaAdresu;

        public List<Polozka> SouhrnPolozek { get { return souhrnPolozek; } set { souhrnPolozek = value; } }
        public Zakaznik Kupujici { get { return zakaznik; } set { zakaznik = value; } }
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
            } 
        }
        public bool DoruceniNaAdresu { get { return doruceniNaAdresu; } set { doruceniNaAdresu = value; } }
        

        public Objednavka(Zakaznik zak)
        {
            Kupujici = zak; 
            SouhrnPolozek = new List<Polozka>();
            Sleva = null;
            doruceniNaAdresu = false;
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
                    output += "\nSleva: " + Sleva + "%\n";
                }
            }           
            return output;
        }

        public void AddPolozka(Polozka polozka)
        {
            SouhrnPolozek.Add(polozka);
        }
    }
}
