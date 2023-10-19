using Microsoft.EntityFrameworkCore;

namespace School
{

    public class Grade
    {
        public int Id { get; set; }
        public int Value { get; set; }
    }
    public class Student
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public List<Grade> Grades { get; set; }
    }

    public class MyContext : DbContext
    {
        protected override void OnConfiguring(
        DbContextOptionsBuilder b) =>
        b.UseSqlite("Data Source=database.db");
        // b.UseSqlServer(...)
        public DbSet<Student> Studenten { get; set; }

    }

    public class MainClass
    {

        public static void Main(string[] args)
        {
            MyContext context = new MyContext();
            var Bob = new Student{Naam = "Bob"};
            Bob.Grades.Add(new Grade{Value = 9});
            

        }

    }


}