using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databázový_projekt
{
    internal class Zakaznik : User
    {
        private string jmeno;
        private string prijmeni;
        private DateTime datumNarozeni;

        public string Jmeno { get { return jmeno; } set { jmeno = value; } }
        public string Prijmeni { get { return prijmeni; } set { prijmeni = value; } }
        public DateTime DatumNarozeni { get { return datumNarozeni; } set { datumNarozeni = value; } }

        public Zakaznik(string email, string heslo) : base(email, heslo)
        {
            Jmeno = "NoName";
            Prijmeni = "NoSurname";
            DatumNarozeni = DateTime.Today; 
        }

        public Zakaznik(string email, string heslo, string adresa, string jmeno, string prijmeni, DateTime datumNarozeni) : base(email, heslo, adresa)
        {
            Jmeno = jmeno;
            Prijmeni = prijmeni;
            DatumNarozeni = datumNarozeni;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
