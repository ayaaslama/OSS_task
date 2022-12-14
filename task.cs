using System;

namespace Sec9;
public class Person
{
    public string Name;
    public int Age;

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
    public virtual void Print()
    {
        Console.WriteLine
        ($"My name is: {Name},and my age is: {Age}");
    }
}
public class Student : Person
{
    public int Year;
    public float Gpa;
    public Student(string name, int age, int year, float gpa) : base(name, age)
    {
        Year = year;
        Gpa = gpa;
    }
    public override void Print()
    {
        Console.WriteLine
        ($"My name is: {Name}, my age is: {Age}, and my gpa is: {Gpa}");
    }
}

public class Staff : Person
{
    public double Salary;
    public int JoinYear;
    public Staff(string name, int age, double salary, int joinyear) : base(name, age)
    {
        Salary = salary;
        JoinYear = joinyear;
    }
    public override void Print()
    {
        Console.WriteLine
        ($"My name is: {Name}, my age is: {Age},and my salary is: {Salary} ");
    }

}
public class Database
{
    int _currentIndex;
    public Person[] People = new Person[50];
    public void AddStudent(Student student)
    {
        People[_currentIndex++] = student;
    }
    public void AddStaff(Staff staff)
    {
        People[_currentIndex++] = staff;
    }
    public void AddPerson(Person person)
    {
        People[_currentIndex++] = person;
    }
    public void PrintAll()
    {
        for (int i = 0; i < _currentIndex; i++)
        {
            People[i].Print();
        }

    }

}

public class Program
{
    private static void Main()
    {
        var database = new Database();

        
        while (true)
        {
            Console.WriteLine("enter option 1 to add student : 2 to add staff : 3 to print all : 4 to add person : 0 to stop");
            var option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 0:
                    Console.WriteLine("Done !");
                    return;
                case 1:
                    Console.Write("Enter Name: ");
                    var name = (Console.ReadLine());
                    Console.Write("Enter Age: ");
                    var age = Convert.ToInt32( Console.ReadLine());
                    Console.Write("Enter Year: ");
                    var year = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Gpa: ");
                    var gpa = Convert.ToInt32(Console.ReadLine());
                    var student = new Student(name, age, year, gpa);
                    database.AddStudent(student);
                    break;
                case 2:
                    Console.Write("Enter Name: ");
                    var name2 = Console.ReadLine();
                    Console.Write("Enter Age: ");
                    var age2 = Convert.ToInt32( Console.ReadLine());
                    Console.Write("Enter Salary: ");
                    var salary = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter JoinYear: ");
                    var joinyear = Convert.ToInt32(Console.ReadLine());
                    var staff = new Staff(name2, age2,salary ,joinyear );
                    database.AddStaff(staff);
                    break;
                case 3:
                    database.PrintAll();
                    break;
                case 4:
                    Console.Write("Enter Name: ");
                    var name3 = (Console.ReadLine());
                    Console.Write("Enter Age: ");
                    var age3 = Convert.ToInt32( Console.ReadLine());
                    var person = new Person(name3, age3);
                    database.AddPerson(person);
                    break;
                default:
                    return;

            }
        }
            
    }
}