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
        }

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
