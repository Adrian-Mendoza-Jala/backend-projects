using System;

namespace struct_record_class
{
    public class Employee : IWorker
    {
        public string Name { get; set; }
        public string Department { get; set; }


        public Employee(string name, string department)
        {

            Name = name;
            Department = department;
        }

        public void DisplayEmployeeDetails()
        {
            Console.WriteLine($"Name: {Name}, Department: {Department}");
        }

        public void Work() { Console.WriteLine("Working"); }
    }
}
