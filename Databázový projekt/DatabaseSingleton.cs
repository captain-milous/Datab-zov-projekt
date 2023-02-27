using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databázový_projekt
{
    public class DatabaseSingleton
    {
        private static SqlConnection conn = null;
        private DatabaseSingleton()
        {

        }
        public static SqlConnection GetInstance()
        {
            if (conn == null)
            {
                SqlConnectionStringBuilder consStringBuilder = new SqlConnectionStringBuilder();
                consStringBuilder.UserID = ReadSetting("Pwd");
                consStringBuilder.Password = ReadSetting("Uid");
                consStringBuilder.InitialCatalog = ReadSetting("Database");
                consStringBuilder.DataSource = ReadSetting("Server");
                consStringBuilder.ConnectTimeout = 30;
                conn = new SqlConnection(consStringBuilder.ConnectionString);
                //Console.WriteLine(consStringBuilder.ConnectionString);
                conn.Open();
            }
            return conn;
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
