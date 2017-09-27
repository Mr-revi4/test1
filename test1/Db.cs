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
        string nameDB, nameTable;
        int number;
        List<string> names, types;

        public void CreateDataBase()
        {
            Console.WriteLine("Создание базы данных:");
            Console.Write("Введите название: ");
            nameDB = Console.ReadLine();
            Console.Write(@"Введите путь (Пример: 'C:\Db\Test'): ");
            string path = Console.ReadLine();
            SqlConnection connection = new SqlConnection("Server=localhost; Integrated security=SSPI; database=master");
            string sqlExpression = string.Format(@"CREATE DATABASE {0} ON PRIMARY (NAME = {0}, FILENAME = '{1}\{0}.mdf')", nameDB, path);
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("База данных с именем {0} успешно создана.", nameDB);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void CreateTable()
        {
            Console.WriteLine("Создание таблицы:");
            Console.Write("Введите название таблицы: ");
            nameTable = Console.ReadLine();
            Console.Write("Введите кол-во столбцов (Поле id будет созданно автоматически): ");
            number = int.Parse(Console.ReadLine());
            names = new List<string>();
            types = new List<string>();
            for (int i = 0; i < number; i++)
            {
                Console.Write("Введите имя {0} столбца: ", i + 1);
                names.Add(Console.ReadLine());
                Console.Write("Введите тип {0} столбца (int, real, money и т.д...): ", i + 1);
                types.Add(Console.ReadLine());
            }
            SqlConnection connection = new SqlConnection(string.Format("Server=localhost; Integrated security=SSPI; database={0}", nameDB));
            string sqlExpression = string.Format("CREATE TABLE {0} (id int PRIMARY KEY IDENTITY", nameTable);
            for (int i = 0; i < number; i++)
                sqlExpression += string.Format(", {0} {1}", names[i], types[i]);
            sqlExpression += ")";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Таблица с именем {0} успешно создана", nameTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void Insert()
        {
            string sqlExpression;
            for (int i = 0; i < number; i++)
            {
                Console.Write("Введите значение {0}-го столбца: ", i + 1);
                sqlExpression = string.Format("INSERT INTO dbo.{0} ({1}) VALUES ({2})", nameTable, names[i], Console.ReadLine());
                using (SqlConnection connection = new SqlConnection(string.Format("Server=localhost; Integrated security=SSPI; database={0}", nameDB)))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(sqlExpression, connection);
                        int number = command.ExecuteNonQuery();
                        Console.WriteLine("Добавлено полей: {0}", number);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
        }

        public void Update(string _id)
        {
            for (int i = 0; i < number; i++)
            {
                Console.Write("Введите новое значение {0}-го столбца: ", i + 1);
                string sqlExpression = string.Format("UPDATE dbo.{0} SET {1} = {2} WHERE id = {3}", nameTable, names[i], Console.ReadLine(), _id);
                using (SqlConnection connection = new SqlConnection(string.Format("Server=localhost; Integrated security=SSPI; database={0}", nameDB)))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(sqlExpression, connection);
                        int number = command.ExecuteNonQuery();
                        Console.WriteLine("Обновлено полей: {0}", number);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
        }

        public void Delete(string _id)
        {
            string sqlExpression = string.Format("DELETE FROM dbo.{0} WHERE id = {1}", nameTable, _id);
            using (SqlConnection connection = new SqlConnection(string.Format("Server=localhost; Integrated security=SSPI; database={0}", nameDB)))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    Console.WriteLine("Удалено полей: {0}", number);                
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void Select(string _id)
        {
            string sqlExpression = string.Format("SELECT * FROM dbo.{0} WHERE id = {1}", nameTable, _id);
            List<object> values = new List<object>();
            try
            {
                using (SqlConnection connection = new SqlConnection(string.Format("Server=localhost; Integrated security=SSPI; database={0}", nameDB)))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            for (int i = 1; i <= number; i++)
                                Console.WriteLine("{0} = {1}", reader.GetName(i), reader.GetValue(i));
                        }
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
