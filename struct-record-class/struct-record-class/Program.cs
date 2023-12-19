using System;
using struct_record_class;
class Program
{
    static void Main()
    {
        /**
         * Class
         */
        Employee employee = new Employee("Juan", "Tech");
        employee.Name = "Ana"; // Change allowed

        Employee employee1 = new Employee("Carlos", "Tech");
        Employee employee2 = employee1; // Both point to the same object

        /**
         * Struct
         */
        Point p1 = new Point(1, 2);
        // p1.X = 3; // This would be a compilation error

        /**
        * Record
        */
        User user1 = new User("Ana", "ana@email.com");
        User user2 = new User("Ana", "ana@email.com");
        bool areEqual = user1 == user2; // True

        User user3 = new User("Ana", "email");
        User user4 = user3 with { Email = "newEmail" };

        User user = new User("Ana", "email");
        // user.Name = "Carlos"; // Compilation error

    }
}