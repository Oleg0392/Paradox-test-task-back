using WebServerExample.DataProvider.Interfaces;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace WebServerExample.DataProvider.Implemenations
{
    public class QueryManager : IQueryManager
    {
        IConfiguration configuration { get; set; }
        NpgsqlConnection connection;

        public QueryManager(IConfiguration configuration)
        {
            this.configuration = configuration;
            connection = new NpgsqlConnection(this.configuration.GetConnectionString("DefaultConnection"));
        }

        public int ExecuteNonQuery(string SqlCommandText)
        {
            NpgsqlCommand command = new (SqlCommandText,connection);
            connection.Open();
            using (connection) { return command.ExecuteNonQuery(); }
        }

        public object[,] ExecuteQuery(string SqlComandText)
        {
            NpgsqlCommand command = new (SqlComandText, connection);
            connection.Open();
            object[,] result = null;
            using(connection)
            {
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader != null)
                {
                    int i = 0;
                    while (reader.Read())
                    {
                        object[] temp = new object[reader.VisibleFieldCount];
                        reader.GetValues(temp);
                        for (int j = 0; j < temp.Length; j++) { result[i,j] = temp[j]; }
                        i++;
                    }
                }
            }
            return result;
        }
        
    }
}
