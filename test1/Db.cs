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
            string column1 = "", column2 = "", table = "";
            if (flag == 1)
            {
                column1 = "City";
                column2 = "Name";
                table = "Streets";
            }
            else if (flag == 2)
            {
                column1 = "Street";
                column2 = "Number";
                table = "Houses";
            }

            sqlExpression = string.Format("INSERT INTO {0} ({1}, {2}) VALUES (@value1, @value2)", table, column1, column2);           

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {                     
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlParameter val1 = new SqlParameter("@value1", value1);
                    command.Parameters.Add(val1);
                    SqlParameter val2 = new SqlParameter("@value2", value2);
                    command.Parameters.Add(val2);
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

        public void Update(int id, string value1, string value2, int flag)
        {
            string column1 = "", column2 = "", table = "";
            if (flag == 1)
            {
                column1 = "City";
                column2 = "Name";
                table = "Streets";
            }
            else if (flag == 2)
            {
                column1 = "Street";
                column2 = "Number";
                table = "Houses";
            }
            sqlExpression = string.Format("UPDATE {0} SET {1} = @value1, {2} = @value2 WHERE id = {3}", table, column1, column2, id);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlParameter val1 = new SqlParameter("@value1", value1);
                    command.Parameters.Add(val1);
                    SqlParameter val2 = new SqlParameter("@value2", value2);
                    command.Parameters.Add(val2);
                    
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

        public void Delete(int id, int flag)
        {
            string table = "";
            if (flag == 1)            
                table = "Streets";
            else if (flag == 2)
                table = "Houses";

            sqlExpression = string.Format("DELETE FROM {0} WHERE id = {1}", table, id);
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

        public void Select(int id, int flag)
        {
            string table = "";
            if (flag == 1)
                table = "Streets";
            else if (flag == 2)
                table = "Houses";
            sqlExpression = string.Format("SELECT * FROM {0} WHERE id = {1}", table, id);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                            Console.WriteLine("{0} {1}", reader.GetValue(1), reader.GetValue(2));
                    }
                    reader.Close();
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
    }
}
