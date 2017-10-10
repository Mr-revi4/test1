using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1Entity
{
    class CRUD
    {
        public void CreateStreet(string city, string name)
        {
            using (var db = new HousesAndStreetsEntities())
            {
                Streets street = new Streets {City = city, Name = name };
                db.Streets.Add(street);
                db.SaveChanges();
            }
        }

        public void CreateHouse(string street, string number)
        {
            using (var db = new HousesAndStreetsEntities())
            {
                Houses house = new Houses { Street = street, Number = number };
                db.Houses.Add(house);
                db.SaveChanges();
            }
        }

        public void UpdateStreet(int id, string city, string name)
        {
            using (var db = new HousesAndStreetsEntities())
            {
                Streets street = db.Streets.SingleOrDefault(b => b.Id == id);
                street.Name = name;
                street.City = city;
                db.SaveChanges();
            }
        }

        public void UpdateHouse(int id, string street, string number)
        {
            using (var db = new HousesAndStreetsEntities())
            {
                Houses house = db.Houses.SingleOrDefault(b => b.Id == id);
                house.Street = street;
                house.Number = number;
                db.SaveChanges();
            }
        }

        public void DeleteStreet(int id)
        {
            using (var db = new HousesAndStreetsEntities())
            {
                Streets street = db.Streets.SingleOrDefault(b => b.Id == id);
                db.Streets.Remove(street);
                db.SaveChanges();
            }
        }

        public void DeleteHouse(int id)
        {
            using (var db = new HousesAndStreetsEntities())
            {
                Houses house = db.Houses.SingleOrDefault(b => b.Id == id);
                db.Houses.Remove(house);
                db.SaveChanges();
            }
        }

        public void ReadStreet()
        {
            using (var db = new HousesAndStreetsEntities())
            {
                var list = db.Streets.ToList();
                foreach (var element in list)
                    Console.WriteLine("{0}.{1} {2}", element.Id, element.City, element.Name);
            }
        }

        public void ReadHouse()
        {
            using (var db = new HousesAndStreetsEntities())
            {
                var list = db.Houses.ToList();
                foreach (var element in list)
                    Console.WriteLine("{0}.{1} {2}", element.Id, element.Street, element.Number);
            }
        }
    }
}
