using System;

namespace Sec9;
public class Person
{
    private string _name;

    public string Name{
        get => _name;  
        set{
            if(value==null||value==""||value.Length>=32){
        throw new Exception("Invalid Name");
    }
            _name=value;
        }
    }

    private int _age;

    public int Age{
        get => _age;
        set{
            if(value<=0||value>128){
        throw new Exception("Invalid Age");
    }
            _age=value;
        }
    }
    public Person(string name, int age)
    {
        _name = Name;
        _age = Age;
    }
    
    public virtual void Print()
    {
        Console.WriteLine
        ($"My name is: {Name},and my age is: {Age}");
    }
}
public class Student : Person
{
    private int _year;
    private float _gpa;
    
        public int Year{
        get => _year;  
        set{
            if(value<1||value>5){throw new Exception("Invalid Year");}
           _year=value;
    }
           
        }
    

    public float Gpa{
        get => _gpa;
        set{
             if(value<0||value>4){throw new Exception("Invalid GPA");}
            _gpa=value;
    }
           
        }
    
    public Student(string name, int age, int year, float gpa) 
      : base(name, age)
    {
        _year = Year;
        _gpa = Gpa;
    }
    public override void Print()
    {
        Console.WriteLine
        ($"My name is: {Name}, my age is: {Age}, and my gpa is: {Gpa}");
    }
}

public class Staff : Person
{
    private double _salary;
    private int _joinYear;
    public double Salary{
        get => _salary;
        set{
            if(value<=0||value>120000){throw new Exception("Invalid Salary");}
        _salary=value;
        }
    }
    public int JoinYear{
        get => _joinYear;
        set{
           if(value<21){throw new Exception("Invalid JoinYear");}
            _joinYear=value;
        }
    }
    public Staff(string name, int age, double salary, int joinyear) : base(name, age)
    {        
        _salary = Salary;
        _joinYear = JoinYear;
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
                  
                    try
                    {
                         var student = new Student(name, age, year, gpa);
                         database.AddStudent(student);
                    }
                    catch (Exception e)
                    {
                        
                        Console.WriteLine(e.Message);
                    }
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
                    
                    try
                    {
                        var staff = new Staff(name2, age2,salary ,joinyear );
                        database.AddStaff(staff);
                    }
                    catch (Exception e)
                    {
                        
                        Console.WriteLine(e.Message);
                    }
                    break;
                case 3:
                    database.PrintAll();
                    break;
                case 4:
                    Console.Write("Enter Name: ");
                    var name3 = (Console.ReadLine());
                    Console.Write("Enter Age: ");
                    var age3 = Convert.ToInt32( Console.ReadLine());
                    
                    try
                    {
                        var person = new Person(name3, age3);
                        database.AddPerson(person);
                    }
                    catch (Exception e)
                    {
                        
                        Console.WriteLine(e.Message);
                    }
                    break;
                default:
                    return;

            }
        }
            
    }
}