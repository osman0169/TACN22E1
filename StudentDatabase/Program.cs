
using System;
using Microsoft.EntityFrameworkCore;

namespace StudentDatabase
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudentDB;Integrated Security=True;");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new StudentContext())
            {
                context.Database.EnsureCreated();

                var student = new Student { Name = "John Doe", Age = 20 };
                context.Students.Add(student);
                context.SaveChanges();

                Console.WriteLine("Student added to the database.");
            }
        }
    }
}
