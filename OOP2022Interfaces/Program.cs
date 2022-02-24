using System;
using System.Collections.Generic;

namespace OOP2022Interfaces
{

    interface IUSB
    {
        void TurnOn();
    }
    interface IFirewire
    {
        void Bar();
        void TurnOn();
    }

    class Employee : IComparable, IComparable<Employee>
    {
        public Employee(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public int CompareTo(Employee other)
        {
            return Name.CompareTo(other.Name);
        }

        public int CompareTo(object obj)
        {
            return CompareTo((Employee)obj);
        }

        public override string ToString()
        {
            return $"[{Id}....{Name}]";
        }
    }

    class A
    {

        public void Foo()
        {
            Console.WriteLine("A");
        }
    }
    //class B
    //{
    //    public void Foo()
    //    {
    //        Console.WriteLine("B");
    //    }
    //}

    class AHarddisk
    {
        public void TurnOn()
        {

        }
    }

    class ExternHarddisk : AHarddisk, IUSB,IFirewire
    {

        public void Bar()
        {
            Console.WriteLine("C bar");
        }
    }

    


    class EmployeeComparerById : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            return x.Id.CompareTo(y.Id);
        }
    }
    class RevEmployeeComparerById : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            return -1*x.Id.CompareTo(y.Id);
        }
    }

    class FancyStringComparer : IComparer<string>
    {
        public FancyStringComparer(int startIndex)
        {
            StartIndex = startIndex;
        }

        public int StartIndex { get; }

        public int Compare(string a, string b)
        {
            return a.Substring(StartIndex).CompareTo(b.Substring(StartIndex)); 
        }
    }
    class RevStringComparer<T> : IComparer<T>
    {
        IComparer<T> other;

        public RevStringComparer(IComparer<T> other)
        {
            this.other = other;
        }

        public int Compare(T x, T y)
        {
            return -1*other.Compare(x, y);
        }
    }

    class App2
    {
        public void Run()
        {
            List<string> l = new List<string>() { "a Thomas", "b Hans", "c Anne" };
            l.Sort(new RevStringComparer<string>(new FancyStringComparer(2)));
            foreach (var item in l)
            {
                Console.WriteLine(item);
            }
        }
    }



    internal class Program
    {



        static void Main(string[] args)
        {
            //string s = "Thomas";
            //IComparable c = s;


            App2 app = new App2();
            app.Run();


            //Object o = new ExternHarddisk();

            //IUSB ia = new ExternHarddisk();
            //IFirewire ib = new ExternHarddisk();
            //ib.Bar();
            
            //C c = new ExternHarddisk();
            //c.Foo();
        }
    }
}
