using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databázový_projekt
{
    public class Polozka
    {
        private string nazev;
        private double cena;
        private string popis;
        private int pocetKusu;
        private Obchod obchod;

        public string Nazev { get { return nazev; } set { nazev = value; } }
        public double Cena { get { return cena; } set { cena = value; } }
        public string Popis { get { return popis; } set { popis = value; } }
        public int PocetKusu { get { return pocetKusu; } set { pocetKusu = value; } }
        public Obchod Obchod { get { return obchod; } set { obchod = value; } }

        public Polozka(string nazev, double cena, Obchod obchod)
        {
            Nazev = nazev;
            Cena = cena;
            Popis = "Bez Popisu";
            PocetKusu = 0;
            Obchod = obchod;
        }

        public override string ToString()
        {
            return Nazev+" "+Cena+" Kč\n"+Popis+"\nPočet kusů v "+Obchod.Nazev+": "+PocetKusu;
        }
    }
}
