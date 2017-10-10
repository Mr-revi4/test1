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

            Console.WriteLine("Insert Street:");

            Console.Write("Enter the street name: ");
            string name = Console.ReadLine();
            Console.Write("Enter the city name: ");
            string city = Console.ReadLine();

            db.Insert(city, name, 1);

            Console.WriteLine("Insert House:");

            Console.Write("Enter the street name: ");
            string streetname = Console.ReadLine();
            Console.Write("Enter the house number: ");
            string number = Console.ReadLine();

            db.Insert(streetname, number, 2);

            Console.WriteLine("Update Street:");

            Console.Write("Enter the line number(id): ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter the new street name: ");
            name = Console.ReadLine();
            Console.Write("Enter the new city name: ");
            city = Console.ReadLine();

            db.Update(id, name, city, 1);

            Console.WriteLine("Update House:");

            Console.Write("Enter the line number(id): ");
            id = int.Parse(Console.ReadLine());

            Console.Write("Enter the new street name: ");
            streetname = Console.ReadLine();
            Console.Write("Enter the new house number: ");
            number = Console.ReadLine();

            db.Update(id, streetname, number, 2);

            Console.WriteLine("Delete Street:");

            Console.Write("Enter the line number(id): ");
            id = int.Parse(Console.ReadLine());

            db.Delete(id, 1);

            Console.WriteLine("Delete House:");

            Console.Write("Enter the line number(id): ");
            id = int.Parse(Console.ReadLine());

            db.Delete(id, 2);

            Console.ReadKey();
        }
    }
}