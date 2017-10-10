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

             Console.WriteLine("Insert:");

             Console.Write("Enter the street name: ");
             string name = Console.ReadLine();
             Console.Write("Enter the city name: ");
             string city = Console.ReadLine();

             db.Insert(name, city, 1);

            /*   
            Console.WriteLine("Update:");

            Console.Write("Enter the line number(id): ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter the new street name: ");
            name = Console.ReadLine();
            Console.Write("Enter the new city name: ");
            city = Console.ReadLine();
            Console.Write("Enter the number of houses: ");
            numb = int.Parse(Console.ReadLine());

            db.Update(name, city, numb, id);

            Console.WriteLine("Update:");

            Console.Write("Enter the line number(id): ");
            id = int.Parse(Console.ReadLine());

            db.Delete(id);*/

            db.Select(12);

            Console.ReadKey();
        }
    }
}