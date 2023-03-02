using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databázový_projekt
{
    public class DatabaseSingleton
    {
        private static MySqlConnection conn = null;
        private DatabaseSingleton()
        {

        }
        public static MySqlConnection GetInstance()
        {
            if (conn == null)
            {
                string server = "Server=" + ReadSetting("Server") + ";";
                string database = "Database=" + ReadSetting("Database") + ";";
                string uid = "Uid=" + ReadSetting("Uid") + ";";
                string pwd = "Pwd=" + ReadSetting("Pwd") + ";";
                try
                {
                    conn = new MySqlConnection(server + database + uid + pwd);
                    conn.Open();
                } 
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }                            
            }
            return conn;
        }

        #region Insert Into Tables
        // ještě v progresu
        public static void InsertIntoTable(Zakaznik z) 
        { 
            conn = GetInstance();
            try
            {
                string sql = "INSERT INTO zakaznik (`ID`, `email`, `heslo`, `adresa`, `jmeno`, `prijmeni`, `datum_narozeni`) " +
                    "VALUES (NULL, '"+z.Email+"', '"+z.Heslo+"', '"+z.Adresa+"', '"+z.Jmeno+"', '"+z.Prijmeni+"', '"+z.DatumNarozeni+"');";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public static void InsertIntoTable(Obchod o)
        {
            conn = GetInstance();
            try
            {
                string sql = "INSERT INTO obchod (`ID`, `email`, `heslo`, `adresa`, `nazev`, `web`) " +
                    "VALUES (NULL, '" + o.Email + "', '" + o.Heslo + "', '" + o.Adresa + "', '"+ o.Nazev +"', '"+ o.Web +"');";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void InsertIntoTable(Polozka p)
        {
            conn = GetInstance();
            try
            {
                string sql = "INSERT INTO polozka (`ID`, `nazev`, `cena`, `popis`, `pocet_kusu`, `obchod_id`) " +
                    "VALUES (NULL, '" + p.Nazev + "', '" + p.Cena + "', '"+ p.Popis +"', '"+ p.PocetKusu +"', '" + p.Obchod +"');";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void InsertIntoTable(Objednavka o)
        {
            conn = GetInstance();
            try
            {
                string sql = "INSERT INTO `objednavka` (`ID`, `zakaznik_id`, `polozka_id`, `sleva`, `doruceni`) " +
                    "VALUES (NULL, '"+ o.Kupujici +"', '"+ o.SouhrnPolozek + "', '"+o.Sleva+"', '"+o.DoruceniNaAdresu+"');";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void InsertIntoTable(Nakup n)
        {
            conn = GetInstance();
            try
            {
                string sql = "INSERT INTO `nakup` (`ID`, `objednavka_id`, `obchod_id`, `datum_nakupu`, `clekova_cena`) " +
                    "VALUES (NULL, '"+ n.Objednavka +"', '"+n.Obchod+"', '"+n.DatumNakupu+"', '"+n.CelkovaCena+"');";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion
        #region Get From Tables
        //Ještě v progressu
        public static List<Zakaznik> GetValuesFromZakaznik()
        {
            conn = GetInstance();
            List<Zakaznik> zakaznici = new List<Zakaznik>();
            try
            {
                string sql = "SELECT * FROM zakaznik";
                using var cmd = new MySqlCommand(sql, conn);
                using MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Console.WriteLine("{0}", rdr.GetString(1) + " " + rdr.GetString(2) + " " + rdr.GetString(3) + " " + rdr.GetString(4) + " " + rdr.GetString(5) + " " + rdr.GetString(6));
                    zakaznici.Add(new Zakaznik(rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), null ));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return zakaznici;

        }
        public static List<Obchod> GetValuesFromObchod()
        {
            conn = GetInstance();
            List<Obchod> obchody = new List<Obchod>();
            try
            {
                string sql = "SELECT * FROM zakaznik";
                using var cmd = new MySqlCommand(sql, conn);
                using MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Console.WriteLine("{0}", rdr.GetString(1) + " " + rdr.GetString(2) + " " + rdr.GetString(3) + " " + rdr.GetString(4) + " " + rdr.GetString(5));
                    obchody.Add(new Obchod(rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5)));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return obchody;
        }

        #endregion

        public static void CloseConnection()
        {
            try
            {
                if (conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch { }
            finally
            {
                conn = null;
            }
        }

        private static string ReadSetting(string key)
        {
            var appSettings = ConfigurationManager.AppSettings;
            string result = appSettings[key] ?? "Not Found";
            return result;
        }


    }
}
