namespace test1Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelContext : DbContext
    {
        public ModelContext()
            : base("name=ModelContext")
        {
        }

        public virtual DbSet<TestTable> TestTable { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
