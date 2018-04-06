using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace HalloXamarinForms.Models
{
    [Table("Personen")]
    public class Person
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }

        [MaxLength(255), NotNull]
        public String Name { get; set; }

        public String Status { get; set; }

        public String Profilbild { get; set; }
    }
}
