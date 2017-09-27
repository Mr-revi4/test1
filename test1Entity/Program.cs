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
            Console.Write("Введите значение 1-й колонки: ");
            int col1 = int.Parse(Console.ReadLine());
            Console.Write("Введите значение 2-й колонки: ");
            float col2 = float.Parse(Console.ReadLine());
            Console.WriteLine(crud.Create(col1, col2));
            crud.Read();
            Console.Write("Введите новое значение 1-й колонки: ");
            col1 = int.Parse(Console.ReadLine());
            Console.Write("Введите новое значение 2-й колонки: ");
            col2 = float.Parse(Console.ReadLine());
            Console.WriteLine(crud.Update(col1, col2));
            crud.Read();
            Console.WriteLine(crud.Delete());
            Console.ReadKey();
        }
    }
}