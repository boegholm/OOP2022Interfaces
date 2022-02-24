using System;
using System.Collections.Generic;

namespace OOP2022Interfaces
{
    class App
    {
        public void Run()
        {

            List<Employee> employees = new List<Employee>();

            employees.Add(new Employee(1, "Thomas"));
            employees.Add(new Employee(3, "Mads"));
            employees.Add(new Employee(2, "Henrik"));
            employees.Add(new Employee(4, "Mogens"));
            employees.Add(new Employee(0, "Elisabeth"));

            //employees.Sort();

            employees.Sort(new RevEmployeeComparerById());

            foreach (Employee item in employees)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            employees.Sort(new EmployeeComparerById());

            foreach (Employee item in employees)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine(GetMax(1,2));
            Console.WriteLine(GetMin("Thomas", "Hans"));

            PrintWinner(employees[2], employees[3]);

        }

        public object GetMin(IComparable a, IComparable b)
        {
            if (a.CompareTo(b) < 0)
                return a;
            else
                return b;
        }

        public object GetMax(IComparable a, IComparable b)
        {
            if (a.CompareTo(b) > 0)
                return a;
            else
                return b;

        }


        public void PrintWinner(Employee a, Employee b)
        {
            Console.WriteLine("*******************");
            Console.WriteLine("Comparing:");
            Console.WriteLine(a);
                Console.WriteLine(b);
            Console.WriteLine("*******************");
            Console.WriteLine(GetMax(a, b));
        }
    }
}
