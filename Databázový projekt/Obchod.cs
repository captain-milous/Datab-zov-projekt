using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databázový_projekt
{
    internal class Obchod : User
    {
        private string nazev;
        private string web;

        public string Nazev { get { return nazev; } set { nazev = value; } }
        public string Web { get { return web; } set { web = value; } }

        public Obchod(string email, string heslo) : base(email, heslo)
        {
            Nazev = "Bez Názvu";
            Web = "Bez Webu";
        }
        public Obchod(string email, string heslo, string nazev, string web) : base(email, heslo)
        {
            Nazev = nazev;
            Web = web;
        }
    }
}
