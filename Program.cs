using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public int ID { get; set; }
    public string Name { get; set; } = string.Empty; // Default value to avoid null warning
    public Dictionary<string, double> Grades { get; set; } = new Dictionary<string, double>();

    public double CalculateAverage()
    {
        return Grades.Count > 0 ? Grades.Values.Average() : 0.0;
    }
}

class GradeManagementSystem
{
    private List<Student> students = new List<Student>();

    public void AddStudent()
    {
        Console.Write("Enter Student ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID. Please enter a valid number.\n");
            return;
        }

        Console.Write("Enter Student Name: ");
        string? name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Name cannot be empty.\n");
            return;
        }

        students.Add(new Student { ID = id, Name = name });
        Console.WriteLine("Student added successfully!\n");
    }

    public void AddGrade()
    {
        Console.Write("Enter Student ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID. Please enter a valid number.\n");
            return;
        }

        Student? student = students.FirstOrDefault(s => s.ID == id);
        if (student == null)
        {
            Console.WriteLine("Student not found.\n");
            return;
        }

        Console.Write("Enter Subject: ");
        string? subject = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(subject))
        {
            Console.WriteLine("Subject cannot be empty.\n");
            return;
        }

        Console.Write("Enter Grade: ");
        if (!double.TryParse(Console.ReadLine(), out double grade))
        {
            Console.WriteLine("Invalid grade. Please enter a valid number.\n");
            return;
        }

        student.Grades[subject] = grade;
        Console.WriteLine("Grade added successfully!\n");
    }

    public void ViewStudentGrades()
    {
        Console.Write("Enter Student ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID. Please enter a valid number.\n");
            return;
        }

        Student? student = students.FirstOrDefault(s => s.ID == id);
        if (student == null)
        {
            Console.WriteLine("Student not found.\n");
            return;
        }

        Console.WriteLine($"\nGrades for {student.Name}:");
        if (student.Grades.Count == 0)
        {
            Console.WriteLine("No grades available.\n");
            return;
        }

        foreach (var grade in student.Grades)
        {
            Console.WriteLine($"{grade.Key}: {grade.Value}");
        }
        Console.WriteLine($"Average Grade: {student.CalculateAverage():F2}\n");
    }

    public void ListStudents()
    {
        Console.WriteLine("\nList of Students:");
        if (students.Count == 0)
        {
            Console.WriteLine("No students found.\n");
            return;
        }

        foreach (var student in students)
        {
            Console.WriteLine($"ID: {student.ID}, Name: {student.Name}, Average: {student.CalculateAverage():F2}");
        }
        Console.WriteLine();
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("Student Grade Management System");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Grade");
            Console.WriteLine("3. View Student Grades");
            Console.WriteLine("4. List All Students");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.\n");
                continue;
            }

            switch (choice)
            {
                case 1: AddStudent(); break;
                case 2: AddGrade(); break;
                case 3: ViewStudentGrades(); break;
                case 4: ListStudents(); break;
                case 5: return;
                default: Console.WriteLine("Invalid choice. Try again.\n"); break;
            }
        }
    }
}

class Program
{
    static void Main()
    {
        GradeManagementSystem system = new GradeManagementSystem();
        system.Run();
    }
}
