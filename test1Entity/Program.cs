using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1Entity
{
    class Program
    {
        static void Main(string[] args)
        {
            CRUD crud = new CRUD();

            Console.WriteLine("Insert Street:");

            Console.Write("Enter the street name: ");
            string name = Console.ReadLine();
            Console.Write("Enter the city name: ");
            string city = Console.ReadLine();

            crud.CreateStreet(city, name);

            crud.ReadStreet();

            Console.WriteLine("Insert House:");

            Console.Write("Enter the street name: ");
            string streetname = Console.ReadLine();
            Console.Write("Enter the house number: ");
            string number = Console.ReadLine();

            crud.CreateHouse(streetname, number);

            crud.ReadHouse();

            Console.WriteLine("Update Street:");

            Console.Write("Enter the line number(id): ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter the new street name: ");
            name = Console.ReadLine();
            Console.Write("Enter the new city name: ");
            city = Console.ReadLine();

            crud.UpdateStreet(id, name, city);

            crud.ReadStreet();

            Console.WriteLine("Update House:");

            Console.Write("Enter the line number(id): ");
            id = int.Parse(Console.ReadLine());

            Console.Write("Enter the new street name: ");
            streetname = Console.ReadLine();
            Console.Write("Enter the new house number: ");
            number = Console.ReadLine();

            crud.UpdateHouse(id, streetname, number);

            crud.ReadHouse();

            Console.WriteLine("Delete Street:");

            Console.Write("Enter the line number(id): ");
            id = int.Parse(Console.ReadLine());

            crud.DeleteStreet(id);

            crud.ReadStreet();

            Console.WriteLine("Delete House:");

            Console.Write("Enter the line number(id): ");
            id = int.Parse(Console.ReadLine());

            crud.DeleteHouse(id);

            crud.ReadHouse();

            Console.ReadKey();
        }
    }
}