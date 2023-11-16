using EmployeeService.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Configuration;

public class EmployeesRepository : IEmployeesRepository
{
    private string SqlConnectionString => ConfigurationManager.ConnectionStrings["LocalEmployeesDB"].ConnectionString;

    private const string UpdateEmployeeEnableCommandText = "UPDATE Employee SET Enable = @Enable WHERE ID = @ID";

    private T GetSqlDataReaderValueByColumnName<T>(string columnName, SqlDataReader reader)
        => reader[columnName] == System.DBNull.Value ? default : (T)reader[columnName];

    public void EnableEmployee(int id, bool enable)
    {
        using (SqlConnection connection = new SqlConnection(SqlConnectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand(UpdateEmployeeEnableCommandText, connection))
            {
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@Enable", enable);
                command.ExecuteNonQuery();
            }
        }
    }

    public Employee GetEmployeeById(int id)
    {
        var employees = new List<Employee>();
        using (SqlConnection connection = new SqlConnection(SqlConnectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("dbo.sp_GetEmployeeByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EmployeeID", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var employee = new Employee();

                        employee.Id = GetSqlDataReaderValueByColumnName<int>("ID", reader);
                        employee.ManagerId = GetSqlDataReaderValueByColumnName<int?>("ManagerID", reader);
                        employee.Name = GetSqlDataReaderValueByColumnName<string>("Name", reader);
                        employee.Enable = GetSqlDataReaderValueByColumnName<bool>("Enable", reader);

                        employees.Add(employee);
                    }
                }
            }
        }
        foreach (var employee in employees)
        {
            employee.Employees = employees.Where(e => e.ManagerId == employee.Id);
        }
        return employees.FirstOrDefault(e => e.Id == id);
    }
}