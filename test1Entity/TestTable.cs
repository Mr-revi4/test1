namespace test1Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TestTable")]
    public partial class TestTable
    {
        public int id { get; set; }

        public int? TestCol1 { get; set; }

        public float? TestCol2 { get; set; }
    }
}
