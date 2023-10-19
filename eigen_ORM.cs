
namespace ORM
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Collections.Generic;



    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Education { get; set; }
    }

    public class StudentORM
    {
        private readonly string connectionString;

        public StudentORM(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Students";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            students.Add(new Student
                            {
                                StudentId = (int)reader["StudentId"],
                                Name = (string)reader["Name"],
                                Age = (int)reader["Age"],
                                Education = (string)reader["Education"]
                            });
                        }
                    }
                }
            }

            return students;
        }

        public void InsertStudent(Student student)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Students (Name, Age, Education) VALUES (@Name, @Age, @Education)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", student.Name);
                    command.Parameters.AddWithValue("@Age", student.Age);
                    command.Parameters.AddWithValue("@Education", student.Education);
                    command.ExecuteNonQuery();
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "your_connection_string_here";
            StudentORM orm = new StudentORM(connectionString);

            // Voeg een student toe
            Student newStudent = new Student { Name = "John", Age = 20, Education = "Computer Science" };
            orm.InsertStudent(newStudent);

            // Haal de lijst van studenten op
            List<Student> students = orm.GetStudents();
            foreach (var student in students)
            {
                Console.WriteLine($"StudentId: {student.StudentId}, Name: {student.Name}, Age: {student.Age}, Education: {student.Education}");
            }
        }
    }



}