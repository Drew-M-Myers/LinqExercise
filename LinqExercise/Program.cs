using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO.Pipes;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * Every one of these can be completed using Linq and then printing with a foreach loop.            
             */

            //TODO: Print the Sum of numbers
            var sum = numbers.Sum();
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine("--------------");
            //TODO: Print the Average of numbers
            var average = numbers.Average();
            Console.WriteLine($"Average: {average}");
            Console.WriteLine("-------Ascending Order-------");
            //TODO: Order numbers in ascending order and print to the console
            var ascendingOrder = numbers.OrderBy(num => num);
            foreach (var item in ascendingOrder)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------Decsending Order-------");
            //TODO: Order numbers in decsending order adn print to the console
            var decsendingOrder = numbers.OrderByDescending(num => num);
            foreach (var item in decsendingOrder)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------Numbers Greater Than 6-------");
            //TODO: Print to the console only the numbers greater than 6
            var greaterThanSix = numbers.Where(num => num > 6);
            foreach (var item in greaterThanSix)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------First Four-------");
            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            var firstFour = ascendingOrder.Take(4);
            foreach (var item in firstFour)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------Changing Index 4 To My Age (Decsending Order)-------");
            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order
            numbers[4] = 25;
            foreach (var item in decsendingOrder)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------Employess Who's First Name Starts With 'C' or 'S' (Ordered Ascending)-------");
            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in acesnding order by FirstName.
            var firstNameCOrS = employees.Where(person => person.FirstName[0] == ('C') || person.FirstName[0] == ('S')).OrderBy(person => person.FirstName);
            foreach (var employee in firstNameCOrS)
            {
                Console.WriteLine(employee.FullName);
            }
            Console.WriteLine("-------Employess Who Are Over 26 (Ordered In Ascending Order By Age Then First Name)-------");
            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            var OverTwentySix = employees.Where(person => person.Age > 26).OrderBy(age => age.Age).ThenBy(person => person.FirstName);
            foreach (var emplyee in OverTwentySix)
            {
                Console.WriteLine(emplyee.Age);
                Console.WriteLine(emplyee.FullName);
            }
            Console.WriteLine("-------Sum and Average of Employess YOU Who Are Over 35 and YOE Are Less Than or Equal to 10-------");
            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35
            var YOE = employees.Where(person => person.Age > 35 && person.YearsOfExperience <= 10);
            var SumYOE = employees.Sum(emplyee => emplyee.YearsOfExperience);
            var AverageYOE = employees.Average(emplyee => emplyee.YearsOfExperience);
            
            Console.WriteLine($"Sum: {SumYOE}");
            Console.WriteLine($"Average: {AverageYOE}");
            Console.WriteLine("-------Adding an Employee Without Using the employees.Add()-------");
            //TODO: Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Drew", "Myers", 25, 1)).ToList();
            foreach (var item in employees)
            {
                Console.WriteLine($"First Name: {item.FirstName} Last Name: {item.LastName} Age: {item.Age} YOE: {item.YearsOfExperience}");
            }

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
