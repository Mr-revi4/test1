using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace test1
{
    class Program
    {
        static void Main(string[] args)
        {
            Db db = new Db();
            db.CreateDataBase();
            db.CreateTable();
            Console.WriteLine("Добавление поля: ");
            db.Insert();
            db.Select("1");
            Console.Write("Обновление поля:\nВведите номер поля: ");
            string number = Console.ReadLine();
            db.Update(number);
            db.Select(number);
            Console.Write("Удаление поля:\nВведите номер поля: ");
            number = Console.ReadLine();
            db.Delete(number);
            Console.ReadKey();
        }
    }
}