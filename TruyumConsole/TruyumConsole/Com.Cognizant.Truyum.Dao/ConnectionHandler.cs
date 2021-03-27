using System.Configuration;

namespace Com.Cognizant.Truyum.Dao
{
    class ConnectionHandler
    {
        public static string GetConnection
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            }
        }

    }
}
