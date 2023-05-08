using ElearningApp.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElearningApp.Persistence
{
    public class EmployeeRepository
    {
        private List<Employee> employees = new List<Employee>();
        string connectionString = "Server=10.56.8.36; database=P3_DB_2023_03; user id=P3_PROJECT_USER_03; password=OPENDB_03; TrustServerCertificate=true;";


        public void AddEmployee(Employee employeeToAdd)
        {
            employees.Add(employeeToAdd);
            string sqlQuery = "INSERT INTO Employee(FirstName, LastName, Email, AmountGuidesCompleted) VALUES(@firstName, @lastName, @email, @amountGuidesCompleted)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                cmd.Parameters.Add("@firstName", SqlDbType.NVarChar).Value = employeeToAdd.FirstName;
                cmd.Parameters.Add("@lastName", SqlDbType.NVarChar).Value = employeeToAdd.LastName;
                cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = employeeToAdd.Email;
                cmd.Parameters.Add("@amountGuidesCompleted", SqlDbType.Int).Value = employeeToAdd.AmountGuidesCompleted;
                conn.Open();
                cmd.ExecuteNonQuery();
            }



        }

    }
}
