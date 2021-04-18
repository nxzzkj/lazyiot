
using System.Data.SQLite;


namespace ScadaWeb.Repository
{
    public class MySqlHelper
    {
        public static string datafile = System.Configuration.ConfigurationManager.ConnectionStrings["sqllitconn"].ConnectionString;
        public static string connectionString = "";
        public static System.Data.IDbConnection GetConnection()
        {

      
            var connection = new SQLiteConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
