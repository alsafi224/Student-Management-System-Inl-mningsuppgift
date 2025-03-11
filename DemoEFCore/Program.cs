using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using StudentManagementSystem;

using (var db = new ApplicationDPContext())
{
    // Ensure the database is created.
    db.Database.EnsureCreated();

    while (true)
    {
        Console.WriteLine("\nStudent Management System");
        Console.WriteLine("1. Register New Student");
        Console.WriteLine("2. Edit Student");
        Console.WriteLine("3. List All Students");
        Console.WriteLine("4. Exit");
        Console.Write("Enter your choice: ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                ApplicationDPContext.RegisterStudent(db);
                break;
            case "2":
                ApplicationDPContext.EditStudent(db);
                break;
            case "3":
                ApplicationDPContext.ListStudents(db);
                break;
            case "4":
                return; // Exit the program.
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }
}
