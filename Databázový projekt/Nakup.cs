using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databázový_projekt
{
    public class Nakup
    {
        private Objednavka objednavka;
        private Obchod obchod;
        private DateTime datumNakupu;
        private double celkovaCena;

        public Objednavka Objednavka { get { return objednavka; } set { objednavka = value; } }
        public Obchod Obchod { get { return obchod; } set { obchod = value; } }
        public DateTime DatumNakupu { get { return datumNakupu; } set { datumNakupu = value; } }
        public double CelkovaCena { get { return celkovaCena; } }

        public Nakup(Objednavka objednavka, Obchod obchod) 
        {
            Objednavka = objednavka;
            Obchod = obchod;
            DatumNakupu = DateTime.Today;
            GetCelkovaCena();
        }
        /// <summary>
        /// Změní celkovou cenu
        /// </summary>
        public void GetCelkovaCena()
        {
            double output = 0;
            for (int i = 0; i < Objednavka.SouhrnPolozek.Count(); i++)
            {
                output = output + Objednavka.SouhrnPolozek[i].Cena;
            }
            if (Objednavka.Sleva != null)
            {
                double discount = Math.Round(output / 100 * Objednavka.Sleva.Value, 2);
                output = output - discount;
            }
            this.celkovaCena = Math.Round(output, 2);
        }
    }
}
