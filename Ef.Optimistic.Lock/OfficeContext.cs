using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ef.Optimistic.Lock
{


    public class OfficeContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=192.168.31.215;User ID=hj;Password=hj123;Database=office;Integrated Security=false");
            optionsBuilder.LogTo(Console.WriteLine);
        }


        [Table("Student")]
        public class Student
        {

            [Column("PriKey")]
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            [Timestamp]
            [Column("VerCol")]
            public virtual byte[] RowVersion { get; set; }

            [Column("Name")]
            public string Name { get; set; }
        }
    }
}
