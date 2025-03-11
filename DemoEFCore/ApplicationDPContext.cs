using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    public class ApplicationDPContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DemoDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Students");
        }
        // 3. Implement the RegisterStudent method.
        public static void RegisterStudent(ApplicationDPContext db)
        {
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter City: ");
            string city = Console.ReadLine();

            var newStudent = new Student
            {
                StudentFirstName = firstName,
                StudentLastName = lastName,
                City = city
            };

            db.Students.Add(newStudent);
            db.SaveChanges();

            Console.WriteLine("Student registered successfully.");
        }

        // 4. Implement the EditStudent method.
        public static void EditStudent(ApplicationDPContext db)
        {
            Console.Write("Enter Student ID to edit: ");
            if (int.TryParse(Console.ReadLine(), out int studentId))
            {
                var student = db.Students.Find(studentId);

                if (student != null)
                {
                    Console.Write("Enter new First Name (or press Enter to keep current): ");
                    string newFirstName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newFirstName))
                    {
                        student.StudentFirstName = newFirstName;
                    }

                    Console.Write("Enter new Last Name (or press Enter to keep current): ");
                    string newLastName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newLastName))
                    {
                        student.StudentLastName = newLastName;
                    }

                    Console.Write("Enter new City (or press Enter to keep current): ");
                    string newCity = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newCity))
                    {
                        student.City = newCity;
                    }

                    db.SaveChanges();
                    Console.WriteLine("Student updated successfully.");
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Student ID.");
            }
        }

        // 5. Implement the ListStudents method.
        public static void ListStudents(ApplicationDPContext db)
        {
            var students = db.Students.ToList();

            if (students.Count == 0)
            {
                Console.WriteLine("No students found.");
            }
            else
            {
                Console.WriteLine("Student List:");
                foreach (var student in students)
                {
                    Console.WriteLine($"ID: {student.StudentID}, Name: {student.StudentFirstName} {student.StudentLastName}, City: {student.City}");
                }
            }
        }
    }
}
    

    

