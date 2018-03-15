using System;

namespace Assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee("Lars", "Larsen", 123.456m);
            int months = 5;
            
            Console.WriteLine($"{employee.GetFullName()} makes {employee.GetSalaray(months)} in {months} months");
        }
    }

    class Employee
    {
        public readonly string FirstName;
        public readonly string LastName;
        public readonly decimal MonthlySalary;

        public Employee(string firstName, string lastName, decimal monthlySalary)
        {
            FirstName = firstName;
            LastName = lastName;
            MonthlySalary = monthlySalary;
        }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        public decimal GetSalaray(int n)
        {
            return MonthlySalary * n;
        }
    }
}