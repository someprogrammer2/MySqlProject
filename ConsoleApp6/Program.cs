using MySql.Data;
using MySql.Data.MySqlClient;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string connectionString = "server=localhost;port=3306;user=root;password=Press001!;database=tasks";

            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.Port = 3306;
            builder.UserID = "root";
            builder.Password = "Press001!";
            builder.Database = "tasks";

            string connectionString = builder.ToString();


            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM inventory";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"id: {reader["id"]}, name: {reader["name"]}, quantity: {reader["quantity"]}");
                        }
                    }

                }
            }
        }
    }
}