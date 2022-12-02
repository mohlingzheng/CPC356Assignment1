using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Assignment1.Pages
{
    [Table("record")]
    public class Records
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(100), Unique]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Type { get; set; }
        [MaxLength(4)]
        public string Year { get; set; }
        [MaxLength(10)]
        public string Version { get; set; }

    }
}
