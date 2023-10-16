using System.ComponentModel;
using System.Net.Http.Headers;

namespace OOConceptsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello, World!");

            Employee e2 = new Employee { ID = 111 };
            Employee e3 = new Employee { ID=111, Name="Ravi", Salary=50000 };
            Employee e4 = new Employee();

            // Anonymous object/types
            var p = new { Pid = 111, PName = "IPhone", Rate = 125000 };
            Console.WriteLine(p.PName);
            // p.Rate=0;
        }

    }

    class _ankgdlkfl
    {

    }


    
    class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }    
        public int Salary { get; set; }

        //private int id;
        //private string name;
        //private int salary;

        //public Employee()
        //{
        //    this.id = 0;
        //    this.name = string.Empty;
        //    this.salary = 0;
        //}
        //public Employee(int eid,string name) :this(eid)
        //{
        //    // this.id = eid;
        //    this.name = name;
        //}   
        //public Employee(int eid)
        //{
        //    this.id = eid;
        //}

        //public Employee(int eid, string name,int salary) : this(eid,name)
        //{
        //    // this.id = eid;
        //    // this.name = name;
        //    this.salary = salary;
        //}
    }
}