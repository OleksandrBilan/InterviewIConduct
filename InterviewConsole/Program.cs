using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace InterviewConsole
{
    class Program
    {
        private static string DbConnectionString => ConfigurationManager.AppSettings["LocalEmployeesDbConnectionString"];

        static void Main(string[] args)
        {
            DataTable dtEmployees = GetQueryResult("SELECT * FROM Employee");
        }
        
        private static DataTable GetQueryResult(string query)
        {
            var dt = new DataTable();

			using (var connection = new SqlConnection(DbConnectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
					command.CommandText = query;

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

			return dt;
        }
    }
}
