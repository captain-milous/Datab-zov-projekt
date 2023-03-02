using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databázový_projekt
{
    public class User
    {
        protected string email;
        protected string heslo;
        protected string adresa;

        public string Email { get { return email; } set { email = value; } }
        public string Heslo { get { return heslo; } set { heslo = value; } }
        public string Adresa { get { return adresa; } set { adresa = value; } }

        public User() 
        {
            Email = "Neuvedeno";
            Heslo = "Neuvedeno";
            Adresa = "Neuvedena";
        }   
        public User(string email, string heslo)
        {
            Email = email;
            Heslo = heslo;
            Adresa = "Neuvedena";
        }

        public User(string email, string heslo, string adresa)
        {
            Email = email;
            Heslo = heslo;
            Adresa = adresa;
        }

        public override string ToString()
        {
            return "Email: "+Email+", Heslo: "+Heslo;
        }
    }
}
