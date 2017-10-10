using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace test1
{
    class Db
    {
        string connectionString = "Data Source=localhost;Initial Catalog=HousesAndStreets;Integrated Security=True";
        string sqlExpression;

        public void Insert(string value1, string value2, int flag)
        {            
            sqlExpression = "INSERT INTO @table (@col1, @col2) VALUES (@value1, @value2)";
            string column1 ="", column2 = "", table = "";

            if(flag == 1)
            {
                column1 = "City";
                column2 = "Name";
                table = "Streets";
            }
            else if(flag == 2)
            {
                column1 = "Street";
                column2 = "Number";
                table = "Houses";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {                     
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlParameter val1 = new SqlParameter("@val1", value1);
                    command.Parameters.Add(val1);
                    SqlParameter val2 = new SqlParameter("@val2", value2);
                    command.Parameters.Add(val2);
                    SqlParameter col1 = new SqlParameter("@col1", column1);
                    command.Parameters.Add(col1);
                    SqlParameter col2 = new SqlParameter("@col2", column2);
                    command.Parameters.Add(col2);
                    SqlParameter tab = new SqlParameter("@table", table);
                    command.Parameters.Add(tab);

                    int number = command.ExecuteNonQuery();
                    Console.WriteLine("Uploaded {0}", number);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void Update(string name, string city, int numberOfHouse, int id)
        {            
            sqlExpression = string.Format("UPDATE Streets SET Name = @Name, City = @City, NumberOfHouses = @Numb WHERE id = {0}", id);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlParameter nameParam = new SqlParameter("@Name", name);
                    command.Parameters.Add(nameParam);
                    SqlParameter cityParam = new SqlParameter("@City", city);
                    command.Parameters.Add(cityParam);
                    SqlParameter numbParam = new SqlParameter("@Numb", numberOfHouse);
                    command.Parameters.Add(numbParam);
                    int number = command.ExecuteNonQuery();
                    Console.WriteLine("Updated {0}", number);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void Delete(int id)
        {
            sqlExpression = string.Format("DELETE FROM Streets WHERE id = {0}", id);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    Console.WriteLine("Deleted {0}", number);                
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void Select(int id)
        {
            sqlExpression = string.Format("SELECT * FROM Streets WHERE id = {0}", id);
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())                            
                             Console.WriteLine("{0} = {1}", reader.GetName(2), reader.GetValue(3));
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }            
        }
    }
}
