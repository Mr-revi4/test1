using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1Entity
{
    class CRUD
    {
        public string Create(int col1, float col2)
        {
            using(ModelContext db = new ModelContext())
            {
                db.TestTable.Add(new TestTable { TestCol1 = col1, TestCol2 = col2 });
                db.SaveChanges();                
            }
            return "Добавлено 1 поле.";
        }

        public string Update(int col1, float col2)
        {
            using (ModelContext db = new ModelContext())
            {
                db.TestTable.FirstOrDefault().TestCol1 = col1;
                db.TestTable.FirstOrDefault().TestCol2 = col2;
                db.SaveChanges();
            }
            return "Изменено 1 поле.";
        }

        public string Delete()
        {
            using (ModelContext db = new ModelContext())
            {
                db.TestTable.Remove(db.TestTable.FirstOrDefault());
                db.SaveChanges();
            }
            return "Удалено 1 поле.";
        }

        public void Read()
        {
            using (ModelContext db = new ModelContext())
            {
                var list = db.TestTable.ToList();
                foreach (var element in list)
                    Console.WriteLine("Col1 = {0}\nCol2 = {1}", element.TestCol1, element.TestCol2);
            }
        }
    }
}
