using System.Data.SqlClient;

namespace DAL
{
    public class Connection
    {
        private static string connectionString = "Data Source=LAPTOP-2LRUOKMM;Initial Catalog=SoundSphere;Integrated Security=SSPI;";
        private SqlConnection connection = new SqlConnection(connectionString);

        public SqlConnection GetConnection()
        {
            return connection;
        }
    }
}