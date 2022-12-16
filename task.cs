using System;

namespace Sec9;
public class Person
{
    private string _name;
    private int _age;
    public Person(string name, int age)
    {
     if(name==null||name==""||name.Length>=32){
        throw new Exception("Invalid Name");
    }
    if(age<=0||age>128){
        throw new Exception("Invalid Age");
    }
        _name = name;
        _age = age;
    }
    public string GetName() =>_name;
    public int GetAge() => _age;
    public void SetName(string name){
    _name=name;
}
public void SetAge(int age){
    _age=age;
}
    public virtual void Print()
    {
        Console.WriteLine
        ($"My name is: {GetName()},and my age is: {GetAge()}");
    }
}

public class Student : Person
{
    private int _year;
    private float _gpa;
    
    public Student(string name, int age, int year, float gpa) 
      : base(name, age)
    {
         if(year<1||year>5){throw new Exception("Invalid Year");}
         if(gpa<0||gpa>4){throw new Exception("Invalid GPA");}
        _year = year;
        _gpa = gpa;
    }
 public int GetYear() =>_year;
    public float GetGpa() => _gpa;
    public void SetYear(int year){
    _year=year;
}
public void SetGpa(float gpa){
    _gpa=gpa;
}
    public override void Print()
    {
        Console.WriteLine
        ($"My name is: {GetName()}, my age is: {GetAge()}, and my gpa is: {GetGpa()}");
    }
}

public class Staff : Person
{
    private double _salary;
    private int _joinyear;
    public Staff(string name, int age, double salary, int joinyear) : base(name, age)
    {        
    if(salary<=0||salary>120000){throw new Exception("Invalid Salary");}
    if(joinyear<21){throw new Exception("Invalid JoinYear");}
        _salary = Salary;
        _joinyear = JoinYear;
    }
    public double GetSalary() =>_salary;
    public int GetJoinYear() => _joinyear;
    public void SetSalary(double salary){
    _salary=salary;
}
public void SetJoinYear(int joinyear){
    _joinyear=joinyear;
}
    public override void Print()
    {
        Console.WriteLine
        ($"My name is: {GetName()}, my age is: {GetAge()},and my salary is: {GetSalary()} ");
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