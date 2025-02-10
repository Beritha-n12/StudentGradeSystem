using System;
using System.Collections.Generic;
using System.Linq;

class StudentManagementSystem
{
    private Dictionary<string, int> students = new Dictionary<string, int>();
    
    public void AddStudent()
    {
        Console.Write("Enter Student Name: ");
        string name = Console.ReadLine()?.Trim() ?? string.Empty;
        
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Invalid name. Please enter a valid student name.\n");
            return;
        }
        
        Console.Write("Enter Student Grade (0-100): ");
        if (!int.TryParse(Console.ReadLine(), out int grade) || grade < 0 || grade > 100)
        {
            Console.WriteLine("Invalid grade. Please enter a number between 0 and 100.\n");
            return;
        }
        
        students[name] = grade;
        Console.WriteLine("Student added successfully!\n");
    }
    
    public void DisplayAllStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students found.\n");
            return;
        }
        
        Console.WriteLine("\nStudent Records:");
        foreach (var student in students)
        {
            Console.WriteLine($"{student.Key}: {student.Value}");
        }
        Console.WriteLine();
    }
    
    public void SearchStudent()
    {
        Console.Write("Enter Student Name to Search: ");
        string name = Console.ReadLine()?.Trim() ?? string.Empty;
        
        if (students.TryGetValue(name, out int grade))
        {
            Console.WriteLine($"\n{name}'s Grade: {grade}\n");
        }
        else
        {
            Console.WriteLine("Student not found.\n");
        }
    }
    
    public void CalculateAverageGrade()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students found to calculate average grade.\n");
            return;
        }
        
        double average = students.Values.Average();
        Console.WriteLine($"Average Grade: {average:F2}\n");
    }
    
    public void FindHighestAndLowestGrades()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students found to determine highest and lowest grades.\n");
            return;
        }
        
        int highest = students.Values.Max();
        int lowest = students.Values.Min();
        
        Console.WriteLine($"Highest Grade: {highest}");
        Console.WriteLine($"Lowest Grade: {lowest}\n");
    }
    
    public void Run()
    {
        while (true)
        {
            Console.WriteLine("Student Management System");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Display All Students");
            Console.WriteLine("3. Search for a Student");
            Console.WriteLine("4. Calculate Average Grade");
            Console.WriteLine("5. Find Highest and Lowest Grades");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");
            
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.\n");
                continue;
            }
            
            switch (choice)
            {
                case 1: AddStudent(); break;
                case 2: DisplayAllStudents(); break;
                case 3: SearchStudent(); break;
                case 4: CalculateAverageGrade(); break;
                case 5: FindHighestAndLowestGrades(); break;
                case 6: return;
                default: Console.WriteLine("Invalid choice. Try again.\n"); break;
            }
        }
    }
}

class Program
{
    static void Main()
    {
        StudentManagementSystem system = new StudentManagementSystem();
        system.Run();
    }
}
