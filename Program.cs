using ETA25_Intermediate.Session01;

namespace ETA25_Intermediate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");


            #region Session01
            Person person = new Person();

            var years = EmployeeUtilities.CalculateSeniorityInYears(DateTime.Now.AddYears(-10));

            Person person2 = new Person();
            Console.WriteLine($"The person's first name is {person2.FirstName}, last name is {person2.LastName} and age is {person2.Age}");

            Person person3 = new Person("Radu", "Fifiita", 32);
            Console.WriteLine($"The person's first name is {person3.FirstName}, last name is {person3.LastName} and age is {person3.Age}");

            Person person4 = new Person("Test", "Boundary", 5);
            Console.WriteLine($"The person's first name is {person4.FirstName}, last name is {person4.LastName} and age is {person4.Age}");

            person4.Age = -1;
            #endregion

            Console.ReadKey();
        }
    }
}
