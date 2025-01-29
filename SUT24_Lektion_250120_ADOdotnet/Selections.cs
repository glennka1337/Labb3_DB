using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace SUT24_Lektion_250120_ADOdotnet
{
    internal class Selections
    {
        public void GetAllStudents(string sort1, string sort2)
        {
            Console.Clear();
            var connectionString = @"Data Source = localhost;Initial Catalog = LABB2_SUT24;Integrated Security = true;Trust Server Certificate = true;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT * FROM Students ORDER BY {sort1} {sort2}";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0]}, {reader[1]}, {reader[2]}, {reader[3]}, {reader[4]}");
                    }
                }




                connection.Close();
            }
        }

        public void ShowAllClasses()
        {
            Console.Clear();
            var connectionString = @"Data Source = localhost;Initial Catalog = LABB2_SUT24;Integrated Security = true;Trust Server Certificate = true;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT * FROM Class";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0]}. {reader[1]}");
                    }
                }
            }
        }

        public void ShowClass(int input)
        {
            Console.Clear();
            var connectionString = @"Data Source = localhost;Initial Catalog = LABB2_SUT24;Integrated Security = true;Trust Server Certificate = true;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT s.FirstName + ' ' + s.LastName AS Student, s.StudentId AS [Student Id], c.ClassName AS [Class Name], c.ClassId AS [Class Id] FROM Class c JOIN Students s ON s.ClassId = c.ClassId WHERE c.ClassId = {input}";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0]}. {reader[1]}");
                    }
                }
            }
        }

        public void AddPersonnel(string personnelId, string firstName, string lastName, string job)
        {
            var connectionString = @"Data Source = localhost;Initial Catalog = LABB2_SUT24;Integrated Security = true;Trust Server Certificate = true;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Personnel (PersonnelId, FirstName, LastName, Job)
                         VALUES (@PersonnelId, @FirstName, @LastName, @Job)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonnelId", personnelId);
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Job", job);

                    connection.Open();
                    var rowsAffected = command.ExecuteNonQuery();
                    Console.Clear();
                    Console.WriteLine($"{rowsAffected} personal tillagd.");
                }
            }
        }
    }
}
