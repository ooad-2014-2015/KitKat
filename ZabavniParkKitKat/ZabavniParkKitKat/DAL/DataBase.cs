using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZabavniParkKitKat.DAL
{
    public abstract class DataBase
    {
        private string server;
        private string username;
        private string password;
        private string db;
        public readonly string connectionString;
        public SqlConnection connection;
        public DataBase(string password, string server = "db4free.net", string username = "studioakord", string database = "muzickistudio")
        {
            this.server = server;
            this.username = username;
            this.password = password;
            this.db = database;
            connectionString= "Integrated Security=true;Initial Catalog=KitKat; " + "Data Source=PROBOOK450\\SQLEXPRESS";
            validirajKorisnika();
            connection = new SqlConnection(connectionString);
        }

        private void validirajKorisnika()
        {
            try
            {
                SqlConnection test = new SqlConnection(connectionString);
                test.Open();
                test.Close();
            }
            catch(SqlException e)
            {
                System.Windows.MessageBox.Show("Konekcija na bazu nije moguca!\nPoruka : " + e.Message, "Greska pri konekciji", System.Windows.MessageBoxButton.OKCancel, System.Windows.MessageBoxImage.Error);
            }
        }
    }
}
