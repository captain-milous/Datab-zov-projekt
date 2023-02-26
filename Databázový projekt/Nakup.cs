using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databázový_projekt
{
    public class Nakup
    {
        private Zakaznik zakaznik;
        private Objednavka objednavka;
        private Obchod obchod;
        private DateTime datumNakupu;
        private bool doruceniNaAdresu;

        public Zakaznik Zakaznik { get { return zakaznik;} set { zakaznik = value;} }
        public Objednavka Objednavka { get { return objednavka; } set { objednavka = value; } }
        public Obchod Obchod { get { return obchod; } set { obchod = value; } }
        public DateTime DatumNakupu { get { return datumNakupu; } set { datumNakupu = value; } }
        public bool DoruceniNaAdresu { get { return doruceniNaAdresu; } set { doruceniNaAdresu = value; } }

        public Nakup(Zakaznik zakaznik, Objednavka objednavka, Obchod obchod) 
        {
            Zakaznik = zakaznik;
            Objednavka = objednavka;
            Obchod = obchod;
            DatumNakupu = DateTime.Today;
            doruceniNaAdresu = false;
        }
    }
}
